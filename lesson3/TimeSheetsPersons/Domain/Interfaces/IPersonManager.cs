using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetsPersons.Models;
using TimeSheetsPersons.Models.DTO;

namespace TimeSheetsPersons.Domain.Interfaces
{
    public interface IPersonManager
    {
        int Create(DtoPersonCreate DtoPerson);
        Person GetById(int id);
        Person GetByName(string name);
        IEnumerable<Person> GetByPagination(int skip, int take);
        void Update(Person person);
        void Delete(int id);
    }
}
