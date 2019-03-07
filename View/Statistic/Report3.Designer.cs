namespace CourseworkDB.View.Statistic
{
	partial class Report3
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
			this.tyreBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.databaseDataSet = new CourseworkDB.DatabaseDataSet();
			this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
			this.tyreTableAdapter = new CourseworkDB.DatabaseDataSetTableAdapters.TyreTableAdapter();
			((System.ComponentModel.ISupportInitialize)(this.tyreBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).BeginInit();
			this.SuspendLayout();
			// 
			// tyreBindingSource
			// 
			this.tyreBindingSource.DataMember = "Tyre";
			this.tyreBindingSource.DataSource = this.databaseDataSet;
			// 
			// databaseDataSet
			// 
			this.databaseDataSet.DataSetName = "DatabaseDataSet";
			this.databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// reportViewer1
			// 
			this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
			reportDataSource1.Name = "DataSetCross";
			reportDataSource1.Value = this.tyreBindingSource;
			this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
			this.reportViewer1.LocalReport.ReportEmbeddedResource = "CourseworkDB.Reports.Report3.rdlc";
			this.reportViewer1.Location = new System.Drawing.Point(0, 0);
			this.reportViewer1.Name = "reportViewer1";
			this.reportViewer1.ServerReport.BearerToken = null;
			this.reportViewer1.Size = new System.Drawing.Size(577, 431);
			this.reportViewer1.TabIndex = 0;
			// 
			// tyreTableAdapter
			// 
			this.tyreTableAdapter.ClearBeforeFill = true;
			// 
			// Report3
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(577, 431);
			this.Controls.Add(this.reportViewer1);
			this.Name = "Report3";
			this.Text = "Отчет";
			this.Load += new System.EventHandler(this.Report3_Load);
			((System.ComponentModel.ISupportInitialize)(this.tyreBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
		private DatabaseDataSet databaseDataSet;
		private System.Windows.Forms.BindingSource tyreBindingSource;
		private DatabaseDataSetTableAdapters.TyreTableAdapter tyreTableAdapter;
	}
}