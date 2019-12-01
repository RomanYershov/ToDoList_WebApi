using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.BLL.Abstraction;

namespace ToDoList.BLL.Models
{
    public class AccountInfoModel : ModelBase
    {
        public string Token { get; set; }
        public string Login { get; set; }
        public string Role { get; set; }    
    }
}
