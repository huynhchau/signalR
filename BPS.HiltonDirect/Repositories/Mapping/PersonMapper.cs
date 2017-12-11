using BPS.HiltonDirect.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Repositories.Mapping
{
    [LoggingInterception(LoggingCategory.Repositories)]
    public interface IPersonMapper
    {
        Model.Person MapToDomainObject(Person efObject);
        void MapToEfObject(Person efObject, Model.Person domainObject);
    }
    public class PersonMapper: BaseMapper, IPersonMapper
    {
        public PersonMapper(HiltonDirectEntities context) : base(context) { }

        public Model.Person MapToDomainObject(Person efObject)
        {
            if (efObject == null)
                return null;
            return new Model.Person
            {
                EmailAddress = efObject.EmailAddress,
                ModifiedById = efObject.ModifiedById,
                FirstName = efObject.FirstName,
                OfficeLocation = efObject.OfficeLocation,
                LastName = efObject.LastName,
                IsActive = efObject.IsActive,
                ModifiedDate = efObject.ModifiedDate,
                PhoneNumber = efObject.PhoneNumber,
            };
        }

        public void MapToEfObject(Person efObject, Model.Person domainObject)
        {
            efObject.EmailAddress = domainObject.EmailAddress;
            efObject.FirstName = domainObject.FirstName;
            efObject.LastName = domainObject.LastName;
            efObject.OfficeLocation = domainObject.OfficeLocation;
            efObject.IsActive = domainObject.IsActive;
            efObject.PhoneNumber = domainObject.PhoneNumber;
            efObject.ModifiedById = domainObject.ModifiedById;
            efObject.ModifiedDate = domainObject.ModifiedDate;
        }
    }
}
