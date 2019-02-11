using IfCompany.Entity;
using IfCompany.Entity.Repository;
using IfCompany.Interface.Business;
using IfCompanyTask.Entity.Repository;
using IfCompanyTask.Interface.Repository;
using IfCompanyTask.Repository.Repository;
using System;
using System.Collections.Generic;
using IfCompanyTask.Exceptions.ApiExceptions;
using System.Text;
using System.Threading.Tasks;

namespace IfCompanyTask.Business.BusinessService
{
    public class RiskPolicyAuditBusiness : IRiskPolicyAuditBusiness
    {
        private readonly IRiskPolicyAuditRepository _riskPolicyAuditRepository;
        private readonly IPolicyAuditRepository _policyAuditRepository;
        private readonly IRiskRepository _riskRepository;
        private readonly IPolicyRepository _policyRepository;
        public RiskPolicyAuditBusiness(IRiskPolicyAuditRepository riskPolicyAuditRepository, IPolicyAuditRepository policyAuditRepository, IRiskRepository riskRepository, IPolicyRepository policyRepository)
        {
            _riskPolicyAuditRepository = riskPolicyAuditRepository;
            _riskRepository = riskRepository;
            _policyAuditRepository = policyAuditRepository;
            _policyRepository = policyRepository;
            AvailableRisks = _riskRepository.GetAll();
        }

