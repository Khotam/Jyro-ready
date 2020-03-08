﻿using Jyro.DAL;
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

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you really want to close appllication?", "Exit", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new AboutForm().ShowDialog();
        }

        private void allTicketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyForms.GetForm<TicketListForm>().Show();
        }

        private void newSprintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SprintCreateForm().CreateNewSprint();
        }

        private void allSprintsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyForms.GetForm<SprintListForm>().Show();
        }

        private void newTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new TicketEditForm().CreateNewTicket();
        }
    }
}
