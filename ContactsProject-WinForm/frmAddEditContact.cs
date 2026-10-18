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
    public partial class frmAddEditContact : Form
    {
        private int _ContactID;

        enum Mode { AddNew = 0, UpdateMode = 1 }

        Mode _Mode= Mode.AddNew;

        clsContact _Contact;

        public frmAddEditContact(int ContactID)
        {
            InitializeComponent();

            _ContactID = ContactID;

            if (ContactID == -1)
            {
                _Mode= Mode.AddNew;
            }
            else
            {
                _Mode= Mode.UpdateMode;
            }
        }

        private void _FillCountrysInComboBox()
        {
            DataTable dataTable=clsCountry.ListCountries();

            foreach(DataRow row in dataTable.Rows)
            {
                cbCountrys.Items.Add(row["CountryName"]);
            }

        }

        private void _LoadData()
        {
            _FillCountrysInComboBox();
            if(_ContactID == -1)
            {
                lbAddEditContact.Text = "Add New Contact ";
                _Contact=new clsContact();
                return;
            }

            _Contact = clsContact.Find(_ContactID);

            if(_Contact == null )
            {
                MessageBox.Show("This form will be closed becouse no contact with ID = " + _ContactID);
                this.Close();
                return;
            }

            tbFirstName.Text = _Contact.FirstName;
            tbLastName.Text = _Contact.LastName;
            tbEmail.Text = _Contact.Email;
            tbPhone.Text = _Contact.Phone;
            dtpDateOfBirth.Value = _Contact.DateOfBirth;
            lbAddEditContact.Text = "Edit Contact ID " + _Contact.ID;
            lbMode.Text =_ContactID.ToString();
            tbAddress.Text = _Contact.Address;

            if(_Contact.ImagePath!="")
            {
                pictureBox1.Load(_Contact.ImagePath);
            }

            llRemoveImage.Visible = (_Contact.ImagePath != "");


        }

        private void frmAddEditContact_Load(object sender, EventArgs e)
        {

            _LoadData();
        }




        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int CountryID = clsCountry.Find(cbCountrys.Text).ID;
            
            _Contact.FirstName = tbFirstName.Text;
            _Contact.LastName = tbLastName.Text;
            _Contact.Email = tbEmail.Text;
            _Contact.Phone = tbPhone.Text;
            _Contact.Address = tbAddress.Text;
            _Contact.CountryID=CountryID;

            if(pictureBox1.ImageLocation!=null)
            {
                _Contact.ImagePath= pictureBox1.ImageLocation.ToString();
            }
            else
            {
                _Contact.ImagePath = "";
            }

            if(_Contact.Save())
            {
                MessageBox.Show("Data Saved Successfuly");
            }
            else
            {
                MessageBox.Show("Error Data is not Saved Successsfuly");
            }

            _Mode = Mode.UpdateMode;
            lbAddEditContact.Text = "Edit Contact ID = " + _Contact.ID;
            lbMode.Text=_Contact.ID.ToString();

        }

        private void llRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.ImageLocation= null;
            llRemoveImage.Visible= false;
        }

        private void OpenFileDialog_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "image file|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory= true;
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                string SelectFilePath= openFileDialog1.FileName;
                pictureBox1.Load(SelectFilePath);
            }


        }

        private void cbCountrys_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "image file|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string SelectFilePath = openFileDialog1.FileName;
                pictureBox1.Load(SelectFilePath);
                llRemoveImage.Visible = true;
            }
        }
    }
}
