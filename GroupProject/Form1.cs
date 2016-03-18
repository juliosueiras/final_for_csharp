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

namespace GroupProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        FileStream file;
        DataTable table;

        private void Form1_Load(object sender, EventArgs e)
        {
            //Init table
            //Init file
            // TODO: Implement Me
            dataGridView1.Click += dataGridView1_Click;
            cmd_Delete.Click += cmd_Delete_Click;
            cmd_Insert.Click += cmd_Insert_Click;
            cmd_Update.Click += cmd_Update_Click;
        }

        void cmd_Update_Click(object sender, EventArgs e)
        {
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

        void ClearText()
        {
            // TODO: Implement
        }

        bool DataGood()
        {
            // TODO: Implement
            return true;
        }

        bool IsValidIndex()
        {
            // TODO: Implement
            return true;
        }

        void SetControlState(string state)
        {
            // TODO: Implement
        }
    }
}
