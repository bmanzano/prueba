using LTraker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTraker.Data.Repositories
{

    public class AssignedCourseRepository : BaseRepository<AssignedCourse>
    {
        public AssignedCourseRepository(LearningContext context) : base(context)
        {

        }
        public void InsertAssignedPlaneacionRepository(AssignedCourse assignedcourse)
        {
            Planeacion planeacion = new Planeacion();
            _context.AssignedCourses.Add(assignedcourse);
            _context.SaveChanges();
            planeacion.AssignedCourseId = assignedcourse.Id;
            _context.Planeacion.Add(planeacion);
        }
    }

}
