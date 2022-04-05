using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspcore.Models
{
    public class Ticket
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name ="Company Name")]
        public string Title { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public string CableType { get; set; }
        public string TestType { get; set; }
        public string CoresNumbers { get; set; }
        public string CableLength { get; set; }
        public string Wavelength { get; set; }


       
        public string Note { get; set; }
        public bool IsOpein { get; set; }

        public string userId { get; set; }
        public DateTime LastUpdate { get; set; }
        public DateTime CreateDate { get; set; }
        [NotMapped]
        public List<Comment> Comments { get; set; }


    }
   public enum TestType
    {
        SingleCore,
        MultiCore
    }
}
