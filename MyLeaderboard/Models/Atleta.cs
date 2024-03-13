using MyLeaderboard.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace MyLeaderboard.Models
{
    public class Atleta
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "A categoria é obrigatória.")]
        public Category Category { get; set; }

        public string? Score1 { get; set; }

        public string? Score2 { get; set; }

        public string? Score3 { get; set; }
                
    }
}
