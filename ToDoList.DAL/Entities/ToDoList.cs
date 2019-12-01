using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.DAL.Abstraction;

namespace ToDoList.DAL.Entities
{
    public class ToDoList : Entity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }  
        public bool IsDone { get; set; }
        public List<Tag> Tags { get; set; }

        public ToDoList()
        {
            Tags = new List<Tag>();
            CreationDate = DateTime.Today.Date;
        }
    }
}
