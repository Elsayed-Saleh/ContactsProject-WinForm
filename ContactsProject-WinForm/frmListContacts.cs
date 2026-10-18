using ContactsBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactsProject_WinForm
{
    public partial class frmListContacts : Form
    {
        public frmListContacts()
        {
            InitializeComponent();
        }
        private void _RefreshContactsList()
        {
            dgvAllContacts.DataSource = clsContact.GetAllContacts();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _RefreshContactsList();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddEdit_Click(object sender, EventArgs e)
        {
            frmAddEditContact frmAddEdit = new frmAddEditContact(-1);
            frmAddEdit.ShowDialog();
            _RefreshContactsList();
        }
        
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete contact ["+dgvAllContacts.CurrentRow.Cells[0].Value+"]",
                "Confirm Delete",MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                if (clsContact.DeleteContact((int)dgvAllContacts.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("The Contacts Deleted Successfuly");
                    _RefreshContactsList();
                }
                else
                    MessageBox.Show("The Contacts is not Deleted");
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditContact frmAddEditContact = new frmAddEditContact((int)dgvAllContacts.CurrentRow.Cells[0].Value);
            frmAddEditContact.ShowDialog();
            _RefreshContactsList();
        }


    }
}
