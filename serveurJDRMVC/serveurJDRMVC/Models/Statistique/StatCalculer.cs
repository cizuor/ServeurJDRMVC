using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace serveurJDRMVC.Models.Statistique
{
    public class StatCalculer
    {
        public int Id { get; set; }
        public virtual List<StatUtil> ListStatUtils { get; set; }
    }
}