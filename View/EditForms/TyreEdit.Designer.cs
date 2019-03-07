namespace CourseworkDB.View
{
	partial class TyreEdit
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
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.amount = new System.Windows.Forms.TextBox();
			this.year = new System.Windows.Forms.TextBox();
			this.size = new System.Windows.Forms.TextBox();
			this.name = new System.Windows.Forms.TextBox();
			this.season = new System.Windows.Forms.ComboBox();
			this.errors = new System.Windows.Forms.TextBox();
			this.databaseDataSet1 = new CourseworkDB.DatabaseDataSet();
			this.tyreTableAdapter1 = new CourseworkDB.DatabaseDataSetTableAdapters.TyreTableAdapter();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.databaseDataSet1)).BeginInit();
			this.SuspendLayout();
			// 
			// button2
			// 
			this.button2.BackColor = System.Drawing.Color.WhiteSmoke;
			this.button2.Location = new System.Drawing.Point(131, 226);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 23);
			this.button2.TabIndex = 7;
			this.button2.Text = "Отмена";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.button1.Location = new System.Drawing.Point(45, 226);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 6;
			this.button1.Text = "OK";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// amount
			// 
			this.amount.Location = new System.Drawing.Point(21, 186);
			this.amount.Name = "amount";
			this.amount.Size = new System.Drawing.Size(100, 20);
			this.amount.TabIndex = 5;
			this.amount.Enter += new System.EventHandler(this.textBox_Enter);
			this.amount.Leave += new System.EventHandler(this.textBoxInt_Leave);
			// 
			// year
			// 
			this.year.Location = new System.Drawing.Point(21, 147);
			this.year.Name = "year";
			this.year.Size = new System.Drawing.Size(100, 20);
			this.year.TabIndex = 4;
			this.year.Enter += new System.EventHandler(this.textBox_Enter);
			this.year.Leave += new System.EventHandler(this.textBoxInt_Leave);
			// 
			// size
			// 
			this.size.Location = new System.Drawing.Point(21, 68);
			this.size.Name = "size";
			this.size.Size = new System.Drawing.Size(100, 20);
			this.size.TabIndex = 2;
			this.size.Enter += new System.EventHandler(this.textBox_Enter);
			this.size.Leave += new System.EventHandler(this.textBoxStr_Leave);
			// 
			// name
			// 
			this.name.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.name.Location = new System.Drawing.Point(21, 29);
			this.name.Name = "name";
			this.name.Size = new System.Drawing.Size(100, 20);
			this.name.TabIndex = 1;
			this.name.Enter += new System.EventHandler(this.textBox_Enter);
			this.name.Leave += new System.EventHandler(this.textBoxStr_Leave);
			// 
			// season
			// 
			this.season.BackColor = System.Drawing.Color.White;
			this.season.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.season.FormattingEnabled = true;
			this.season.Items.AddRange(new object[] {
            "Лето",
            "Зима",
            "Всесезон"});
			this.season.Location = new System.Drawing.Point(21, 107);
			this.season.Name = "season";
			this.season.Size = new System.Drawing.Size(100, 21);
			this.season.TabIndex = 3;
			// 
			// errors
			// 
			this.errors.BackColor = System.Drawing.Color.WhiteSmoke;
			this.errors.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.errors.Location = new System.Drawing.Point(144, 34);
			this.errors.Multiline = true;
			this.errors.Name = "errors";
			this.errors.Size = new System.Drawing.Size(126, 124);
			this.errors.TabIndex = 8;
			this.errors.Visible = false;
			// 
			// databaseDataSet1
			// 
			this.databaseDataSet1.DataSetName = "DatabaseDataSet";
			this.databaseDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// tyreTableAdapter1
			// 
			this.tyreTableAdapter1.ClearBeforeFill = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(18, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(57, 13);
			this.label1.TabIndex = 9;
			this.label1.Text = "Название";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(18, 52);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(46, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Размер";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(18, 91);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 13);
			this.label3.TabIndex = 11;
			this.label3.Text = "Сезон";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(18, 131);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(71, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "Год выпуска";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(18, 170);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(66, 13);
			this.label5.TabIndex = 13;
			this.label5.Text = "Количество";
			// 
			// TyreEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(281, 268);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.errors);
			this.Controls.Add(this.season);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.amount);
			this.Controls.Add(this.year);
			this.Controls.Add(this.size);
			this.Controls.Add(this.name);
			this.Name = "TyreEdit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Шина";
			((System.ComponentModel.ISupportInitialize)(this.databaseDataSet1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox amount;
		private System.Windows.Forms.TextBox year;
		private System.Windows.Forms.TextBox size;
		private System.Windows.Forms.TextBox name;
		private System.Windows.Forms.ComboBox season;
		private System.Windows.Forms.TextBox errors;
		private DatabaseDataSet databaseDataSet1;
		private DatabaseDataSetTableAdapters.TyreTableAdapter tyreTableAdapter1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
	}
}