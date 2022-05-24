namespace Exam.Domain.Dto
{
    public class MarkDto
    {
        public int Id { get; set; }
        public double PartialMark { get; set; }
        public double ExamMark { get; set; }
        public double TotalMark { get; set; }
        public bool IsConfirmed { get; set; }
    }
}
