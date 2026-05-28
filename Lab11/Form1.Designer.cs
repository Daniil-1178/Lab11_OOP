namespace Lab11
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtBox1 = new System.Windows.Forms.TextBox();
            this.txtBox2 = new System.Windows.Forms.TextBox();
            this.txtBox3 = new System.Windows.Forms.TextBox();
            this.pictBox1 = new System.Windows.Forms.PictureBox();
            this.txtBox4 = new System.Windows.Forms.TextBox();
            this.txtBoxSearch = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnFaculties = new System.Windows.Forms.Button();
            this.btnValue = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.oleDbSelectCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbInsertCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbUpdateCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDeleteCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lbl1 = new System.Windows.Forms.Label();
            this.lbl2 = new System.Windows.Forms.Label();
            this.lbl3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(800, 450);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            this.dataGridView1.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dataGridView1_UserDeletingRow);
            // 
            // txtBox1
            // 
            this.txtBox1.Location = new System.Drawing.Point(588, 185);
            this.txtBox1.Name = "txtBox1";
            this.txtBox1.Size = new System.Drawing.Size(200, 20);
            this.txtBox1.TabIndex = 1;
            // 
            // txtBox2
            // 
            this.txtBox2.Location = new System.Drawing.Point(588, 224);
            this.txtBox2.Name = "txtBox2";
            this.txtBox2.Size = new System.Drawing.Size(200, 20);
            this.txtBox2.TabIndex = 2;
            // 
            // txtBox3
            // 
            this.txtBox3.Location = new System.Drawing.Point(588, 263);
            this.txtBox3.Name = "txtBox3";
            this.txtBox3.Size = new System.Drawing.Size(200, 20);
            this.txtBox3.TabIndex = 3;
            // 
            // pictBox1
            // 
            this.pictBox1.Location = new System.Drawing.Point(592, 4);
            this.pictBox1.Name = "pictBox1";
            this.pictBox1.Size = new System.Drawing.Size(196, 139);
            this.pictBox1.TabIndex = 4;
            this.pictBox1.TabStop = false;
            this.pictBox1.Click += new System.EventHandler(this.pictBox1_Click);
            // 
            // txtBox4
            // 
            this.txtBox4.Location = new System.Drawing.Point(701, 148);
            this.txtBox4.Name = "txtBox4";
            this.txtBox4.Size = new System.Drawing.Size(87, 20);
            this.txtBox4.TabIndex = 5;
            this.txtBox4.TextChanged += new System.EventHandler(this.txtBox4_TextChanged);
            // 
            // txtBoxSearch
            // 
            this.txtBoxSearch.Location = new System.Drawing.Point(12, 324);
            this.txtBoxSearch.Name = "txtBoxSearch";
            this.txtBoxSearch.Size = new System.Drawing.Size(200, 20);
            this.txtBoxSearch.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(12, 350);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "Пошук";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // btnFaculties
            // 
            this.btnFaculties.Location = new System.Drawing.Point(588, 308);
            this.btnFaculties.Name = "btnFaculties";
            this.btnFaculties.Size = new System.Drawing.Size(75, 23);
            this.btnFaculties.TabIndex = 8;
            this.btnFaculties.Text = "Факультети";
            this.btnFaculties.UseVisualStyleBackColor = true;
            this.btnFaculties.Click += new System.EventHandler(this.buttonReport1_Click);
            // 
            // btnValue
            // 
            this.btnValue.Location = new System.Drawing.Point(588, 350);
            this.btnValue.Name = "btnValue";
            this.btnValue.Size = new System.Drawing.Size(75, 23);
            this.btnValue.TabIndex = 9;
            this.btnValue.Text = "Вартість";
            this.btnValue.UseVisualStyleBackColor = true;
            this.btnValue.Click += new System.EventHandler(this.buttonReport2_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(12, 389);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 10;
            this.btnReset.Text = "На головну";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // oleDbDataAdapter1
            // 
            this.oleDbDataAdapter1.DeleteCommand = this.oleDbDeleteCommand1;
            this.oleDbDataAdapter1.InsertCommand = this.oleDbInsertCommand1;
            this.oleDbDataAdapter1.SelectCommand = this.oleDbSelectCommand1;
            this.oleDbDataAdapter1.UpdateCommand = this.oleDbUpdateCommand1;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // lbl1
            // 
            this.lbl1.AutoSize = true;
            this.lbl1.Location = new System.Drawing.Point(589, 169);
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(42, 13);
            this.lbl1.TabIndex = 11;
            this.lbl1.Text = "Назва:";
            // 
            // lbl2
            // 
            this.lbl2.AutoSize = true;
            this.lbl2.Location = new System.Drawing.Point(589, 208);
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(38, 13);
            this.lbl2.TabIndex = 12;
            this.lbl2.Text = "Місто:";
            // 
            // lbl3
            // 
            this.lbl3.AutoSize = true;
            this.lbl3.Location = new System.Drawing.Point(589, 247);
            this.lbl3.Name = "lbl3";
            this.lbl3.Size = new System.Drawing.Size(99, 13);
            this.lbl3.TabIndex = 13;
            this.lbl3.Text = "Форма власності:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lbl3);
            this.Controls.Add(this.lbl2);
            this.Controls.Add(this.lbl1);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnValue);
            this.Controls.Add(this.btnFaculties);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtBoxSearch);
            this.Controls.Add(this.txtBox4);
            this.Controls.Add(this.pictBox1);
            this.Controls.Add(this.txtBox3);
            this.Controls.Add(this.txtBox2);
            this.Controls.Add(this.txtBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtBox1;
        private System.Windows.Forms.TextBox txtBox2;
        private System.Windows.Forms.TextBox txtBox3;
        private System.Windows.Forms.PictureBox pictBox1;
        private System.Windows.Forms.TextBox txtBox4;
        private System.Windows.Forms.TextBox txtBoxSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnFaculties;
        private System.Windows.Forms.Button btnValue;
        private System.Windows.Forms.Button btnReset;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private System.Data.OleDb.OleDbCommand oleDbSelectCommand1;
        private System.Data.OleDb.OleDbCommand oleDbInsertCommand1;
        private System.Data.OleDb.OleDbCommand oleDbUpdateCommand1;
        private System.Data.OleDb.OleDbCommand oleDbDeleteCommand1;
        private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.Label lbl2;
        private System.Windows.Forms.Label lbl3;
    }
}

