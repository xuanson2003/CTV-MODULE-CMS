using Microsoft.EntityFrameworkCore;
using OcdServiceMono.API.Models.Entities.SM;
using OcdServiceMono.Lib.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OcdServiceMono.API.Models.Entities.CMS
{
    [Table("CMS_Cer_Unit")]
    public class CMS_Cer_Unit 
    {
        [Column("CerId ")]
        public Guid CerId { get; set; }
        [ForeignKey("Id")]
        public CMS_Certification CMS_Certification { get; set; }

        // 
        [Column("UnitId ")]
        public Guid UnitId { get; set; }
        [ForeignKey("Id")]
        public CMS_Unit CMS_Unit { get; set; }
    }
}
