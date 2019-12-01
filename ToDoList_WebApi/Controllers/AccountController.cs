using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using ToDoList.BLL.Helpers;
using ToDoList.BLL.Models;
using ToDoList.BLL.Services;

namespace ToDoList_WebApi.Controllers
{
    // [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountService;
        public AccountController(IAccountService service) => _accountService = service;

        [HttpPost]
        [Route("api/adduser")]
        public async Task Registration([FromBody] AccountModel account)
        {
            if (account == null) await Response.WriteAsync("");//todo
            Response.ContentType = "application/json";
            _accountService.Registration(account);
            var identity = GetIdentity(account);
            if (identity == null)
            {
                await Response.WriteAsync("Не верный логин или пароль");
                return;
            }
            string jwtToken = GetToken(identity);
            AccountInfoModel accountInfo = _accountService.GetAccountInfo(account);
            accountInfo.Token = jwtToken;
            await Response.WriteAsync(JsonConvert.SerializeObject(accountInfo,
                new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        [HttpPost]
        [Route("api/gettoken")]
        public async Task GetToken([FromBody] AccountModel account)
        {
            Response.ContentType = "application/json";
            var identity = GetIdentity(account);
            if (identity == null)
            {
                await Response.WriteAsync("Не верный логин или пароль");
                return;
            }

            AccountInfoModel accountInfo = _accountService.GetAccountInfo(account);
            string jwtToken = GetToken(identity);
            accountInfo.Token = jwtToken;
            await Response.WriteAsync(JsonConvert.SerializeObject(accountInfo,
                new JsonSerializerSettings { Formatting = Formatting.Indented }));
        }

        private ClaimsIdentity GetIdentity(AccountModel account)
        {
            if (!_accountService.IsAuthorized(account)) return null;
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, account.Login),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, account.Role)
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Token",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }

        private string GetToken(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),
                    SecurityAlgorithms.HmacSha256)
                );

            var encodeJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodeJwt;
        }
    }
}