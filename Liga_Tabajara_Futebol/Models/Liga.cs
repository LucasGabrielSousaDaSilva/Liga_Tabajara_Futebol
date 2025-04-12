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

        public static bool LigaEstaApta(List<Time> times)
        {
            return times.Count == 20 &&
                   times.All(time => time.Jogadores.Count >= 30 &&
                                     time.ComissaoTecnica.Count >= 5 &&
                                     time.ComissaoTecnica.Select(c => c.Cargo).Distinct().Count() >= 5);
        }

    }
}