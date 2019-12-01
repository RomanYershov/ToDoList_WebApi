using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.BLL.Abstraction;

namespace ToDoList.BLL.Models
{
    public class TagModel : ModelBase
    {
        public int ToDoId { get; set; } 
        public string Name { get; set; }    
    }
}
