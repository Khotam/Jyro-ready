using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jyro.DAL
{
    public class SprintList
    {
        // Method for getting all sprints from the database sp_sprint table
        public List<Sprint> GetAllSprints()
        {
            return new SprintManager().GetAll();
        }

    }
}
