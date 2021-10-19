using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMS.BusinessLayer.Core;
using TMS.Common.BusinessObjects;
using TMS.Common.Core;
using TMS.Common.Entities;
using TMS.DataAccess.Core.Interfaces;

namespace TMS.BusinessLayer.Managers.ServiceRequestManagement
{
    public class ServiceRequestManager : BusinessManager, IServiceRequestManager
    {
        private readonly IRepository _repository;
        private readonly ILogger<ServiceRequestManager> _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ServiceRequestManager(IRepository repository, ILogger<ServiceRequestManager> logger, IUnitOfWork unitOfWork):base()
        {
            this._repository = repository;
            this._logger = logger;
            this._unitOfWork = unitOfWork;
        }

        public IUnitOfWork UnitOfWork { get { return _unitOfWork; } }

        public void Create(BaseEntity entity)
        {
            ServiceRequest serviceRequest = (ServiceRequest)entity;
            _logger.LogInformation("Creating record for {0}", this.GetType());
            _repository.Create<ServiceRequest>(serviceRequest);
            _logger.LogInformation("Record saved for {0}", this.GetType());
        }

        public void Delete(BaseEntity entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BaseEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TenantServiceRequest> GetAllTenantServiceRequests()
        {
            var query = from tenants in _repository.All<Tenant>()
                        join serviceReqs in _repository.All<ServiceRequest>()
                        on tenants.ID equals serviceReqs.TenantID
                        join status in _repository.All<Status>()
                        on serviceReqs.StatusID equals status.ID
                        select new TenantServiceRequest()
                        {
                            TenantID = tenants.ID,
                            Description = serviceReqs.Description,
                            Email = tenants.Email,
                            EmployeeComments = serviceReqs.EmployeeComments,
                            Phone = tenants.Phone,
                            Status = status.Description,
                            TenantName = tenants.Name
                        };
            return query.ToList<TenantServiceRequest>();
        }

        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }

        public void Update(BaseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
