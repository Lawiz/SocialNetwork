using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BLL.Domain.Models
{
    public class Tag
    {
        [Key()]
        public  int Id { get; set; }
        private ICollection<Article> Articles { get; set; }

        public string TagName { get; set; }
        public Tag()
        {
            this.Articles = new List<Article>();
        }
    }
}