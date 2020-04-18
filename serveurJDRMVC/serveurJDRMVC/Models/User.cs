using serveurJDRMVC.Models.Personnage;
using serveurJDRMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace serveurJDRMVC.Models
{
    public class User
    {
        public int Id { get; set; }
        public String IdAppUtilisateur { get; set; }
        public UserRole Role { get; set; }
        public virtual List<Perso> Persos { get; set; }
        public virtual PersoViewModel PersoEnCreation { get; set; }

        public User()
        {
            Role = UserRole.Joueur;
        }

        public enum UserRole
        {
            Mj = 0,
            Joueur = 1
        }
    }
}