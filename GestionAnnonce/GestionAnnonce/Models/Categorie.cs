using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GestionAnnonce.Models
{
    [Table("cat")]
    public class Categorie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "Nom de la catégorie", ShortName = "Nom", Prompt = "categorie")]
        [Required(ErrorMessage = "Nom obligatoire")]
        [StringLength(20, ErrorMessage = "{1} caractères max.")]
        [Column("name")]
        public string Nom { get; set; }
        
        [Display(Name = "Description de la catégorie")]
        [DataType(DataType.MultilineText)]
        [Required(ErrorMessage = "Description obligatoire")]
        public string Description { get; set; }

        //public ICollection<Annonce> Annonces { get; set; }
    }
}