using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Habr.Models
{
    public class JsonResponse<T> 
    {
        public IActionResult Status { get; set; }

        public IEnumerable<T> Data { get; set; }

        public string State { get; set; }

    }
}
