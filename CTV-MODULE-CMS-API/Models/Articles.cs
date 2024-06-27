
namespace CTV_MODULE_CMS_API.Models
{
    public class Articles
    {
        private int Id { get; set; }
        private string URLAvatar { get; set; }  // avatar
        private string Title { get; set; }  // tieu de
        private string Content { get; set; }  // noi dung
        private bool IsHighlighted { get; set; } // noi bat
        private DateTime dateTime { get; set; }  // ngay dang
        private int LuotXem {  get; set; } // luot xem

        public Articles() {
            this.Id = this.LuotXem = 0;
            this.Title = this.Content = this.URLAvatar = "";
            this.IsHighlighted = false;
            this.dateTime = DateTime.Now;
        }

        public Articles(int id, string avt, string title, string content, bool highlight, DateTime tgian, int view) { 
            this.Id = id;
            this.URLAvatar = avt;
            this.Title = title;
            this.Content = content;
            this.IsHighlighted = highlight;
            this.dateTime = tgian;
            this.LuotXem = view;
        }

        public void setID(int id) { this.Id = id; }
        public int getId() { return this.Id; }
        public void setURLAvatar(string url) {  this.URLAvatar = url; }
        public string getURLAvatar() { return this.URLAvatar; }
        public void setTitle(string title) { this.Title = title; }
        public string getTitle() { return this.Title; }
        public void setContent(string content) { this.Content = content; }
        public string getContent() { return this.Content; }
        public void setHighlight(bool highlight) { this.IsHighlighted = highlight; }
        public bool getHighlighted() { return this.IsHighlighted; }
        public void setNgayDang(DateTime dateTime) { this.dateTime = dateTime; }
        public DateTime getNgayDang() { return this.dateTime; }
        public void setLuotXem(int luotXem) { this.LuotXem =  luotXem; }
        public int getLuotXem() { return this.LuotXem; }

    }
}


