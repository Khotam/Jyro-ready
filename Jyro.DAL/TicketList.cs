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
        public List<Ticket> GetAllTickets()
        {
            return new TicketManager().GetAll();
        }

        public List<Ticket> GetBacklogTickets()
        {
            return new TicketManager().GetBackLogTickets();
        }


        public List<Ticket> Sort(ByAttribute attribute)
        {
            switch (attribute)
            {
                case ByAttribute.PriorityNumber:
                    return GetBacklogTickets().OrderBy(t => t.Priority).ToList();
                case ByAttribute.Priority:
                    return GetAllTickets().OrderBy(t => t.Priority).ToList();
                case ByAttribute.Status:
                    return GetAllTickets().OrderBy(t => t.Status).ToList();
            }

            //if we are here - something went wrong
            return null;
        }

        public List<Ticket> Search(int value)
        {
            var tickets = GetAllTickets().OrderBy(t => t.Id).ToList();
            return BinarySearch(tickets, value);
        }

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
            MessageBox.Show("No data found which has ID of " + value);
            return null;

        }

        public List<Ticket> GetTicketSprint(int developers)
        {
            List<Ticket> allSortedTickets = new TicketList().Sort(ByAttribute.PriorityNumber);
            List<Ticket> source = new List<Ticket>(); 

            var inputValue = developers;
            var allocatedPoint = 0;
            int index = 0;

            while (allocatedPoint < inputValue * 10 && index < allSortedTickets.Count)
            {
                allocatedPoint += allSortedTickets[index].Estimation;
                if (allocatedPoint <= inputValue * 10)
                {
                    source.Add(allSortedTickets[index]);
                }
                index++;

            }

            if (allocatedPoint < 9 * inputValue)
            {
                MessageBox.Show("Sprint is not fully loaded");
            }
            return source;

        }

    }
}
