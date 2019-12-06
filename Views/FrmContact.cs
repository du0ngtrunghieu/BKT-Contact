using Contacts_KT.Controllers;
using Contacts_KT.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contacts_KT.Views
{
    public partial class FrmContact : Form
    {
        private readonly FrmLogin _frmLogin;
        public String path;
        public string value1;
        public string fullname;
        public string phone;
        public string email;
        public string idContact;
        public int idUser;
        public FrmContact(FrmLogin frmLogin)
        {
            //path = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory())) + "//Data//ContactData.txt";
           
            InitializeComponent();
            _frmLogin = frmLogin;
            Update_tableContact();
           
        }
        
        public void Update_tableContact()
        {
            
            //List<ContactModel> contacts = ContactController.GetContacts(path);
            List<ContactModel> contacts = ContactController.GetContactsDb(_frmLogin.Iduser);
            dsContact.DataSource = null;

            ClearGrid();
            
            if (contacts == null)
            {
                MessageBox.Show(
                   "Data Không Có FILE !!!",
                   "thông báo",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Information
               );
            }
            else
            {

                dsContact.DataSource = contacts;
                
            }
            tbContact.DataSource = dsContact;
            update_lable();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            idUser = _frmLogin.Iduser;
            FrmAddContact t = new FrmAddContact(this);
            t.Show();
            
            

        }
        private void ClearGrid()
        {
            if (this.InvokeRequired) this.Invoke(new Action(this.ClearGrid));

            tbContact.DataSource = null;
            tbContact.Rows.Clear();
            tbContact.Refresh();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            var rs = MessageBox.Show(
               "Bạn có chắc là muốn xóa dữ liệu này không?",
               "Thông báo",
               MessageBoxButtons.OKCancel,
               MessageBoxIcon.Warning);
            if (rs == DialogResult.OK)
            {
                ContactModel ctselect = new ContactModel();
                foreach (DataGridViewRow row in tbContact.SelectedRows)
                {
                    string value1 = row.Cells[0].Value.ToString();
                    string fullname = row.Cells[1].Value.ToString();
                    string phone = row.Cells[2].Value.ToString();
                    string email = row.Cells[3].Value.ToString();
                    string id = row.Cells[4].Value.ToString();
                    string idusn = row.Cells[5].Value.ToString();
                    ctselect.FullName = fullname;
                    ctselect.Phone = int.Parse(phone);
                    ctselect.Email = email;
                    ctselect.IdContact = int.Parse(id);
                    ctselect.IdUser = int.Parse(idusn);
                    ContactController.deleteContactDb(ctselect);
                    Update_tableContact();


                }


            }
        }

        private void TbContact_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
                
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in tbContact.SelectedRows)
            {
               value1 = row.Cells[0].Value.ToString();
               fullname = row.Cells[1].Value.ToString();
               phone = row.Cells[2].Value.ToString();
               email = row.Cells[3].Value.ToString();
               idContact = row.Cells[4].Value.ToString();
               idUser = _frmLogin.Iduser;
            }
            FrmEdit frmEdit = new FrmEdit(this);
            frmEdit.Show();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void Txtsearch_TextChanged(object sender, EventArgs e)
        {
            var contacts = ContactController.GetContactBySearchDb(txtsearch.Text, _frmLogin.Iduser);
            if (contacts != null)
            {
                dsContact.DataSource = contacts;
            }
            tbContact.DataSource = dsContact;
            // update lại bảng chữ
            flowLayoutPanel1.Controls.Clear();
            List<String> t = ContactController.removeDuplicatesSearch(txtsearch.Text,path, _frmLogin.Iduser);
            for (int i = 0; i < t.Count; i++)
            {
                Label lbl = new Label();
                lbl.Text = t[i];
                lbl.Click += new System.EventHandler(this.Label_Click);
                flowLayoutPanel1.Controls.Add(lbl);
            }
        }
        public void update_lable()
        {
            flowLayoutPanel1.Controls.Clear();
            List<String> t=  ContactController.removeDuplicates(_frmLogin.Iduser);
            for (int i = 0; i < t.Count; i++)
            {
                Label lbl = new Label();
                lbl.Text = t[i];
                lbl.Click += new System.EventHandler(this.Label_Click);
                flowLayoutPanel1.Controls.Add(lbl);
            }
        }
        private void Label_Click(object sender, EventArgs e)
        {
            var labelName = ((Label)sender).Text;
            var listContactNoSort = ContactController.GetContactbyWordDb(labelName, _frmLogin.Iduser);
            var newContactList = listContactNoSort.OrderBy(x => x.firstWordName).ToList();
            if (newContactList != null)
            {
                dsContact.DataSource = newContactList;
            }
            tbContact.DataSource = dsContact;
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            FrmImport frmimp = new FrmImport(this);
            idUser = _frmLogin.Iduser;
            frmimp.Show();
        }
    }
}
