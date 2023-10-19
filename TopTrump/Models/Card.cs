using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TopTrump.Models
{
    public class Card
    {
        public int CardId { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Card Name")]
        [DataType(DataType.Text)]
        public required string CardName { get; set; }

        [Required]
        [Display(Name = "Stat 1")]
        public required int Stat1 { get; set; }

        [Required]
        [Display(Name = "Stat 2")]
        public required int Stat2 { get; set; }

        [Required]
        [Display(Name = "Stat 3")]
        public required int Stat3 { get; set; }

        [Required]
        [Display(Name = "Stat 4")]
        public required int Stat4 { get; set; }
        [ForeignKey("Deck")]
        public int DeckId { get; set; }
        public Deck? Deck { get; set; }

        [MaxLength(255)]
        [Display(Name = "Image")]
        [DataType(DataType.Text)]
        public string? Image { get; set; }

        [MaxLength(255)]
        [Display(Name = "Description")]
        [DataType(DataType.Text)]
        public string? Description { get; set; }
        public int GetStatValue(string statName)
        {
            switch (statName)
            {
                case "Stat1":
                    return Stat1;
                case "Stat2":
                    return Stat2;
                case "Stat3":
                    return Stat3;
                case "Stat4":
                    return Stat4;
                default:
                    throw new ArgumentException("Invalid stat name");
            }
        }
    }
}
