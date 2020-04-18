using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace serveurJDRMVC.Models.Statistique
{
    public class StatUtil
    {
        public int Id { get; set; }
        public virtual Stat StatUtile { get; set; }
        public int Valeur { get; set; }
    }
}