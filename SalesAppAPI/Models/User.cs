using System.ComponentModel.DataAnnotations;

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
        public string Password { get; set; }
        [Required]
        public String Email { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime? UpdateAt { get; set; }      

        public Gender? Gender { get; set; }
       
    }




   public enum Gender
    {
        male,
        female
    }




}