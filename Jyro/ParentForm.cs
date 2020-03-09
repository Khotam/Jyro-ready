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
    public partial class ParentForm : Form
    {
        public ParentForm()
        {
            InitializeComponent();
        }

        // Event handler for exiting application
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you really want to close appllication?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Event handler for showing About form
        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        // Event handler for showing All tickets form
        private void allTicketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyForms.GetForm<TicketListForm>().Show();
        }


        // Event handler for showing Sprint create form
        private void newSprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SprintCreateForm().CreateNewSprint();
        }

        // Event handler for showing All sprints form
        private void allSprintsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyForms.GetForm<SprintListForm>().Show();
        }

        // Event handler for showing Tikcet create form
        private void newTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TicketEditForm().CreateNewTicket();
        }
    }
}
