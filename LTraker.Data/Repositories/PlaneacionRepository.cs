using LTraker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTraker.Data.Repositories
{
    public class PlaneacionRepository : BaseRepository<Planeacion>
    {
        public PlaneacionRepository(LearningContext context) : base(context)
        {

        }
    }
}
