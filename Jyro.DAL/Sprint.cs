using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jyro.DAL
{
    public class Sprint
    {
        private string _name;
        private int _noOfDevelopers;

        public enum SprintStatuses
        {
            Planned,
            Complete
        }

        public int Id { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Name cannot be empty.");
                }
                _name = value;
            }
        }

        public DateTime Date { get; set; }

        public int NumberOfDevelopers
        {
            get => _noOfDevelopers;
            set
            {
                if (value <= 0)
                {
                    throw new Exception("Number of Developers should be at least one.");
                }
                _noOfDevelopers = value;
            }
        }

        public SprintStatuses Status { get; set; }

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}
