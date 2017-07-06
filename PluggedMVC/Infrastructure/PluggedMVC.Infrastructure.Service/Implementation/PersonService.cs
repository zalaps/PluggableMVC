using PluggedMVC.Core.Data.Repository;
using PluggedMVC.Core.Model;
using PluggedMVC.Core.Service;
using System.Collections.Generic;
using System.Linq;

namespace PluggedMVC.Infrastructure.Service
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository personRepository;
        public PersonService(IPersonRepository personRepo)
        {
            this.personRepository = personRepo;
        }

        public List<PersonViewModel> GetAllPersons()
        {
            var allpersons = personRepository.GetAll().Select(p => new PersonViewModel { FirstName = p.FirstName}).ToList();
            return allpersons;
        }
    }
}
