using AutoMapper;
using BusinessLayer.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class AuthorController : Controller
    {
        protected IMapper mapper;
        #region before adding GenericRepository
        //private AuthorRepository authorRepository;

        //public AuthorController()
        //{
        //    authorRepository = new AuthorRepository(new Model1());
        //}
        //public ActionResult Index()
        //{
        //    var model = authorRepository.GetAll();
        //    return View(model);
        //}
        #endregion

        #region Generic Repository
        //private IRepository<Authors> authorRepository;

        //public AuthorController()
        //{
        //    authorRepository = new Repository<Authors>();
        //}
        //public ActionResult Index()
        //{
        //    var model = authorRepository.GetAll();
        //    return View(model);
        //}
        #endregion

        public AuthorController(IMapper mapper)
        {
            this.mapper = mapper;
        }
        public ActionResult Index()
        {
            var authorBO = DependencyResolver.Current.GetService<AuthorBO>();
            var authorList = authorBO.GetAuthorsList();

            return View(/*model*/);
        }
    }
}