using Contacts_KT.Controllers;
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
    public partial class FrmLogin : Form
    {
        public int Iduser;
       
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            String usn = txttaikhoan.Text;
            String password = txtmatkhau.Text;
            if(usn != "")
            {
                if( password != "")
                {
                    var userContact = UserController.CheckUserLogin(usn, password);
                    if(userContact != null)
                    {
                        Iduser = userContact.IdUser;
                        FrmContact frmct = new FrmContact(this);
                        frmct.Show();
                        
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản mật khẩu không đúng !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin !.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
