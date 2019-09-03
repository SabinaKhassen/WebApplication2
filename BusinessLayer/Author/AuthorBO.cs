using AutoMapper;
using DataLayer;
using DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace BusinessLayer.Author
{
   public class AuthorBO : BusinessObjectBase
    {
        private readonly IUnityContainer unityContainer;

        public int? Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public AuthorBO(IMapper mapper, UnitOfWorkFactory unitOfWorkFactory, IUnityContainer unityContainer)
            :base(mapper, unitOfWorkFactory)
        {
            this.unityContainer = unityContainer;
        }

        public List<AuthorBO> GetAuthorsList()
        {
            List<AuthorBO> authors = new List<AuthorBO>();

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                authors = unitOfWork.AuthorUowRepository.GetAll().Select(item => mapper.Map<AuthorBO>(item)).ToList();
            }
            return authors;
        }

        public AuthorBO GetAuthorsListById(int id)
        {
            AuthorBO author;

            using (var unitOfWork = unitOfWorkFactory.Create())
            {
               author = unitOfWork.AuthorUowRepository.GetAll().Where(a => a.Id == id).Select(item => mapper.Map<AuthorBO>(item)).FirstOrDefault();
            }
            return author;
        }

        public void Save()
        {
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                if (Id != 0)
                    Update(unitOfWork);
                else
                    Add(unitOfWork);
                unitOfWork.Save();
            }
        }

        public void Delete(int id)
        {
            using (var unitOfWork = unitOfWorkFactory.Create())
            {
                unitOfWork.AuthorUowRepository.Delete(id);
                unitOfWork.Save();
            }
        }

        void Add(IUnitOfWork unitOfWork)
        {
            var author = mapper.Map<Authors>(this);
            unitOfWork.AuthorUowRepository.Add(author);
        }

        void Update(IUnitOfWork unitOfWork)
        {
            var author = mapper.Map<Authors>(this);
            unitOfWork.AuthorUowRepository.Update(author);
        }
    }
}
