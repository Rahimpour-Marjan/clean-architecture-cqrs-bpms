namespace Domain.Resources
{
    public class Menu
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Key { get; set; }
        public bool IsPage { get; set; }

        public List<Menu> Children { get; set; }
    }
}
