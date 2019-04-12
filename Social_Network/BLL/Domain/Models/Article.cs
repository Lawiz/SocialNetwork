using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BLL.Domain.Models
{
    
    public class Article
    {
        [Key()]
        public int Id { get; set; }
       
        public string ArticleText { get; set; }

        public string Discription {
            get { return this.ArticleText.Substring(0, 100) + "..."; }
        }

        public string Headline { get; set; }

        public string Theme { get; set; }

        public DateTime CreaDateTime { get; set; }

        public ICollection<Tag> Tags { get; set; }

        public Article()
        {
            this.Tags = new List<Tag>();
        }
    }
}
