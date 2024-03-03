using System.ComponentModel.DataAnnotations;

namespace final_portfolio.Models
{
    public class Skill
    {
        [Key] 
        public int Id { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
    }
}
