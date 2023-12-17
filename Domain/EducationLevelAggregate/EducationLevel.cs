namespace Domain
{
    public class EducationLevel
    {
        protected EducationLevel()
        {
        }

        public EducationLevel(string title, DateTime modifiedDate)
        {
            Title = title;
            ModifiedDate = modifiedDate;
            CreateDate = DateTime.Now;
        }

        public int Id { get; private set; }
        public string Title { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
