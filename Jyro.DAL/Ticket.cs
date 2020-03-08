using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jyro.DAL
{
    public class Ticket
    {
        private string _summary; 
        private string _description; 
        private int _estimation; 

        public enum Priorities
        {
            Showstopper,
            High,
            Normal,
            Low
        }

        public enum Statuses
        {
            Backlog,
            Planned,
            Done
        }


        public int Id { get; set; }

        public string Summary 
        {
            get => _summary;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Summary cannot be empty.");
                }
                _summary = value;
            }
        }

        public string Description 
        {
            get => _description;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new Exception("Description cannot be empty.");
                }
                _description = value;
            }
        }

        public int Estimation
        {
            get => _estimation;
            set
            {
                if (value <= 0 || value > 5)
                {
                    throw new Exception("Estimation must be between 1 and 5.");
                }
                _estimation = value;
            }
        }

        public Priorities Priority { get; set; }
        public Statuses Status { get; set; }
        public Sprint SprintId { get; set; }
    }
}
