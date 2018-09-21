using System.ComponentModel.DataAnnotations;

namespace WasteManagementAPI.Data
{
    public class ExceptionDetailsEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Type { get; set; }

        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        [Required]
        [MaxLength(500)]
        public string Notes { get; set; }

        [Required]
        public string EventId { get; set; }
        public WasteManagementEventEntity WasteManagementEventEntity { get; set; }
    }
}
