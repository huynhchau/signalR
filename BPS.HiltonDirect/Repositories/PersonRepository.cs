using BPS.HiltonDirect.Core;
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
    public interface IPersonRepository
    {
        Model.Person GetPersonByEmail(string email);
        List<Model.Person> GetUsersByEmails(List<string> emailAddresses);
        List<Model.Person> GetAllReferenceActivePersons();
    }

    public class PersonRepository: BaseRepository, IPersonRepository
    {
        private readonly IPersonMapper mapper;
        private readonly IUserContext userContext;
        public PersonRepository(HiltonDirectEntities context, IPersonMapper mapper, IUserContext userContext)
            : base(context)
        {
            this.mapper = mapper;
            this.userContext = userContext;
        }

        public List<Model.Person> GetAllReferenceActivePersons()
        {
            List<Person> users = context.Persons
                .Where(u => u.IsActive == true)
                .OrderBy(p => p.FirstName).ThenBy(p => p.LastName)
                .ToList();

            return users.Select(u => mapper.MapToDomainObject(u)).ToList();
        }

        public Model.Person GetPersonByEmail(string email)
        {
            using (var context = new HiltonDirectEntities(ConfigManager.ConnectionString.DbContext, userContext))
            {
                var user = context.Persons.FirstOrDefault(p => p.EmailAddress.ToLower() == email.ToLower());
                if (user != null)
                {
                    return mapper.MapToDomainObject(user);
                }
                return null;
            }
        }

        public List<Model.Person> GetUsersByEmails(List<string> emailAddresses)
        {
            return context.Persons.Where(p => emailAddresses.Contains(p.EmailAddress)).ToList().Select(p => mapper.MapToDomainObject(p)).ToList();
        }
    }
}
