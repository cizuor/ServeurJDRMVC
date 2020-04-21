using serveurJDRMVC.Models.Effets;
using serveurJDRMVC.Models.Statistique;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace serveurJDRMVC.Models.Objet
{
    public class Genre
    {
        public int Id { get; set; }
        public Equipement.typeMateriel TypeMat { get; set; }
        public int Prix{ get; set; }
        public int Poid{ get; set; }
        public String Nom { get; set; }
        public String Definition { get; set; }
        public virtual List<ValeurGenreStat> Stats { get; set; }
        public virtual List<EffetActivable> Effets { get; set; }
    }
}