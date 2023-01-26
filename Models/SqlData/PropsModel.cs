namespace DriveHack.Site.Models
{
    public class PropsModel
    {
        public int id { get; set; } = 0;
        public int startId { get; set; } = 0;
        public string link { get; set; } = "";
        public DateTime publishTime { get; set; } = DateTime.Now;
    }
}