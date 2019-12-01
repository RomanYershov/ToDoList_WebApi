using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using ToDoList.BLL.Models;
using ToDoList.DAL.Entities;

namespace ToDoList.BLL.Automapper
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<DAL.Entities.ToDoList, ToDoListModel>().ReverseMap();
            CreateMap<Tag, TagModel>().ReverseMap();
        }
    }
}
