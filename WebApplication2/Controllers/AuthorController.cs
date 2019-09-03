using AutoMapper;
using BusinessLayer.Author;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.App_Start;
using WebApplication2.Author;

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
            ViewBag.Authors = authorBO.GetAuthorsList();

            return View();
        }

        public ActionResult Edit(int? id)
        {
            var authorBO = DependencyResolver.Current.GetService<AuthorBO>();
            AuthorViewModel model = null;
            if (id != null)
            {
                //var authorList = authorBO.GetAuthorsListById((int)id);
                //var mappers = AutomapperConfig.CreateMapperConfig().GetMappers();
                ViewBag.Message = "Edit";
                model = mapper.Map<AuthorViewModel>(authorBO.GetAuthorsListById((int)id));
            }
            else
                ViewBag.Message = "Create";

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(AuthorViewModel model)
        {
            var authorBO = DependencyResolver.Current.GetService<AuthorBO>();
            var change = mapper.Map<AuthorBO>(model);
            change.Save();

            return RedirectToActionPermanent("Index", "Author");
        }

        public ActionResult Delete(int id)
        {
            var author = DependencyResolver.Current.GetService<AuthorBO>().GetAuthorsListById(id);
            author.Delete(id);

            return RedirectToActionPermanent("Index", "Author");
        }
    }
}