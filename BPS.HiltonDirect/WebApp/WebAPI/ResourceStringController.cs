using BPS.HiltonDirect.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BPS.HiltonDirect.WebApp.WebAPI
{
    public class ResourceStringController : BaseApiController
    {
        readonly IResourceStringService resourceService;
        public ResourceStringController(IResourceStringService resourceService)
        {
            this.resourceService = resourceService;
        }

        public Model.Client.ClientServiceResult<Model.Configuration.ResourceStrings> GetAllResourceStrings()
        {
            return new Model.Client.ClientServiceResult<Model.Configuration.ResourceStrings>
            {
                Data = resourceService.GetAllResourceStrings()
            };
        }
    }
}
