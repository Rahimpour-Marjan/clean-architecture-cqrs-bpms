using Application.EducationFieldApplication.Models;

namespace Application.EducationSubFieldApplication.Models
{
    public class EducationSubFieldInfo
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public EducationFieldInfo EducationField { get; private set; }
    }
}
