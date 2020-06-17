using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.Models.Entities
{
    public class Products
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int Existence { get; set; }
    }
}