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
    public partial class TicketEditForm : Form
    {
        public TicketEditForm()
        {
            InitializeComponent();
        }

        public Ticket Ticket { get; set; }

        public FormMode Mode { get; set; }

        public void CreateNewTicket()
        {
            Mode = FormMode.Create;
            Ticket = new Ticket();
            MdiParent = MyForms.GetForm<ParentForm>();
            Show();
        }

        public void UpdateTicket(Ticket ticket)
        {
            Mode = FormMode.Update; 
            Ticket = ticket;
            ShowTicketInControls();
            MdiParent = MyForms.GetForm<ParentForm>();
            Show();
        }

        // Showing ticket values in controls
        private void ShowTicketInControls()
        {
            tbxSummary.Text = Ticket.Summary;
            tbxDescription.Text = Ticket.Description;
            nudEstimation.Value = Ticket.Estimation;
            switch (Ticket.Priority)
            {
                case Ticket.Priorities.Showstopper:
                    cbxPriority.SelectedIndex = 0;
                    break;
                case Ticket.Priorities.High:
                    cbxPriority.SelectedIndex = 1;
                    break;
                case Ticket.Priorities.Normal:
                    cbxPriority.SelectedIndex = 2;
                    break;
                case Ticket.Priorities.Low:
                    cbxPriority.SelectedIndex = 3;
                    break;
            }

            switch (Ticket.Status)
            {
                case Ticket.Statuses.Backlog:
                    cbxStatus.SelectedIndex = 0;
                    break;
                case Ticket.Statuses.Planned:
                    cbxStatus.SelectedIndex = 1;
                    break;
                case Ticket.Statuses.Done:
                    cbxStatus.SelectedIndex = 2;
                    break;
            }
        }

        // Grabbing user input
        private void GrabUserInput()
        {
            Ticket.Summary = tbxSummary.Text;
            Ticket.Description = tbxDescription.Text;
            Ticket.Estimation = Convert.ToInt32(nudEstimation.Value);
            switch (cbxPriority.SelectedIndex)
            {
                case 0:
                    Ticket.Priority = Ticket.Priorities.Showstopper;
                    break;
                case 1:
                    Ticket.Priority = Ticket.Priorities.High;
                    break;
                case 2:
                    Ticket.Priority = Ticket.Priorities.Normal;
                    break;
                case 3:
                    Ticket.Priority = Ticket.Priorities.Low;
                    break;

            }
            switch (cbxStatus.SelectedIndex)
            {
                case 0:
                    Ticket.Status = Ticket.Statuses.Backlog;
                    break;
                case 1:
                    Ticket.Status = Ticket.Statuses.Planned;
                    break;
                case 2:
                    Ticket.Status = Ticket.Statuses.Done;
                    break;
            }
        }

        // Event handler for Cancel button
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Event handler for Save button
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                GrabUserInput();
                var manager = new TicketManager();
                if (Mode == FormMode.Create)
                    manager.Create(Ticket);
                else
                    manager.Update(Ticket);

                MyForms.GetForm<TicketListForm>().LoadData();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
