namespace Domain
{
    public class EducationField
    {
        protected EducationField()
        {
        }

        public EducationField(string title, DateTime modifiedDate)
        {
            Title = title;
            ModifiedDate = modifiedDate;
            CreateDate = DateTime.Now;
        }

        public int Id { get; private set; }
        public string Title { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreateDate { get; private set; }

        public virtual ICollection<EducationSubField> EducationSubFields { get; set; }
    }
}
