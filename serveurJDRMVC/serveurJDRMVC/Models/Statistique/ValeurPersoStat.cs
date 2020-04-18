using serveurJDRMVC.Models.Personnage;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace serveurJDRMVC.Models.Statistique
{
    public class ValeurPersoStat
    {
        public int Id { get; set; }
        public virtual Stat Stat { get; set; }
        public int Valeur { get; set; }
    }
}