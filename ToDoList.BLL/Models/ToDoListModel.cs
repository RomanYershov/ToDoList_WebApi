using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.BLL.Abstraction;
using ToDoList.DAL.Entities;

namespace ToDoList.BLL.Models
{
    public class ToDoListModel : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }      
        public bool IsDone { get; set; }
        public List<Tag> Tags { get; set; }
        //public ToDoListModel() => Tags = new List<Tag>();
    }
}
