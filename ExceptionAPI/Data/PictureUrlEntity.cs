using System.ComponentModel.DataAnnotations;

namespace ExceptionAPI.Data
{
    public class PictureUrlEntity
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Url { get; set; }

        public int ExceptionId { get; set; }
        public ExceptionEntity ExceptionEntity { get; set; }
    }
}
