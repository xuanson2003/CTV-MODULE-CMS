using Microsoft.EntityFrameworkCore;
using OcdServiceMono.API.Models.Entities.SM;
using OcdServiceMono.Lib.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OcdServiceMono.API.Models.Entities.CMS
{
    [Table("CMS_Posts_Menu")]
    public class CMS_Posts_Menu 
    { 
        
        [Column("MenuId ")]
        public Guid MenuId { get; set; }
        [ForeignKey("Id")]
        public SM_Menu SM_Menu { get; set; }
        // postid

        [Column("PostId ")]
        public Guid PostId { get; set; }
        [ForeignKey("Id")]
        public CMS_Posts CMS_Posts { get; set; }
    }
}
