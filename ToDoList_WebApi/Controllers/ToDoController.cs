using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ToDoList.BLL.Abstraction;
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
            var todos = _service.Get(User.Identity.Name);
            await Response.WriteAsync(JsonConvert.SerializeObject(todos, Formatting.None));
        }
        [HttpPost]
        [Route("api/addtodo")]
        public async Task AddTodo([FromBody] ToDoListModel model)
        {
            _service.Create(model, User.Identity.Name);
            await Response.WriteAsync(JsonConvert.SerializeObject(StatusCode(StatusCodes.Status201Created, "")));
        }
        [HttpGet]
        [Route("api/toggle")]
        public void Toggle(int id)
        {
            _service.Done(id);
        }
    }
}