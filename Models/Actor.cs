using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using V3_Movie_MVC_RepoPattern_Ef_CodeFirst_Identity.Validators;

namespace V3_Movie_MVC_RepoPattern_Ef_CodeFirst_Identity.Models
{
    public class Actor
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Date Of Birth")]
        [DateValidator]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public Gender Gender { get; set; }
        public Movie Movie { get; set; }
    }
}