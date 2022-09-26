using System.ComponentModel.DataAnnotations;
namespace MusicWebAPI.Models
{
    public class Artist
    {
        public Artist()
        {
            Songs = new List<Song>();
        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Ім'я виконавця")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Поле не повинно бути порожнім")]
        [Display(Name = "Країна")]
        public string Country { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }

}
