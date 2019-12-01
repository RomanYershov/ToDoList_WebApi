using System;
using System.Collections.Generic;
using System.Text;

namespace ToDoList.BLL.Abstraction
{
    public interface IService<TM> where TM : ModelBase
    {
        IEnumerable<TM> Get(string login);      
        TM GetById(int id);
        TM Create(TM model, string login);
        TM Edit(int id, TM model);
        void Remove(int id);
    }
}
