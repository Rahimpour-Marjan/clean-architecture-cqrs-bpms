namespace Domain
{
    public class EducationSubField
    {
        public EducationSubField()
        {
        }
        public EducationSubField(string title, int educationFieldId, int creatorId)
        {
            Title = title;
            EducationFieldId = educationFieldId;
            CreatorId = creatorId;
            CreateDate = DateTime.Now;
        }

        public int Id { get; private set; }
        public int EducationFieldId { get; set; }
        public virtual EducationField EducationField { get; set; }
        public string Title { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreateDate { get; private set; }
    }
}
