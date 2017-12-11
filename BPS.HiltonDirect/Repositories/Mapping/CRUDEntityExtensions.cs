using BPS.HiltonDirect.Core.Context;
using BPS.HiltonDirect.Core.Extensions;
using BPS.HiltonDirect.Model;
using BPS.HiltonDirect.Model.Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class CRUDEntityExtensions
    {
        public static T SetCreatedInfo<T>(this T source, IUserContext callContext) where T : BaseCRUDEntity
        {
            source.CreatedDate = DateTimeOffset.UtcNow;
            if (callContext.CurrentUser != null)
                source.CreatedBy = callContext.CurrentUser;
            source.ModifiedDate = source.CreatedDate;
            source.ModifiedBy = source.CreatedBy;
            return source;
        }

        public static T SetModifiedInfo<T>(this T source, IUserContext callContext) where T : BaseCRUDEntity
        {
            source.ModifiedDate = DateTimeOffset.UtcNow;
            if (callContext.CurrentUser != null)
                source.ModifiedBy = callContext.CurrentUser;
            return source;
        }

        public static T GetCreatedInfo<T>(this T source, BaseCRUDEntity domain) where T : BaseCRUDEntityViewModel
        {
            source.CreatedDate = domain.CreatedDate.ToShortBPSDateString();
            source.CreatedBy = domain.CreatedBy;
            source.ModifiedDate = domain.ModifiedDate.ToShortBPSDateString();
            source.ModifiedBy = domain.ModifiedBy;
            return source;
        }
        
    }
}
