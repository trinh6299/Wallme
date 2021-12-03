using System;

namespace Wallme_Web_API.Models
{
    public interface IBaseModel
    {
        public DateTime CreatedOn { get; set; }

        public DateTime UpdatedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}