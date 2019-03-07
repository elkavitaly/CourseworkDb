namespace CourseworkDB
{
	partial class Main
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.label1 = new System.Windows.Forms.Label();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
			this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.data = new System.Windows.Forms.ToolStripDropDownButton();
			this.автомобилиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.шиныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.комплектыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.пробегToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripDropDownButton3 = new System.Windows.Forms.ToolStripDropDownButton();
			this.добавитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.удалитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripDropDownButton4 = new System.Windows.Forms.ToolStripDropDownButton();
			this.фильтрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripDropDownButton2 = new System.Windows.Forms.ToolStripDropDownButton();
			this.запросыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.отчет1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.отчет2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.databaseDataSet = new CourseworkDB.DatabaseDataSet();
			this.carTableAdapter = new CourseworkDB.DatabaseDataSetTableAdapters.CarTableAdapter();
			this.tyreTableAdapter = new CourseworkDB.DatabaseDataSetTableAdapters.TyreTableAdapter();
			this.setTableAdapter = new CourseworkDB.DatabaseDataSetTableAdapters.SetTableAdapter();
			this.view3TableAdapter = new CourseworkDB.DatabaseDataSetTableAdapters.View3TableAdapter();
			this.label2 = new System.Windows.Forms.Label();
			this.billToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToDeleteRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.dataGridView1.BackgroundColor = System.Drawing.Color.WhiteSmoke;
			this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.GridColor = System.Drawing.Color.Gray;
			this.dataGridView1.Location = new System.Drawing.Point(12, 75);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.ReadOnly = true;
			this.dataGridView1.RowHeadersVisible = false;
			this.dataGridView1.ShowEditingIcon = false;
			this.dataGridView1.Size = new System.Drawing.Size(646, 360);
			this.dataGridView1.TabIndex = 0;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label1.Location = new System.Drawing.Point(12, 46);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(70, 26);
			this.label1.TabIndex = 1;
			this.label1.Text = "label1";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.data,
            this.toolStripDropDownButton3,
            this.toolStripDropDownButton4,
            this.toolStripDropDownButton2,
            this.toolStripTextBox1,
            this.toolStripButton1,
            this.toolStripButton2});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(790, 25);
			this.toolStrip1.TabIndex = 2;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripDropDownButton1
			// 
			this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.закрытьToolStripMenuItem,
            this.billToolStripMenuItem});
			this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
			this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
			this.toolStripDropDownButton1.Size = new System.Drawing.Size(49, 22);
			this.toolStripDropDownButton1.Text = "Файл";
			// 
			// закрытьToolStripMenuItem
			// 
			this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
			this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.закрытьToolStripMenuItem.Text = "Закрыть";
			this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
			// 
			// data
			// 
			this.data.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.data.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.автомобилиToolStripMenuItem,
            this.шиныToolStripMenuItem,
            this.комплектыToolStripMenuItem,
            this.пробегToolStripMenuItem});
			this.data.Image = ((System.Drawing.Image)(resources.GetObject("data.Image")));
			this.data.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.data.Name = "data";
			this.data.Size = new System.Drawing.Size(63, 22);
			this.data.Text = "Данные";
			// 
			// автомобилиToolStripMenuItem
			// 
			this.автомобилиToolStripMenuItem.Name = "автомобилиToolStripMenuItem";
			this.автомобилиToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.автомобилиToolStripMenuItem.Text = "Автомобили";
			this.автомобилиToolStripMenuItem.Click += new System.EventHandler(this.itemToolStripMenuItem_Click);
			// 
			// шиныToolStripMenuItem
			// 
			this.шиныToolStripMenuItem.Name = "шиныToolStripMenuItem";
			this.шиныToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.шиныToolStripMenuItem.Text = "Шины";
			this.шиныToolStripMenuItem.Click += new System.EventHandler(this.itemToolStripMenuItem_Click);
			// 
			// комплектыToolStripMenuItem
			// 
			this.комплектыToolStripMenuItem.Name = "комплектыToolStripMenuItem";
			this.комплектыToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.комплектыToolStripMenuItem.Text = "Комплекты";
			this.комплектыToolStripMenuItem.Click += new System.EventHandler(this.itemToolStripMenuItem_Click);
			// 
			// пробегToolStripMenuItem
			// 
			this.пробегToolStripMenuItem.Name = "пробегToolStripMenuItem";
			this.пробегToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
			this.пробегToolStripMenuItem.Text = "Пробег";
			this.пробегToolStripMenuItem.Visible = false;
			this.пробегToolStripMenuItem.Click += new System.EventHandler(this.itemToolStripMenuItem_Click);
			// 
			// toolStripDropDownButton3
			// 
			this.toolStripDropDownButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripDropDownButton3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.добавитьToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.удалитьToolStripMenuItem});
			this.toolStripDropDownButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton3.Image")));
			this.toolStripDropDownButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton3.Name = "toolStripDropDownButton3";
			this.toolStripDropDownButton3.Size = new System.Drawing.Size(109, 22);
			this.toolStripDropDownButton3.Text = "Редактирование";
			// 
			// добавитьToolStripMenuItem
			// 
			this.добавитьToolStripMenuItem.Name = "добавитьToolStripMenuItem";
			this.добавитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
			this.добавитьToolStripMenuItem.Text = "Добавить";
			this.добавитьToolStripMenuItem.Click += new System.EventHandler(this.insertToolStripMenuItem_Click);
			// 
			// изменитьToolStripMenuItem
			// 
			this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
			this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
			this.изменитьToolStripMenuItem.Text = "Изменить";
			this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.updateToolStripMenuItem_Click);
			// 
			// удалитьToolStripMenuItem
			// 
			this.удалитьToolStripMenuItem.Name = "удалитьToolStripMenuItem";
			this.удалитьToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
			this.удалитьToolStripMenuItem.Text = "Удалить";
			this.удалитьToolStripMenuItem.Click += new System.EventHandler(this.удалитьToolStripMenuItem_Click);
			// 
			// toolStripDropDownButton4
			// 
			this.toolStripDropDownButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripDropDownButton4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фильтрToolStripMenuItem});
			this.toolStripDropDownButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton4.Image")));
			this.toolStripDropDownButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton4.Name = "toolStripDropDownButton4";
			this.toolStripDropDownButton4.Size = new System.Drawing.Size(80, 22);
			this.toolStripDropDownButton4.Text = "Обработка";
			// 
			// фильтрToolStripMenuItem
			// 
			this.фильтрToolStripMenuItem.Name = "фильтрToolStripMenuItem";
			this.фильтрToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
			this.фильтрToolStripMenuItem.Text = "Фильтр";
			this.фильтрToolStripMenuItem.Click += new System.EventHandler(this.фильтрToolStripMenuItem_Click);
			// 
			// toolStripDropDownButton2
			// 
			this.toolStripDropDownButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripDropDownButton2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.запросыToolStripMenuItem,
            this.отчетыToolStripMenuItem});
			this.toolStripDropDownButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton2.Image")));
			this.toolStripDropDownButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripDropDownButton2.Name = "toolStripDropDownButton2";
			this.toolStripDropDownButton2.Size = new System.Drawing.Size(81, 22);
			this.toolStripDropDownButton2.Text = "Статистика";
			// 
			// запросыToolStripMenuItem
			// 
			this.запросыToolStripMenuItem.Name = "запросыToolStripMenuItem";
			this.запросыToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.запросыToolStripMenuItem.Text = "Запросы";
			this.запросыToolStripMenuItem.Click += new System.EventHandler(this.запросыToolStripMenuItem_Click);
			// 
			// отчетыToolStripMenuItem
			// 
			this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отчет1ToolStripMenuItem,
            this.отчет2ToolStripMenuItem});
			this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
			this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
			this.отчетыToolStripMenuItem.Text = "Отчеты";
			// 
			// отчет1ToolStripMenuItem
			// 
			this.отчет1ToolStripMenuItem.Name = "отчет1ToolStripMenuItem";
			this.отчет1ToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.отчет1ToolStripMenuItem.Text = "Комплекты по машинам";
			this.отчет1ToolStripMenuItem.Click += new System.EventHandler(this.отчет1ToolStripMenuItem_Click_1);
			// 
			// отчет2ToolStripMenuItem
			// 
			this.отчет2ToolStripMenuItem.Name = "отчет2ToolStripMenuItem";
			this.отчет2ToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
			this.отчет2ToolStripMenuItem.Text = "Склад шин";
			this.отчет2ToolStripMenuItem.Click += new System.EventHandler(this.отчет2ToolStripMenuItem_Click);
			// 
			// toolStripTextBox1
			// 
			this.toolStripTextBox1.Name = "toolStripTextBox1";
			this.toolStripTextBox1.Size = new System.Drawing.Size(100, 25);
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.AutoToolTip = false;
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Margin = new System.Windows.Forms.Padding(0);
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(23, 25);
			this.toolStripButton1.Text = "toolStripButton1";
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// toolStripButton2
			// 
			this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
			this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton2.Name = "toolStripButton2";
			this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton2.Text = "toolStripButton2";
			this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Location = new System.Drawing.Point(466, 28);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(51, 23);
			this.groupBox1.TabIndex = 3;
			this.groupBox1.TabStop = false;
			this.groupBox1.Visible = false;
			// 
			// button2
			// 
			this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
			this.button2.Location = new System.Drawing.Point(27, 2);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(20, 18);
			this.button2.TabIndex = 4;
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
			this.button1.Location = new System.Drawing.Point(3, 2);
			this.button1.Margin = new System.Windows.Forms.Padding(0);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(20, 18);
			this.button1.TabIndex = 3;
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// databaseDataSet
			// 
			this.databaseDataSet.DataSetName = "DatabaseDataSet";
			this.databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// carTableAdapter
			// 
			this.carTableAdapter.ClearBeforeFill = true;
			// 
			// tyreTableAdapter
			// 
			this.tyreTableAdapter.ClearBeforeFill = true;
			// 
			// setTableAdapter
			// 
			this.setTableAdapter.ClearBeforeFill = true;
			// 
			// view3TableAdapter
			// 
			this.view3TableAdapter.ClearBeforeFill = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(680, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(47, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Фильтр";
			this.label2.Visible = false;
			// 
			// billToolStripMenuItem
			// 
			this.billToolStripMenuItem.Name = "billToolStripMenuItem";
			this.billToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
			this.billToolStripMenuItem.Text = "Загрузить накладную";
			this.billToolStripMenuItem.Click += new System.EventHandler(this.billToolStripMenuItem_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.FileName = "openFileDialog1";
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.ClientSize = new System.Drawing.Size(790, 447);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.dataGridView1);
			this.Name = "Main";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Главная";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
		private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
		private System.Windows.Forms.ToolStripDropDownButton data;
		private System.Windows.Forms.ToolStripMenuItem автомобилиToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem шиныToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem комплектыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem пробегToolStripMenuItem;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton3;
		private System.Windows.Forms.ToolStripMenuItem добавитьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem удалитьToolStripMenuItem;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton4;
		private System.Windows.Forms.ToolStripMenuItem фильтрToolStripMenuItem;
		private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton2;
		private System.Windows.Forms.ToolStripMenuItem запросыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem отчет1ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem отчет2ToolStripMenuItem;
		private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
		private System.Windows.Forms.ToolStripButton toolStripButton2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private DatabaseDataSet databaseDataSet;
		private DatabaseDataSetTableAdapters.CarTableAdapter carTableAdapter;
		private DatabaseDataSetTableAdapters.TyreTableAdapter tyreTableAdapter;
		private DatabaseDataSetTableAdapters.SetTableAdapter setTableAdapter;
		private DatabaseDataSetTableAdapters.View3TableAdapter view3TableAdapter;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolStripMenuItem billToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
	}
}