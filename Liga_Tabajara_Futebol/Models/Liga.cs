using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Liga_Tabajara_Futebol.Models
{
    public class Liga
    {
        public int Id { get; set; }
        public bool Status { get; set; }

        public ICollection<Time> Times { get; set; }
    }
}