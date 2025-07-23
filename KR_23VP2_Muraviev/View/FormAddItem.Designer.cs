namespace KR_23VP2_Muraviev
{
    partial class FormAddItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddItem));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.name_input = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.category_input = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.amount_input = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.price_input = new System.Windows.Forms.NumericUpDown();
            this.add_button = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.amount_input)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.price_input)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(98, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите данные";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Название товара";
            // 
            // name_input
            // 
            this.name_input.Location = new System.Drawing.Point(160, 39);
            this.name_input.Name = "name_input";
            this.name_input.Size = new System.Drawing.Size(130, 20);
            this.name_input.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Категория";
            // 
            // category_input
            // 
            this.category_input.FormattingEnabled = true;
            this.category_input.Items.AddRange(new object[] {
            "Письменные принадлежности",
            "Бумажная продукция",
            "Архивация и хранение документов",
            "Клейкие и скрепляющие материалы",
            "Чертежные принадлежности",
            "Товары для творчества"});
            this.category_input.Location = new System.Drawing.Point(160, 74);
            this.category_input.Name = "category_input";
            this.category_input.Size = new System.Drawing.Size(130, 21);
            this.category_input.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Количество на складе";
            // 
            // amount_input
            // 
            this.amount_input.Location = new System.Drawing.Point(160, 110);
            this.amount_input.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.amount_input.Name = "amount_input";
            this.amount_input.Size = new System.Drawing.Size(130, 20);
            this.amount_input.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(12, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(107, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Цена за единицу";
            // 
            // price_input
            // 
            this.price_input.Location = new System.Drawing.Point(160, 144);
            this.price_input.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.price_input.Name = "price_input";
            this.price_input.Size = new System.Drawing.Size(130, 20);
            this.price_input.TabIndex = 8;
            // 
            // add_button
            // 
            this.add_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.add_button.Location = new System.Drawing.Point(101, 181);
            this.add_button.Name = "add_button";
            this.add_button.Size = new System.Drawing.Size(101, 34);
            this.add_button.TabIndex = 9;
            this.add_button.Text = "Добавить";
            this.add_button.UseVisualStyleBackColor = true;
            this.add_button.Click += new System.EventHandler(this.add_button_Click);
            // 
            // FormAddItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 225);
            this.Controls.Add(this.add_button);
            this.Controls.Add(this.price_input);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.amount_input);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.category_input);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.name_input);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormAddItem";
            this.Text = "Добавить новый";
            ((System.ComponentModel.ISupportInitialize)(this.amount_input)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.price_input)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox name_input;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox category_input;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown amount_input;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown price_input;
        private System.Windows.Forms.Button add_button;
    }
}