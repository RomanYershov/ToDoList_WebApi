using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.DAL.Abstraction;

namespace ToDoList.DAL.Entities
{
    public class Tag : Entity
    {
        public string Name { get; set; }   
    }
}
