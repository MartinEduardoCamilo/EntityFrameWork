using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TutorialEF.Entidades
{
    public class Person
    {
        [Key]
        public int pesonId { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }

        public Person()
        {
            pesonId = 0;
            name = string.Empty;
            lastName = string.Empty;
        }
    }
}
