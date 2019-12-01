using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.BLL.Abstraction;

namespace ToDoList.BLL.Models
{
    public  class AccountModel : ModelBase
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
