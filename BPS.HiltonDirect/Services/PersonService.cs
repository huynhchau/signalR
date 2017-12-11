using BPS.HiltonDirect.Model;
using BPS.HiltonDirect.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BPS.HiltonDirect.Services
{
    [LoggingInterception(LoggingCategory.Services)]
    public interface IPersonService
    {
        Model.Person GetPersonByEmail(string email);
    }

    public class PersonService : IPersonService
    {
        private IPersonRepository repository;

        public PersonService(IPersonRepository personRepository)
        {
            this.repository = personRepository;
        }

        public Model.Person GetPersonByEmail(string email)
        {
            return repository.GetPersonByEmail(email);
        }
    }
}
