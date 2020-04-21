using serveurJDRMVC.Models.Objet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace serveurJDRMVC.Models.Effets
{
    public class EffetActivable
    {
        public int Id { get; set; }
        public virtual Effet Effet { get; set; }
        public List<Genre> Genre { get; set; }
        public List<Materiel> Materiels { get; set; }
        public List<Qualite> Qualites { get; set; }
        public TypeActivation Activation { get; set; }



        public enum TypeActivation
        {
            Toucher = 0,
            Critique = 1,
            DebutTour = 2,
            DebutCombat = 3
        }
    }
}