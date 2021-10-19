using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.BusinessLayer.Core;
using TMS.BusinessLayer.Managers.ServiceRequestManagement;
using TMS.Common.Core;
using TMS.Common.Entities;
using TMS.Common.Facade;
using TMS.DataAccess.Core.Interfaces;

namespace TMS.BusinessLayer.Managers.TenantManagement
{
    public class TenantManager : BusinessManager, ITenantManager
    {
        private readonly IRepository _repository;
        private readonly ILogger<TenantManager> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IServiceRequestManager serviceRequestManager;

        public TenantManager(IRepository repository, ILogger<TenantManager>logger, IUnitOfWork unitOfWork, IServiceRequestManager serviceRequestManager):base()
        {
            this._repository = repository;
            this._logger = logger;
            this._unitOfWork = unitOfWork;
            this.serviceRequestManager = serviceRequestManager;
        }

        public IUnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        public void Create(BaseEntity entity)
        {
            try
            {
                Tenant tenant = (Tenant)entity;
                _logger.LogInformation("Creating Record for {0}", this.GetType());
                _repository.Create<Tenant>(tenant);
                SaveChanges();
                _logger.LogInformation("Record saved for {0}", this.GetType());
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Delete(BaseEntity entity)
        {
            try
            {
                Tenant tenant = (Tenant)entity;
                _logger.LogInformation("Deleting record for {0}", this.GetType());
                _repository.Delete<Tenant>(tenant);
                SaveChanges();
                _logger.LogInformation("Record deleted for {0}", this.GetType());

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            return _repository.All<Tenant>().ToList<Tenant>();
        }

        public virtual Tenant GetTenant(long tenantId)
        {
            try
            {
                _logger.LogInformation(LoggingEvents.GET_ITEM, "The tenant Id is " + tenantId);
                return _repository.All<Tenant>().FirstOrDefault(i => i.ID == tenantId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public void Update(BaseEntity entity)
        {
            try
            {
                Tenant tenant = (Tenant)entity;
                _logger.LogInformation("Updating record for {0}", this.GetType());
                _repository.Update<Tenant>(tenant);
                SaveChanges();
                _logger.LogInformation("Record updated for {0}", this.GetType());

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
