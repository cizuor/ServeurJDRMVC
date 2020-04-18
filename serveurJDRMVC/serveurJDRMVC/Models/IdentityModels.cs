using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using serveurJDRMVC.Models.Effets;
using serveurJDRMVC.Models.Personnage;
using serveurJDRMVC.Models.Statistique;

namespace serveurJDRMVC.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant d'autres propriétés à votre classe ApplicationUser. Pour en savoir plus, consultez https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<SousRace> SousRaces { get; set; }
        public DbSet<Classe> Classes { get; set; }
        public DbSet<Stat> Stats { get; set; }
        public DbSet<Effet> Effets { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<serveurJDRMVC.Models.Statistique.ValeurRaceStat> ValeurRaceStats { get; set; }

        public System.Data.Entity.DbSet<serveurJDRMVC.Models.Statistique.ValeurClasseStat> ValeurClasseStats { get; set; }

        public System.Data.Entity.DbSet<serveurJDRMVC.Models.Statistique.ValeurPersoStat> ValeurPersoStats { get; set; }

        public System.Data.Entity.DbSet<serveurJDRMVC.Models.Statistique.DeeStat> DeeStats { get; set; }

        public System.Data.Entity.DbSet<serveurJDRMVC.Models.Personnage.Perso> Persoes { get; set; }
    }
}