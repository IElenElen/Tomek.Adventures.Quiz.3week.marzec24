using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tomek.Adventures.Quiz._3week.marzec24.App.Abstract
{
    public interface IOperations<T>
    {
    List<T> GetAll();
    void Add(T entity);
    void Update(T entity);
    void Remove(T entity);
    }
}

