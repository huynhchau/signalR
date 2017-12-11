using BPS.HiltonDirect.Core.Context;
using BPS.HiltonDirect.Repositories.Mapping;
using BPS.HiltonDirect.Services;
using BPS.HiltonDirect.WebApp.Hubs;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BPS.HiltonDirect.WebApp.WebAPI
{
    public class RequestController : BaseApiController
    {
        private readonly IRequestService service;
        private readonly IRequestMapper mapper;
        public RequestController(IUserContext context, IPersonService personService,
            IRequestService service, IRequestMapper mapper)
            :base(context, personService)
        {
            this.service = service;
            this.mapper = mapper;
        }

        [HttpPost]
        [HttpGet]
        public Model.Client.ClientServiceResult<Model.Client.ViewModel.BrowsePageViewModel<Model.Client.ViewModel.RequestViewModel>>
            GetRequests()
        {
            var result = new Model.Client.ClientServiceResult<Model.Client.ViewModel.BrowsePageViewModel<Model.Client.ViewModel.RequestViewModel>>();
            result.Data = new Model.Client.ViewModel.BrowsePageViewModel<Model.Client.ViewModel.RequestViewModel>();
            result.Data.BrowseItems = service.GetAllOfRequests().Select(b => mapper.MapToViewModel(b)).ToList();

            result.HasPermission = true;
            return result;
        }

        [HttpPost]
        [HttpGet]
        public Model.Client.ClientServiceResult<Model.Client.ViewModel.RequestViewModel, Model.RequestLookupInfo>
            GetRequestById(int id)
        {
            var result = new Model.Client.ClientServiceResult<Model.Client.ViewModel.RequestViewModel, Model.RequestLookupInfo>();
            if (id == 0)
            {
                result.Data = new Model.Client.ViewModel.RequestViewModel();
            }
            else
            {
                result.Data = mapper.MapToViewModel(service.GetRequestById(id));
            }
            var lookupInfo = service.GetLookupInformation();
            result.Lookup = lookupInfo;
            return result;
        }

        [HttpPost]
        public Model.Client.ClientServiceResult<bool>
            UpdateRequest(Model.Client.ViewModel.RequestViewModel request)
        {
            var result = new Model.Client.ClientServiceResult<bool>();
            var domObject = service.GetRequestById(request.Id);
            mapper.MapToDomainObject(request, domObject);
            service.UpdateRequest(domObject);
            result.Data = true;
            DashboardHub.ReloadRequestList();
            return result;
        }

        [HttpPost]
        public Model.Client.ClientServiceResult<Model.Client.ViewModel.RequestViewModel>
            AddRequest(Model.Client.ViewModel.RequestViewModel request)
        {
            var result = new Model.Client.ClientServiceResult<Model.Client.ViewModel.RequestViewModel>();
            var domObject = new Model.Request();
            mapper.MapToDomainObject(request, domObject);
            result.Data = mapper.MapToViewModel(service.CreateRequest(domObject));
            DashboardHub.ReloadRequestList();
            return result;
        }

        [HttpPost]
        public Model.Client.ClientServiceResult<bool> RemoveRequest(JObject jsonData)
        {
            var result = new Model.Client.ClientServiceResult<bool>();
            dynamic json = jsonData;
            int requestId = json.id;
            try
            {
                service.DeleteRequest(requestId);
                result.Data = true;
                DashboardHub.ReloadRequestList();
            }
            catch (Exception ex)
            {
                result = HandleError<bool>(ex, Model.Resource.delete_error);
            }
            return result;
        }
    }
}
