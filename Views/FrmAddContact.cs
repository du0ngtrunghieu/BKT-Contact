using Contacts_KT.Controllers;
using Contacts_KT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Contacts_KT.Views
{
   
    public partial class FrmAddContact : Form
    {
        private readonly FrmContact frmContact1;
        public string name;
        public string phone;
        public string email;
        public Boolean check = false;
        public FrmAddContact(FrmContact frmContact)
        {

            InitializeComponent();
            frmContact1 = frmContact;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            name = txtten.Text;
            phone = txtsdt.Text;
            email = txtemail.Text;
           
            if (name != null || phone != null || email != null)
            {
                ContactModel contact = new ContactModel();
                contact.FullName = name;
                contact.Phone = int.Parse(phone);
                contact.Email =email;
                
                ContactController.addContact(contact, frmContact1.path);
                MessageBox.Show("Thêm Thành Công: " + contact.FullName);
                frmContact1.Update_tableContact(frmContact1.path);
            }
            this.Close();
           
           
        }
    }
}
