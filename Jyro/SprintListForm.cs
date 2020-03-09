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
    public partial class SprintListForm : Form
    {
        public SprintListForm()
        {
            InitializeComponent();
        }

        // Method for clearing and showing the latest Sprints
        public void LoadData()
        {
            dgvSprint.DataMember = "";
            dgvSprint.DataSource = null;
            dgvSprint.DataSource = new SprintList().GetAllSprints();
        }

        // Event handler for add button
        private void btnAdd_Click(object sender, EventArgs e)
        {
            new SprintCreateForm().CreateNewSprint();
            LoadData();
        }

        // Event handler for refresh button
        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }

        // Event handler for form load
        private void SprintListForm_Load_1(object sender, EventArgs e)
        {
            // Setting MdiParent
            MdiParent = MyForms.GetForm<ParentForm>();
            LoadData();
        }

        // Event handler for add button
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            new SprintCreateForm().CreateNewSprint();
        }

        // Event handler for complete button
        private void btnComplete_Click(object sender, EventArgs e)
        {
            // Getting the data from selected row
            var s = (Sprint)dgvSprint.SelectedRows[0].DataBoundItem;
            // Changing the status of Sprints to 'Complete' and all linked Tickets statuses to 'Done'
            new TicketManager().AlterTicketStatuses(s.Id);
            new SprintManager().AlterSprintStatuses(s.Id);
            LoadData();
            // Refreshing the form
            MyForms.GetForm<TicketListForm>().LoadData();
        }
    }
}