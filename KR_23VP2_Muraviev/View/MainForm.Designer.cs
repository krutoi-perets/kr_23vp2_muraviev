namespace KR_23VP2_Muraviev
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.table_of_data = new System.Windows.Forms.DataGridView();
            this.check_column = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.name_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.category_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price_column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refresh_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.find_name = new System.Windows.Forms.TextBox();
            this.edit_group = new System.Windows.Forms.GroupBox();
            this.delete_button = new System.Windows.Forms.Button();
            this.add_button = new System.Windows.Forms.Button();
            this.close_edit_button = new System.Windows.Forms.Button();
            this.save_edit_button = new System.Windows.Forms.Button();
            this.edit_button = new System.Windows.Forms.Button();
            this.file_menu = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteDBToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.generateReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.opened_db = new System.Windows.Forms.ToolStripMenuItem();
            this.filter_checkbox = new System.Windows.Forms.CheckedListBox();
            this.reset_filter_button = new System.Windows.Forms.Button();
            this.filter_group = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.table_of_data)).BeginInit();
            this.edit_group.SuspendLayout();
            this.file_menu.SuspendLayout();
            this.filter_group.SuspendLayout();
            this.SuspendLayout();
            // 
            // table_of_data
            // 
            this.table_of_data.AllowUserToAddRows = false;
            this.table_of_data.AllowUserToDeleteRows = false;
            this.table_of_data.AllowUserToResizeColumns = false;
            this.table_of_data.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.table_of_data.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.table_of_data.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.table_of_data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.table_of_data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.table_of_data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.check_column,
            this.name_column,
            this.category_column,
            this.amount_column,
            this.price_column});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.table_of_data.DefaultCellStyle = dataGridViewCellStyle3;
            this.table_of_data.Location = new System.Drawing.Point(12, 28);
            this.table_of_data.Name = "table_of_data";
            this.table_of_data.RowHeadersVisible = false;
            this.table_of_data.RowTemplate.Height = 30;
            this.table_of_data.Size = new System.Drawing.Size(653, 202);
            this.table_of_data.TabIndex = 0;
            this.table_of_data.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.table_of_data_CellBeginEdit);
            this.table_of_data.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.table_of_data_CellEndEdit);
            // 
            // check_column
            // 
            this.check_column.Frozen = true;
            this.check_column.HeaderText = "";
            this.check_column.Name = "check_column";
            this.check_column.ReadOnly = true;
            this.check_column.Width = 30;
            // 
            // name_column
            // 
            this.name_column.Frozen = true;
            this.name_column.HeaderText = "Название товара";
            this.name_column.Name = "name_column";
            this.name_column.ReadOnly = true;
            this.name_column.Width = 170;
            // 
            // category_column
            // 
            this.category_column.Frozen = true;
            this.category_column.HeaderText = "Категория";
            this.category_column.Name = "category_column";
            this.category_column.ReadOnly = true;
            this.category_column.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.category_column.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.category_column.Width = 200;
            // 
            // amount_column
            // 
            this.amount_column.Frozen = true;
            this.amount_column.HeaderText = "Количество на складе";
            this.amount_column.Name = "amount_column";
            this.amount_column.ReadOnly = true;
            this.amount_column.Width = 125;
            // 
            // price_column
            // 
            this.price_column.Frozen = true;
            this.price_column.HeaderText = "Цена за единицу";
            this.price_column.Name = "price_column";
            this.price_column.ReadOnly = true;
            this.price_column.Width = 125;
            // 
            // refresh_button
            // 
            this.refresh_button.BackColor = System.Drawing.SystemColors.Control;
            this.refresh_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.refresh_button.Location = new System.Drawing.Point(274, 236);
            this.refresh_button.Name = "refresh_button";
            this.refresh_button.Size = new System.Drawing.Size(131, 36);
            this.refresh_button.TabIndex = 1;
            this.refresh_button.Text = "Обновить таблицу";
            this.refresh_button.UseVisualStyleBackColor = false;
            this.refresh_button.Click += new System.EventHandler(this.refresh_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 248);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Поиск по названию:";
            // 
            // find_name
            // 
            this.find_name.Location = new System.Drawing.Point(146, 245);
            this.find_name.Name = "find_name";
            this.find_name.Size = new System.Drawing.Size(116, 20);
            this.find_name.TabIndex = 3;
            this.find_name.TextChanged += new System.EventHandler(this.find_name_TextChanged);
            // 
            // edit_group
            // 
            this.edit_group.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.edit_group.Controls.Add(this.delete_button);
            this.edit_group.Controls.Add(this.add_button);
            this.edit_group.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edit_group.Location = new System.Drawing.Point(12, 340);
            this.edit_group.Name = "edit_group";
            this.edit_group.Size = new System.Drawing.Size(393, 57);
            this.edit_group.TabIndex = 5;
            this.edit_group.TabStop = false;
            this.edit_group.Text = "Редактирование";
            this.edit_group.Visible = false;
            // 
            // delete_button
            // 
            this.delete_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.delete_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delete_button.Location = new System.Drawing.Point(242, 16);
            this.delete_button.Name = "delete_button";
            this.delete_button.Size = new System.Drawing.Size(131, 35);
            this.delete_button.TabIndex = 1;
            this.delete_button.Text = "Удалить выбранные";
            this.delete_button.UseVisualStyleBackColor = false;
            this.delete_button.Click += new System.EventHandler(this.delete_button_Click);
            // 
            // add_button
            // 
            this.add_button.BackColor = System.Drawing.SystemColors.Control;
            this.add_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.add_button.Location = new System.Drawing.Point(26, 16);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(131, 35);
            this.add_button.TabIndex = 0;
            this.add_button.Text = "Добавить\r\nновый";
            this.add_button.UseVisualStyleBackColor = false;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // close_edit_button
            // 
            this.close_edit_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.close_edit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.close_edit_button.Location = new System.Drawing.Point(221, 285);
            this.close_edit_button.Name = "close_edit_button";
            this.close_edit_button.Size = new System.Drawing.Size(136, 36);
            this.close_edit_button.TabIndex = 6;
            this.close_edit_button.Text = "Отменить изменения";
            this.close_edit_button.UseVisualStyleBackColor = false;
            this.close_edit_button.Visible = false;
            this.close_edit_button.Click += new System.EventHandler(this.close_edit_button_Click);
            // 
            // save_edit_button
            // 
            this.save_edit_button.BackColor = System.Drawing.SystemColors.Control;
            this.save_edit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.save_edit_button.Location = new System.Drawing.Point(60, 285);
            this.save_edit_button.Name = "save_edit_button";
            this.save_edit_button.Size = new System.Drawing.Size(136, 36);
            this.save_edit_button.TabIndex = 7;
            this.save_edit_button.Text = "Сохранить изменения";
            this.save_edit_button.UseVisualStyleBackColor = false;
            this.save_edit_button.Visible = false;
            this.save_edit_button.Click += new System.EventHandler(this.save_edit_button_Click);
            // 
            // edit_button
            // 
            this.edit_button.BackColor = System.Drawing.SystemColors.Control;
            this.edit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.edit_button.Location = new System.Drawing.Point(138, 285);
            this.edit_button.Name = "edit_button";
            this.edit_button.Size = new System.Drawing.Size(131, 36);
            this.edit_button.TabIndex = 8;
            this.edit_button.Text = "Редактировать таблицу";
            this.edit_button.UseVisualStyleBackColor = false;
            this.edit_button.Click += new System.EventHandler(this.edit_button_Click);
            // 
            // file_menu
            // 
            this.file_menu.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.file_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.opened_db});
            this.file_menu.Location = new System.Drawing.Point(0, 0);
            this.file_menu.Name = "file_menu";
            this.file_menu.Size = new System.Drawing.Size(678, 24);
            this.file_menu.TabIndex = 9;
            this.file_menu.Text = "Файл";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.BackColor = System.Drawing.SystemColors.MenuBar;
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createDBToolStripMenuItem,
            this.deleteDBToolStripMenuItem,
            this.toolStripSeparator1,
            this.generateReportToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // createDBToolStripMenuItem
            // 
            this.createDBToolStripMenuItem.Name = "createDBToolStripMenuItem";
            this.createDBToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.createDBToolStripMenuItem.Text = "Создать новую БД";
            this.createDBToolStripMenuItem.Click += new System.EventHandler(this.createDBToolStripMenuItem_Click);
            // 
            // deleteDBToolStripMenuItem
            // 
            this.deleteDBToolStripMenuItem.Name = "deleteDBToolStripMenuItem";
            this.deleteDBToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.deleteDBToolStripMenuItem.Text = "Удалить БД";
            this.deleteDBToolStripMenuItem.Click += new System.EventHandler(this.deleteDBToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(188, 6);
            // 
            // generateReportToolStripMenuItem
            // 
            this.generateReportToolStripMenuItem.Name = "generateReportToolStripMenuItem";
            this.generateReportToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.generateReportToolStripMenuItem.Text = "Сформировать отчет";
            this.generateReportToolStripMenuItem.Click += new System.EventHandler(this.generateReportToolStripMenuItem_Click);
            // 
            // opened_db
            // 
            this.opened_db.ForeColor = System.Drawing.Color.Black;
            this.opened_db.Name = "opened_db";
            this.opened_db.Size = new System.Drawing.Size(121, 20);
            this.opened_db.Text = "<Выберите файл>";
            this.opened_db.Click += new System.EventHandler(this.opened_db_Click);
            // 
            // filter_checkbox
            // 
            this.filter_checkbox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.filter_checkbox.FormattingEnabled = true;
            this.filter_checkbox.Items.AddRange(new object[] {
            "Письменные принадлежности",
            "Бумажная продукция",
            "Архивация и хранение документов",
            "Клейкие и скрепляющие материалы",
            "Чертежные принадлежности",
            "Товары для творчества"});
            this.filter_checkbox.Location = new System.Drawing.Point(6, 19);
            this.filter_checkbox.Name = "filter_checkbox";
            this.filter_checkbox.Size = new System.Drawing.Size(242, 94);
            this.filter_checkbox.TabIndex = 0;
            this.filter_checkbox.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.filter_checkbox_ItemCheck);
            // 
            // reset_filter_button
            // 
            this.reset_filter_button.BackColor = System.Drawing.SystemColors.Control;
            this.reset_filter_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reset_filter_button.Location = new System.Drawing.Point(60, 119);
            this.reset_filter_button.Name = "reset_filter_button";
            this.reset_filter_button.Size = new System.Drawing.Size(131, 36);
            this.reset_filter_button.TabIndex = 10;
            this.reset_filter_button.Text = "Сбросить фильтр";
            this.reset_filter_button.UseVisualStyleBackColor = false;
            this.reset_filter_button.Click += new System.EventHandler(this.reset_filter_button_Click);
            // 
            // filter_group
            // 
            this.filter_group.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filter_group.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.filter_group.Controls.Add(this.filter_checkbox);
            this.filter_group.Controls.Add(this.reset_filter_button);
            this.filter_group.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.filter_group.Location = new System.Drawing.Point(411, 236);
            this.filter_group.Name = "filter_group";
            this.filter_group.Size = new System.Drawing.Size(254, 161);
            this.filter_group.TabIndex = 11;
            this.filter_group.TabStop = false;
            this.filter_group.Text = "Фильтр по категориям";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 409);
            this.Controls.Add(this.filter_group);
            this.Controls.Add(this.edit_button);
            this.Controls.Add(this.save_edit_button);
            this.Controls.Add(this.close_edit_button);
            this.Controls.Add(this.edit_group);
            this.Controls.Add(this.find_name);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.refresh_button);
            this.Controls.Add(this.table_of_data);
            this.Controls.Add(this.file_menu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(694, 448);
            this.Name = "MainForm";
            this.Text = "Учет канцтоваров";
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.table_of_data)).EndInit();
            this.edit_group.ResumeLayout(false);
            this.file_menu.ResumeLayout(false);
            this.file_menu.PerformLayout();
            this.filter_group.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView table_of_data;
        private System.Windows.Forms.Button refresh_button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox find_name;
        private System.Windows.Forms.GroupBox edit_group;
        private System.Windows.Forms.Button delete_button;
        private System.Windows.Forms.Button add_button;
        private System.Windows.Forms.Button close_edit_button;
        private System.Windows.Forms.Button save_edit_button;
        private System.Windows.Forms.Button edit_button;
        private System.Windows.Forms.MenuStrip file_menu;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteDBToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateReportToolStripMenuItem;
        private System.Windows.Forms.CheckedListBox filter_checkbox;
        private System.Windows.Forms.Button reset_filter_button;
        private System.Windows.Forms.DataGridViewCheckBoxColumn check_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn name_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn category_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount_column;
        private System.Windows.Forms.DataGridViewTextBoxColumn price_column;
        private System.Windows.Forms.GroupBox filter_group;
        private System.Windows.Forms.ToolStripMenuItem opened_db;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

