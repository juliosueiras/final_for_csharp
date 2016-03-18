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
            this.cmd_Insert = new System.Windows.Forms.Button();
            this.cmd_Update = new System.Windows.Forms.Button();
            this.cmd_Delete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmd_Insert
            // 
            this.cmd_Insert.Location = new System.Drawing.Point(234, 168);
            this.cmd_Insert.Name = "cmd_Insert";
            this.cmd_Insert.Size = new System.Drawing.Size(75, 23);
            this.cmd_Insert.TabIndex = 0;
            this.cmd_Insert.Text = "Insert";
            this.cmd_Insert.UseVisualStyleBackColor = true;
            // 
            // cmd_Update
            // 
            this.cmd_Update.Location = new System.Drawing.Point(315, 168);
            this.cmd_Update.Name = "cmd_Update";
            this.cmd_Update.Size = new System.Drawing.Size(75, 23);
            this.cmd_Update.TabIndex = 1;
            this.cmd_Update.Text = "Update";
            this.cmd_Update.UseVisualStyleBackColor = true;
            // 
            // cmd_Delete
            // 
            this.cmd_Delete.Location = new System.Drawing.Point(396, 168);
            this.cmd_Delete.Name = "cmd_Delete";
            this.cmd_Delete.Size = new System.Drawing.Size(75, 23);
            this.cmd_Delete.TabIndex = 2;
            this.cmd_Delete.Text = "Delete";
            this.cmd_Delete.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(234, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(240, 150);
            this.dataGridView1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 261);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cmd_Delete);
            this.Controls.Add(this.cmd_Update);
            this.Controls.Add(this.cmd_Insert);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmd_Insert;
        private System.Windows.Forms.Button cmd_Update;
        private System.Windows.Forms.Button cmd_Delete;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

