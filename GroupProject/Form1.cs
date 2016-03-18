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
            // TODO: Integrate table factory
            //table = TableFactory.makeTable();
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
            // TODO: Implement me
            throw new NotImplementedException();
        }

        void cmd_Delete_Click(object sender, EventArgs e)
        {
            // TODO: Implement
            throw new NotImplementedException();
        }

        void dataGridView1_Click(object sender, EventArgs e)
        {
            // TODO: Implement Me
            throw new NotImplementedException();
        }

        void ReadFile()
        {
            // TODO: Implement
        }

        private void ClearText()
        {

            txt_ExpLevel.Text = "";
            txt_ID.Text = "";
            txt_Name.Text = "";
            txt_YearsExp.Text = "";
            txt_desciption.Text = "";

            txt_ID.Focus();

            dataGridView1.ClearSelection();
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
                DisplayErrorMessage("Index must be within the range 1 to 100.", "Invalid Index");
            }
            if (state.Equals(insertState))
            {
            }
            else if (state.Equals(updateState))
            {

            }
            return true;
        }

        void SetControlState(string state)
        {
            // TODO: Implement
        }

        void DisplayErrorMessage(string message, string title)
        {
            MessageBox.Show(message, "ERROR: " + title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