        public IList<Risk> AvailableRisks { get; set; }
        /// <summary>
        /// This method able to add risk to Policy
        /// </summary>
        /// <param name="nameOfInsuredObject"></param>
        /// <param name="risk"></param>
        /// <param name="validFrom"></param>
        /// <param name="effectiveDate"></param>
        public void AddRisk(string nameOfInsuredObject, Risk risk, DateTime validFrom, DateTime effectiveDate)
        {
            try
            {
                //validDate must be greater or equal than current date and time
                //risk must be non edit 
                if (validFrom >= DateTime.Now)
                {
                    if (risk != null)
                    {
                        //add risk and returned id
                        if (risk.Id == 0)
                            risk.Id = _riskRepository.AddRisk(risk).Result.Id;

                        Policy policy = _policyRepository.GetPolicyByName(nameOfInsuredObject).Result;
                        if (policy != null)
                        {
                            var policyInstance = _policyAuditRepository.FindAllAsync(x => x.IsActive && x.PolicyId == policy.Id).Result;
                            //name of the insured object. Must be unique in the given period
                            foreach (var policyAudit in policyInstance)
                            {
                                //effective date must be between to start/end date from sold Policy
                                if (policyAudit.ValidFrom <= effectiveDate && policyAudit.ValidFrom.AddMonths(policyAudit.ValidMonths) >= effectiveDate)
                                {
                                    _riskPolicyAuditRepository.AddRiskPolicyAudit(new RiskPolicyAudit()
                                    {
                                        IsActive = true,
                                        PolicyAuditId = policyAudit.Id,
                                        RiskId = risk.Id,
                                        ValidFrom = validFrom,
                                    }).Wait();
                                }
                            }
                        }
                        else
                        {
                            throw new NotFoundException("Check Your Effective Date.Cannot Found Policy");
                        }
                    }
                    else
                    {
                        throw new MissingMemberException("Risk object or member cannot found");
                    }
                }
                else
                {
                    throw new InvalidDateInputException("ValidFrom Value Must Be Greater Than Current date and time");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// This method can get policy by name within effective date
        /// </summary>
        /// <param name="nameOfInsuredObject">Policy name</param>
        /// <param name="effectiveDate">Active Policy</param>
        /// <returns>Policy More information</returns>
        public IPolicy GetPolicy(string nameOfInsuredObject, DateTime effectiveDate)
        {
            try
            {
                Policy policy = _policyRepository.GetPolicyByName(nameOfInsuredObject).Result;
                if (policy != null)
                {
                    //All Sold policies
                    var policyInstance = _policyAuditRepository.FindAllAsync(x => x.IsActive && x.PolicyId == policy.Id).Result;
                    //name of the insured object. Must be unique in the given period
                    foreach (var policyAudit in policyInstance)
                    {
                        //effective date must be between to start/end date from sold Policy
                        if (policyAudit.ValidFrom <= effectiveDate && policyAudit.ValidFrom.AddMonths(policyAudit.ValidMonths) >= effectiveDate)
                        {
                            policy.Premium = 0;
                            //bak
                            var auditList = _riskPolicyAuditRepository.FindAllAsync(x => x.IsActive && x.PolicyAuditId == policyAudit.Id).Result;
                            foreach (var audit in auditList)
                            {
                                policy.InsuredRisks.Add(audit.Risk);
                                policy.Premium = policy.Premium + audit.Risk.YearlyPrice;
                            }
                        }
                    }
                }
                return policy;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// This method remove risk to active Policy.
        /// </summary>
        /// <param name="nameOfInsuredObject">Policy Object Name</param>
        /// <param name="risk">want to delete object</param>
        /// <param name="validTill">Policy inactive date </param>
        /// <param name="effectiveDate">ACtive time from policy</param>
        public void RemoveRisk(string nameOfInsuredObject, Risk risk, DateTime validTill, DateTime effectiveDate)
        {
            if (risk != null)
            {
                //Get policy by name and active 
                Policy policy = _policyRepository.GetPolicyByName(nameOfInsuredObject).Result;

                if (policy != null)
                {
                    var policyInstance = _policyAuditRepository.FindAllAsync(x => x.IsActive && x.PolicyId == policy.Id).Result;
                    //name of the insured object. Must be unique in the given period
                    foreach (var policyAudit in policyInstance)
                    {
                        //effective date must be between to start/end date from sold Policy
                        //Date when risk become inactive. Must be equal to or greater than date when risk become active
                        if (policyAudit.ValidFrom <= effectiveDate && policyAudit.ValidFrom.AddMonths(policyAudit.ValidMonths) >= effectiveDate && policyAudit.ValidFrom <= validTill)
                        {
                            var deletedEntity = _riskPolicyAuditRepository.FindAsync(x => x.IsActive && x.PolicyAuditId == policyAudit.Id && x.RiskId == risk.Id).Result;
                            if (deletedEntity != null)
                            {
                                deletedEntity.IsActive = false;
                                _riskPolicyAuditRepository.UpdateRiskPolicyAudit(deletedEntity).Wait();
                            }
                            else
                            {
                                throw new NotFoundException("Risk Object Can not Found");
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// This method create new instance Policy with Risk List
        /// </summary>
        /// <param name="nameOfInsuredObject"></param>
        /// <param name="validFrom"></param>
        /// <param name="validMonths"></param>
        /// <param name="selectedRisks"></param>
        /// <returns></returns>
        public IPolicy SellPolicy(string nameOfInsuredObject, DateTime validFrom, short validMonths, IList<Risk> selectedRisks)
        {
            try
            {
                bool invalidPeriod = false;
                //beginning date must be to now 
                if (validFrom >= DateTime.Now)
                {
                    if (selectedRisks.Count == 0)
                        throw new NotFoundException("Must be select Risk/Risks group");
                    //Get policy By name
                    Policy policy = _policyRepository.GetPolicyByName(nameOfInsuredObject).Result;
                    if (policy == null)
                        throw new NotFoundException("Check Your Effective Date.Cannot Found Policy");
                    //All Sold policies
                    var policyInstance = _policyAuditRepository.FindAllAsync(x => x.IsActive && x.PolicyId == policy.Id).Result;
                    foreach (var polI in policyInstance)
                    {
                        //name of the insured object. Must be unique in the given period
                        if (validFrom >= polI.ValidFrom && validFrom.AddMonths(validMonths) >= validFrom)
                        {
                            invalidPeriod = true;
                        }
                    }
                    if (!invalidPeriod)
                    {
                        //Create new PolicyAudit instance 
                        var createdPolicyEntity = _policyAuditRepository.AddPolicyAudit(new PolicyAudit()
                        {
                            PolicyId = policy.Id,
                            IsActive = true,
                            ValidFrom = validFrom,
                            ValidTill = validFrom.AddMonths(validMonths),
                            Premium = 0,
                            ValidMonths = validMonths,
                        }).Result;

                        //Policy is avaliable to Sell
                        foreach (var risk in selectedRisks)
                        {
                            //invalid risk, item must be in Risk List
                            if (risk.Id != 0)
                            {
                                _riskPolicyAuditRepository.AddRiskPolicyAudit(new RiskPolicyAudit()
                                {
                                    PolicyAuditId = createdPolicyEntity.Id,
                                    ValidFrom = validFrom,
                                    RiskId = risk.Id,
                                    //ValidMonths = validMonths,
                                    IsActive = true
                                }).Wait();
                                createdPolicyEntity.Premium = createdPolicyEntity.Premium + risk.YearlyPrice;
                            }

                        }
                        policy.InsuredRisks = selectedRisks;
                        policy.Premium = createdPolicyEntity.Premium;
                        _policyAuditRepository.UpdateAsync(createdPolicyEntity, true);
                        return policy;
                    }
                    else
                    {
                        throw new FormatException("Policy can not sell in this period");
                    }
                }
                else
                {
                    throw new FormatException("Date Must be greater than Now");
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}
