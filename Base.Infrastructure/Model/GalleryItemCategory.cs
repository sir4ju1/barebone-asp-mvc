using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Infrastructure.Model
{
    public class GalleryItemCategory
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(40)]
        [Index(IsUnique = true)]
        public string Name { get; set; }
        public string Description { get; set; }
        [MaxLength(25)]
        public string CategoryCode { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
    }
}