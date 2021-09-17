using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetsPersons.Domain.Interfaces;
using TimeSheetsPersons.Models;
using TimeSheetsPersons.Models.DTO;
using TimeSheetsPersons.Data.Interfaces;

namespace TimeSheetsPersons.Domain.Implementation
{
    public class PersonManager : IPersonManager
    {
        private readonly IPersonRepo personRepo;
        public PersonManager(IPersonRepo personRepo)
        {
            this.personRepo = personRepo;
        }
        public int Create(DtoPersonCreate DtoPerson)
        {
            Person person = new Person
            {
                Id = personRepo.GenerateId(),
                FirstName = DtoPerson.FirstName,
                LastName = DtoPerson.LastName,
                Email = DtoPerson.Email,
                Company = DtoPerson.Company,
                Age = DtoPerson.Age
            };

            personRepo.Create(person);

            return person.Id;
        }

        public void Delete(int id)
        {
            personRepo.Delete(id);
        }

        public IEnumerable<Person> GetByPagination(int skip, int take)
        {
            List<Person> result = personRepo.GetByPagination(skip, take).ToList();

            return result;
        }

        public Person GetById(int id)
        {
            Person result = personRepo.GetById(id);

            return result;
        }

        public Person GetByName(string name)
        {
            Person result = personRepo.GetByName(name);

            return result;
        }

        public void Update(Person person)
        {
            personRepo.Update(person);
        }
    }
}
