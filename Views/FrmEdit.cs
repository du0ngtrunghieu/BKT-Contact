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
    public partial class FrmEdit : Form
    {
        private readonly FrmContact frmContact1;
        public FrmEdit(FrmContact frmContact)
        {
            InitializeComponent();
            frmContact1 = frmContact;
            txtemail.Text = frmContact1.email;
            txtsdt.Text = frmContact1.phone;
            txtten.Text = frmContact1.fullname;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            String name = txtten.Text;
            String phone = txtsdt.Text;
            String email = txtemail.Text;

            if (name != null || phone != null || email != null)
            {
                ContactModel contact = new ContactModel();
                contact.FullName = name;
                contact.Phone = int.Parse(phone);
                contact.Email = email;
                contact.IdContact = int.Parse(frmContact1.idContact);

                ContactController.updateContactDb(contact);
                MessageBox.Show("Sửa thành công: " + contact.FullName);
                frmContact1.Update_tableContact();
            }
            this.Close();
        }
    }
}
