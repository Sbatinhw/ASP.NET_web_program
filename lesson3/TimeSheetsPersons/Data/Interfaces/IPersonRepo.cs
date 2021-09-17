using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetsPersons.Models;
using TimeSheetsPersons.Data;

namespace TimeSheetsPersons.Data.Interfaces
{
    public interface IPersonRepo : IRepoBase<Person>
    {
    }
}
