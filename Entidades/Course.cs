using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TutorialEF.Entidades
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }

        //Aplicando relaciones 
        public int studentId { get; set; }
        [ForeignKey("studentId")]
        public IList<StudentCourse> StudentCourses { get; set; }

        public Course()
        {
            CourseId = 0;
            CourseName = string.Empty;
            studentId = 0;
        }
    }
}
