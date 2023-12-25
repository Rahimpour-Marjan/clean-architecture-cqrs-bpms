namespace Domain
{
    public class EducationSubField
    {
        public EducationSubField()
        {
        }
        public EducationSubField(string title, int educationFieldId, DateTime modifiedDate)
        {
            Title = title;
            EducationFieldId = educationFieldId;
            ModifiedDate = modifiedDate;
            CreateDate = DateTime.Now;
        }

        public int Id { get; private set; }
        public int EducationFieldId { get; set; }
        public virtual EducationField EducationField { get; set; }
        public string Title { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime CreateDate { get; private set; }
    }
}
