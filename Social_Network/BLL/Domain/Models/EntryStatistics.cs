using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BLL.Domain.Models
{
    public class EntryStatistics
    {
        [Key()]
        public int Id { get; set; }
        public DateTime EntryDate { get; set; }
    }
}
