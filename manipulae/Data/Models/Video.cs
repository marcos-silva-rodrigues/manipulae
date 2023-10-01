using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace manipulae.Data.Models
{
    [Table("videos")]
    public class Video
    {

        [Key]
        [Required]
        public string Id { get; set; }

        [MaxLength(200)]
        [Required]
        public string Title { get; set; }

        [MaxLength(400)]
        [Required]
        public string Description { get; set; }

        [MaxLength(100)]
        [Required]
        public string Autor { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }
    }
}
