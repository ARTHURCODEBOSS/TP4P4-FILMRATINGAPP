using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmRatingsApp.Models
{
    public class Utilisateur
    {
        
        public int UtilisateurId { get; set; }

        public string? Nom { get; set; }

        public string? Prenom { get; set; }


        public string? Mobile { get; set; }

        public string Mail { get; set; } = null!;

        public string Pwd { get; set; } = null!;

        public string? Rue { get; set; }


        public string? CodePostal { get; set; }

        public string? Ville { get; set; }

        public string? Pays { get; set; } = "France";

        public float? Latitude { get; set; }

        public float? Longitude { get; set; }

        public DateTime DateCreation { get; set; } = DateTime.Now;

        public ICollection<Notation> NotesUtilisateur { get; set; } = new List<Notation>();
    }
}
