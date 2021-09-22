using RestWithASPNET.Model;
using RestWithASPNET.Model.Context;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNET.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private readonly MySqlContext _context;

        public PersonServiceImplementation(MySqlContext context)
        {
            _context = context;
        }

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
        }

        public List<Person> FindAll()
        {
            return _context.Persons.ToList();
        }

        public Person FindById(long id)
        {
            return new Person 
            { 
                Id = 1,
                FirstName = "Renan",
                LastName = "Rinaldi",
                Address = "São Paulo - Brasil",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            person.Address = "Rua Adélia";
            return person;
        }
    }
}
