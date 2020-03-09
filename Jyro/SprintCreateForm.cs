using Jyro.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Jyro
{
    // Sprint create form for creating new sprints
    public partial class SprintCreateForm : Form
    {
        public SprintCreateForm()
        {
            InitializeComponent();
        }

        // Initializing Sprint property
        public Sprint Sprint { get; set; }

        // Method for creating a new sprint
        public void CreateNewSprint()
        {
            Sprint = new Sprint();
            MdiParent = MyForms.GetForm<ParentForm>();
            Show();
        }

        // Private method for grabbing user input
        private void GrabUserInput()
        {
            Sprint.Name = tbxName.Text;
            Sprint.Date = dtpDate.Value;
            Sprint.NumberOfDevelopers = Convert.ToInt32(nudDevelopers.Value); // Converting
            Sprint.Status = Sprint.SprintStatuses.Planned;
        }


        // Event handler for add button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // try / catch for showing error messages in case of error occurs
            try
            {
                // Grabbing user input
                GrabUserInput(); 
                // Assigning instance of SprintManager class to the manager variable
                var manager = new SprintManager();
                // Inserting data to the database
                manager.Create(Sprint);
                // Clearing the form and then showing data on the form
                MyForms.GetForm<SprintListForm>().LoadData();                                                            
                // Getting the last sprint
                Sprint s = manager.GetAll().Last();                              
                // Getting all the backlog tickets by given number of developers and assigning to source List
                List<Ticket> source = new TicketList().GetSortedBacklogTickets((int)nudDevelopers.Value);
                // Iterating over the source List with foreach
                foreach (var ticket in source)
                {
                    // Creating new instance of TicketManager and calling SetTicketStatusAndSprint for updating tickets status and sprint ID
                    new TicketManager().SetTicketStatusAndSprint(ticket, s.Id);
                }

                MyForms.GetForm<TicketListForm>().LoadData();
                // Refreshing the TicketListForm 
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Event handler for click button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Event handler for Form Load
        // When form loads all data will be firstly cleared and DataGridView shows the latest data 
        private void SprintCreateForm_Load(object sender, EventArgs e)
        {
            dgv.DataMember = "";
            dgv.DataSource = null;
            // Sorting tickets by Status
            dgv.DataSource = new TicketList().Sort(ByAttribute.PriorityNumber);
        }

        // Event handler for numericUpDown value change
        private void nudDevelopers_ValueChanged(object sender, EventArgs e)
        {
            dgv.DataMember = "";
            dgv.DataSource = null;
            // Whenever nud is changed GetSortedBacklogTickets will be called
            dgv.DataSource = new TicketList().GetSortedBacklogTickets((int)nudDevelopers.Value);
        }
    }
}
