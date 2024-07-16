using Microsoft.EntityFrameworkCore;
using OcdServiceMono.Lib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OcdServiceMono.API.Models.Entities.CMS
{
    [Table("CMS_Group_News")]
    public class CMS_Group_News :AuditEntity
    {
        //[Key]
        //public int GroupId { get; set; }

        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string Url { get; set; }
      
        public string Descible { get; set; }    
        public Guid? ParentId { get; set; }

        [MaxLength(255)]
        public string CreateBy { get; set; }
     
        public DateTime CreateAt { get; set; }

        public int Order { get; set; }
        [JsonIgnore]
        public IEnumerable<CMS_Posts> TopPosts { get; set; }
       

    }
}
