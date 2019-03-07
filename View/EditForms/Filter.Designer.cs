namespace CourseworkDB.View.EditForms
{
	partial class Filter
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
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button3 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// comboBox1
			// 
			this.comboBox1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Name",
            "Size",
            "Season",
            "Year",
            "Amount"});
			this.comboBox1.Location = new System.Drawing.Point(12, 39);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(100, 21);
			this.comboBox1.TabIndex = 0;
			// 
			// comboBox2
			// 
			this.comboBox2.BackColor = System.Drawing.Color.WhiteSmoke;
			this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Items.AddRange(new object[] {
            "greater",
            "greater or equal",
            "smaller",
            "smaller or equal",
            "equal",
            "not equal",
            "between"});
			this.comboBox2.Location = new System.Drawing.Point(118, 39);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(100, 21);
			this.comboBox2.TabIndex = 1;
			this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(224, 39);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(100, 20);
			this.textBox1.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(330, 39);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 21);
			this.button1.TabIndex = 3;
			this.button1.Text = "Добавить";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 167);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(100, 23);
			this.button2.TabIndex = 4;
			this.button2.Text = "Фильтровать";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(138, 67);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.Size = new System.Drawing.Size(492, 228);
			this.dataGridView1.TabIndex = 5;
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(12, 66);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(100, 95);
			this.listBox1.TabIndex = 6;
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(274, 39);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(50, 20);
			this.textBox2.TabIndex = 7;
			this.textBox2.Visible = false;
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(12, 196);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(100, 23);
			this.button3.TabIndex = 8;
			this.button3.Text = "Очистить";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// Filter
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(642, 334);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.comboBox2);
			this.Controls.Add(this.comboBox1);
			this.Name = "Filter";
			this.Text = "Filter";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button3;
	}
}