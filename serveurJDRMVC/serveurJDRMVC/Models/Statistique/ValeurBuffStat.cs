using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace serveurJDRMVC.Models.Statistique
{
    public class ValeurBuffStat
    {
        public int Id { get; set; }
        public virtual Stat Stat { get; set; }
        public int Valeur { get; set; }
    }
}