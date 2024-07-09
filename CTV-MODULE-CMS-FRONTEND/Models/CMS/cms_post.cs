using System.ComponentModel.DataAnnotations;

namespace CTV_MODULE_CMS_FRONTEND.Models.CMS
{
    public class cms_post
    {
		public Guid Id { get; set; }

		[StringLength(55)]
		public string CreatedBy { get; set; }

		public DateTimeOffset CreatedDateTime { get; set; }

		[StringLength(55)]
		public string UpdatedBy { get; set; }

		public DateTimeOffset? UpdatedDateTime { get; set; }
		[StringLength(255)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Desc { get; set; }

        [StringLength(500)]
        public string Content { get; set; }

        public int View { get; set; }

        public bool IsHot { get; set; }

        public int Source { get; set; }

        public bool IsActive { get; set; }

        [StringLength(255)]
        public string Avatar { get; set; }

        [StringLength(255)]
        public string Status { get; set; }
    }
}
