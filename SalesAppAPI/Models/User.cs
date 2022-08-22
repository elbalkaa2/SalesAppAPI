using System.ComponentModel.DataAnnotations;
using static SalesAppAPI.Enums.Enums;

namespace SalesAppAPI.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]    
        public string UserName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [MaxLength(50)]
        public String Email { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }      

        public Gender? Gender { get; set; }
       
    }







}