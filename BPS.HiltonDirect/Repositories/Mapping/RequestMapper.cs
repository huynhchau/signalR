using BPS.HiltonDirect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BPS.HiltonDirect.Model.Client.ViewModel;
using BPS.HiltonDirect.Core.Extensions;
using BPS.HiltonDirect.Model.Client;

namespace BPS.HiltonDirect.Repositories.Mapping
{
    [LoggingInterception(LoggingCategory.Repositories)]
    public interface IRequestMapper
    {
        Model.Request MapToDomainObject(Request efObject);
        void MapToEfObject(Model.Request domObject, Request efObject);
        void MapToDomainObject(RequestViewModel request, Model.Request domObject);
        RequestViewModel MapToViewModel(Model.Request request);
        IEnumerable<RequestViewModel> MapToViewModel(List<Model.Request> i);
    }

    public class RequestMapper : BaseMapper, IRequestMapper
    {
        private readonly IPersonMapper personMapper;

        public RequestMapper(HiltonDirectEntities context, IPersonMapper personMapper)
            : base(context)
        {
            this.personMapper = personMapper;
        }

        public Model.Request MapToDomainObject(Request efObject)
        {
            if (efObject == null)
                return new Model.Request();

            return new Model.Request
            {
                Id = efObject.Id,
                Type = efObject.RequestType,
                CreatedBy = personMapper.MapToDomainObject(efObject.CreatedBy),
                CreatedDate = efObject.CreatedDate,
                ModifiedBy = personMapper.MapToDomainObject(efObject.ModifiedBy),
                ModifiedDate = efObject.ModifiedDate,
                DirectLeadRequest = MapToDomainObject(efObject.DirectLeadRequest),
                EchannelRequest = MapToDomainObject(efObject.EchannelRequest),
            };
        }

        public void MapToEfObject(Model.Request domObject, Request efObject)
        {
            efObject.RequestType = domObject.Type;
            efObject.CreatedDate = domObject.CreatedDate;
            efObject.ModifiedDate = domObject.ModifiedDate;
            efObject.CreatedBy = context.Persons.FirstOrDefault(p => p.EmailAddress == domObject.CreatedBy.EmailAddress);
            efObject.ModifiedBy = context.Persons.FirstOrDefault(p => p.EmailAddress == domObject.ModifiedBy.EmailAddress);
            if (domObject.Type == RequestType.eChannel && domObject.EchannelRequest != null)
            {
                if (domObject.EchannelRequest.Id <= 0)
                {
                    efObject.EchannelRequest = new EchannelRequest();
                }
                MapToEfObject(domObject.EchannelRequest, efObject.EchannelRequest);
            }
            else if(domObject.Type != RequestType.eChannel && domObject.DirectLeadRequest != null)
            {
                if (domObject.DirectLeadRequest.Id <= 0)
                {
                    efObject.DirectLeadRequest = new DirectLeadRequest();
                }
                MapToEfObject(domObject.DirectLeadRequest, efObject.DirectLeadRequest);
            }
        }

        private void MapToEfObject(Model.DirectLeadRequest domObject, DirectLeadRequest efObject)
        {
            efObject.Admin1 = domObject.Admin1 != null ? context.Persons.FirstOrDefault(d => d.EmailAddress == domObject.Admin1.EmailAddress) : null;
            efObject.SPRPerson = domObject.SPR != null ? context.Persons.FirstOrDefault(d => d.EmailAddress == domObject.SPR.EmailAddress) : null;
            efObject.Note = domObject.Note;
        }

        private Model.DirectLeadRequest MapToDomainObject(DirectLeadRequest efObject)
        {
            if (efObject == null)
                return new Model.DirectLeadRequest();

            return new Model.DirectLeadRequest
            {
                Id = efObject.Id,
                Admin1 = personMapper.MapToDomainObject(efObject.Admin1),
                SPR = personMapper.MapToDomainObject(efObject.SPRPerson),
                Note = efObject.Note,
            };
        }

        private void MapToEfObject(Model.EchannelRequest domObject, EchannelRequest efObject)
        {
            efObject.Admin1 = domObject.Admin1 != null ? context.Persons.FirstOrDefault(d => d.EmailAddress == domObject.Admin1.EmailAddress) : null;
            efObject.Admin2 = domObject.Admin2 != null ? context.Persons.FirstOrDefault(d => d.EmailAddress == domObject.Admin2.EmailAddress) : null;
            efObject.Admin3 = domObject.Admin3 != null ? context.Persons.FirstOrDefault(d => d.EmailAddress == domObject.Admin3.EmailAddress) : null;
            efObject.Admin4 = domObject.Admin4 != null ? context.Persons.FirstOrDefault(d => d.EmailAddress == domObject.Admin4.EmailAddress) : null;
            efObject.Admin5 = domObject.Admin5 != null ? context.Persons.FirstOrDefault(d => d.EmailAddress == domObject.Admin5.EmailAddress) : null;
            efObject.CommissionRate = domObject.CommissionRate;
            efObject.DecisionDueDate = domObject.DecisionDueDate;
            efObject.FollowUpActivity = domObject.FollowUpActivity != null ? context.FollowUpActivities.FirstOrDefault(f => f.Id == domObject.FollowUpActivity.Id) : null;
            efObject.IsCommissionable = domObject.IsCommissionable;
            efObject.IsCreateTask = domObject.IsCreateTask;
            efObject.MeetingClass = domObject.MeetingClass != null ? context.MeetingClasses.FirstOrDefault(f => f.Id == domObject.MeetingClass.Id) : null;
            efObject.TaskDueDate = domObject.TaskDueDate;
            efObject.SPRPerson = domObject.SPR != null ? context.Persons.FirstOrDefault(d => d.EmailAddress == domObject.SPR.EmailAddress) : null;
        }

