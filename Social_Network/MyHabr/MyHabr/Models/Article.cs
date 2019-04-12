using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SQLite;

namespace MyHabr.Models
{
    using System;
    using System.Collections.Generic;

    namespace BLL.Domain.Models
    {
        
        public class Article
        {
            
            [PrimaryKey, AutoIncrement]
            public int Id { get; set; }

            public string ArticleText { get; set; }

            public string Description
            {
                get { return this.ArticleText.Substring(0, 3) + "..."; }
            }

            public string Headline { get; set; }

            public string Theme { get; set; }

            public DateTime CreaDateTime { get; set; }


            
        }
    }

}
