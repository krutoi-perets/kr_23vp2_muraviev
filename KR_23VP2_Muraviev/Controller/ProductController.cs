using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KR_23VP2_Muraviev
{
    /// <summary>
    /// Контроллер для работы с товарами и базой данных.
    /// </summary>
    public class ProductController
    {
        /// <summary>
        /// Объект-помощник для работы с базой данных.
        /// </summary>
        private DBHelper dbHelper;



        /// <summary>
        /// Конструктор класса.
        /// </summary>
        public ProductController()
        {
            dbHelper = new DBHelper();
        }

        /// <summary>
        /// Проверяет, существует ли текущая база данных.
        /// </summary>
        /// <returns>true, если база данных существует, иначе false.</returns>
        public bool DBExist()
        {
            return dbHelper.IsDBExist();
        }

        /// <summary>
        /// Создаёт новую базу данных.
        /// </summary>
        /// <param name="path">Полный путь для создания файла базы данных.</param>
        public void CreateNewDB(string path)
        {
            dbHelper.CreateDB(path);
        }

        /// <summary>
        /// Удаляет текущую базу данных.
        /// </summary>
        public void DeleteDB()
        {
            dbHelper.DeleteCurDB();
        }

        /// <summary>
        /// Открывает выбранную базу данных.
        /// </summary>
        /// <param name="path">Полный путь к файлу базы данных для открытия.</param>
        public void OpenDB(string path)
        {
            dbHelper.OpenSelectedDB(path);
        }

        /// <summary>
        /// Сохраняет изменения списка товаров в базе данных.
        /// </summary>
        /// <param name="dataGridView">Таблица с исходными данными.</param>
        /// <returns>Кортеж с количеством сохранённых, обновлённых и удалённых записей.</returns>
        public (int saved, int updated, int deleted) SaveChanges(DataGridView dataGridView)
        {
            var productList = new List<Product>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                string name = row.Cells[1].Value?.ToString();
                string category = row.Cells[2].Value?.ToString();
                string amountStr = row.Cells[3].Value?.ToString().Replace(" шт.", "");
                string priceStr = row.Cells[4].Value?.ToString().Replace(" руб.", "");

                if (!int.TryParse(amountStr, out int amount) || !int.TryParse(priceStr, out int price))
                    continue;

                string tag = row.Tag?.ToString();

                productList.Add(new Product{
                    Name = name,
                    Category = category,
                    Amount = amount,
                    Price = price,
                    Tag = tag 
                });
            }

            return dbHelper.SaveAll(productList);
        }

        /// <summary>
        /// Загружает все товары из базы данных.
        /// </summary>
        /// <returns>Список всех товаров.</returns>
        public List<Product> LoadAll()
        {
            return dbHelper.GetAll();
        }

        /// <summary>
        /// Извлекает список товаров из таблицы DataGridView.
        /// </summary>
        /// <returns>Список товаров, соответствующих строкам таблицы.</returns>
        public List<Product> GetProductsFromTable(DataGridView dataGridView)
        {
            List<Product> products = new List<Product>();

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                products.Add(new Product
                {
                    Name = row.Cells[1].Value?.ToString(),
                    Category = row.Cells[2].Value?.ToString(),
                    Amount = Convert.ToInt32(row.Cells[3].Value?.ToString().Replace(" шт.", "")),
                    Price = Convert.ToInt32(row.Cells[4].Value?.ToString().Replace(" руб.", ""))
                });
            }

            return products;
        }

        /// <summary>
        /// Генерирует PDF-отчёт по списку товаров и сохраняет его в указанный файл.
        /// </summary>
        /// <param name="dataGridView">Таблица с исходными данными.</param>
        /// <param name="filePath">Путь для сохранения PDF-файла.</param>
        public void GenerateReport(DataGridView dataGridView, string filePath)
        {
            List<Product> products = GetProductsFromTable(dataGridView);
            dbHelper.GeneratePdfReport(products, filePath);
        }
    }

}
