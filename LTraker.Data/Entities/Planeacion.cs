using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTraker.Data.Entities
{
    public class Planeacion
    {
        public int? Id { get; set; }
        public string DateEstimatedInicio { get; set; }
        public string DateEstimatedFin { get; set; }
        public string DurationEstimated { get; set; }
        public AssignedCourse AssignedCourse { get; set; }
        public int? AssignedCourseId { get; set; }
    }
}