        private Model.EchannelRequest MapToDomainObject(EchannelRequest efObject)
        {
            if (efObject == null)
                return new Model.EchannelRequest();

            return new Model.EchannelRequest
            {
                Id = efObject.Id,
                Admin1 = personMapper.MapToDomainObject(efObject.Admin1),
                Admin2 = personMapper.MapToDomainObject(efObject.Admin2),
                Admin3 = personMapper.MapToDomainObject(efObject.Admin3),
                Admin4 = personMapper.MapToDomainObject(efObject.Admin4),
                Admin5 = personMapper.MapToDomainObject(efObject.Admin5),
                SPR = personMapper.MapToDomainObject(efObject.SPRPerson),
                CommissionRate = efObject.CommissionRate,
                DecisionDueDate = efObject.DecisionDueDate,
                FollowUpActivity = efObject.FollowUpActivityId.HasValue ? new GenericItem {
                    Id = efObject.FollowUpActivityId.Value,
                    Name = efObject.FollowUpActivity.Name
                } : null,
                IsCommissionable = efObject.IsCommissionable,
                IsCreateTask = efObject.IsCreateTask,
                MeetingClass = efObject.MeetingClassId.HasValue ? new GenericItem
                {
                    Id = efObject.MeetingClassId.Value,
                    Name = efObject.MeetingClass.Name
                } : null,
                TaskDueDate = efObject.TaskDueDate,
            };
        }

        public void MapToDomainObject(RequestViewModel vm, Model.Request domObject)
        {
            domObject.Id = vm.Id;
            domObject.Type = vm.Type;
            if (vm.Type == RequestType.eChannel)
                domObject.EchannelRequest = MapToEchannel(vm);
            else
                domObject.DirectLeadRequest = MapToDirectLeadRequest(vm);
        }

        private Model.EchannelRequest MapToEchannel(RequestViewModel vm)
        {
            var domainObject = new Model.EchannelRequest();
            domainObject.Id = vm.Id;
            domainObject.Admin1 = vm.Admin1;
            domainObject.Admin2 = vm.EchannelRequest.Admin2;
            domainObject.SPR = vm.SPR;
            domainObject.TaskDueDate = !string.IsNullOrEmpty(vm.TaskDueDate) ? vm.TaskDueDate.TryParseToDateTime() : null;

            return domainObject;
        }

        private Model.DirectLeadRequest MapToDirectLeadRequest(RequestViewModel vm)
        {
            var domainObject = new Model.DirectLeadRequest();
            domainObject.Id = vm.Id;
            domainObject.Admin1 = vm.Admin1;
            domainObject.SPR = vm.SPR;
            domainObject.Note = vm.DirectLeadRequest.Note;

            return domainObject;
        }

        private void MapToViewModel(Model.EchannelRequest domain, RequestViewModel vm)
        {
            if (vm.EchannelRequest == null)
            {
                vm.EchannelRequest = new EchannelRequestViewModel();
            }
            vm.EchannelRequest.Id = domain.Id;
            vm.EchannelRequest.Admin2 = domain.Admin2;
            vm.Admin1 = domain.Admin1;
            vm.SPR = domain.SPR;
            vm.TaskDueDate = domain.TaskDueDate.ToShortBPSDateString();
        }

        private void MapToViewModel(Model.DirectLeadRequest domain, RequestViewModel vm)
        {
            if (vm.DirectLeadRequest == null)
            {
                vm.DirectLeadRequest = new DirectLeadRequestViewModel();
            }
            vm.DirectLeadRequest.Id = domain.Id;
            vm.Admin1 = domain.Admin1;
            vm.SPR = domain.SPR;
            vm.DirectLeadRequest.Note = domain.Note;
        }

        public RequestViewModel MapToViewModel(Model.Request request)
        {
            RequestViewModel vm = new RequestViewModel();
            vm.Id = request.Id;
            vm.Type = request.Type;
            vm.GetCreatedInfo(request);
            if (vm.Type == RequestType.eChannel)
                MapToViewModel(request.EchannelRequest, vm);
            else
                MapToViewModel(request.DirectLeadRequest, vm);
            return vm;
        }

        public IEnumerable<RequestViewModel> MapToViewModel(List<Model.Request> items)
        {
            return items.Select(b => MapToViewModel(b));
        }
    }
}
