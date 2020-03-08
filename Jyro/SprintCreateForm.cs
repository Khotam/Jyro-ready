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
    public partial class SprintCreateForm : Form
    {
        public SprintCreateForm()
        {
            InitializeComponent();
        }

        public Sprint Sprint { get; set; }

        public void CreateNewSprint()
        {
            Sprint = new Sprint();
            MdiParent = MyForms.GetForm<ParentForm>();
            Show();
        }

        private void GrabUserInput()
        {
            Sprint.Name = tbxName.Text;
            Sprint.Date = dtpDate.Value;
            Sprint.NumberOfDevelopers = Convert.ToInt32(nudDevelopers.Value);
            Sprint.Status = Sprint.SprintStatuses.Planned;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                GrabUserInput(); 
                var manager = new SprintManager();
                manager.Create(Sprint);
                MyForms.GetForm<SprintListForm>().LoadData();                                                            

                Sprint s = manager.GetAll().Last();                              

                List<Ticket> source = new TicketList().GetTicketSprint((int)nudDevelopers.Value);
                foreach (var item in source)
                {
                    new TicketManager().SetTicketStatusAndSprint(item, s.Id);
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

        }

        private void SprintCreateForm_Load(object sender, EventArgs e)
        {
            dgv.DataMember = "";
            dgv.DataSource = null;
            dgv.DataSource = new TicketList().Sort(ByAttribute.PriorityNumber);
        }

        private void nudDevelopers_ValueChanged(object sender, EventArgs e)
        {
            dgv.DataMember = "";
            dgv.DataSource = null;
            dgv.DataSource = new TicketList().GetTicketSprint((int)nudDevelopers.Value);
        }
    }
}
