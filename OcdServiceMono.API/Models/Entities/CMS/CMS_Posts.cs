using Microsoft.EntityFrameworkCore;
using OcdServiceMono.Lib.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OcdServiceMono.API.Models.Entities.CMS
{
    [Table("CMS_Post")]
    public class CMS_Posts :AuditEntity
    {
        //[Key]
        //public Guid PostId { get; set; }

        [StringLength(255)]
        [Comment("Tiêu đề")]
        public string Title { get; set; }

        [StringLength(500)]
        [Comment("Mô tả ngắn")]
        public string Desc { get; set; }

        [StringLength(500)]
        [Comment("Nội dung")]
        public string Content { get; set; }

        [Comment("Lượt xem")]
        public int View { get; set; }

        [Comment("Là tin nổi bật")]
        public bool IsHot { get; set; }

        [Comment("Nguồn của bài viết")]
        public string Source { get; set; }

        [Comment("Tình trạng của bài viết (true: Hoạt động, false: Không hoạt động)")]
        public bool IsActive { get; set; }

        [Comment("Đường dẫn ảnh đại diện")]
        [StringLength(255)]
        public string Avatar { get; set; }

        [Comment("Trạng thái của tin bài (da_duyet: Đã duyệt, chua_duyet: Chưa duyệt, ...)")]
        [StringLength(255)]
        public string Status { get; set; }
    }
}
