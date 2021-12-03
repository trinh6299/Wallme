using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wallme_Web_API.Models.ViewModels.Comments
{
    public class CommentVM
    {
        public int Id { get; set; }

        public int productId { get; set; }

        public int UserId { get; set; }

        public string Content { get; set; }
    }
}
