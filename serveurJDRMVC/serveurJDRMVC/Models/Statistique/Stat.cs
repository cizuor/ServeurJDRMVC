﻿using serveurJDRMVC.Models.Personnage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace serveurJDRMVC.Models.Statistique
{
    public class Stat
    {
        public int Id { get; set; }
        public String Nom { get; set; }
        public String Definition { get; set; }
        public stats Stats { get; set; }
        public Typestats Type { get; set; }
        public virtual StatCalculer StatCalculer { get; set; }


        public override string ToString()
        {
            return Nom;
        }

        public enum Typestats
        {
            Base = 0,
            Secondaire = 1,
            Calculé = 2
        }

        public enum stats
        {
            CC = 0,
            CT = 1,
            Ag = 2,
            F = 3,
            E = 4,
            Int = 5,
            Fm = 6,
            P = 7,
            Soc = 8,
            PV = 9,
            PVManquand = 10,
            PVBonus = 11,
            Acrobatie = 12,
            Apnee = 13,
            Crochetage = 14,
            ChanceCrit = 15,
            Charisme = 16,
            DeplacementSilentieux = 17,
            Dissimulation = 18,
            Encaissement = 19,
            Equitation = 20,
            Escalade = 21,
            Fuite = 22,
            Initiative = 23,
            Marchandage = 24,
            Menace = 25,
            Mensonge = 26,
            Mouvement = 27,
            Natation = 28,
            Navigation = 29,
            Noeud = 30,
            PAuditive = 31,
            POlfactive = 32,
            PVisuel = 33,
            PerceptionMagique = 34,
            PetForce = 35,
            PetEndu = 36,
            PetChanceCrit = 37,
            PetAg = 38,
            PetToucher = 39,
            PetVie = 40,
            PetDegatsCrit = 41,
            NBPetL = 42,
            NBPetM = 43,
            NBPetS = 44,
            Pistage = 45,
            PointDestin = 46,
            PS = 47,
            RatioXp = 48,
            ResistanceEcho = 49,
            ResistanceAlcool = 50,
            EsquiveCac = 51,
            EsquiveDist = 52,
            ResistanceMaladie = 53,
            ReussiteSort = 54,
            Torture = 55,
            VolALaTir = 56,
            Maitrise = 57,
            NBMains = 58,
            VisionNocturne = 59,
            Regen = 60,
            RegenNuit = 61,
            Cartographe = 62,
            Herboristerie = 63,
            Alchimie = 64,
            Parade = 65,
            Riposte = 66,
            NbMaxRiposte = 67,
            ResistanceMutation = 68,
            Armure = 69,
            RM = 70,
            ResistContondant = 71,
            ResistPerforant = 72,
            ResistTranchant = 73,
            ResistFeu = 74,
            ResistFroid = 75,
            ResistFoudre = 76,
            ResistChaos = 77,
            ResistPoison = 78,
            ResistMaladie = 79,
            ResistSaignement = 80,
            ResistSacré = 81,
            ResistOmbre = 82,
            ResistEsprit = 83,
            Degatbonus = 84,
            DegatContondant = 85,
            DegatPerforant = 86,
            DegatTranchant = 87,
            DegatFeu = 88,
            DegatFroid = 89,
            DegatFoudre = 90,
            DegatChaos = 91,
            DegatPoison = 92,
            DegatMaladie = 93,
            DegatSaignement = 94,
            DegatSacré = 95,
            DegatOmbre = 96,
            DegatEsprit = 97,
            DegatCrit = 98,
            DegatDos = 99,

        }
    }
}