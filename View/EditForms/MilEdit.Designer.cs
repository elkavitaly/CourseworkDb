namespace CourseworkDB.View
{
	partial class MilEdit
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
			System.Windows.Forms.Label idLabel;
			System.Windows.Forms.Label setIdLabel;
			System.Windows.Forms.Label monthLabel;
			System.Windows.Forms.Label yearLabel;
			System.Windows.Forms.Label kilometersLabel;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MilEdit));
			this.databaseDataSet = new CourseworkDB.DatabaseDataSet();
			this.mileageBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.mileageTableAdapter = new CourseworkDB.DatabaseDataSetTableAdapters.MileageTableAdapter();
			this.tableAdapterManager = new CourseworkDB.DatabaseDataSetTableAdapters.TableAdapterManager();
			this.mileageBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
			this.bindingNavigatorAddNewItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
			this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
			this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
			this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
			this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.mileageBindingNavigatorSaveItem = new System.Windows.Forms.ToolStripButton();
			this.idTextBox = new System.Windows.Forms.TextBox();
			this.setIdTextBox = new System.Windows.Forms.TextBox();
			this.monthTextBox = new System.Windows.Forms.TextBox();
			this.yearTextBox = new System.Windows.Forms.TextBox();
			this.kilometersTextBox = new System.Windows.Forms.TextBox();
			idLabel = new System.Windows.Forms.Label();
			setIdLabel = new System.Windows.Forms.Label();
			monthLabel = new System.Windows.Forms.Label();
			yearLabel = new System.Windows.Forms.Label();
			kilometersLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mileageBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.mileageBindingNavigator)).BeginInit();
			this.mileageBindingNavigator.SuspendLayout();
			this.SuspendLayout();
			// 
			// idLabel
			// 
			idLabel.AutoSize = true;
			idLabel.Location = new System.Drawing.Point(37, 68);
			idLabel.Name = "idLabel";
			idLabel.Size = new System.Drawing.Size(19, 13);
			idLabel.TabIndex = 1;
			idLabel.Text = "Id:";
			// 
			// setIdLabel
			// 
			setIdLabel.AutoSize = true;
			setIdLabel.Location = new System.Drawing.Point(37, 94);
			setIdLabel.Name = "setIdLabel";
			setIdLabel.Size = new System.Drawing.Size(38, 13);
			setIdLabel.TabIndex = 3;
			setIdLabel.Text = "Set Id:";
			// 
			// monthLabel
			// 
			monthLabel.AutoSize = true;
			monthLabel.Location = new System.Drawing.Point(37, 120);
			monthLabel.Name = "monthLabel";
			monthLabel.Size = new System.Drawing.Size(40, 13);
			monthLabel.TabIndex = 5;
			monthLabel.Text = "Month:";
			// 
			// yearLabel
			// 
			yearLabel.AutoSize = true;
			yearLabel.Location = new System.Drawing.Point(37, 146);
			yearLabel.Name = "yearLabel";
			yearLabel.Size = new System.Drawing.Size(32, 13);
			yearLabel.TabIndex = 7;
			yearLabel.Text = "Year:";
			// 
			// kilometersLabel
			// 
			kilometersLabel.AutoSize = true;
			kilometersLabel.Location = new System.Drawing.Point(37, 172);
			kilometersLabel.Name = "kilometersLabel";
			kilometersLabel.Size = new System.Drawing.Size(58, 13);
			kilometersLabel.TabIndex = 9;
			kilometersLabel.Text = "Kilometers:";
			// 
			// databaseDataSet
			// 
			this.databaseDataSet.DataSetName = "DatabaseDataSet";
			this.databaseDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// mileageBindingSource
			// 
			this.mileageBindingSource.DataMember = "Mileage";
			this.mileageBindingSource.DataSource = this.databaseDataSet;
			// 
			// mileageTableAdapter
			// 
			this.mileageTableAdapter.ClearBeforeFill = true;
			// 
			// tableAdapterManager
			// 
			this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
			this.tableAdapterManager.CarTableAdapter = null;
			this.tableAdapterManager.MileageTableAdapter = this.mileageTableAdapter;
			this.tableAdapterManager.SetTableAdapter = null;
			this.tableAdapterManager.TyreTableAdapter = null;
			this.tableAdapterManager.UpdateOrder = CourseworkDB.DatabaseDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
			// 
			// mileageBindingNavigator
			// 
			this.mileageBindingNavigator.AddNewItem = this.bindingNavigatorAddNewItem;
			this.mileageBindingNavigator.BindingSource = this.mileageBindingSource;
			this.mileageBindingNavigator.CountItem = this.bindingNavigatorCountItem;
			this.mileageBindingNavigator.DeleteItem = this.bindingNavigatorDeleteItem;
			this.mileageBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorAddNewItem,
            this.bindingNavigatorDeleteItem,
            this.mileageBindingNavigatorSaveItem});
			this.mileageBindingNavigator.Location = new System.Drawing.Point(0, 0);
			this.mileageBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
			this.mileageBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
			this.mileageBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
			this.mileageBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
			this.mileageBindingNavigator.Name = "mileageBindingNavigator";
			this.mileageBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
			this.mileageBindingNavigator.Size = new System.Drawing.Size(322, 25);
			this.mileageBindingNavigator.TabIndex = 0;
			this.mileageBindingNavigator.Text = "bindingNavigator1";
			// 
			// bindingNavigatorAddNewItem
			// 
			this.bindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorAddNewItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem.Image")));
			this.bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
			this.bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorAddNewItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorAddNewItem.Text = "Добавить";
			// 
			// bindingNavigatorCountItem
			// 
			this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
			this.bindingNavigatorCountItem.Size = new System.Drawing.Size(43, 22);
			this.bindingNavigatorCountItem.Text = "для {0}";
			this.bindingNavigatorCountItem.ToolTipText = "Общее число элементов";
			// 
			// bindingNavigatorDeleteItem
			// 
			this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorDeleteItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem.Image")));
			this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
			this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorDeleteItem.Text = "Удалить";
			// 
			// bindingNavigatorMoveFirstItem
			// 
			this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
			this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
			this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveFirstItem.Text = "Переместить в начало";
			// 
			// bindingNavigatorMovePreviousItem
			// 
			this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
			this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
			this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMovePreviousItem.Text = "Переместить назад";
			// 
			// bindingNavigatorSeparator
			// 
			this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
			this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
			// 
			// bindingNavigatorPositionItem
			// 
			this.bindingNavigatorPositionItem.AccessibleName = "Положение";
			this.bindingNavigatorPositionItem.AutoSize = false;
			this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
			this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
			this.bindingNavigatorPositionItem.Text = "0";
			this.bindingNavigatorPositionItem.ToolTipText = "Текущее положение";
			// 
			// bindingNavigatorSeparator1
			// 
			this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
			this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// bindingNavigatorMoveNextItem
			// 
			this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
			this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
			this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveNextItem.Text = "Переместить вперед";
			// 
			// bindingNavigatorMoveLastItem
			// 
			this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
			this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
			this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
			this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
			this.bindingNavigatorMoveLastItem.Text = "Переместить в конец";
			// 
			// bindingNavigatorSeparator2
			// 
			this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
			this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// mileageBindingNavigatorSaveItem
			// 
			this.mileageBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.mileageBindingNavigatorSaveItem.Image = ((System.Drawing.Image)(resources.GetObject("mileageBindingNavigatorSaveItem.Image")));
			this.mileageBindingNavigatorSaveItem.Name = "mileageBindingNavigatorSaveItem";
			this.mileageBindingNavigatorSaveItem.Size = new System.Drawing.Size(23, 22);
			this.mileageBindingNavigatorSaveItem.Text = "Сохранить данные";
			this.mileageBindingNavigatorSaveItem.Click += new System.EventHandler(this.mileageBindingNavigatorSaveItem_Click_1);
			// 
			// idTextBox
			// 
			this.idTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mileageBindingSource, "Id", true));
			this.idTextBox.Location = new System.Drawing.Point(101, 65);
			this.idTextBox.Name = "idTextBox";
			this.idTextBox.Size = new System.Drawing.Size(100, 20);
			this.idTextBox.TabIndex = 2;
			// 
			// setIdTextBox
			// 
			this.setIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mileageBindingSource, "SetId", true));
			this.setIdTextBox.Location = new System.Drawing.Point(101, 91);
			this.setIdTextBox.Name = "setIdTextBox";
			this.setIdTextBox.Size = new System.Drawing.Size(100, 20);
			this.setIdTextBox.TabIndex = 4;
			// 
			// monthTextBox
			// 
			this.monthTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mileageBindingSource, "Month", true));
			this.monthTextBox.Location = new System.Drawing.Point(101, 117);
			this.monthTextBox.Name = "monthTextBox";
			this.monthTextBox.Size = new System.Drawing.Size(100, 20);
			this.monthTextBox.TabIndex = 6;
			// 
			// yearTextBox
			// 
			this.yearTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mileageBindingSource, "Year", true));
			this.yearTextBox.Location = new System.Drawing.Point(101, 143);
			this.yearTextBox.Name = "yearTextBox";
			this.yearTextBox.Size = new System.Drawing.Size(100, 20);
			this.yearTextBox.TabIndex = 8;
			// 
			// kilometersTextBox
			// 
			this.kilometersTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mileageBindingSource, "Kilometers", true));
			this.kilometersTextBox.Location = new System.Drawing.Point(101, 169);
			this.kilometersTextBox.Name = "kilometersTextBox";
			this.kilometersTextBox.Size = new System.Drawing.Size(100, 20);
			this.kilometersTextBox.TabIndex = 10;
			// 
			// MilEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(322, 290);
			this.Controls.Add(idLabel);
			this.Controls.Add(this.idTextBox);
			this.Controls.Add(setIdLabel);
			this.Controls.Add(this.setIdTextBox);
			this.Controls.Add(monthLabel);
			this.Controls.Add(this.monthTextBox);
			this.Controls.Add(yearLabel);
			this.Controls.Add(this.yearTextBox);
			this.Controls.Add(kilometersLabel);
			this.Controls.Add(this.kilometersTextBox);
			this.Controls.Add(this.mileageBindingNavigator);
			this.Name = "MilEdit";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Пробег";
			this.Load += new System.EventHandler(this.MilEdit_Load);
			((System.ComponentModel.ISupportInitialize)(this.databaseDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mileageBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.mileageBindingNavigator)).EndInit();
			this.mileageBindingNavigator.ResumeLayout(false);
			this.mileageBindingNavigator.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DatabaseDataSet databaseDataSet;
		private System.Windows.Forms.BindingSource mileageBindingSource;
		private DatabaseDataSetTableAdapters.MileageTableAdapter mileageTableAdapter;
		private DatabaseDataSetTableAdapters.TableAdapterManager tableAdapterManager;
		private System.Windows.Forms.BindingNavigator mileageBindingNavigator;
		private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem;
		private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
		private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
		private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
		private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
		private System.Windows.Forms.ToolStripButton mileageBindingNavigatorSaveItem;
		private System.Windows.Forms.TextBox idTextBox;
		private System.Windows.Forms.TextBox setIdTextBox;
		private System.Windows.Forms.TextBox monthTextBox;
		private System.Windows.Forms.TextBox yearTextBox;
		private System.Windows.Forms.TextBox kilometersTextBox;
	}
}