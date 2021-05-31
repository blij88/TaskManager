using System;
using System.ComponentModel.DataAnnotations;


namespace TaskManager.Data.models
{
    public class PeopleWhoCanHelp
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        [Required]
        [MaxLength(30)]
        public string ContactInfo { get; set; }
    }
}
