using System.Collections.Generic;
using TutorialEF.Entidades;

namespace TutorialEntityFrameWork.Entidades
{
    public class Grade
    {
        public int GradoId { get; set; }
        public string Name { get; set; }
        public string Selection { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
