using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace KR_23VP2_Muraviev
{
    /// <summary>
    /// Класс формы для добавления товаров.
    /// </summary>
    public partial class FormAddItem : Form
    {
        /// <summary>
        /// Название товара.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Категория товара.
        /// </summary>
        public string category { get; set; }

        /// <summary>
        /// Количество товара на складе.
        /// </summary>
        public int amount { get; set; }

        /// <summary>
        /// Цена за единицу товара.
        /// </summary>
        public int price { get; set; }



        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public FormAddItem()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }

        /// <summary>
        /// Нажатие на кнопку "Добавить".
        /// Сохраняет введенные пользователем данные и передает их основной форме.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void add_button_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(name_input.Text) && category_input.SelectedIndex > -1)
            {
                name = name_input.Text;
                category = category_input.Text;
                amount = (int)amount_input.Value;
                price = (int)price_input.Value;

                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Введите корректные данные!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
