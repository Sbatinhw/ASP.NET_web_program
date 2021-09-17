using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetsPersons.Models;

namespace TimeSheetsPersons.Data
{
    public interface IRepoBase<T>
    {
        void Create(T item);
        T GetById(int id);
        T GetByName(string name);
        IEnumerable<T> GetByPagination(int skip, int take);
        void Update(T item);
        void Delete(int id);
        int GenerateId();
    }
}
