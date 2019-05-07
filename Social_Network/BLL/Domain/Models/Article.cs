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

        public string Discription { get; set; }

        public string Headline { get; set; }

        public string Theme { get; set; }

        public DateTime CreaDateTime { get; set; }

        public List<Tag> Tags { get; set; }

        public List<ViewsStatistics> ViewsStatisticses { get; set; }
        public Article()
        {
            this.ViewsStatisticses = new List<ViewsStatistics>();
            this.Tags = new List<Tag>();
        }
    }
}
