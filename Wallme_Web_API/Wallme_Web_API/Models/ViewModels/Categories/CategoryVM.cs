using System;

namespace Wallme_Web_API.Models.ViewModels.Categories
{
    public class CategoryVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}