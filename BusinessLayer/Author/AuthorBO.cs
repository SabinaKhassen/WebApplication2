using AutoMapper;
using DataLayer.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace BusinessLayer.Author
{
   public class AuthorBO : BusinessObjectBase
    {
        private readonly IUnityContainer unityContainer;
        public int Id { get; set; }
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
               var authorsList = unitOfWork.AuthorUowRepository.GetAll();
                mapper.Map<AuthorBO>(authorsList);
            }
                return authors;
        }
    }
}
