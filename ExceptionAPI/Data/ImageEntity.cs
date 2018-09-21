using System.ComponentModel.DataAnnotations;

namespace WasteManagementAPI.Data
{
    public class ImageEntity
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string ImageURL { get; set; }

        public string EventId { get; set; }
        public WasteManagementEventEntity WasteManagementEventEntity { get; set; }
    }
}
