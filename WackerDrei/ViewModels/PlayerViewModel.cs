using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using WackerDrei.Models;

namespace WackerDrei.ViewModels
{
    public class PlayerViewModel
    {
        [Display(Name = "Vorname")]
        public string Firstname { get; set; }

        [Display(Name = "Nachname")]
        public string Lastname { get; set; }

        [Display(Name = "E-Mail")]
        public string EMail { get; set; }

        [Display(Name = "Spitzname")]
        public string Nickname { get; set; }

        [Display(Name = "Position")]
        public string Position { get; set; }

        [Display(Name = "Rückennummer")]
        public int Number { get; set; }

        [Display(Name = "Geburtstag")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

        [Display(Name = "Gewicht")]
        public float Weight { get; set; }

        [Display(Name = "Grösse")]
        public float Height { get; set; }

        [Display(Name = "Dioptre Links")]
        public string DioptreLeft { get; set; }

        [Display(Name = "Dioptre Rechts")]
        public string DioptreRight { get; set; }

        [Display(Name = "Dioptre Kommentar")]
        public string DioptreDescription { get; set; }

        [Display(Name = "Beruf")]
        public string Job { get; set; }

        [Display(Name = "Lebensmotto")]
        public string MottoOfLife { get; set; }

        [Display(Name = "Grösster Traum")]
        public string Dream { get; set; }

        [Display(Name = "Eigene Beschreibung")]
        public string OwnDescription { get; set; }

        [Display(Name = "Beschreibung durch Team")]
        public string TeamDescription { get; set; }

        [Display(Name = "Tagesnikotinmenge")]
        public string DailyNicotine { get; set; }

        [Display(Name = "Biermenge nach Training")]
        public string BeerAfterTraining { get; set; }

        [Display(Name = "Aktiv?")]
        public bool Active { get; set; }

        [Display(Name = "Passwort")]
        public string Password { get; set; }

        [Display(Name = "Verein")]
        public string Association { get; set; }

        [Display(Name = "Team")]
        public string Team { get; set; }

        [Display(Name = "Von")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime TeamFrom { get; set; }

        [Display(Name = "Bis")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime TeamTo { get; set; }

        public ICollection<CarrierViewModel> Carriers { get; set; } = new List<CarrierViewModel>();
        
        public ICollection<Injury> Injuries { get; set; }
        
        public Dioptre Dioptre { get; set; }

        public int DioptreId { get; set; }

        [Display(Name = "Hobby")]
        public string Hobbies { get; set; }
        
        [Display(Name = "Funktion(en) bei Wacker")]
        public string Functions { get; set; }
    }
}