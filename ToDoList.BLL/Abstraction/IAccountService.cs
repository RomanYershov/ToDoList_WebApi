using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.BLL.Models;

namespace ToDoList.BLL.Services
{
    public interface IAccountService
    {
        bool IsAuthorized(AccountModel accountModel);
        AccountInfoModel GetAccountInfo(AccountModel accountModel);
        AccountModel Registration(AccountModel accountModel);
    }
}
