using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.DAL.Abstraction;

namespace ToDoList.DAL.Entities
{
    public class User : Entity
    {
        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
        public string Role { get; set; }
        public List<ToDoList> ToDoLists { get; set; }
        public User() => ToDoLists = new List<ToDoList>();
    }
}
