using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using LibraryForForm48;
using Newtonsoft.Json;

namespace WorksPLS
{
    public partial class CPUCreationForm : Form
    {
        private CPU newCpu;
        private string photoFilePath = string.Empty;

        public CPUCreationForm()
        {
            InitializeComponent();
            string folderPath = Path.Combine(Application.StartupPath, "FormFiles");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            InitializeComboBox();
            listBoxCPU.DisplayMember = "DisplayName";
            this.listBoxCPU.SelectedIndexChanged += new System.EventHandler(this.listBoxCPU_SelectedIndexChanged);
            this.button3.Click += new EventHandler(this.button3_Click); // Привязка к кнопке "Сохранить в JSON"
            this.button4.Click += new EventHandler(this.button4_Click); // Привязка к кнопке "Открыть из JSON"
            this.buttonAdjustMaxClock.Click += new EventHandler(this.button5_Click); // Привязка к кнопке "Найти самый мощный"
            this.buttonAdjustMaxClock.Click += new EventHandler(this.buttonAdjustMaxClock_Click);
            this.buttonCalculatePower.Click += new EventHandler(this.buttonCalculatePower_Click); // Кнопка для вычисления мощности
            this.buttonDeadlineGuarantee.Click += new EventHandler(this.buttonDeadlineGuarantee_Click); // Привязка к кнопке "Срок гарантии"
            this.buttonChangeFont.Click += new EventHandler(this.buttonChangeFont_Click);
            this.buttonChangeColor.Click += new EventHandler(this.buttonChangeColor_Click);
            this.FormClosing += new FormClosingEventHandler(CPUCreationForm_FormClosing);

        }

        private void InitializeComboBox()
        {
            comboBox1.Items.Clear();

            List<string> items = new List<string> { "Intel", "AMD", "Apple" };

            foreach (var item in items)
            {
                comboBox1.Items.Add(item);
            }
        }

        private void buttonAddDevice_Click(object sender, EventArgs e)
        {
            // Собираем данные с формы
            string brand = (string)comboBox1.SelectedItem;
            string model = this.textBox1.Text;
            int coreCount = (int)numericUpDown1.Value;
            int threadCount = (int)numericUpDown2.Value;
            int baseLock = (int)numericUpDown3.Value;
            int maxLock = (int)numericUpDown4.Value;
            string socketType = this.textBox2.Text;
            string condition = string.Empty;
            string serialNumber = this.textBoxSerialNumber.Text;
            string yearOfRelease = this.textBoxYearRelease.Text; // Год выпуска из textBoxYearRelease

            // Определяем состояние процессора
            if (radiobuttonAddDevice.Checked)
            {
                condition = radiobuttonAddDevice.Text;
            }
            else if (radioButton2.Checked)
            {
                condition = radioButton2.Text;
            }
            else if (radioButton3.Checked)
            {
                condition = radioButton3.Text;
            }

            // Получаем дату окончания гарантии из DateTimePicker
            DateTime guaranteeEndDate = dateTimePickerGuarantee.Value;

            // Создаем объект CPU с датой окончания гарантии
            newCpu = new CPU(brand, model, coreCount, threadCount, baseLock, maxLock, socketType, condition, guaranteeEndDate, serialNumber);

            // Присваиваем год выпуска и фото через индексатор
            newCpu["YearOfRelease"] = yearOfRelease;
            if (!string.IsNullOrEmpty(photoFilePath))
            {
                newCpu["PhotoPath"] = photoFilePath; // Присваиваем путь к фото через индексатор
            }

            // Добавляем информацию о процессоре в ListBox
            listBoxCPU.Items.Add(newCpu); // Добавляем объект в ListBox
        }


