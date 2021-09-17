using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetsPersons.Models;
using TimeSheetsPersons.Data.Interfaces;

namespace TimeSheetsPersons.Data.Implementation
{
    public class PersonRepo : IPersonRepo
    {
        private ValuesHolder valuesHolder;

        public PersonRepo(ValuesHolder valuesHolder)
        {
            this.valuesHolder = valuesHolder;
        }
        public void Create(Person item)
        {
            valuesHolder.PersonList.Add(item);
        }

        public void Delete(int id)
        {
            var result = from t in valuesHolder.PersonList
                                      where t.Id != id
                                      orderby t.Id
                                      select t;

            valuesHolder.PersonList = result.AsEnumerable().ToList();
        }

        //предполагаю что неправильно понял задание
        public IEnumerable<Person> GetByPagination(int skip, int take)
        {
            List<Person> result = new List<Person>();
            for(int i = 0; i < take; i++)
            {
                result.Add(valuesHolder.PersonList[i + skip]);
            }
            return result;
        }

        public Person GetById(int id)
        {
            Person result = valuesHolder.PersonList.SingleOrDefault(t => t.Id == id);

            return result;
        }

        public Person GetByName(string name)
        {
            Person result = valuesHolder.PersonList.SingleOrDefault
                (t => 
                t.FirstName == name || 
                t.LastName == name || 
                $"{t.FirstName.ToLower()} {t.LastName.ToLower()}" == name.ToLower());

            return result;
        }

        public void Update(Person item)
        {
            var result = valuesHolder.PersonList.Where(t => t.Id != item.Id).ToList();
            result.Add(item);
            valuesHolder.PersonList = result;
        }

        public int GenerateId()
        {
            Random rnd = new Random();
            int start = 0;
            int end = 10;
            int result;
            while (true)
            {
                for(int i = 0; i < 10; i++)
                {
                    result = rnd.Next(start, end);
                    var test = valuesHolder.PersonList.SingleOrDefault(t => t.Id == result);
                    if(test == null)
                    {
                        return result;
                    }
                }
                end = end * 2;
            }
            //return default;
        }
    }
}
