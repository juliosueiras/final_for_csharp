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

namespace binaryFile1
{
    public partial class Form1 : Form
    {
        private FileStream file = null;
        private const int MAX_RECORDS = 100;
        private int fileSize = MAX_RECORDS * AccountRecord.RecordSize;
        private DataTable myTable = null;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                file = new FileStream("clients.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
                if (file.Length != fileSize)
                {
                    initData();
                }
                makeDataTableAndDisplay();
                readFile();
            }
            catch (IOException io)
            {
                MessageBox.Show(io.Message, "Error Creating File");
            }
            txtAccountBalance.KeyPress += txtAccountBalance_KeyPress;
            txtFirstName.KeyPress += txtFirstName_KeyPress;
            txtLastName.KeyPress += txtLastName_KeyPress;
            txtAccountNum.KeyPress += txtAccountNum_KeyPress;
            dg1.Click += dg1_Click;
        }
        void dg1_Click(object sender, EventArgs e)
        {
            //select current row when column header clicked
            dg1.CurrentRow.Selected = true;
            //populate text boxes
            txtAccountNum.Text = dg1.CurrentRow.Cells["AccountNumber"].Value.ToString();
            txtFirstName.Text = dg1.CurrentRow.Cells[1].Value.ToString();
            txtLastName.Text = dg1.CurrentRow.Cells[2].Value.ToString();
            txtAccountBalance.Text = dg1.CurrentRow.Cells[3].Value.ToString();
            setControlState("u/d");
        }
        private void makeDataTableAndDisplay()
        {
            //create table
            myTable = TableFactory.makeTable();
            //bind and display data:
            bindingSource1.DataSource = myTable;
            dg1.DataSource = bindingSource1;
            for (int i = 0; i < dg1.Columns.Count; i++)
            {
                dg1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dg1.Columns["Balance"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dg1.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
        }
        void txtAccountNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            if (c != 8) //backspace
            {
                if(len == 0 && (c < '0' || c > '9'))
                {
                    e.Handled = true;
                }
                else if(len > 0 && (c < '0' || c > '9'))
                {
                    e.Handled = true;
                }
            }
        }
        void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionStart = len;
            if (c != 8) //backspace
            {
                if ((c < 'A' || c > 'Z') &&
                    (c < 'a' || c > 'z'))
                {
                    e.Handled = true;
                }
                else if (len == 0 && (c >= 'a' && c <= 'z'))
                {
                    e.KeyChar = (char)(c - 32);
                }
                else if (len > 0 && (c >= 'A' && c <= 'Z'))
                {
                    e.KeyChar = (char)(c + 32);
                }
            }
        }
        void txtLastName_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionStart = len;
            if (c != 8) //backspace
            {
                if ((c < 'A' || c > 'Z') &&
                    (c < 'a' || c > 'z'))
                {
                    e.Handled = true;
                }
                else if (len == 0 && (c >= 'a' && c <= 'z'))
                {
                    e.KeyChar = (char)(c - 32);
                }
                else if (len > 0 && (c >= 'A' && c <= 'Z'))
                {
                    e.KeyChar = (char)(c + 32);
                }
            }
        }
        void txtAccountBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            int len = ((TextBox)sender).Text.Length;
            ((TextBox)sender).SelectionStart = len;
            if (c != 8)
            {
                if (len == 0)
                {
                    if (c != '-')
                    {
                        if (c < '0' || c > '9')
                        {
                            e.Handled = true;
                        }
                    }
                }
                else
                {
                    int decimalIndex = ((TextBox)sender).Text.IndexOf('.');
                    if (c < '0' || c > '9')
                    {
                        //not number
                        if (c == '.')
                        {
                            if (decimalIndex > -1)
                            {
                                //number already contains a '.'
                                e.Handled = true;
                            }
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                    else if (decimalIndex > -1)
                    {
                        if (len == decimalIndex + 3)
                        {
                            //we already have two decimal places
                            e.Handled = true;
                        }
                    }
                }
            }
           
        }
        private void initData()
        {
            AccountRecordRA ra = new AccountRecordRA();
            try
            {
                //position file pointer:
                file.Seek(0, SeekOrigin.Begin);
                for (int i = 0; i < MAX_RECORDS; i++)
                {
                    ra.write(file);
                }
                readFile();
                MessageBox.Show("Data file has been initialized");
            }
            catch (IOException io)
            {
                MessageBox.Show(io.Message, "Error initializing File");
            }
        }
        private void readFile()
        {
            //listbxClients.Items.Clear();
            myTable.Rows.Clear();
            AccountRecordRA ra = new AccountRecordRA();
            try
            {
                file.Seek(0, SeekOrigin.Begin);
                for (int i = 0; i < MAX_RECORDS; i++)
                {
                    ra.read(file);
                    if (ra.AccountNumber > 0)
                    {
                        //listbxClients.Items.Add(formatRecordToString(ra));
                        myTable.Rows.Add(formatRecordToDataRow(ra));
                    }
                }
                dg1.ClearSelection();
            }
            catch (IOException io)
            {
                MessageBox.Show(io.Message, "Error reading from File");
            }

        }
        private DataRow formatRecordToDataRow(AccountRecordRA ra)
        {
            DataRow row = myTable.NewRow();
            row["AccountNumber"] = ra.AccountNumber;
            row["FirstName"] = ra.FirstName;
            row["LastName"] = ra.LastName;
            row["Balance"] = ra.AccountBalance.ToString("c");
            return row;
        }
        private string formatRecordToString(AccountRecordRA ra){
            StringBuilder sb = new StringBuilder();
            sb.Append(ra.AccountNumber);
            sb.Append("|");
            sb.Append(ra.FirstName);
            sb.Append("|");
            sb.Append(ra.LastName);
            sb.Append("|");
            sb.Append(ra.AccountBalance.ToString("c"));
            return sb.ToString();
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (btnInsert.Text == "Cancel")
            {
                setControlState("i");
                return;
            }
            if (dataGood())
            {
                int accountNumber = Convert.ToInt32(txtAccountNum.Text);
                if (isValidAccount(accountNumber))
                {
                    string firstName = txtFirstName.Text;
                    string lastName = txtLastName.Text;
                    double balance = Convert.ToDouble(txtAccountBalance.Text);
                    AccountRecordRA ra = new AccountRecordRA(accountNumber, firstName, lastName, balance);
                    try
                    {
                        //position file pointer
                        file.Seek(ra.FileIndex, SeekOrigin.Begin);
                        ra.write(file);
                        readFile();
                        clearText();
                    }
                    catch (IOException io)
                    {
                        MessageBox.Show(io.Message, "Error writing to File");
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGood())
            {
                int acct = Convert.ToInt32(txtAccountNum.Text);
                string fn = txtFirstName.Text;
                string ln = txtLastName.Text;
                string sbal = txtAccountBalance.Text;
                if (sbal[0] == '$')
                {
                    sbal = sbal.Remove(0, 1);
                }
                else if (sbal[0] == '-' && sbal[1] == '$')
                {
                    sbal = sbal.Remove(1, 1);
                }
                double bal = Convert.ToDouble(sbal);
                AccountRecordRA ra = new AccountRecordRA(acct, fn, ln, bal);
                try
                {
                    file.Seek(ra.FileIndex, SeekOrigin.Begin);
                    ra.write(file);
                    readFile();
                }
                catch (IOException io) 
                {
                    MessageBox.Show(io.Message, "Error updating record");
                }
                setControlState("i");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete this record?", "Record Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2) ==
                System.Windows.Forms.DialogResult.Yes)
            {
                AccountRecordRA ra = new AccountRecordRA();
                ra.AccountNumber = Convert.ToInt32(txtAccountNum.Text);
                try
                {
                    file.Seek(ra.FileIndex, SeekOrigin.Begin);
                    ra.delete(file);
                    readFile();
                }
                catch (IOException io)
                {
                    MessageBox.Show(io.Message, "Error deleting record");
                }
                setControlState("i");
            }
        }

        private void clearText()
        {
            txtAccountNum.Text = "";
            txtFirstName.Text = "";
            txtLastName.Text = "";
            txtAccountBalance.Text = "";
            txtAccountNum.Focus();
            //ListBox.clearSelected();
            dg1.ClearSelection();
        }

        private bool dataGood()
        {
            
            return true;
        }

        private bool isValidAccount(int acct)
        {
            //ItemListBox
            //for (int i = 0; i < listbxClients.Items.Count; i++)
            //{
            //    int len = listbxClients.Items[i].ToString().IndexOf("|");
            //    string sAcct = listbxClients.Items[i].ToString().Substring(0, len);
            //    if (acct == Convert.ToInt32(sAcct))
            //    {
            //        MessageBox.Show("This account number already exists.\nPlease choose a new account number.", "Primary key violation",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return false;
            //    }
            //}
            //DataGridView
            //for (int i = 0; i < dg1.Rows.Count; i++)
            //{
            //    if(acct == Convert.ToInt32(dg1.Rows[i].Cells[0].Value))
            //    {
            //        MessageBox.Show("This account number already exists.\nPlease choose a new account number.", "Primary key violation",
            //            MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return false;
            //    }
            //}
            //DataTable
            for (int i = 0; i < myTable.Rows.Count; i++)
            {
                if (acct == Convert.ToInt32(myTable.Rows[i].ItemArray[0]))
                {
                    MessageBox.Show("This account number already exists.\nPlease choose a new account number.", "Primary key violation",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            return true;
        }

        private void setControlState(string state)
        {
            if (state.Equals("i"))
            {
                txtAccountNum.Enabled = true;
                txtFirstName.Enabled = true;
                txtLastName.Enabled = true;
                btnInsert.Text = "Insert Record";
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
                clearText();
            }
            else if (state.Equals("u/d"))
            {
                txtAccountNum.Enabled = false;
                txtFirstName.Enabled = false;
                txtLastName.Enabled = false;
                btnInsert.Text = "Cancel";
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;

            }
        }

        private void listbxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (listbxClients.SelectedIndex > -1)
            //{
            //    string record = listbxClients.Items[listbxClients.SelectedIndex].ToString();
            //    string[] tokens = record.Split(new char[] {'|'});
            //    txtAccountNum.Text = tokens[0];
            //    txtFirstName.Text = tokens[1];
            //    txtLastName.Text = tokens[2];
            //    txtAccountBalance.Text = tokens[3];
            //    setControlState("u/d");

            //}
        }
    }
}
