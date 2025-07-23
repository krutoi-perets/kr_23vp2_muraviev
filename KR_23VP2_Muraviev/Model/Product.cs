using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR_23VP2_Muraviev
{
    /// <summary>
    /// Представляет товар на складе.
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Название товара.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Категория товара.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Количество товара на складе.
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Цена за единицу товара.
        /// </summary>
        public int Price { get; set; }

        /// <summary>
        /// Тег состояния строки (new, edit, delete).
        /// </summary>
        public string Tag { get; set; }
    }
}
