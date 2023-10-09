using System.ComponentModel.DataAnnotations;

namespace TopTrump.Models
{
    public class Deck
    {
        public int DeckId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Deck Name")]
        [DataType(DataType.Text)]
        public string? DeckName { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Stat 1")]
        [DataType(DataType.Text)]
        public required string Stat1 { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Stat 2")]
        [DataType(DataType.Text)]
        public required string Stat2 { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Stat 3")]
        [DataType(DataType.Text)]
        public required string Stat3 { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Stat 4")]
        [DataType(DataType.Text)]
        public required string Stat4 { get; set; }
        public List<Card>? Cards { get; set; }
    }
}
