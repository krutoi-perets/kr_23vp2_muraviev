using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations.Model;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace KR_23VP2_Muraviev
{
    /// <summary>
    /// Класс главной формы.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Предыдущее значение ячейки в таблице.
        /// Используется для восстановления значения при некорректном редактировании.
        /// </summary>
        private int oldCellValue;

        /// <summary>
        /// Контроллер для управления логикой работы с товарами.
        /// </summary>
        private ProductController controller;



        /// <summary>
        /// Конструктор формы.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            controller = new ProductController();
        }

        /// <summary>
        /// Создание пустой таблицы базы данных.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void createDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "SQLite Database (*.db)|*.db";
                saveFileDialog.Title = "Создать новую базу данных";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    controller.CreateNewDB(saveFileDialog.FileName);
                    opened_db.Text = Path.GetFileName(saveFileDialog.FileName);
                    ShowAll();
                    MessageBox.Show("База данных успешно создана", "Успех",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при создании базы данных: " + ex.Message, "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Удаление таблицы базы данных.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void deleteDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                var confirm = MessageBox.Show("Вы действительно хотите удалить базу данных?", "Удаление БД",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    controller.DeleteDB();
                    table_of_data.Rows.Clear();

                    opened_db.Text = "<Выберите файл>";
                    MessageBox.Show("База данных успешно удалена", "Удаление БД",
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении базы данных: " + ex.Message, "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Открытие выбранной таблицы базы данных.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void opened_db_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "SQLite Database (*.db)|*.db";
                openFileDialog.Title = "Открыть БД";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    controller.OpenDB(openFileDialog.FileName);
                    opened_db.Text = Path.GetFileName(openFileDialog.FileName);
                    ShowAll();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при открытии базы данных: " + ex.Message, "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Вывод всех элементов из БД.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void refresh_button_Click(object sender, EventArgs e)
        {
            find_name.Text = "";
            ShowAll();
        }

        /// <summary>
        /// Редактирование таблицы.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void edit_button_Click(object sender, EventArgs e)
        {
            if (!controller.DBExist())
            {
                MessageBox.Show("База данных не найдена", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                table_of_data.Rows.Clear();
                return;
            }

            StartEditing();
        }

        /// <summary>
        /// Нажатие на кнопку "Отменить изменения".
        /// Все внесенные изменения не будут сохраняться.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void close_edit_button_Click(object sender, EventArgs e)
        {
            if (!controller.DBExist())
            {
                MessageBox.Show("База данных не найдена", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseEditing();
                table_of_data.Rows.Clear();
                return;
            }

            CloseEditing();
            ShowAll();
        }

        /// <summary>
        /// Нажатие на кнопку "Сохранить изменения".
        /// Все внесенные изменения будут сохранены и внесены в таблицу БД.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void save_edit_button_Click(object sender, EventArgs e)
        {
            try
            {
                var (saved, updated, deleted) = controller.SaveChanges(table_of_data);
                CloseEditing();
                ShowAll();

                MessageBox.Show($"Сохранено: {saved} добавлено, {updated} изменено, {deleted} удалено",
                               "Сохранить изменения", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message, "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Вывод всех элементов из БД.
        /// </summary>
        private void ShowAll()
        {
            if (!controller.DBExist())
            {
                MessageBox.Show("База данных не найдена", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                table_of_data.Rows.Clear();
                return;
            }

            table_of_data.Rows.Clear();

            foreach (var product in controller.LoadAll())
            {
                table_of_data.Rows.Add(
                    false,
                    product.Name,
                    product.Category,
                    $"{product.Amount} шт.",
                    $"{product.Price} руб."
                );
            }
        }

        /// <summary>
        /// Открыть редактирование.
        /// </summary>
        private void StartEditing()
        {
            edit_button.Visible = false;
            close_edit_button.Visible = true;
            save_edit_button.Visible = true;
            edit_group.Visible = true;

            table_of_data.Columns[0].ReadOnly = false;
            table_of_data.Columns[3].ReadOnly = false;
            table_of_data.Columns[4].ReadOnly = false;
        }

        /// <summary>
        /// Закрыть редактирование.
        /// </summary>
        private void CloseEditing()
        {
            edit_button.Visible = true;
            close_edit_button.Visible = false;
            save_edit_button.Visible = false;
            edit_group.Visible = false;

            table_of_data.Columns[0].ReadOnly = true;
            table_of_data.Columns[3].ReadOnly = true;
            table_of_data.Columns[4].ReadOnly = true;
        }

        /// <summary>
        /// Сохранение изначального значения кол-ва/цены.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void table_of_data_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            var cell = table_of_data.Rows[e.RowIndex].Cells[e.ColumnIndex];

            if (cell.Value != null)
            {
                string value = cell.Value.ToString();
                if (e.ColumnIndex == 3) // Количество
                    value = value.Replace(" шт.", "");
                else if (e.ColumnIndex == 4) // Цена
                    value = value.Replace(" руб.", "");

                if (int.TryParse(value, out int parsedValue))
                {
                    oldCellValue = parsedValue;
                    cell.Value = value;
                }
            }
        }

        /// <summary>
        /// Проверка на корректность введенного значения кол-ва/цены.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void table_of_data_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) return;

            var cell = table_of_data.Rows[e.RowIndex].Cells[e.ColumnIndex];
            string input = cell.Value?.ToString().Trim();

            if (!int.TryParse(input, out int result) || result < 0 || string.IsNullOrEmpty(input))
            {
                MessageBox.Show("Введите корректное положительное число");
                if (e.ColumnIndex == 3) // Количество
                    cell.Value = $"{oldCellValue} шт.";
                else if (e.ColumnIndex == 4) // Цена
                    cell.Value = $"{oldCellValue} руб.";
                return;
            }

            if (e.ColumnIndex == 3) // Количество
                cell.Value = $"{result} шт.";
            else if (e.ColumnIndex == 4) // Цена
                cell.Value = $"{result} руб.";

            if (result != oldCellValue)
            {
                if (table_of_data.Rows[e.RowIndex].Tag == null)
                {
                    table_of_data.Rows[e.RowIndex].Tag = "edit";
                    table_of_data.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.PaleGoldenrod;
                }
            }
        }

        /// <summary>
        /// Нажатие на кнопку "Добавить новый".
        /// Открывает форму добавления нового товара.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void add_button_Click(object sender, EventArgs e)
        {
            if (!controller.DBExist())
            {
                MessageBox.Show("База данных не найдена", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseEditing();
                table_of_data.Rows.Clear();
                return;
            }

            using (FormAddItem form = new FormAddItem())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.Height = 30;

                    newRow.Cells.Add(new DataGridViewCheckBoxCell() { Value = false });
                    newRow.Cells.Add(new DataGridViewTextBoxCell() { Value = form.name });
                    newRow.Cells.Add(new DataGridViewTextBoxCell() { Value = form.category });
                    newRow.Cells.Add(new DataGridViewTextBoxCell() { Value = form.amount + " шт." });
                    newRow.Cells.Add(new DataGridViewTextBoxCell() { Value = form.price + " руб." });

                    newRow.DefaultCellStyle.BackColor = Color.LightGreen;
                    newRow.Tag = "new";

                    table_of_data.Rows.Add(newRow);
                }
            }
        }

        /// <summary>
        /// Нажатие на кнопку "Удалить выбранные".
        /// Удаляет выбранные пользователем элементы из таблицы.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void delete_button_Click(object sender, EventArgs e)
        {
            if (!controller.DBExist())
            {
                MessageBox.Show("База данных не найдена", "Ошибка",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                CloseEditing();
                table_of_data.Rows.Clear();
                return;
            }

            bool anySelected = false;

            for (int i = 0; i < table_of_data.Rows.Count; i++)
            {
                var cell = table_of_data.Rows[i].Cells[0];
                if (cell.Value is bool selected && selected)
                {
                    anySelected = true;

                    table_of_data.Rows[i].DefaultCellStyle.BackColor = Color.IndianRed;
                    cell.ReadOnly = true;
                    table_of_data.Rows[i].Tag = "delete";
                }
            }

            if (!anySelected)
            {
                MessageBox.Show("Вы не выбрали ни один элемент", "Удалить выбранные",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Поиск по названию.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void find_name_TextChanged(object sender, EventArgs e)
        {
            string searchText = find_name.Text.Trim().ToLower();

            foreach (DataGridViewRow row in table_of_data.Rows)
            {
                string productName = row.Cells[1].Value?.ToString().ToLower();
                bool isMatch = !string.IsNullOrEmpty(productName) && productName.Contains(searchText);

                row.Visible = string.IsNullOrEmpty(searchText) || isMatch;
            }
        }

        /// <summary>
        /// Нажатие на кнопку "Сбросить фильтр".
        /// Сбрасывает фильтр.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void reset_filter_button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < filter_checkbox.Items.Count; i++)
            {
                filter_checkbox.SetItemChecked(i, false);
            }

            foreach (DataGridViewRow row in table_of_data.Rows)
            {
                row.Visible = true;
            }
        }

        /// <summary>
        /// Смена элемента CheckedListBox.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void filter_checkbox_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)FilterByCategories);
        }

        /// <summary>
        /// Фильтровать по выбранным категориям.
        /// </summary>
        private void FilterByCategories()
        {
            var selectedCategories = filter_checkbox.CheckedItems.Cast<string>().ToList();

            foreach (DataGridViewRow row in table_of_data.Rows)
            {
                if (selectedCategories.Count == 0)
                {
                    row.Visible = true;
                    continue;
                }

                string category = row.Cells[2].Value?.ToString();
                row.Visible = selectedCategories.Contains(category);
            }
        }

        /// <summary>
        /// Формирование отчета в виде PDF-файла с таблицей базы данных.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void generateReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (table_of_data.Rows.Count == 0)
            {
                MessageBox.Show("Нет данных для формирования отчета", "Сформировать отчет",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PDF файл (*.pdf)|*.pdf";
                saveFileDialog.Title = "Сохранить отчет как...";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        controller.GenerateReport(table_of_data, saveFileDialog.FileName);
                        MessageBox.Show("Отчет успешно сформирован и сохранен", "Сформировать отчет",
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при создании отчета: " + ex.Message, "Ошибка",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Обработчик изменения размера главной формы.
        /// </summary>
        /// <param name="sender">Объект, вызвавший событие.</param>
        /// <param name="e">Аргументы события.</param>
        private void MainForm_Resize(object sender, EventArgs e)
        {
            table_of_data.Height = (int)(this.ClientSize.Height * 0.45);
            table_of_data.Columns[0].Width = (int)(table_of_data.Width * 0.05);
            table_of_data.Columns[1].Width = (int)(table_of_data.Width * 0.26);
            table_of_data.Columns[2].Width = (int)(table_of_data.Width * 0.31);
            table_of_data.Columns[3].Width = (int)(table_of_data.Width * 0.19);
            table_of_data.Columns[4].Width = (int)(table_of_data.Width * 0.19);

            refresh_button.Left = (int)(this.ClientSize.Width * 0.4);
            refresh_button.Top = table_of_data.Height + 34;
            label1.Left = refresh_button.Left - 262;
            label1.Top = refresh_button.Top + 12;
            find_name.Left = refresh_button.Left - 128;
            find_name.Top = refresh_button.Top + 9;

            edit_button.Left = refresh_button.Left - 136;
            edit_button.Top = refresh_button.Top + 49;
            save_edit_button.Left = edit_button.Left - 78;
            save_edit_button.Top = edit_button.Top;
            close_edit_button.Left = edit_button.Left + 83;
            close_edit_button.Top = edit_button.Top;

            edit_group.Left = refresh_button.Left - 262;
            edit_group.Top = refresh_button.Top + 104;
            filter_group.Left = refresh_button.Left + 137;
            filter_group.Top = table_of_data.Height + 34;
        }
    }
}
