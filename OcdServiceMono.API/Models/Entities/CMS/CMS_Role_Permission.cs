using Microsoft.EntityFrameworkCore;
using OcdServiceMono.API.Models.Entities.SM;
using OcdServiceMono.Lib.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OcdServiceMono.API.Models.Entities.CMS
{
    [Table("CMS_Role_Permission")]
    public class CMS_Role_Permission 
    {
        [Column("RoleId ")]
        public Guid RoleId { get; set; }
        [ForeignKey("Id")]
        public SM_Role SM_Role { get; set; }

        // 
        [Column("PerId ")]
        public Guid PerId { get; set; }
        [ForeignKey("Id")]
        public SM_Permission SM_Permission { get; set; }
    }
}
