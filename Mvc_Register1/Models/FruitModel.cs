using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc_Register1.Models
{
    public class FruitModel
    {
        public List<SelectListItem> Fruits { get; set; }
        public int? FruitId { get; set; }
        public string  StudentName { get; set; }
        public bool Gender { get; set; }

    }
}