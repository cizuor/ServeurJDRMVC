using serveurJDRMVC.Models.Outil;
using serveurJDRMVC.Models.Statistique;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace serveurJDRMVC.Models.Personnage
{
    public class Race
    {
        public int Id { get; set; }
        public String Nom { get; set; }
        public String Definition { get; set; }
        public virtual List<ValeurRaceStat> Stat { get; set; }
        public virtual List<DeeStat> StatDee { get; set; }
        public virtual List<SousRace> ListSousRace { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Race race &&
                   Id == race.Id;
        }
    }
}