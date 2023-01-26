namespace DriveHack.Site.Models
{
    [Serializable]
    public struct ViewData : IComparable
    {
        public string Name;
        public int Id;
        public int IdCount;

        public int CompareTo(object? obj)
        {
            return this.IdCount.CompareTo(((ViewData)obj).IdCount);
        }
    }
}