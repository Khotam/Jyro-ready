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
    public partial class TicketListForm : Form
    {
        public TicketListForm()
        {
            InitializeComponent();
        }

        // Event handler for Form Load 
        private void TicketListForm_Load(object sender, EventArgs e)
        {
            MdiParent = MyForms.GetForm<ParentForm>();
            LoadData();
        }

        // Method for clearing and showing the latest Sprints
        public void LoadData()
        {
            dgv.DataMember = "";
            dgv.DataSource = null;
            dgv.DataSource = new TicketList().GetAllTickets();
        }

        // Event handler for Refresh button
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        // Event handler for Sort button
        private void btnSort_Click(object sender, EventArgs e)
        {
            // Validation for user experience
            if (cbxSort.SelectedIndex < 0)
                MessageBox.Show("Select an attribute to sort by");
            else
            {
                // Sorting logic
                ByAttribute selectedAttribute;
                if (cbxSort.SelectedIndex == 0)
                    selectedAttribute = ByAttribute.Priority;
                else
                    selectedAttribute = ByAttribute.Status;

                dgv.DataMember = "";
                dgv.DataSource = null;
                dgv.DataSource = new TicketList().Sort(selectedAttribute);
            }

        }

        // Event handler for Search button
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Validation for user experience
            if (nudSearch.Value <= 0)
                MessageBox.Show("Must be a positive number");
            else
            {
                dgv.DataMember = "";
                dgv.DataSource = null;
                dgv.DataSource = new TicketList().Search((int)nudSearch.Value);
            }


        }

        // Event handler for add button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            new TicketEditForm().CreateNewTicket();
        }


        // Event handler for Update button
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
                MessageBox.Show("Please select a ticket");
            else
            {
                var t = (Ticket)dgv.SelectedRows[0].DataBoundItem;
                new TicketEditForm().UpdateTicket(t);
            }
        }

        // Event handler for Delete button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0)
                MessageBox.Show("Please select a ticket to delete");
            else
            {
                if (MessageBox.Show("Are you sure you want to delete?", "Delete Ticket", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var t = (Ticket)dgv.SelectedRows[0].DataBoundItem;
                    new TicketManager().Delete(t.Id);
                    LoadData();
                    MessageBox.Show("Ticket is deleted successfully!");
                }
            }
        }
    }
       
}
