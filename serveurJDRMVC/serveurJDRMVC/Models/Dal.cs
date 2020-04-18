using serveurJDRMVC.Models.Effets;
using serveurJDRMVC.Models.Personnage;
using serveurJDRMVC.Models.Statistique;
using serveurJDRMVC.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace serveurJDRMVC.Models
{
    public class Dal
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public List<StatUtil> GetAllStatUtil()
        {
            List<Stat> lStat = db.Stats.ToList();
            List<StatUtil> statUtils = new List<StatUtil>();
            foreach(Stat s in lStat)
            {
                if (s.StatCalculer != null && s.StatCalculer.ListStatUtils != null)
                {
                    statUtils.AddRange(s.StatCalculer.ListStatUtils);
                }
            }
            return statUtils;
        }
        public List<StatCalculer> GetAllStatCalculer()
        {
            List<Stat> stats = GetAllStat();
            List<StatCalculer> retour = new List<StatCalculer>();

            foreach(Stat st in stats)
            {
                if(st.StatCalculer != null)
                {
                    retour.Add(st.StatCalculer);
                }
            }
            return retour;

        }

        public List<Race> GetAllRace()
        {
            return db.Races.ToList();
        }
        public List<Classe> GetAllClasse()
        {
            return db.Classes.ToList();
        }
        public List<User> GetAllUser()
        {
            return db.Users.ToList();
        }
        public List<SousRace> GetAllSousRace()
        {
            return db.SousRaces.ToList();
        }
        public List<Stat> GetAllStat()
        {
            return db.Stats.ToList();
        }

        public User GetUserById(String idUser)
        {
            return db.Users.FirstOrDefault(u => u.IdAppUtilisateur == idUser);
        }
        public User GetUserById(int idUser)
        {
            return db.Users.FirstOrDefault(u => u.Id == idUser);
        }
        public List<Perso> GetPersoFromUser(int idUser)
        {
            return GetUserById(idUser).Persos.ToList();
        }
        public List<Perso> GetPersoFromUser(String idUser)
        {
            return GetUserById(idUser).Persos.ToList();
        }
        public Race GetRaceById(int idRace)
        {
            return db.Races.FirstOrDefault(r => r.Id == idRace);
        }
        public SousRace GetSousRaceById(int idSousRace)
        {
            return db.SousRaces.FirstOrDefault(r => r.Id == idSousRace);
        }
        public List<SousRace> GetSousRacesFromRace(int idRace)
        {
            return GetRaceById(idRace).ListSousRace.ToList();
        }
        public Classe GetClasseById(int idClasse)
        {
            return db.Classes.FirstOrDefault(c => c.Id == idClasse);
        }




        public void AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }
        public void AddRace(Race race)
        {
            foreach (ValeurRaceStat s in race.Stat)
            {
                s.Stat = GetAllStat().FirstOrDefault(sta => sta.Id == s.Stat.Id);
                db.Entry(s.Stat).State = EntityState.Modified;
            }
            foreach (DeeStat d in race.StatDee)
            {
                d.Stat = GetAllStat().FirstOrDefault(sta => sta.Id == d.Stat.Id);
                db.Entry(d.Stat).State = EntityState.Modified;
            }
            db.Races.Add(race);
            db.SaveChanges();
        }
        public void AddClasse(Classe classe)
        {
            foreach (ValeurClasseStat s in classe.Stat)
            {
                s.Stat = GetAllStat().FirstOrDefault(sta => sta.Id == s.Stat.Id);
                db.Entry(s.Stat).State = EntityState.Modified;
            }
            db.Classes.Add(classe);
            db.SaveChanges();
        }
        public void AddSousRace(SousRace sousRace)
        {
            foreach(ValeurSousRaceStat s in sousRace.Stat)
            {
                s.Stat = GetAllStat().FirstOrDefault(sta => sta.Id == s.Stat.Id);
                db.Entry(s.Stat).State = EntityState.Modified;
            }
            db.SousRaces.Add(sousRace);
            db.SaveChanges();
        }
        public void AddStat(Stat stat)
        {
            db.Stats.Add(stat);
            db.SaveChanges();
        }
        public void AddPersoToUser(int idUser,Perso perso)
        {
            GetUserById(idUser).Persos.Add(perso);
            db.SaveChanges();
        }

        public void AddPersoCreatToUser(int idUser, PersoViewModel perso)
        {
            User u = GetUserById(idUser);
            if(u.PersoEnCreation != null)
            {
                db.Entry(u.PersoEnCreation.Race).State = EntityState.Modified;
                db.Entry(u.PersoEnCreation.Classe).State = EntityState.Modified;
                u.PersoEnCreation = null;
               
            }
            u.PersoEnCreation = perso ;
            db.Entry(u).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void AddStatUtil(StatUtil Util, Stat StatUtile, Stat StatCible)
        {
            Util.StatUtile = StatUtile;
            db.Entry(StatCible).State = EntityState.Modified;
            if (StatCible.StatCalculer == null)
            {
                StatCible.StatCalculer = new StatCalculer { ListStatUtils = new List<StatUtil>() };
            }

            StatCible.StatCalculer.ListStatUtils.Add(Util);
            db.SaveChanges();
        }

        public void UpdateSousRace(SousRace sr, Race race)
        {
            db.Entry(sr).State = EntityState.Modified;
            db.SaveChanges();
            /*if (race.ListSousRace == null)
            {
                race.ListSousRace = new List<SousRace>();
            }
            SousRace sousRace = GetSousRaceById(sr.Id);
            GetSousRaceStats(sousRace);
            for (int i = 0; i< sousRace.Stat.Count(); i++)
            {
                sousRace.Stat[i].Valeur = sr.Stat[i].Valeur;
            }

            if(sousRace.listRace == null)
            {
                sousRace.listRace = new List<Race>();
            }
            List<Stat> lStat = GetAllStat();
            race.ListSousRace.Add(sousRace);
            sousRace.listRace.Add(race);
            db.SousRaces.Add(sousRace);
            db.Entry(sousRace).State = EntityState.Modified;
            db.Entry(race).State = EntityState.Modified;
            db.SaveChanges();
            int j = 2;
            for(int i = 0; i< 50; i++)
            {

            }*/



        }

        public void DeleteSousRace(SousRace sousRace)
        {
            List<Race> oldRaces = sousRace.listRace;
            foreach(Race r in oldRaces)
            {
                r.ListSousRace.Remove(sousRace);
            }
            db.SousRaces.Remove(sousRace);
            db.SaveChanges();
        }


        public void AddEffet(Effet effet)
        {
            db.Entry(effet.StatAffecter).State = EntityState.Modified;
            db.Entry(effet.StatUtil).State = EntityState.Modified;
            db.Entry(effet.StatResist).State = EntityState.Modified;
            db.Entry(effet.StatReduc).State = EntityState.Modified;

            db.Effets.Add(effet);
            db.SaveChanges();
        }



        public void MajEffet(Effet effet)
        {
            db.Entry(effet.StatAffecter).State = EntityState.Modified;
            db.Entry(effet.StatUtil).State = EntityState.Modified;
            db.Entry(effet.StatResist).State = EntityState.Modified;
            db.Entry(effet.StatReduc).State = EntityState.Modified;

            db.Entry(effet).State = EntityState.Modified;
            db.SaveChanges();
        }







        public void SaveJson()
        {

            /*List<Race> races = GetAllRace();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string jsonData = js.Serialize(races);
            List<Stat> statsrecup = js.Deserialize<List<Stat>>(jsonData);*/

            /*List<Stat> stats = GetAllStat();
            StatCalculer oldStatcalculer = null;
            StatCalculer tmp;

            foreach (Stat s in stats)
            {
                tmp = s.StatCalculer;

                if (s.Id >= 50)
                {
                    s.StatCalculer = oldStatcalculer;
                    oldStatcalculer = tmp;
                    db.Entry(s).State = EntityState.Modified;
                    db.SaveChanges();
                }
            }*/

            /*List<Stat> stats = GetAllStat();
            JavaScriptSerializer js = new JavaScriptSerializer();
            string jsonData = js.Serialize(stats);
            List<Stat> statsrecup = js.Deserialize<List<Stat>>(jsonData);

            List<StatUtil> statUtils = GetAllStatUtil();
            jsonData = js.Serialize(statUtils);
            List<StatUtil> statsUtilrecup = js.Deserialize<List<StatUtil>>(jsonData);

            List<StatCalculer> statCalculers = GetAllStatCalculer();
            jsonData = js.Serialize(statUtils);
            List<StatCalculer> statCalculer = js.Deserialize<List<StatCalculer>>(jsonData);*/

        }



        public void MajRace(Race race)
        {
            foreach (ValeurRaceStat s in race.Stat)
            {
                s.Stat = GetAllStat().FirstOrDefault(sta => sta.Id == s.Stat.Id);
                db.Entry(s.Stat).State = EntityState.Modified;
                db.Entry(s).State = EntityState.Modified;
            }
            foreach (DeeStat d in race.StatDee)
            {
                d.Stat = GetAllStat().FirstOrDefault(sta => sta.Id == d.Stat.Id);
                db.Entry(d.Stat).State = EntityState.Modified;
                db.Entry(d).State = EntityState.Modified;
            }
            db.Entry(race).State = EntityState.Modified;
            db.SaveChanges();
        }



        public void MajClasse(Classe classe)
        {
            foreach (ValeurClasseStat s in classe.Stat)
            {
                s.Stat = GetAllStat().FirstOrDefault(sta => sta.Id == s.Stat.Id);
                db.Entry(s.Stat).State = EntityState.Modified;
                db.Entry(s).State = EntityState.Modified;
            }
            db.Entry(classe).State = EntityState.Modified;
            db.SaveChanges();
        }


        public void DeleteRace(int idRace)
        {
            Race race = db.Races.Find(idRace);
            foreach (ValeurRaceStat valeur in race.Stat)
            {
                db.Entry(valeur).State = EntityState.Modified;
            }
            race.Stat = null;
            foreach (DeeStat valeur in race.StatDee)
            {
                db.Entry(valeur).State = EntityState.Modified;
            }
            race.StatDee = null;
            
            
            db.Entry(race).State = EntityState.Modified;
            db.Races.Remove(race);
            db.SaveChanges();
        }


        public void DeleteClasse(int idClasse)
        {
            Classe classe = db.Classes.Find(idClasse);
            foreach (ValeurClasseStat valeur in classe.Stat)
            {
                db.Entry(valeur).State = EntityState.Modified;
            }
            classe.Stat = null;

            db.Entry(classe).State = EntityState.Modified;
            db.Classes.Remove(classe);
            db.SaveChanges();
        }

        public void MajSousRace(SousRace sousRace)
        {
            foreach (ValeurSousRaceStat s in sousRace.Stat)
            {
                s.Stat = GetAllStat().FirstOrDefault(sta => sta.Id == s.Stat.Id);
                db.Entry(s.Stat).State = EntityState.Modified;
                db.Entry(s).State = EntityState.Modified;
            }
            db.Entry(sousRace).State = EntityState.Modified;
            db.SaveChanges();
        }


        public void Dispose()
        {
            db.Dispose();
        }
    }
}