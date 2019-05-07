using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BLL.Domain.Models
{
    public class ViewsStatistics
    {
        [Key()]
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
