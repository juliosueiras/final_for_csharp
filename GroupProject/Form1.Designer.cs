namespace GroupProject
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmd_Insert = new System.Windows.Forms.Button();
            this.cmd_Update = new System.Windows.Forms.Button();
            this.cmd_Delete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.txt_ExpLevel = new System.Windows.Forms.TextBox();
            this.txt_YearsExp = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_desciption = new System.Windows.Forms.TextBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmd_Insert
            // 
            this.cmd_Insert.Location = new System.Drawing.Point(15, 91);
            this.cmd_Insert.Name = "cmd_Insert";
            this.cmd_Insert.Size = new System.Drawing.Size(75, 23);
            this.cmd_Insert.TabIndex = 0;
            this.cmd_Insert.Text = "Insert";
            this.cmd_Insert.UseVisualStyleBackColor = true;
            // 
            // cmd_Update
            // 
            this.cmd_Update.Location = new System.Drawing.Point(96, 91);
            this.cmd_Update.Name = "cmd_Update";
            this.cmd_Update.Size = new System.Drawing.Size(75, 23);
            this.cmd_Update.TabIndex = 1;
            this.cmd_Update.Text = "Update";
            this.cmd_Update.UseVisualStyleBackColor = true;
            // 
            // cmd_Delete
            // 
            this.cmd_Delete.Location = new System.Drawing.Point(177, 91);
            this.cmd_Delete.Name = "cmd_Delete";
            this.cmd_Delete.Size = new System.Drawing.Size(75, 23);
            this.cmd_Delete.TabIndex = 2;
            this.cmd_Delete.Text = "Delete";
            this.cmd_Delete.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(15, 120);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(425, 237);
            this.dataGridView1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Skill ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Skill Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Experience Level";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(337, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Years  of Experience";
            // 
            // txt_ID
            // 
            this.txt_ID.Location = new System.Drawing.Point(15, 25);
            this.txt_ID.MaxLength = 3;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.ShortcutsEnabled = false;
            this.txt_ID.Size = new System.Drawing.Size(100, 20);
            this.txt_ID.TabIndex = 8;
            // 
            // txt_Name
            // 
            this.txt_Name.Location = new System.Drawing.Point(124, 25);
            this.txt_Name.MaxLength = 32;
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.ShortcutsEnabled = false;
            this.txt_Name.Size = new System.Drawing.Size(100, 20);
            this.txt_Name.TabIndex = 9;
            // 
            // txt_ExpLevel
            // 
            this.txt_ExpLevel.Location = new System.Drawing.Point(231, 25);
            this.txt_ExpLevel.MaxLength = 32;
            this.txt_ExpLevel.Name = "txt_ExpLevel";
            this.txt_ExpLevel.ShortcutsEnabled = false;
            this.txt_ExpLevel.Size = new System.Drawing.Size(100, 20);
            this.txt_ExpLevel.TabIndex = 10;
            // 
            // txt_YearsExp
            // 
            this.txt_YearsExp.Location = new System.Drawing.Point(337, 25);
            this.txt_YearsExp.MaxLength = 2;
            this.txt_YearsExp.Name = "txt_YearsExp";
            this.txt_YearsExp.ShortcutsEnabled = false;
            this.txt_YearsExp.Size = new System.Drawing.Size(100, 20);
            this.txt_YearsExp.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 48);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Description";
            // 
            // txt_desciption
            // 
            this.txt_desciption.Location = new System.Drawing.Point(15, 65);
            this.txt_desciption.MaxLength = 128;
            this.txt_desciption.Name = "txt_desciption";
            this.txt_desciption.ShortcutsEnabled = false;
            this.txt_desciption.Size = new System.Drawing.Size(422, 20);
            this.txt_desciption.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 374);
            this.Controls.Add(this.txt_desciption);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_YearsExp);
            this.Controls.Add(this.txt_ExpLevel);
            this.Controls.Add(this.txt_Name);
            this.Controls.Add(this.txt_ID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmd_Delete);
            this.Controls.Add(this.cmd_Update);
            this.Controls.Add(this.cmd_Insert);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmd_Insert;
        private System.Windows.Forms.Button cmd_Update;
        private System.Windows.Forms.Button cmd_Delete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.TextBox txt_ExpLevel;
        private System.Windows.Forms.TextBox txt_YearsExp;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_desciption;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}

