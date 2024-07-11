using Microsoft.EntityFrameworkCore;
using OcdServiceMono.Lib.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OcdServiceMono.API.Models.Entities.CMS
{
    [Table("CMS_Cer_Content")]
    public class CMS_Cer_Content : AuditEntity
    {
        //[Key]
        //public int ContentId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string Content { get; set; }

        public int Order { get; set; }
     
        public bool Active { get; set; }

    }
}
