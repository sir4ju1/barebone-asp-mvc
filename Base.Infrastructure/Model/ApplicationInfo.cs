using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Base.Infrastructure.Model
{
    public class ApplicationInfo
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string ApplicationName { get; set; }
        [MaxLength(50)]
        public string CompanyName { get; set; }
        public bool IsHeaderImage { get; set; }
        public string HeaderText { get; set; }
        public string LogoPath { get; set; }
        public string HeaderBackground { get; set; }

    }
}