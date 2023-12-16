namespace Domain.Resources
{
    public class Tree
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }

        public List<Tree> Children { get; set; }
    }
}
