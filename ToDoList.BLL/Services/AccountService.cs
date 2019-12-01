using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoList.BLL.Helpers;
using ToDoList.BLL.Models;
using ToDoList.DAL.EF;

namespace ToDoList.BLL.Services
{
    public class AccountService : IAccountService
    {
        private readonly ToDoListDbContext _dbContext;
        public AccountService(ToDoListDbContext context) => _dbContext = context;
        public bool IsAuthorized(AccountModel accountModel)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Login == accountModel.Login);
            if (user == null) return false;
            var salt = user.Salt;
            var hash = HashingMethods.GenerateSha256Hash(accountModel.Password, salt);
            return hash == user.PasswordHash;
        }

        public AccountInfoModel GetAccountInfo(AccountModel accountModel)
        {
            throw new NotImplementedException();
        }

        public AccountModel Registration(AccountModel accountModel)
        {
            throw new NotImplementedException();
        }
    }
}
