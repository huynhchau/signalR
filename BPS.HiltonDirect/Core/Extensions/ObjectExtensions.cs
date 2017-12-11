using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public static class ObjectExtensions
    {
        public static bool IsNull<T>(this T theObject)
        {

            object obj = theObject;

            if (theObject is string)
                return string.IsNullOrWhiteSpace((string)obj) ? true : false;
            if (theObject is Guid && theObject != null)
                return ((Guid)obj).Equals(Guid.Empty);
            return theObject == null ? true : false;
        }

        public static T IsNull<T>(this T theObject, Action action)
        {
            if (IsNull(theObject))
            {
                action.Invoke();
            }
            return theObject;
        }
    }
}
