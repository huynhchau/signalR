using BPS.HiltonDirect.Core.Context;
using BPS.HiltonDirect.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BPS.HiltonDirect.WebApp.WebAPI
{
    public class TestController : BaseApiController
    {
        public TestController(IUserContext context, IPersonService personService) : 
            base(context, personService)
        {
        }

        [HttpGet]
        [HttpPost]
        public Model.Client.ClientServiceResult<Model.Person> Test()
        {
            var result = new Model.Client.ClientServiceResult<Model.Person>();
            result.Data = this.CurrentUser;
            return result;
        }
    }
}
