using BPS.HiltonDirect.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Services
{
    [LoggingInterception(LoggingCategory.Services)]
    public interface IResourceStringService
    {
        Model.Configuration.ResourceStrings GetAllResourceStrings();
    }

    public class ResourceStringService : IResourceStringService
    {
        public ResourceStringService()
        {
        }

        public Model.Configuration.ResourceStrings GetAllResourceStrings()
        {
            var result = new Model.Configuration.ResourceStrings();
            var resourceSet = Model.Resource.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
            result.Resources = resourceSet.Cast<DictionaryEntry>()
                                    .ToDictionary(r => r.Key.ToString(),
                                                  r => r.Value.ToString());
            return result;
        }
    }
}
