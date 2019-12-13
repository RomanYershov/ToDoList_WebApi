using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ToDoList.BLL.Abstraction;
using ToDoList.BLL.Helpers;
using ToDoList.BLL.Models;


namespace ToDoList_WebApi.Controllers
{
    [Authorize]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private ITodoService _service;
        public ToDoController(ITodoService service) => _service = service;

        [HttpGet]
        [Route("api/gettodos")]
        public async Task GetTodoLists()
        {
            var todos = _service.Get(User.Identity.Name);//.OrderBy(x => x.IsDone).ThenByDescending(x => x.CreationDate);
            await Response.WriteAsync(JsonConvert.SerializeObject(todos, Formatting.None));
        }
        [HttpPost]
        [Route("api/addtodo")]
        public async Task AddTodo([FromBody] ToDoListModel model)
        {
            _service.Create(model, User.Identity.Name);
            await Response.WriteAsync(JsonConvert.SerializeObject(StatusCode(StatusCodes.Status201Created)));
        }
        [HttpGet]
        [Route("api/toggle/{id}")]
        public async Task Toggle(int id)
        {
            _service.Done(id);
            await Response.WriteAsync(JsonConvert.SerializeObject(SimpleResponse.Success()));
        }
        [HttpPost]
        [Route("api/addtag")]
        public async Task AddTag(TagModel model)
        {
            var res = _service.AddTag(model);
            await Response.WriteAsync(JsonConvert.SerializeObject(SimpleResponse.Success(res)));
        }
    }
}