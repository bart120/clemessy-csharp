using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GestionAnnonce.Models
{
    public class Categorie
    {
        [Display(Name = "Nom de la catégorie", ShortName = "Nom", Prompt = "categorie")]
        [Required(ErrorMessage = "Nom obligatoire")]
        [StringLength(20, ErrorMessage = "{1} caractères max.")]
        public string Nom { get; set; }
        
        [Display(Name = "Description de la catégorie")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Description obligatoire")]
        public string Description { get; set; }
    }
}