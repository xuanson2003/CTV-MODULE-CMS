using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using OcdServiceMono.Lib.Models;
using System;
using OcdServiceMono.API.Models.Entities.CMS;

namespace OcdServiceMono.API.Models.Entities.SM
{
    [Table("SM_File")]
    public class SM_File : AuditEntity
    {
        //[Key]
        //public int FileId { get; set; }

        [Required]
        [MaxLength(30)]
        public string FileName { get; set; }

      
        [MaxLength(255)]
        public string Url { get; set; }

        [MaxLength(20)]
        public string Extention { get; set; }

        [MaxLength(20)]
        public string Type { get; set; }

        [MaxLength(50)]
        public string Size { get; set; }

        public DateTime CreateAt { get; set; }

        [MaxLength(255)]
        public string CreateBy { get; set; }




        // khóa ngoai
        //public int ContentId { get; set; }
        [Column("ContentId ")]
        public Guid ContentId { get; set; }
        [ForeignKey("Id")]
        public CMS_Cer_Content CMS_Cer_Content { get; set; }
        //public int PostId { get; set; }
        [Column("PostId ")]
        public Guid PostId { get; set; }
        [ForeignKey("Id")]
        public CMS_Posts CMS_Post { get; set; }


    }
}
