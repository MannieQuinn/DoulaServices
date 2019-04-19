using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoulaServices.Data
{
    public class Mother
    {
        [Key]
        public int MotherId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string MotherLocation { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public DateTime DueDate { get; set; }
        [Required]
        public bool FirstPregnancy { get; set; }
        [Required]
        public bool VagBirAftCes { get; set; }
        [Required]
        public bool BreastFeeding { get; set; }
    }
}
