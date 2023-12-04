namespace Domain.Resources
{
    public class AccessTree
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string Key { get; set; }
        public string AccessType { get; set; }
        public bool IsSelected { get; set; }
        public bool IsPage { get; set; }
        public List<AccessTree> Children { get; set; }
    }
}
