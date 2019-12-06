using Contacts_KT.Controllers;
using Contacts_KT.Models;
using Microsoft.VisualBasic.FileIO;
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
    public partial class FrmImport : Form
    {
        private readonly FrmContact frmContact;
        public FrmImport(FrmContact frm)
        {
            InitializeComponent();
            frmContact = frm;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            int ImportedRecord = 0, inValidItem = 0;
            string SourceURl = "";
            if (dialog.FileName != "")
            {
                if (dialog.FileName.EndsWith(".csv"))
                {
                    String name = dialog.FileName;
                    DataTable dtNew = new DataTable();
                    dtNew = GetDataTabletFromCSVFile(name);
                    if (dtNew.Rows != null && dtNew.Rows.ToString() != String.Empty)
                    {
                        dgItems.DataSource = dtNew;
                    }
                    dataGridView1.DataSource = dgItems;
                }
                else
                {
                    MessageBox.Show("LỖI KHÔNG THẤY FILE !!!");
                }

            }
            else
            {
                MessageBox.Show("LỖI KHÔNG THẤY FILE !!!");
            }
        }
        public static DataTable GetDataTabletFromCSVFile(String path)
        {
            DataTable csvData = new DataTable();
            if (path.EndsWith(".csv"))
            {
                TextFieldParser csvReader = new TextFieldParser(path);
                csvReader.SetDelimiters(new string[] { "," });
                csvReader.HasFieldsEnclosedInQuotes = true;
                string[] colFields = csvReader.ReadFields();

                foreach (string column in colFields)
                {
                    DataColumn datecolumn = new DataColumn(column);
                    datecolumn.AllowDBNull = true;
                    csvData.Columns.Add(datecolumn);
                }
                while (!csvReader.EndOfData)
                {
                    string[] fieldData = csvReader.ReadFields();
                    for (int i = 0; i < fieldData.Length; i++)
                    {
                        if (fieldData[i] == "")
                        {
                            fieldData[i] = null;
                        }
                    }
                    csvData.Rows.Add(fieldData);
                }
            }
            return csvData;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            // save vào database 
            String FullName, Phone, Email,IdUser;
            
            DataTable dtItem = (DataTable)(dgItems.DataSource);
               
                foreach (DataRow dr in dtItem.Rows)
                {
                    ContactModel ctselect = new ContactModel();

                    FullName = Convert.ToString(dr["FullName"]);
                    Phone = Convert.ToString(dr["Phone"]);
                    Email = Convert.ToString(dr["Email"]);
                    

                   
                    var db = new ContactsContext();
                    if(FullName != null && Phone != null && Email != null && FullName != "" && Phone != "" && Email != "")
                {
                    ctselect.FullName = FullName;
                    ctselect.Phone = int.Parse(Phone);
                    ctselect.Email = Email;
                    ctselect.IdUser = frmContact.idUser;
                    ContactController.CheckImp(ctselect);
                
                    
                   
                }
                   

                }
                MessageBox.Show("Đã Lưu vào DataBase !!");
                dgItems.DataSource = null;
                dataGridView1.DataSource = dgItems;
                frmContact.Update_tableContact();
            
        }
            
        
    }
}
