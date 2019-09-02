using AutoMapper;
using BusinessLayer.Author;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Unity;
using System.Web.Mvc;

namespace WebApplication2.App_Start
{
    public static class AutomapperConfig
    {
        public static void RegisterWithUnity(IUnityContainer container)
        {
            IMapper mapper = CreateMapperConfig().CreateMapper();

            container.RegisterInstance<IMapper>(mapper);
        }

        static MapperConfiguration CreateMapperConfig()
        {
            return new MapperConfiguration(cfg =>
                cfg.CreateMap<Authors, AuthorBO>()
                .ConstructUsing(item=> DependencyResolver.Current.GetService<AuthorBO>()));
        }

    }
}