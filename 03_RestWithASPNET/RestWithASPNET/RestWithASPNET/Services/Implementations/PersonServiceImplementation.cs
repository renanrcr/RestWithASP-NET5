using RestWithASPNET.Model;
using System.Collections.Generic;
using System.Threading;

namespace RestWithASPNET.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();
            for (int i = 0; i < 8; i++)
            {
                persons.Add(MockPerson(i));
            }

            return persons;
        }

        public Person FindById(long id)
        {
            return new Person 
            { 
                Id = ImplementAndGet(),
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

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = ImplementAndGet(),
                FirstName = "Renan" + i,
                LastName = "Rinaldi" + i,
                Address = "São Paulo - Brasil" + i,
                Gender = "Male"
            };
        }

        private long ImplementAndGet()
        {
            return Interlocked.Increment(ref count);
        }
    }
}
