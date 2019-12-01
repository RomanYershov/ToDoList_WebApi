using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoList.BLL.Helpers;
using ToDoList.BLL.Models;
using ToDoList.DAL.EF;
using ToDoList.DAL.Entities;

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
            var user = _dbContext.Users.FirstOrDefault(x => x.Login == accountModel.Login);
            if (user == null) return null;
            var accountInfo = new AccountInfoModel
            {
                Id = user.Id,
                Role = user.Role,
                Login = user.Login
            };
            return accountInfo;
        }

        public AccountModel Registration(AccountModel accountModel)
        {
            var salt = HashingMethods.CreateSalt();
            var user = new User
            {
                Login = accountModel.Login,
                Salt = salt,
                PasswordHash = HashingMethods.GenerateSha256Hash(accountModel.Password, salt),
                Role = "user"
            };
            try
            {
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.InnerException?.Message);
            }
            return accountModel;
        }
    }
}
