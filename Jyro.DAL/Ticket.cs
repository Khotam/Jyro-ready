using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jyro.DAL
{
    // Blueprint class for creating Ticket instances
    public class Ticket
    {
        private string _summary; // Making properties private and using getter/setter to validate user input and for encapsulation
        private string _description; 
        private int _estimation; 

        public enum Priorities // Creating enumerable Priorities for sorting Tickets by Priority in TicketListForm.cs
        {
            Showstopper,
            High,
            Normal,
            Low
        }

        public enum Statuses // Creating enumerable Statuses for getting Tickets by Backlog status and changing their status in SprintCreateForm.cs
        {
            Backlog,
            Planned,
            Done
        }


        public int Id { get; set; }
        // Validation for earlier created private properties _summary, _description, _estimation
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
