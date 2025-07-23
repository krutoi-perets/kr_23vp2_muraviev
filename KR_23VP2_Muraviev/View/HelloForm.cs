using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KR_23VP2_Muraviev
{
    /// <summary>
    /// Всплывающее окно с информацией.
    /// </summary>
    public partial class HelloForm: Form
    {
        /// <summary>
        /// Таймер для автоматического закрытия формы.
        /// </summary>
        private Timer timer;



        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public HelloForm()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;

            timer = new Timer();
            timer.Interval = 3000;
            timer.Tick += (sender, e) =>
            {
                timer.Stop();
                this.Close();
            };
        }

        /// <summary>
        /// Загрузка формы.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void HelloForm_Load(object sender, EventArgs e)
        {
            timer.Start();
        }
    }
}
