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

namespace SkillTracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static int maxRecords = 100;

        private int fileSize = SkillRecord.RECORD_SIZE * maxRecords;
        private string fileName = "skills.dat";
        private string insertState = "i";
        private string updateState = "u/d";
        private FileStream file = null;
        private DataTable table = null;

        private void Form1_Load(object sender, EventArgs e)
        {
            Initialize();
            dataGridView1.Click += dataGridView1_Click;
            cmd_Delete.Click += cmd_Delete_Click;
            cmd_Insert.Click += cmd_Insert_Click;
            cmd_Update.Click += cmd_Update_Click;
            txt_ID.KeyPress += txt_ID_KeyPress;
            txt_Name.KeyPress += txt_Name_KeyPress;
            txt_ExpLevel.KeyPress += txt_ExpLevel_KeyPress;
            txt_YearsExp.KeyPress += txt_YearsExp_KeyPress;
            txt_desciption.KeyPress += txt_desciption_KeyPress;
        }

        private void Initialize()
        {
            try
            {
                file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                if (file.Length != fileSize)
                {
                    CreateDataFile();
                }
                InitializeDataTable();
                ReadFileAndUpdateTable();
            }
            catch (IOException io)
            {
                DisplayErrorMessage(io.Message, "Failed to Open File");
            }
            //Disable right click
            txt_ID.ContextMenuStrip = new ContextMenuStrip();
            txt_Name.ContextMenuStrip = new ContextMenuStrip();
            txt_ExpLevel.ContextMenuStrip = new ContextMenuStrip();
            txt_YearsExp.ContextMenuStrip = new ContextMenuStrip();
            txt_desciption.ContextMenuStrip = new ContextMenuStrip();
        }

        private void CreateDataFile()
        {
            SkillRecord record = new SkillRecord();
            try
            {
                //Ensure that we are creating file here this ensures that we are removing a corrupt file.
                //The loop below will destroy the data anyway, so we might as well make sure the file is clean.
                file.Close();
                file = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite);
                //position file pointer:
                file.Seek(0, SeekOrigin.Begin);
                for (int i = 0; i < maxRecords; i++)
                {
                    record.Write(file);
                }
            }
            catch (IOException io)
            {
                DisplayErrorMessage(io.Message, "Failed to Create File");
            }
        }

        void InitializeDataTable()
        {
            table = TableFactory.MakeTable();
            bindingSource1.DataSource = table;
            dataGridView1.DataSource = bindingSource1;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }

        void txt_desciption_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtBx = (TextBox)sender;
            int len = txtBx.Text.Length;
            txtBx.SelectionStart = len;
            char c = e.KeyChar;
            if (c != (char)Keys.Back)
            {
                if (e.KeyChar == ' ')
                {
                    if (len == 0 || txtBx.Text[len - 1] == ' ')
                    {
                        e.Handled = true;
                    }
                }
                else if (c >= 'a' && c <= 'z')
                {
                    if (len > 2)
                    {
                        if (txtBx.Text[len - 2] == '.' && txtBx.Text[len - 1] == ' ')
                        {
                            e.KeyChar = (char)(c - 32);
                        }
                    }
                    else if (len == 0)
                    {
                        e.KeyChar = (char)(c - 32);
                    }
                }
            }
        }

        void txt_YearsExp_KeyPress(object sender, KeyPressEventArgs e)
        {
            ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
            char c = e.KeyChar;
            if (c != (char)Keys.Back)
            {
                if (c < '0' || c > '9')
                {
                    e.Handled = true;
                }
            }
        }

        void txt_ExpLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtBx = (TextBox)sender;
            int len = txtBx.Text.Length;
            txtBx.SelectionStart = len;
            char c = e.KeyChar;
            if (c != (char)Keys.Back)
            {
                if (c >= '0' && c <= '9' ||
                    c >= 'a' && c <= 'z' ||
                    c >= 'A' && c <= 'Z')
                {
                    if (c >= 'a' && c <= 'z')
                    {
                        if (len == 0 || txtBx.Text[len - 1] == ' ')
                        {
                            e.KeyChar = (char)(c - 32);
                        }
                    }
                }
                else if (e.KeyChar == ' ')
                {
                    if (len == 0 || txtBx.Text[len - 1] == ' ')
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        void txt_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox txtBx = (TextBox)sender;
            int len = txtBx.Text.Length;
            txtBx.SelectionStart = len;
            char c = e.KeyChar;
            if (c != (char)Keys.Back)
            {
                if (c >= '0' && c <= '9' ||
                    c >= 'a' && c <= 'z' ||
                    c >= 'A' && c <= 'Z' || 
                    c == '.')
                {
                    if (c >= 'a' && c <= 'z')
                    {
                        if (len == 0 || txtBx.Text[len - 1] == ' ')
                        {
                            e.KeyChar = (char)(c - 32);
                        }
                    }
                }
                else if (e.KeyChar == ' ')
                {
                    if (len == 0 || txtBx.Text[len - 1] == ' ')
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        void txt_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            ((TextBox)sender).SelectionStart = ((TextBox)sender).Text.Length;
            char c = e.KeyChar;
            if (c != (char)Keys.Back)
            {
                if (c < '0' || c > '9')
                {
                    e.Handled = true;
                }
            }
        }

        void cmd_Update_Click(object sender, EventArgs e)
        {
            if (DataGood())
            {
                int skillId = Convert.ToInt32(txt_ID.Text);
                string skillName = txt_Name.Text;
                string skillLevel = txt_ExpLevel.Text;
                int yearsExp = Convert.ToInt32(txt_YearsExp.Text);
                string desc = txt_desciption.Text;
                SkillRecord sr = new SkillRecord(skillId, skillName, skillLevel, yearsExp, desc);
                try
                {
                    file.Seek((skillId - 1) * SkillRecord.RECORD_SIZE, SeekOrigin.Begin);
                    sr.Write(file);
                    ReadFileAndUpdateTable();
                    SetControlState(insertState);
                }
                catch (IOException ex)
                {
                    DisplayErrorMessage(ex.Message, "Error Updating Record");
                }
            }
        }

        void cmd_Insert_Click(object sender, EventArgs e)
        {
            if (cmd_Insert.Text.Equals("Cancel"))
            {
                SetControlState(insertState);
                return;
            }
            if (DataGood())
            {
                int skillId = Convert.ToInt32(txt_ID.Text);
                if (IsValidIndex(skillId))
                {
                    string skillName = txt_Name.Text;
                    string skillLevel = txt_ExpLevel.Text;
                    int yearExp = Convert.ToInt32(txt_YearsExp.Text);
                    string desc = txt_desciption.Text;
                    SkillRecord record = new SkillRecord(skillId, skillName, skillLevel, yearExp, desc);
                    try
                    {
                        file.Seek((skillId - 1) * SkillRecord.RECORD_SIZE, SeekOrigin.Begin);
                        record.Write(file);
                        ReadFileAndUpdateTable();
                    }
                    catch (IOException ex)
                    {
                        DisplayErrorMessage(ex.Message, "Error Inserting Record");
                    }
                }
            }
        }

        void cmd_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want delete this SkillRecord?", "Confirm Record Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                // delete record
                int skillId = Convert.ToInt32(txt_ID.Text);
                SkillRecord sr = new SkillRecord();
                try
                {
                    // position file pointer
                    file.Seek((skillId - 1) * SkillRecord.RECORD_SIZE, SeekOrigin.Begin);
                    sr.Write(file);
                    ReadFileAndUpdateTable();
                    SetControlState(insertState);
                }
                catch (IOException ex)
                {
                    DisplayErrorMessage(ex.Message, "Error Deleting Record");
                }
            }
        }

        void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                txt_ID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                txt_Name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                txt_ExpLevel.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txt_YearsExp.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                txt_desciption.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                SetControlState(updateState);
            }
        }

        void ReadFileAndUpdateTable()
        {
            table.Rows.Clear();
            SkillRecord sr = new SkillRecord();
            try
            {
                file.Seek(0, SeekOrigin.Begin);
                for (int i = 0; i < maxRecords; i++)
                {
                    sr.Read(file);
                    if (sr.SkillID > 0)
                    {
                        DataRow dr = table.NewRow();
                        dr["SkillID"] = sr.SkillID;
                        dr["SkillName"] = sr.SkillName.Trim();
                        dr["SkillLevel"] = sr.SkillLevel.Trim();
                        dr["YearsExperience"] = sr.YearsExperience;
                        dr["Description"] = sr.Desc.Trim();
                        table.Rows.Add(dr);
                    }
                }
                dataGridView1.ClearSelection();
                ClearTextAndSelection();
            }
            catch (IOException ex)
            {
                DisplayErrorMessage(ex.Message, "Error Reading File");
            }
        }

        private void ClearTextAndSelection()
        {

            txt_ExpLevel.Text = "";
            txt_ID.Text = "";
            txt_Name.Text = "";
            txt_YearsExp.Text = "";
            txt_desciption.Text = "";

            txt_ID.Focus();

            dataGridView1.ClearSelection();
        }

        private bool DataGood()
        {
            if (txt_ID.Text.Length < 1)
            {
                DisplayErrorMessage("Skill ID Required!", "Missing Skill ID");
                txt_ID.Focus();
                return false;
            }

            if (txt_Name.Text.Length < 1)
            {
                DisplayErrorMessage("Skill Name Required!", "Missing Skill Name");
                txt_Name.Focus();
                return false;
            }

            if (txt_ExpLevel.Text.Length < 1)
            {
                DisplayErrorMessage("Exprience Level Required!", "Missing Exprience Level");
                txt_ExpLevel.Focus();
                return false;
            }

            if (txt_YearsExp.Text.Length < 1)
            {
                DisplayErrorMessage("Years of Exprience Required!", "Missing Years of Exprience");
                txt_YearsExp.Focus();
                return false;
            }
            else if (Convert.ToInt32(txt_YearsExp.Text) < 0)
            {
                DisplayErrorMessage("Years of Exprience cannot be less than 0!", "Years of Exprience less than 0");
                txt_YearsExp.Focus();
                return false;
            }

            if (txt_desciption.Text.Length < 1)
            {
                DisplayErrorMessage("Description Required!", "Missing Description");
                txt_desciption.Focus();
                return false;
            }

            return true;
        }

        bool IsValidIndex(int index)
        {
            if (index < 1 || index > 100)
            {
                DisplayErrorMessage("Skill ID must be within the range 1 to 100.", "Invalid Skill ID");
                txt_ID.Focus();
                txt_ID.SelectAll();
                return false;
            }
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (index == Convert.ToInt32(table.Rows[i].ItemArray[0]))
                {
                    DisplayErrorMessage("Skill ID selected is already in use.", "Invalid Skill ID");
                    txt_ID.Focus();
                    txt_ID.SelectAll();
                    return false;
                }
            }
            return true;
        }

        void SetControlState(string state)
        {
            if (state.Equals(insertState))
            {
                txt_ID.Enabled = true;
                cmd_Insert.Text = "Insert";
                cmd_Update.Enabled = false;
                cmd_Delete.Enabled = false;
                ClearTextAndSelection();
            }
            else if (state.Equals(updateState))
            {
                txt_ID.Enabled = false;
                cmd_Insert.Text = "Cancel";
                cmd_Update.Enabled = true;
                cmd_Delete.Enabled = true;
            }
        }

        void DisplayErrorMessage(string message, string title)
        {
            MessageBox.Show(message, "ERROR: " + title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
