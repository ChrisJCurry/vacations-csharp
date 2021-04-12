using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Vacation
    {
        public int Id { get; set; }

        [Required]
        public decimal Cost { get; set; }
        [Required]
        public int LengthInDays { get; set; }
        [Required]
        public string Location { get; set; }
    }
}