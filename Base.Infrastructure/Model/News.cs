using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Infrastructure.Model
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(250)]
        public string NewsHeadline { get; set; }
        public string NewsDetails { get; set; }
        public DateTime? PublishDate {get; set;}
        public DateTime? ValidUntil { get; set; }
        public DateTime? Created { get; set; }
    }
}
