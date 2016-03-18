﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GroupProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static int maxRecords = 100;
        int fileSize = SkillRecord.RECORD_SIZE * maxRecords;
        string fileName = "skills.dat";
        FileStream file;
        DataTable table;
        string insertState = "i";
        string updateState = "u";

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
                    initData();
                }
                CreateTableAndDisplay();
                ReadFile();
            }
            catch (IOException io)
            {
                DisplayErrorMessage(io.Message, "Failed to Create File");
            }
            //Disable right click
            txt_ID.ContextMenuStrip = new ContextMenuStrip();
            txt_Name.ContextMenuStrip = new ContextMenuStrip();
            txt_ExpLevel.ContextMenuStrip = new ContextMenuStrip();
            txt_YearsExp.ContextMenuStrip = new ContextMenuStrip();
            txt_desciption.ContextMenuStrip = new ContextMenuStrip();
        }

        private void initData()
        {
            SkillRecord record = new SkillRecord() ;
            record.SkillID = 0;
            try
            {
                //position file pointer:
                file.Seek(0, SeekOrigin.Begin);
                for (int i = 0; i < maxRecords; i++)
                {
                    record.write(file);
                }
                ReadFile();
            }
            catch (IOException io)
            {
                DisplayErrorMessage(io.Message, "Failed to Initialize File");
            }
        }

        void CreateTableAndDisplay()
        {
            table = TableFactory.makeTable();
            bindingSource1.DataSource = table;
            dataGridView1.DataSource = bindingSource1;
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        void txt_desciption_KeyPress(object sender, KeyPressEventArgs e)
        {
            // TODO: Implement Me
            throw new NotImplementedException();
        }

        void txt_YearsExp_KeyPress(object sender, KeyPressEventArgs e)
        {
            // TODO: Implement Me
            throw new NotImplementedException();
        }

        void txt_ExpLevel_KeyPress(object sender, KeyPressEventArgs e)
        {
            // TODO: Implement Me
            throw new NotImplementedException();
        }

        void txt_Name_KeyPress(object sender, KeyPressEventArgs e)
        {
            // TODO: Implement Me
            //throw new NotImplementedException();
        }

        void txt_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // TODO: Implement Me
            throw new NotImplementedException();
        }

        void cmd_Update_Click(object sender, EventArgs e)
        {
            // TODO: Implement Me
            throw new NotImplementedException();
        }

        void cmd_Insert_Click(object sender, EventArgs e)
        {
            if(cmd_Insert.Text.Equals("Cancel"))
            {
                SetControlState(insertState);
                return;
            }
            if(DataGood())
            {
                int skillId = Convert.ToInt32(txt_ID.Text);
                if(IsValidIndex(skillId, insertState))
                {
                    string skillName = txt_Name.Text;
                    string skillLevel = txt_ExpLevel.Text;
                    int yearExp = Convert.ToInt32(txt_ExpLevel.Text);
                    string desc = txt_desciption.Text;
                    SkillRecord record = new SkillRecord(skillId, skillName, skillLevel, yearExp, desc);
                    try
                    {
                        file.Seek((skillId - 1)*SkillRecord.RECORD_SIZE, SeekOrigin.Begin);
                        record.write(file);
                        ReadFile();
                    }
                    catch(IOException ex)
                    {
                        MessageBox.Show(ex.Message, "Error Updating Record");
                    }
                }
                SetControlState("i");
            }
            //if (cmdInsert.Text.Equals("Return to Insert Mode"))
            //{
            //    setControlState("i");
            //    return;
            //}
            //if (dataGood())
            //{
            //    int acct = Convert.ToInt32(txtAcctNum.Text);
            //    if (isValidAccount(acct))
            //    {
            //        string fn = txtFName.Text;
            //        string ln = txtLName.Text;
            //        double bal = Convert.ToDouble(txtBalance.Text);  // unhandled ex here!!!
            //        AccountRecordRA ra = new AccountRecordRA(acct, fn, ln, bal);
            //        try
            //        {
            //            //position file pointer
            //            raFile.Seek((acct - 1) * 44, SeekOrigin.Begin);
            //            ra.write(raFile);
            //            readFile();
            //            clearText();
            //        }
            //        catch (IOException ex)
            //        {
            //            MessageBox.Show(ex.Message, "Error Inserting Record");
            //        }
            //    }
            //}
        }

        void cmd_Delete_Click(object sender, EventArgs e)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index >= 0)
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

        void ReadFile()
        {
            // TODO: Implement
        }

        void ClearText()
        {
            // TODO: Implement
        }

        bool DataGood()
        {
            // TODO: Implement
            return true;
        }

        bool IsValidIndex(int index, string state)
        {
            if (index < 1 || index > 100)
            {
                DisplayErrorMessage("Skill ID must be within the range 1 to 100.", "Invalid Skill ID");
                return false;
            }
            for (int i = 0; i < table.Rows.Count; i++)
            {
                if (index == Convert.ToInt32(table.Rows[i].ItemArray[0]))
                {
                    if (state.Equals(insertState))
                    {
                        DisplayErrorMessage("Skill ID selected is already in use.", "Invalid Skill ID");
                        return false;
                    }
                    else if (state.Equals(updateState))
                    {
                        int currentIndex = Convert.ToInt32(txt_ID.Text);
                        if (index != currentIndex)
                        {
                            DisplayErrorMessage("Skill ID selected is already in use.", "Invalid Skill ID");
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        void SetControlState(string state)
        {
            if (state.Equals("i"))
            {
                txt_ID.Enabled = true;
                cmd_Insert.Text = "Insert";
                cmd_Update.Enabled = false;
                cmd_Delete.Enabled = false;
                ClearText();
            }
            else if (state.Equals("u/d"))
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
