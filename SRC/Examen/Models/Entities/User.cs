using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Examen.Models.Entities
{
    public class User
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Url { get; set; }

        public string Date { get; set; }
    }
}