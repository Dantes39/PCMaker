using LibraryForForm48;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace DynamicFormGenerator
{
    public partial class DynamicForm<T> : Form where T : Device, new()
    {
        public T Instance { get; private set; } // Ссылка на созданный объект
        Type deviceType = typeof(T);
        private List<Device> devices = new List<Device>(); // Список устройств
        private ListBox listBox;
        private RichTextBox richTextBox;
        private Button saveButton;
        private Button loadButton;
        private Button createButton; // Кнопка для создания устройства
        private Button deleteButton; // Кнопка для удаления устройства

        public DynamicForm()
        {
            InitializeDynamicControls(); // Инициализация элементов управления вручную
        }

        // Инициализация динамических элементов управления на форме
        private void InitializeDynamicControls()
        {
            // Выводим тип класса, переданного в качестве параметра
            MessageBox.Show($"Тип переданного класса: {deviceType.Name}");
            // ListBox для отображения созданных объектов
            listBox = new ListBox
            {
                Location = new System.Drawing.Point(15, 15),
                Size = new System.Drawing.Size(250, 120)
            };
            listBox.SelectedIndexChanged += ListBox_SelectedIndexChanged;

            // RichTextBox для отображения информации о выбранном объекте
            richTextBox = new RichTextBox
            {
                Location = new System.Drawing.Point(15, 150),
                Size = new System.Drawing.Size(250, 100)
            };

            // Кнопка для сохранения в файл
            saveButton = new Button
            {
                Text = "Сохранить в файл",
                Location = new System.Drawing.Point(15, 260),
                Size = new System.Drawing.Size(120, 30)
            };
            saveButton.Click += SaveButton_Click;

            // Кнопка для загрузки из файла
            loadButton = new Button
            {
                Text = "Загрузить из файла",
                Location = new System.Drawing.Point(145, 260),
                Size = new System.Drawing.Size(120, 30)
            };
            loadButton.Click += LoadButton_Click;

            // Кнопка для удаления устройства
            deleteButton = new Button
            {
                Text = "Удалить устройство",
                Location = new System.Drawing.Point(15, 300),
                Size = new System.Drawing.Size(250, 30)
            };
            deleteButton.Click += DeleteButton_Click;

            // Кнопка для создания устройства
            createButton = new Button
            {
                Text = "Создать устройство",
                Location = new System.Drawing.Point(15, 340),
                Size = new System.Drawing.Size(250, 30)
            };
            createButton.Click += CreateButton_Click;

            // Добавляем элементы на форму
            Controls.Add(listBox);
            Controls.Add(richTextBox);
            Controls.Add(saveButton);
            Controls.Add(loadButton);
            Controls.Add(createButton);
            Controls.Add(deleteButton);

            // Заполнение формы полями, специфичными для типа T
            FillFormWithFields();
            this.FormClosing += new FormClosingEventHandler(DynamicForm_FormClosing);
        }

        // Метод для добавления динамических полей на форму
        private void FillFormWithFields()
        {
            int yOffset = 380; // Начальная вертикальная позиция для полей (после кнопок)
            var properties = typeof(T).GetProperties();

            foreach (var property in properties)
            {
                Label label = new Label
                {
                    Text = property.Name,
                    Location = new System.Drawing.Point(15, yOffset),
                    Size = new System.Drawing.Size(120, 20)
                };
                Controls.Add(label);

                Control control = CreateControlForProperty(property);
                control.Location = new System.Drawing.Point(140, yOffset);
                control.Tag = property; // Сохраняем информацию о свойстве
                Controls.Add(control);

                yOffset += 30; // Сдвигаем поля для следующего элемента
            }

            // Автоматически изменяем размер формы, чтобы вместить все элементы
            this.ClientSize = new System.Drawing.Size(300, yOffset + 60); // 60 — это отступ для кнопки "Создать"
        }

        // Метод для создания соответствующего контрола на основе типа свойства
        private Control CreateControlForProperty(System.Reflection.PropertyInfo property)
        {
            Control control = null;

            // Создаем контрол в зависимости от типа свойства
            if (property.PropertyType == typeof(string))
            {
                control = new TextBox();
            }
            else if (property.PropertyType == typeof(int))
            {
                control = new NumericUpDown
                {
                    Minimum = int.MinValue,
                    Maximum = int.MaxValue,
                    DecimalPlaces = 0
                };
            }
            else if (property.PropertyType == typeof(double))
            {
                control = new NumericUpDown
                {
                    Minimum = decimal.MinValue,
                    Maximum = decimal.MaxValue,
                    DecimalPlaces = 2
                };
            }
            else if (property.PropertyType == typeof(bool))
            {
                control = new CheckBox();
            }
            else
            {
                control = new TextBox(); // Для всех остальных типов используем TextBox
            }

            control.Size = new System.Drawing.Size(120, 20);
            return control;
        }

        // Обработчик события для создания объекта
        private void CreateButton_Click(object sender, EventArgs e)
        {
            // Создаем объект типа T
            Instance = new T();
            var properties = typeof(T).GetProperties();

            // Заполняем объект значениями из полей формы
            foreach (var property in properties)
            {
                if (property.CanWrite) // Проверка на наличие сеттера
                {
                    var control = Controls.OfType<Control>()
                        .FirstOrDefault(c => c.Tag == property);
                    if (control != null)
                    {
                        object value = null;

                        // Проверяем тип контрола и пытаемся извлечь значение
                        if (control is TextBox textBox)
                        {
                            value = Convert.ChangeType(textBox.Text, property.PropertyType);
                        }
                        else if (control is NumericUpDown numericUpDown)
                        {
                            value = Convert.ChangeType(numericUpDown.Value, property.PropertyType);
                        }
                        else if (control is CheckBox checkBox)
                        {
                            value = checkBox.Checked;
                        }

                        if (value != null)
                        {
                            try
                            {
                                property.SetValue(Instance, value); // Устанавливаем значение свойства
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Ошибка при присваивании значения свойству {property.Name}: {ex.Message}");
                            }
                        }
                    }
                }
            }

            // Добавляем объект в список и обновляем listBox
            devices.Add(Instance);
            listBox.Items.Add(Instance);

            MessageBox.Show("Объект успешно создан!");
        }

        // Обработчик для изменения выбора в ListBox
        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox.SelectedItem is Device selectedDevice)
            {
                richTextBox.Clear();
                richTextBox.Text = selectedDevice.GetInfo();
            }
        }

        // Метод для сохранения списка объектов в файл JSON
        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "JSON Files|*.json|All Files|*.*";

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Сохраняем процессоры в JSON файл
                    Device.SaveToJson(devices, saveFileDialog1.FileName);
                    MessageBox.Show("Данные успешно сохранены в JSON!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении: {ex.Message}");
            }
        }

        // Метод для загрузки объектов из файла JSON
        private void LoadButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JSON Files|*.json|All Files|*.*";

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    List<T> newDevices = Device.LoadFromJson<T>(openFileDialog1.FileName);

                    foreach (var newDevice in newDevices)
                    {
                        devices.Add(newDevice); // Добавление новых устройств в список
                        listBox.Items.Add(newDevice); // Отображение в ListBox
                    }

                    MessageBox.Show("Данные успешно загружены из JSON!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}");
                }
            }
        }

        // Метод для удаления устройства из списка
        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem is Device selectedDevice)
            {
                devices.Remove(selectedDevice); // Удаляем устройство из списка
                listBox.Items.Remove(selectedDevice); // Убираем его из отображения в ListBox
                MessageBox.Show("Устройство удалено!");
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите устройство для удаления.");
            }
        }

        private void DynamicForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listBox.Items.Count > 0)
            {
                string directoryPath = Path.Combine(Application.StartupPath, "FormFiles");
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string filePath = Path.Combine(directoryPath, $"{deviceType.Name}.json");
                try
                {
                    // Используем встроенный метод класса Device
                    Device.SaveToJson(devices, filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }


}
