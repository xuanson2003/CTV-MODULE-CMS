using Microsoft.EntityFrameworkCore;
using OcdServiceMono.API.Models.Entities.SM;
using OcdServiceMono.Lib.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OcdServiceMono.API.Models.Entities.CMS
{
    [Table("CMS_Certification")]
    public class CMS_Certification : AuditEntity
    {
        //[Key]
        //public int CerId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }


        public DateTime ExpDate { get; set; }

        public DateTime ReleaseDate { get; set; }

        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        [MaxLength(50)]
        public string Unit { get; set; }

        [MaxLength(50)]
        public string Category { get; set; }

        [MaxLength(255)]
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; }

        [MaxLength(50)]
        public string CreateBy { get; set; }
        //khóa ngoại

        //public int ContentId { get; set; }
        [Column("ContentId ")]
        public Guid ContentId { get; set; }
        [ForeignKey("Id")]
        public CMS_Cer_Content CMS_Cer_Content { get; set; }

        //public int MenuId { get; set; }
        [Column("MenuId ")]
        public Guid MenuId { get; set; }
        [ForeignKey("Id")]
        public SM_Menu SM_Menu { get; set; }

        //public int AccId { get; set; }

        [Column("AccId ")]
        public Guid AccId { get; set; }
        [ForeignKey("Id")]
        public SM_Accounts SM_Accounts { get; set; }
    }
}
