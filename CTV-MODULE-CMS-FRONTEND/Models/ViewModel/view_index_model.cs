using CTV_MODULE_CMS_FRONTEND.Models.CMS;

namespace CTV_MODULE_CMS_FRONTEND.Models.ViewModel
{
    public class view_index_model
    {
        public view_index_model(List<cms_post> topPosts, List<cms_post> newsPosts)
        {
            TopPosts = topPosts;
            NewsPosts = newsPosts;
        }

        public List<cms_post> TopPosts { get; set; }
        public List<cms_post> NewsPosts { get; set; }
    }
}
