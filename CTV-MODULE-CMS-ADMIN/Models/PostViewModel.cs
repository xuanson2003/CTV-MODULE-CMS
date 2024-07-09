namespace CTV_MODULE_CMS_ADMIN.Models
{
	public class PostViewModel
	{
		public int STT { get; set; }
		public Guid Id { get; set; }
		public string Title { get; set; }

		public bool IsActive { get; set; }

		public DateTime created_date_time { get; set; }

		public string Status { get; set; }
	}
}
