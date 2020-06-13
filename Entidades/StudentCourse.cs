using System.ComponentModel.DataAnnotations;

namespace TutorialEF.Entidades
{
    public class StudentCourse
    {
        [Key]
        public int STDcourseID { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

    }
}