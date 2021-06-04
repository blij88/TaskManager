using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TaskManager.App.Logic;

namespace TaskManager.Data.models
{
    public class Chore : LateLogic
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(500)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Start")]
        public DateTime StartDate { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Required]
        [Display(Name = "Finished")]
        public DateTime EndDate { get; set; }
        public Progress Progress { get; set; }
        public ICollection<FilePath> FilePaths { get; set; }
    }
}