        private void buttonSetPhoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                photoFilePath = openFileDialog1.FileName;
                pictureBox1.Image = System.Drawing.Image.FromFile(photoFilePath);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            }
        }

        private void listBoxCPU_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxCPU.SelectedItem is CPU selectedCpu)
            {
                richTextBoxInfo.Clear();
                string textForRichBox = $"CPU: {selectedCpu.Brand}\n" +
                    $"Модель: {selectedCpu.Model}\n" +
                    $"Сокет: {selectedCpu.SocketType}\n" +
                    $"Количество ядер: {selectedCpu.CoreCount}\n" +
                    $"Количество потоков: {selectedCpu.ThreadCount} \n" +
                    $"Базовая частота: {selectedCpu.BaseClock}\n" +
                    $"Максимальная частота: {selectedCpu.MaxClock}\n" +
                    $"Состояние: {selectedCpu.Condition}\n" +
                    $"Срок гарантии: {selectedCpu.GuaranteeEndDate.ToShortDateString()}\n" +
                    $"Год выпуска: {selectedCpu["YearOfRelease"]}"; // Получаем год выпуска через индексатор
                richTextBoxInfo.Text = textForRichBox;

                // Отображаем фото, если оно есть
                string photoPath = selectedCpu["PhotoPath"];
                if (!string.IsNullOrEmpty(photoPath))
                {
                    pictureBox1.Image = System.Drawing.Image.FromFile(photoPath);
                }
                else
                {
                    pictureBox1.Image = null;
                }
            }
            else
            {
                richTextBoxInfo.Clear();
                richTextBoxInfo.Text = "Выбранный элемент не является процессором.";
            }
        }


        // Обработчик для кнопки "Сохранить в JSON"
        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "JSON Files|*.json|All Files|*.*";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Сохраняем процессоры в JSON файл
                List<CPU> cpus = new List<CPU> { newCpu };
                CPU.SaveToJson(cpus, saveFileDialog1.FileName);
                MessageBox.Show("Данные успешно сохранены в JSON!");
            }
        }

        // Обработчик для кнопки "Открыть из JSON"
        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JSON Files|*.json|All Files|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Загружаем данные из JSON файла
                    List<CPU> cpus = Device.LoadFromJson<CPU>(openFileDialog1.FileName);

                    // Добавляем загруженные процессоры в listBox, не очищая его
                    foreach (var cpu in cpus)
                    {
                        listBoxCPU.Items.Add(cpu); // Добавляем объект CPU в ListBox
                    }

                    MessageBox.Show("Данные успешно загружены из JSON!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
                }
            }
        }


        // Обработчик для кнопки "Срок гарантии"
        private void buttonDeadlineGuarantee_Click(object sender, EventArgs e)
        {
            if (listBoxCPU.SelectedItem is CPU selectedCpu)
            {
                // Получаем дату окончания гарантии из выбранного процессора
                DateTime guaranteeEndDate = selectedCpu.GuaranteeEndDate;

                // Получаем текущую дату
                DateTime currentDate = DateTime.Now;

                // Вычисляем разницу между текущей датой и датой окончания гарантии
                TimeSpan remainingTime = guaranteeEndDate - currentDate;

                string result;

                if (remainingTime.Days >= 0)
                {
                    result = $"Оставшийся срок гарантии: {remainingTime.Days} дней.";
                }
                else
                {
                    result = $"Гарантия истекла {Math.Abs(remainingTime.Days)} дней назад.";
                }

                // Отображаем результат в richTextBoxInfo
                richTextBoxInfo.Text = result;
            }
            else
            {
                MessageBox.Show("Выберите процессор, чтобы узнать срок гарантии!");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Проверяем, есть ли добавленные процессоры в listBox
            if (listBoxCPU.Items.Count == 0)
            {
                richTextBoxInfo.Text = "Нет добавленных процессоров.";
                return;
            }

            CPU mostPowerfulCpu = null;
            double highestPower = double.MinValue;

            // Проходим по всем процессорам в listBoxCPU и ищем самый мощный
            foreach (CPU cpu in listBoxCPU.Items)
            {
                // Вычисляем мощность процессора по формуле
                double power = (cpu.CoreCount * cpu.ThreadCount) * cpu.MaxClock;

                // Если найден процессор с большей мощностью, обновляем
                if (power > highestPower)
                {
                    highestPower = power;
                    mostPowerfulCpu = cpu;
                }
            }

            // Отображаем информацию о самом мощном процессоре в richTextBox1
            if (mostPowerfulCpu != null)
            {
                richTextBoxInfo.Clear();
                richTextBoxInfo.Text = $"Самый мощный процессор:\n" +
                                    $"Производитель: {mostPowerfulCpu.Brand}\n" +
                                    $"Модель: {mostPowerfulCpu.Model}\n" +
                                    $"Количество ядер: {mostPowerfulCpu.CoreCount}\n" +
                                    $"Количество потоков: {mostPowerfulCpu.ThreadCount}\n" +
                                    $"Базовая частота: {mostPowerfulCpu.BaseClock} GHz\n" +
                                    $"Максимальная частота: {mostPowerfulCpu.MaxClock} GHz\n" +
                                    $"Сокет: {mostPowerfulCpu.SocketType}\n" +
                                    $"Мощность: {highestPower}\n" +
                                    $"Состояние: {mostPowerfulCpu.Condition}";
            }
            else
            {
                richTextBoxInfo.Text = "Ошибка при нахождении самого мощного процессора.";
            }
        }

        private void buttonAdjustMaxClock_Click(object sender, EventArgs e)
        {
            if (listBoxCPU.SelectedItem is CPU selectedCpu)
            {
                double oldMaxClock = selectedCpu.MaxClock;
                // Изменяем частоту процессора
                CPU.AdjustMaxClock(ref selectedCpu);

                // Обновляем информацию о процессоре в списке
                listBoxCPU.Items[listBoxCPU.SelectedIndex] = selectedCpu;

                // Отображаем изменения в richTextBox
                richTextBoxInfo.Text = $"Процессор {selectedCpu.Model} обновлен.\n" +
                    $"Максимальная частота до изменений: {oldMaxClock} GHz\n" +
                    $"Максимальная частота теперь: {selectedCpu.MaxClock} GHz";
            }
            else
            {
                MessageBox.Show("Выберите процессор для изменения!");
            }
        }

        private void buttonCalculatePower_Click(object sender, EventArgs e)
        {
            if (listBoxCPU.SelectedItem is CPU selectedCpu)
            {
                // Вычисляем мощность процессора и категорию с использованием out
                double power;
                string powerCategory;

                CPU.CalculateCpuPower(selectedCpu, out power, out powerCategory);

                // Отображаем результаты в richTextBox
                richTextBoxInfo.Text = $"Процессор {selectedCpu.Brand} {selectedCpu.Model} имеет мощность: {power}.\nКатегория мощности: {powerCategory}";
            }
            else
            {
                MessageBox.Show("Выберите процессор для вычисления мощности!");
            }
        }

        private void buttonChangeFont_Click(object sender, EventArgs e)
        {
            // Создаем и настраиваем диалог для выбора шрифта
            using (FontDialog fontDialog = new FontDialog())
            {
                fontDialog.Font = richTextBoxInfo.Font; // Устанавливаем текущий шрифт как начальный
                if (fontDialog.ShowDialog() == DialogResult.OK)
                {
                    // Применяем выбранный шрифт к richTextBoxInfo
                    richTextBoxInfo.Font = fontDialog.Font;
                }
            }
        }

        private void buttonChangeColor_Click(object sender, EventArgs e)
        {
            // Создаем и настраиваем диалог для выбора цвета
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = richTextBoxInfo.ForeColor; // Устанавливаем текущий цвет как начальный
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    // Применяем выбранный цвет к richTextBoxInfo
                    richTextBoxInfo.ForeColor = colorDialog.Color;
                }
            }
        }

        private void CPUCreationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listBoxCPU.Items.Count > 0)
            {
                List<CPU> cpus = new List<CPU>();
                foreach (var item in listBoxCPU.Items)
                {
                    if (item is CPU cpu)
                    {
                        cpus.Add(cpu);
                    }
                }

                string directoryPath = Path.Combine(Application.StartupPath, "FormFiles");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string filePath = Path.Combine(directoryPath, "CPU.json");

                try
                {
                    // Используем встроенный метод класса Device
                    Device.SaveToJson(cpus, filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
