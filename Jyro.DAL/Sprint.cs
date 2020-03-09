using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jyro.DAL
{
    // Blueprint class for creating Sprint instances
    public class Sprint
    {
        // Creating private properties _name, _noOfDevelopers for encapsulation and using validation for user input as well
        private string _name;
        private int _noOfDevelopers;

        // Create SprintStatuses enumerable for easily change whenever Complete button is clicked in SprintListForm.cs
        public enum SprintStatuses 
        {
            Planned,
            Complete
        }

        public int Id { get; set; }

        // Validation for earlier created private properties _name, _noOfDevelopers
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
