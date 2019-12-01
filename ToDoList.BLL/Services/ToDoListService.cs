using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using AutoMapper.Configuration;
using Microsoft.EntityFrameworkCore;
using ToDoList.BLL.Abstraction;
using ToDoList.BLL.Models;
using ToDoList.DAL.EF;
using ToDoList.DAL.Entities;



namespace ToDoList.BLL.Services
{
    public class ToDoListService : ITodoService
    {
        private readonly ToDoListDbContext _dbContext;
        private readonly IMapper _mapper;

        public ToDoListService(ToDoListDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public IEnumerable<ToDoListModel> Get(string login)
        {
            var todoLists = _dbContext.Users.AsNoTracking()
                .Include(x => x.ToDoLists)
                .ThenInclude(x => x.Tags).FirstOrDefault(x => x.Login == login)?.ToDoLists;
            if (todoLists == null) return null;
            List<ToDoListModel> listModels = new List<ToDoListModel>();
            try
            {
                listModels = todoLists.Select(x => _mapper.Map<ToDoListModel>(x)).ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return listModels;
        }

        public ToDoListModel GetById(int id)
        {
            var entity = _dbContext.ToDoLists.Find(id);
            var model = _mapper.Map<ToDoListModel>(entity);
            return model;
        }

        public ToDoListModel Create(ToDoListModel model, string login)
        {
            var user = _dbContext.Users.Include(x => x.ToDoLists).SingleOrDefault(x => x.Login == login);
            var newToDo = _mapper.Map<DAL.Entities.ToDoList>(model);
            user?.ToDoLists.Add(newToDo);
            _dbContext.ToDoLists.Add(newToDo);
            _dbContext.SaveChanges();
            return model;
        }

        public ToDoListModel Edit(int id, ToDoListModel model)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Done(int id)
        {
            var todo = _dbContext.ToDoLists.Find(id);
            if(todo == null) return;
            todo.IsDone = !todo.IsDone;
            _dbContext.SaveChanges();
        }
    }
}
