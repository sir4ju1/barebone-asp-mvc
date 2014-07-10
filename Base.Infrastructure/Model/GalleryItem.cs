using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Infrastructure.Model
{
    public class GalleryItem
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual GalleryItemCategory Category { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }        
        [MaxLength(25)]
        [Index(IsUnique=true)]
        public string ItemCode { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        [Required]
        public string ImagePath { get; set; }
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }


    }
}
