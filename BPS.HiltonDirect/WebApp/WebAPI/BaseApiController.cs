using BPS.HiltonDirect.Core.Context;
using BPS.HiltonDirect.Core.Extensions;
using BPS.HiltonDirect.Core.Utilities;
using BPS.HiltonDirect.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BPS.HiltonDirect.WebApp.WebAPI
{
    public class BaseApiController : ApiController
    {
        private readonly IUserContext context;
        private readonly IPersonService personService;
        Model.Person _currentUser;

        public BaseApiController()
        {

        }

        public BaseApiController(IUserContext context, IPersonService personService)
        {
            this.context = context;
            this.personService = personService;
            RetrieveUserInfo();
        }

        private void RetrieveUserInfo()
        {
            this.context.User = CookieUtil<Model.SessionUser>.TryGetCookie(HttpContext.Current.Request, Core.Constants.Session.sesUserEmail);
            this.context.CurrentUser = CurrentUser;
        }

        public Model.Person CurrentUser
        {
            get
            {
                _currentUser.IsNull(() =>
                {
                    if (personService != null)
                        _currentUser = personService.GetPersonByEmail(this.context.User.UserEmail);
                    else
                        throw new Exception("To use the CurrentUser property, please inject the IPersonService and pass it to the BaseController");
                });
                return _currentUser;
            }
        }

        protected Model.Client.ClientServiceResult<T> HandleError<T>(Exception ex, string errorResourceKey)
        {
            var result = new Model.Client.ClientServiceResult<T>
            {
                HasError = true,
                ErrorMessage = errorResourceKey,
                ErrorDetail = ex != null ? ex.GetBaseException().ToString() : string.Empty
            };

            return result;
        }
    }
}
