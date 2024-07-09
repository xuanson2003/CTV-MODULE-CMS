namespace CTV_MODULE_CMS_ADMIN.Models
{
	public class CreatingPost
	{
		public Guid Id { get; set; }
		public string Title { get; set; }

		public string Desc { get; set; }

		public string Content { get; set; }

		public bool? IsHot { get; set; }

		public int Source { get; set; }

		public bool IsActive { get; set; }

		public IFormFile Avatar { get; set; }

		public string Status { get; set; }

	}
}