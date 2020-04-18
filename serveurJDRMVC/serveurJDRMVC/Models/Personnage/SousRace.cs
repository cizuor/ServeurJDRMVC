using serveurJDRMVC.Models.Outil;
using serveurJDRMVC.Models.Statistique;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace serveurJDRMVC.Models.Personnage
{
    public class SousRace
    {
        public int Id { get; set; }
        public String Nom { get; set; }
        public String Definition { get; set; }
        public virtual List<ValeurSousRaceStat> Stat { get; set; }
        public virtual List<Race> listRace { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Race race &&
                   Id == race.Id;
        }

        public override string ToString()
        {
            return Nom;
        }
    }
}