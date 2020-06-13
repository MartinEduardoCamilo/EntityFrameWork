using System;
using System.Collections.Generic;
using System.Text;
using TutorialEF.Entidades;

namespace TutorialEntityFrameWork.Entidades
{
    class Grade
    {
        public int GradoId { get; set; }
        public string Name { get; set; }
        public string Selection { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
