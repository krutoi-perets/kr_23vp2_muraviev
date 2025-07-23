using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text.pdf.parser;

namespace KR_23VP2_Muraviev
{
    /// <summary>
    /// Класс-помощник для работы с базой данных SQLite и генерацией PDF-отчётов.
    /// </summary>
    class DBHelper
    {
        /// <summary>
        /// Путь к файлу базы данных SQLite.
        /// Используется для подключения к текущей базе данных проекта.
        /// </summary>
        private string dbPath;



        /// <summary>
        /// Возвращает текущий путь к базе данных.
        /// </summary>
        /// <returns>Путь к файлу базы данных.</returns>
        public string GetPath()
        {
            return dbPath;
        }

        /// <summary>
        /// Проверяет, существует ли база данных по текущему пути.
        /// </summary>
        /// <returns>true, если файл существует, иначе false.</returns>
        public bool IsDBExist()
        {
            if (string.IsNullOrEmpty(dbPath) || !File.Exists(dbPath))
                return false;
            return true;
        }

        /// <summary>
        /// Создаёт новую базу данных по указанному пути.
        /// Если файл уже существует — он будет удалён.
        /// Создаётся таблица products.
        /// </summary>
        /// <param name="path">Полный путь для создания базы данных.</param>
        public void CreateDB(string path)
        {
            dbPath = path;

            if (File.Exists(dbPath))
                File.Delete(dbPath);

            SQLiteConnection.CreateFile(dbPath);

            using (SQLiteConnection conn = new SQLiteConnection($"Data Source={dbPath}"))
            {
                conn.Open();

                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS products (
                    id INTEGER PRIMARY KEY AUTOINCREMENT,
                    name TEXT NOT NULL,
                    category TEXT NOT NULL,
                    amount INTEGER NOT NULL,
                    price INTEGER NOT NULL
                );";

                using (SQLiteCommand cmd = new SQLiteCommand(createTableQuery, conn))
                {
                    cmd.ExecuteNonQuery();
                }

                conn.Close();
            }
        }

        /// <summary>
        /// Удаляет текущую базу данных и сбрасывает путь.
        /// </summary>
        public void DeleteCurDB()
        {
            File.Delete(dbPath);
            dbPath = null;
        }

        /// <summary>
        /// Открывает существующую базу данных по указанному пути.
        /// </summary>
        /// <param name="path">Путь к существующему файлу базы данных.</param>
        /// <exception cref="Exception">Если файл не найден.</exception>
        public void OpenSelectedDB(string path)
        {
            if (!File.Exists(path))
                throw new Exception("Файл базы данных не найден.");
            dbPath = path;
        }

        /// <summary>
        /// Загружает все записи товаров из базы данных.
        /// </summary>
        /// <returns>Список товаров.</returns>
        public List<Product> GetAll()
        {
            var products = new List<Product>();

            using (var conn = new SQLiteConnection($"Data Source={dbPath}"))
            {
                conn.Open();
                string query = "SELECT Name, Category, Amount, Price FROM products";

                using (var cmd = new SQLiteCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        products.Add(new Product
                        {
                            Name = reader.GetString(0),
                            Category = reader.GetString(1),
                            Amount = reader.GetInt32(2),
                            Price = reader.GetInt32(3)
                        });
                    }
                }
            }

            return products;
        }

        /// <summary>
        /// Сохраняет список товаров в базу данных.
        /// Добавляет, обновляет или удаляет записи в зависимости от значения поля Tag у товара.
        /// </summary>
        /// <param name="products">Список товаров для обработки.</param>
        /// <returns>Кортеж с количеством добавленных, обновлённых и удалённых записей.</returns>
        /// <exception cref="Exception">Если база данных не существует.</exception>
        public (int saved, int updated, int deleted) SaveAll(List<Product> products)
        {
            if (string.IsNullOrEmpty(dbPath) || !File.Exists(dbPath))
            {
                throw new Exception("База данных не найдена");
            }

            int saved = 0, updated = 0, deleted = 0;

            using (var conn = new SQLiteConnection($"Data Source={dbPath}"))
            {
                conn.Open();

                foreach (var product in products)
                {
                    switch (product.Tag)
                    {
                        case "new":
                            string insertQuery = @"
                                INSERT INTO products (Name, Category, Amount, Price)
                                VALUES (@Name, @Category, @Amount, @Price)";
                            using (var cmd = new SQLiteCommand(insertQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@Name", product.Name);
                                cmd.Parameters.AddWithValue("@Category", product.Category);
                                cmd.Parameters.AddWithValue("@Amount", product.Amount);
                                cmd.Parameters.AddWithValue("@Price", product.Price);
                                cmd.ExecuteNonQuery();
                                saved++;
                            }
                            break;

                        case "delete":
                            string deleteQuery = "DELETE FROM products WHERE Name = @Name";
                            using (var cmd = new SQLiteCommand(deleteQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@Name", product.Name);
                                cmd.ExecuteNonQuery();
                                deleted++;
                            }
                            break;

                        case "edit":
                            string updateQuery = @"
                                UPDATE products
                                SET Category = @Category, Amount = @Amount, Price = @Price
                                WHERE Name = @Name";
                            using (var cmd = new SQLiteCommand(updateQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@Name", product.Name);
                                cmd.Parameters.AddWithValue("@Category", product.Category);
                                cmd.Parameters.AddWithValue("@Amount", product.Amount);
                                cmd.Parameters.AddWithValue("@Price", product.Price);
                                cmd.ExecuteNonQuery();
                                updated++;
                            }
                            break;
                    }
                }
            }

            return (saved, updated, deleted);
        }

        /// <summary>
        /// Генерирует PDF-отчёт по товарам и сохраняет его в файл.
        /// </summary>
        /// <param name="products">Список товаров для отчёта.</param>
        /// <param name="filePath">Путь для сохранения PDF-файла.</param>
        public void GeneratePdfReport(List<Product> products, string filePath)
        {
            string fontPath = System.IO.Path.Combine(Application.StartupPath, "Fonts", "arial.ttf");
            BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            iTextSharp.text.Font titleFont = new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font cellFont = new iTextSharp.text.Font(baseFont, 12);

            Document doc = new Document(PageSize.A4, 20, 20, 20, 20);
            PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
            doc.Open();

            Paragraph title = new Paragraph("Учет канцтоваров", titleFont);
            title.Alignment = Element.ALIGN_CENTER;
            title.SpacingAfter = 20;
            doc.Add(title);

            PdfPTable pdfTable = new PdfPTable(4);
            pdfTable.WidthPercentage = 100;

            string[] headers = { "Название товара", "Категория", "Количество на складе", "Цена за единицу" };
            foreach (string header in headers)
            {
                PdfPCell cell = new PdfPCell(new Phrase(header, cellFont))
                {
                    BackgroundColor = new BaseColor(100, 255, 100),
                    HorizontalAlignment = Element.ALIGN_CENTER
                };
                pdfTable.AddCell(cell);
            }

            foreach (Product p in products)
            {
                pdfTable.AddCell(new Phrase(p.Name, cellFont));
                pdfTable.AddCell(new Phrase(p.Category, cellFont));
                pdfTable.AddCell(new Phrase(p.Amount.ToString() + " шт.", cellFont));
                pdfTable.AddCell(new Phrase(p.Price.ToString() + " руб.", cellFont));
            }

            doc.Add(pdfTable);
            doc.Close();
        }
    }
}
