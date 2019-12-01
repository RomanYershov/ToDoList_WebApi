using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.BLL.Models;

namespace ToDoList.BLL.Abstraction
{
    public interface ITodoService : IService<ToDoListModel>
    {
        void Done(int id);
    }
}
