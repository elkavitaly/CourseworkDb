namespace CourseworkDB.View.Statistic
{
	partial class Report2
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
			Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Report2));
			this.view2BindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.databaseDataSet1 = new CourseworkDB.DatabaseDataSet1();
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.view2TableAdapter = new CourseworkDB.DatabaseDataSet1TableAdapters.View2TableAdapter();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.view2BindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.databaseDataSet1)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// view2BindingSource
			// 
			this.view2BindingSource.DataMember = "View2";
			this.view2BindingSource.DataSource = this.databaseDataSet1;
			// 
			// databaseDataSet1
			// 
			this.databaseDataSet1.DataSetName = "DatabaseDataSet1";
			this.databaseDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// reportViewer1
			// 
			this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			reportDataSource1.Name = "Report2Set";
			reportDataSource1.Value = this.view2BindingSource;
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
			this.reportViewer1.LocalReport.ReportEmbeddedResource = "CourseworkDB.Reports.Report2.rdlc";
			this.reportViewer1.Location = new System.Drawing.Point(0, 22);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.ServerReport.BearerToken = null;
			this.reportViewer1.Size = new System.Drawing.Size(585, 437);
			this.reportViewer1.TabIndex = 0;
			// 
			// view2TableAdapter
			// 
			this.view2TableAdapter.ClearBeforeFill = true;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
			this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(585, 22);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// toolStripButton1
			// 
			this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
			this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton1.Name = "toolStripButton1";
			this.toolStripButton1.Size = new System.Drawing.Size(52, 19);
			this.toolStripButton1.Text = "График";
			this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
			// 
			// Report2
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(585, 459);
			this.Controls.Add(this.reportViewer1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "Report2";
			this.Text = "Отчет";
			this.Load += new System.EventHandler(this.Report2_Load);
			((System.ComponentModel.ISupportInitialize)(this.view2BindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.databaseDataSet1)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
		private DatabaseDataSet1 databaseDataSet1;
		private System.Windows.Forms.BindingSource view2BindingSource;
		private DatabaseDataSet1TableAdapters.View2TableAdapter view2TableAdapter;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolStripButton1;
	}
}