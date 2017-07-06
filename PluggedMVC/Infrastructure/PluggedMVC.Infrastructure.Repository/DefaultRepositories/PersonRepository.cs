using PluggedMVC.Core.Data.Repository;
using PluggedMVC.Infrastructure.Data;

namespace PluggedMVC.Infrastructure.Repository
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(AdventureWorksEntities context) : base(context)
        {
        }
    }
}
