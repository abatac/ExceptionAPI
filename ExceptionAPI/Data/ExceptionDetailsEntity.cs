using System.ComponentModel.DataAnnotations;

namespace ExceptionAPI.Data
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

        [MaxLength(20)]
        public string ContactName { get; set; }

        public int ContactNumber { get; set; }

        [Required]
        [MaxLength(500)]
        public string Notes { get; set; }

        [Required]
        public string EventId { get; set; }
        public WasteManagementEventEntity WasteManagementEventEntity { get; set; }
    }
}
