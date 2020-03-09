using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jyro.DAL
{
    public class TicketList
    {
        // Public method for getting all the Ticket instances created by Ticket.cs
        public List<Ticket> GetAllTickets()
        {
            return new TicketManager().GetAll();
        }

        // Public method for getting all the Ticket instances with Status Backlog created by Ticket.cs for using in SprintCreatForm.cs
        public List<Ticket> GetBacklogTickets()
        {
            return new TicketManager().GetBackLogTickets();
        }

        // Sorting function using SortLinq for sorting Tickets by Priority and Status in TicketListForm.cs and for sorting Tickets by Priority in SprintCreateForm.cs
        public List<Ticket> Sort(ByAttribute attribute)
        {
            switch (attribute)
            {
                case ByAttribute.PriorityNumber:
                    return GetBacklogTickets().OrderBy(t => t.Priority).ThenBy(t => t.Id).ToList();
                case ByAttribute.Priority:
                    return GetAllTickets().OrderBy(t => t.Priority).ToList();
                case ByAttribute.Status:
                    return GetAllTickets().OrderBy(t => t.Status).ToList();
            }

            //if we are here - something went wrong
            return null;
        }

        // Method for searching Tickets by their ID in TicketListForm.cs using custom implementation of BinarySearch
        public List<Ticket> Search(int value)
        {
            var tickets = GetAllTickets().OrderBy(t => t.Id).ToList();
            return BinarySearch(tickets, value);
        }


        // Source of the code https://www.c-sharpcorner.com/blogs/binary-search-implementation-using-c-sharp1
        // Taking the all tickets and getting ID of Ticket located at the middle of the List 
        // Then if the ID we are looking for is greater than the given value we are removing left side and repeating until finding the actual Ticket
        // If the ID we are looking for is smaller than the given value we are removing right side and repeating until finding the actual Ticket
        public static List<Ticket> BinarySearch(List<Ticket> tickets, int value)
        {
            var result = new List<Ticket>();
            int min = 0;
            int max = tickets.Count - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (value == tickets[mid].Id)
                {
                    result.Add(tickets[mid]);
                    return result;
                }
                else if (value < tickets[mid].Id)
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            // In case if there is no such ID in the List
            MessageBox.Show("No data found which has ID of " + value);
            return null;

        }

        // Method for showing all available tickets according to allocated number of developers for new sprint
        public List<Ticket> GetSortedBacklogTickets(int developers)
        {
            // Getting all Tickets sorted by Priority and with Backlog status
            List<Ticket> allSortedTickets = new TicketList().Sort(ByAttribute.PriorityNumber);
            // Creating empty List type of Ticket
            List<Ticket> source = new List<Ticket>(); 


            var inputNumber = developers;
            var targetPoint = 0;
            int idx = 0;

            // Iterating over allSortedTickets List while target point is smaller than input value and index is smaller than allSortedTicket's Count
            // Adding the points to the target point and adding the instances to the source List for showing in DataGridView
            while (targetPoint < inputNumber * 10 && idx < allSortedTickets.Count)
            {
                targetPoint += allSortedTickets[idx].Estimation;
                if (targetPoint <= inputNumber * 10)
                {
                    source.Add(allSortedTickets[idx]);
                }
                idx++;

            }
            // In case of target point is 10% smaller than the input(allocated number of developers) validating the form
            if (targetPoint < 9 * inputNumber)
            {
                MessageBox.Show("Sprint is not fully loaded");
            }
            return source;

        }

    }
}
