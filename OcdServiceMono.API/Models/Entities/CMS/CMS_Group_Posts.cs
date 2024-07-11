using OcdServiceMono.Lib.Models;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace OcdServiceMono.API.Models.Entities.CMS
{
    [Table("CMS_Group_Posts")]
    public class CMS_Group_Posts 
    {
        [Column("PostId")]
        public Guid PostId { get; set; }
        [ForeignKey("Id")]
        public CMS_Posts CMS_Post { get; set; }

        [Column("GroupId")]
        public Guid GroupId { get; set; }
        [ForeignKey("Id")]
        public CMS_Group_News CMS_Group_News { get; set; }
        

    }
}
