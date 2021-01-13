using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionAnnonce.Models
{
    public class RechercheViewModel
    {
        [Display(Name = "Nom")]
        public string Label { get; set; }

        [Display(Name = "Date de début")]
        [DataType(DataType.Date)]
        public Nullable<DateTime> DateDebut { get; set; }

        [Display(Name = "Date de fin")]
        [DataType(DataType.Date)]
        public DateTime? DateFin { get; set; }
    }
}