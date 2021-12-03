using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Wallme_Web_API.Data.Repositories.IRepositories;
using Wallme_Web_API.Models;

namespace Wallme_Web_API.Data.Repositories
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(Wallme_DbContext context):base(context)
        {

        }
    }
}
