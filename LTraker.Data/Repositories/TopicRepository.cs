using LTraker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LTraker.Data.Repositories
{

    public class TopicRepository : BaseRepository<Topic>
    {
        public TopicRepository(LearningContext context) : base(context)
        {

        }
    }

}
