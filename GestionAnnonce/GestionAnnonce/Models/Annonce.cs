using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionAnnonce.Models
{
    public class Annonce
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required(ErrorMessage = "{0} obligatoire")]
        [Display(Name ="Nom")]
        [StringLength(50)]
        public string Label { get; set; }

        [Required(ErrorMessage = "{0} obligatoire")]
        [Display(Name = "Text")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Date de création")]
        [DataType(DataType.Date)]
        public DateTime DateCreation { get; set; }

        public int Statut { get; set; }

        [Display(Name = "Catégorie")]
        public int CategorieID { get; set; }

        [ForeignKey("CategorieID")]
        public Categorie Categorie { get; set; }
    }
}