using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tomek.Adventures.Quiz._3week.marzec24.App.Abstract;

namespace Tomek.Adventures.Quiz._3week.marzec24.App.CommonApp
{
    //klasa bazowa to klasa wspólnych cech, ktorych nie chcemy powtarzać w serwisach i / lub menadżerach...
    public class BaseApp<T> : IOperations<T>
    {
        public List<T> Entities { get; set; }
        public BaseApp()
        {
            Entities = new List<T>();
        }
        public List<T> GetAll()
        {
            return Entities;
        }
        public void Add(T entity)
        {
            Entities.Add(entity);
        }

        public void Remove(T entity) //w planach
        {
            Entities.Remove(entity);
        }

        public void Update(T entity) //w planach
        {
            if (entity != null)
            {
                return;
            }
            else
            {
                Console.WriteLine($"Brak {entity}");
            }
        }
    }
}
