namespace Domain
{
    public class EducationField
    {
        protected EducationField()
        {
        }

        public EducationField(string title, int creatorId)
        {
            Title = title;
            CreatorId = creatorId;
            CreateDate = DateTime.Now;
        }

        public int Id { get; private set; }
        public string Title { get; set; }
        public int CreatorId { get; set; }
        public int? ModifireId { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreateDate { get; private set; }

        public virtual ICollection<EducationSubField> EducationSubFields { get; set; }
    }
}
