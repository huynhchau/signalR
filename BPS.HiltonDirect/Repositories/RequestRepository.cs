using BPS.HiltonDirect.Core.Context;
using BPS.HiltonDirect.Model;
using BPS.HiltonDirect.Repositories.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Repositories
{
    [LoggingInterception(LoggingCategory.Repositories)]
    public interface IRequestRepository
    {
        Model.Request CreateRequest(Model.Request domObject);
        void UpdateRequest(Model.Request domObject);
        void DeleteRequest(int requestId);

        Model.Request GetRequestById(int id);
        List<Model.Request> GetAllOfRequests();
        Model.RequestLookupInfo GetLookupInformation();
    }

    public class RequestRepository: BaseRepository, IRequestRepository
    {
        private readonly IRequestMapper mapper;
        private readonly IPersonRepository personRepository;
        private readonly IUserContext usercontext;
        public RequestRepository(HiltonDirectEntities context, IRequestMapper mapper, 
            IPersonRepository personRepository, IUserContext usercontext)
            : base(context)
        {
            this.mapper = mapper;
            this.personRepository = personRepository;
            this.usercontext = usercontext;
        }

        public Model.Request CreateRequest(Model.Request domObject)
        {
            domObject.SetCreatedInfo(usercontext);
            domObject.SetModifiedInfo(usercontext);

            var efObject = new Request();
            mapper.MapToEfObject(domObject, efObject);
            context.Requests.Add(efObject);
            context.SaveChanges();
            return mapper.MapToDomainObject(efObject);
        }

        public void DeleteRequest(int requestId)
        {
            var efObject = context.Requests.FirstOrDefault(a => a.Id == requestId);
            if (efObject != null)
            {
                context.Requests.Remove(efObject);
                context.SaveChanges();
            }
        }

        public List<Model.Request> GetAllOfRequests()
        {
            return context.Requests.ToList().Select(b => mapper.MapToDomainObject(b)).ToList();
        }

        public RequestLookupInfo GetLookupInformation()
        {
            var result = new Model.RequestLookupInfo();
            result.FollowUpActivities = context.FollowUpActivities.Select(bk => new Model.GenericItem() { Id = bk.Id, Name = bk.Name }).ToList();
            result.MeetingClasses = context.MeetingClasses.Select(bk => new Model.GenericItem() { Id = bk.Id, Name = bk.Name }).ToList();
            result.Persons = personRepository.GetAllReferenceActivePersons();
            return result;
        }

        public Model.Request GetRequestById(int id)
        {
            return mapper.MapToDomainObject(context.Requests.FirstOrDefault(b => b.Id == id));
        }

        public void UpdateRequest(Model.Request domObject)
        {
            domObject.SetModifiedInfo(usercontext);
            var efObject = context.Requests.FirstOrDefault(b => b.Id == domObject.Id);
            mapper.MapToEfObject(domObject, efObject);

            context.SaveChanges();
        }

        private void RemoveUnusedEntity(Model.Request domObject, Request efObject)
        {
            if (domObject.Type == RequestType.eChannel && efObject.DirectLeadId.HasValue)
            {
                var efItem = context.DirectLeadRequests.FirstOrDefault(e => e.Id == efObject.DirectLeadId);
                context.DirectLeadRequests.Remove(efItem);
            }
            else if (domObject.Type != RequestType.eChannel && efObject.EchannelRequestId.HasValue)
            {
                var efItem = context.EchannelRequests.FirstOrDefault(e => e.Id == efObject.EchannelRequestId);
                context.EchannelRequests.Remove(efItem);
            }
        }
    }
}
