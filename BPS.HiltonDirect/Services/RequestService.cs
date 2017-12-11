using BPS.HiltonDirect.Model;
using BPS.HiltonDirect.Repositories;
using BPS.HiltonDirect.Repositories.Mapping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace BPS.HiltonDirect.Services
{
    [LoggingInterception(LoggingCategory.Services)]
    public interface IRequestService
    {
        Model.Request CreateRequest(Model.Request domObject);
        void UpdateRequest(Model.Request domObject);
        void DeleteRequest(int requestId);

        Model.Request GetRequestById(int id);
        List<Model.Request> GetAllOfRequests();
        Model.RequestLookupInfo GetLookupInformation();
    }

    public class RequestService : IRequestService
    {
        private readonly IRequestRepository repository;
        private readonly IRequestMapper mapper;

        public RequestService(IRequestRepository repository,
            IRequestMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public RequestLookupInfo GetLookupInformation()
        {
            return repository.GetLookupInformation();
        }

        public Model.Request CreateRequest(Model.Request domObject)
        {
            return repository.CreateRequest(domObject);
        }

        public void UpdateRequest(Model.Request domObject)
        {
            repository.UpdateRequest(domObject);
        }

        public void DeleteRequest(int requestId)
        {
            repository.DeleteRequest(requestId);
        }

        public Model.Request GetRequestById(int id)
        {
            return repository.GetRequestById(id);
        }

        public List<Model.Request> GetAllOfRequests()
        {
            return repository.GetAllOfRequests();
        }
    }
}
