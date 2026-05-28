using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab11
{
    public partial class Form1 : Form
    {
        private string baseFolder;
        private string logoFolder;

        DataSet dataSet1 = new DataSet();
        DataTable tableUniversities = new DataTable("Universities");

        DataTable dtReport1 = new DataTable();
        DataTable dtReport2 = new DataTable();

        private int currentTableMode = 0;

        public Form1()
        {
            InitializeComponent();

            string startupPath = Application.StartupPath;
            DirectoryInfo projectDir = Directory.GetParent(startupPath)?.Parent;

            if (projectDir != null)
            {
                baseFolder = projectDir.FullName;
            }
            else
            {
                baseFolder = startupPath;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictBox1.SizeMode = PictureBoxSizeMode.Zoom;
            logoFolder = Path.Combine(baseFolder, "IMG");
            string fullDbPath = Path.Combine(baseFolder, "Database.accdb");

            if (!File.Exists(fullDbPath))
            {
                MessageBox.Show($"Критична помилка! Базу даних не знайдено",
                                "Файл не знайдено", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            oleDbConnection1.ConnectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={fullDbPath};";

            try
            {
                oleDbDataAdapter1.SelectCommand = new OleDbCommand("SELECT * FROM Universities", oleDbConnection1);
                OleDbCommandBuilder builder = new OleDbCommandBuilder(oleDbDataAdapter1);

                dataSet1.Tables.Add(tableUniversities);
                oleDbDataAdapter1.Fill(tableUniversities);

                dataGridView1.DataSource = tableUniversities.DefaultView;
                currentTableMode = 0;

                if (dataGridView1.Columns.Contains("IMG"))
                {
                    dataGridView1.Columns["IMG"].Visible = false;
                }

                // ПОВНИЙ ЗАХИСТ ВІД РУЧНОГО ВВЕДЕННЯ: Робимо всі поля доступними тільки для читання
                txtBox1.ReadOnly = true;
                txtBox2.ReadOnly = true;
                txtBox3.ReadOnly = true;
                txtBox4.ReadOnly = true;

                this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
                this.txtBox4.TextChanged += new System.EventHandler(this.txtBox4_TextChanged);

                UpdateUniversityLogo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка завантаження бази даних: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictBox1_Click(object sender, EventArgs e)
        {
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtBoxSearch.Text.Trim();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                MessageBox.Show("Введіть текст для пошуку!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (currentTableMode == 1)
            {
                DataView dv1 = new DataView(dtReport1);
                dv1.RowFilter = $"[Університет] LIKE '%{searchText}%'";
                dataGridView1.DataSource = dv1;
                return;
            }

            if (currentTableMode == 2)
            {
                DataView dv2 = new DataView(dtReport2);
                dv2.RowFilter = $"[Університет] LIKE '%{searchText}%'";
                dataGridView1.DataSource = dv2;
                return;
            }

            dataGridView1.DataSource = tableUniversities.DefaultView;
            string searchPattern = "%" + searchText + "%";
            string query = "SELECT * FROM Universities WHERE City LIKE ? OR UniName LIKE ?";

            OleDbCommand searchCmd = new OleDbCommand(query, oleDbConnection1);
            searchCmd.Parameters.AddWithValue("@City", searchPattern);
            searchCmd.Parameters.AddWithValue("@UniName", searchPattern);

            try
            {
                tableUniversities.Clear();
                oleDbDataAdapter1.SelectCommand = searchCmd;
                oleDbDataAdapter1.Fill(tableUniversities);

                if (dataGridView1.Columns.Contains("IMG"))
                {
                    dataGridView1.Columns["IMG"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка пошуку в базі даних: " + ex.Message);
            }
        }

        private void buttonReport1_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT Universities.UniName AS [Університет], 
                       Faculties.FacultyName AS [Факультет], 
                       Specialties.SpecCode AS [Код спеціальності], 
                       Specialties.SpecName AS [Назва спеціальності],
                       Universities.IMG AS [IMG]
                FROM (Universities 
                INNER JOIN Faculties ON Universities.ID_University = Faculties.ID_University) 
                INNER JOIN Specialties ON Faculties.ID_Faculty = Specialties.ID_Faculty";

            try
            {
                OleDbDataAdapter reportAdapter = new OleDbDataAdapter(query, oleDbConnection1);
                dtReport1 = new DataTable();
                reportAdapter.Fill(dtReport1);

                DataView dv = new DataView(dtReport1);

                if (!string.IsNullOrWhiteSpace(txtBoxSearch.Text))
                {
                    dv.RowFilter = $"[Університет] LIKE '%{txtBoxSearch.Text.Trim()}%'";
                }

                dataGridView1.DataSource = dv;
                currentTableMode = 1;

                if (dataGridView1.Columns.Contains("IMG")) dataGridView1.Columns["IMG"].Visible = false;
                UpdateUniversityLogo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка побудови звіту №1: " + ex.Message);
            }
        }

        private void buttonReport2_Click(object sender, EventArgs e)
        {
            string query = @"
                SELECT Universities.UniName AS [Університет],
                       Specialties.SpecCode AS [Код спеціальності], 
                       Specialties.SpecName AS [Назва спеціальності], 
                       Specialties.Price AS [Вартість навчання],
                       Universities.IMG AS [IMG]
                FROM (Universities 
                INNER JOIN Faculties ON Universities.ID_University = Faculties.ID_University)
                INNER JOIN Specialties ON Faculties.ID_Faculty = Specialties.ID_Faculty
                ORDER BY Specialties.Price DESC";

            try
            {
                OleDbDataAdapter reportAdapter = new OleDbDataAdapter(query, oleDbConnection1);
                dtReport2 = new DataTable();
                reportAdapter.Fill(dtReport2);

                DataView dv = new DataView(dtReport2);

                if (!string.IsNullOrWhiteSpace(txtBoxSearch.Text))
                {
                    dv.RowFilter = $"[Університет] LIKE '%{txtBoxSearch.Text.Trim()}%'";
                }

                dataGridView1.DataSource = dv;
                currentTableMode = 2;

                if (dataGridView1.Columns.Contains("IMG")) dataGridView1.Columns["IMG"].Visible = false;
                UpdateUniversityLogo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка побудови звіту №2: " + ex.Message);
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            txtBoxSearch.Clear();
            currentTableMode = 0;

            tableUniversities.DefaultView.RowFilter = "";
            dataGridView1.DataSource = tableUniversities.DefaultView;

            oleDbDataAdapter1.SelectCommand = new OleDbCommand("SELECT * FROM Universities", oleDbConnection1);
            tableUniversities.Clear();
            oleDbDataAdapter1.Fill(tableUniversities);

            if (dataGridView1.Columns.Contains("IMG"))
            {
                dataGridView1.Columns["IMG"].Visible = false;
            }
            UpdateUniversityLogo();
        }

        // ОНОВЛЕНИЙ СКРІЗНИЙ ПОШУК ДАНИХ
        private void UpdateUniversityLogo()
        {
            if (dataGridView1.CurrentRow == null || dataGridView1.CurrentRow.IsNewRow)
            {
                pictBox1.Image = null;
                txtBox1.Clear(); txtBox2.Clear(); txtBox3.Clear(); txtBox4.Clear();
                return;
            }
            try
            {
                string uniName = "";
                string city = "";
                string ownership = "";
                string imageName = "";

                // 1. Отримуємо назву університету з поточного рядка DataGridView (назва колонки залежить від режиму)
                if (currentTableMode == 0)
                {
                    uniName = dataGridView1.CurrentRow.Cells["UniName"].Value?.ToString();
                }
                else
                {
                    uniName = dataGridView1.CurrentRow.Cells["Університет"].Value?.ToString();
                }

                // 2. Розумний пошук: шукаємо оригінальний повний рядок у tableUniversities за назвою закладу
                if (!string.IsNullOrEmpty(uniName))
                {
                    DataRow[] rows = tableUniversities.Select($"UniName = '{uniName.Replace("'", "''")}'");
                    if (rows.Length > 0)
                    {
                        // Якщо знайшли — витягуємо абсолютно всі дані, навіть якщо ми у вікні звітів!
                        city = rows[0]["City"]?.ToString();
                        ownership = rows[0]["Ownership"]?.ToString();
                        imageName = rows[0]["IMG"]?.ToString();
                    }
                }

                // Якщо через пошук по базі назва зображення порожня, пробуємо взяти напряму з гріда як запасний варіант
                if (string.IsNullOrEmpty(imageName))
                {
                    if (dataGridView1.Columns.Contains("IMG")) imageName = dataGridView1.CurrentRow.Cells["IMG"].Value?.ToString();
                    if (string.IsNullOrEmpty(imageName)) imageName = txtBox4.Text;
                }

                // 3. Синхронно заповнюємо всі текстові поля програми
                txtBox1.Text = uniName;
                txtBox2.Text = city;
                txtBox3.Text = ownership;
                txtBox4.Text = imageName;

                // 4. Завантаження самого графічного файлу логотипу
                if (string.IsNullOrWhiteSpace(imageName)) { ShowNoLogo(); return; }

                imageName = imageName.Trim();
                string pureName = Path.GetFileNameWithoutExtension(imageName);

                string[] possibleFiles = new string[] {
                    Path.Combine(logoFolder, imageName),
                    Path.Combine(logoFolder, pureName + ".jpg"),
                    Path.Combine(logoFolder, pureName + ".png"),
                    Path.Combine(logoFolder, pureName + ".jpeg")
                };

                string finalImagePath = null;
                foreach (string path in possibleFiles) { if (File.Exists(path)) { finalImagePath = path; break; } }

                if (finalImagePath != null)
                {
                    if (pictBox1.Image != null) pictBox1.Image.Dispose();
                    using (var stream = new FileStream(finalImagePath, FileMode.Open, FileAccess.Read))
                    {
                        pictBox1.Image = Image.FromStream(stream);
                    }
                }
                else { ShowNoLogo(); }
            }
            catch { pictBox1.Image = null; }
        }

        private void ShowNoLogo()
        {
            string noLogoPath = Path.Combine(logoFolder, "no_logo.jpg");
            if (File.Exists(noLogoPath))
            {
                if (pictBox1.Image != null) pictBox1.Image.Dispose();
                using (var stream = new FileStream(noLogoPath, FileMode.Open, FileAccess.Read))
                {
                    pictBox1.Image = Image.FromStream(stream);
                }
            }
            else { pictBox1.Image = null; }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e) { UpdateUniversityLogo(); }
        private void txtBox4_TextChanged(object sender, EventArgs e) { UpdateUniversityLogo(); }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (dataGridView1.DataSource == tableUniversities.DefaultView)
                    oleDbDataAdapter1.Update(tableUniversities);
            }
            catch { }
        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            DialogResult r = MessageBox.Show("Вилучити цей навчальний заклад з бази даних?", "Видалення запису", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (r == DialogResult.Cancel) e.Cancel = true;
        }
    }
}