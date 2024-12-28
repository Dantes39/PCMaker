using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryForForm48;
using DynamicFormGenerator;
using System.Security.Cryptography.X509Certificates;
using System.CodeDom;

namespace WorksPLS
{
    public partial class PCcreationForm : Form
    {
        int countPressingCPU = 0;
        int countPressingRAM = 0;
        int countPressingHDD = 0;
        int countPressingGPU = 0;
        int countPressingMotherboard = 0;
        int countPressingPowerSupply = 0;

        // Список для хранения созданных компьютеров

        public static string directoryPath = Path.Combine(Application.StartupPath, "FormFiles");

        private List<Computer> createdComputers = new List<Computer> ();


        public PCcreationForm()
        {
            InitializeComponent();
            listBoxInfo.DisplayMember = "DisplayName";

            string folderPath = Path.Combine(Application.StartupPath, "FormFiles");
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            try
            {
                createdComputers = Computer.LoadFromJson<Computer>(Path.Combine(directoryPath, "PC.json"));
            }
            catch { }

            listBox_AddList(listBoxInfo, createdComputers);

            this.buttonCreateComputer.Click += new System.EventHandler(this.buttonCreateComputer_Click);
            this.buttonShowComputers.Click += new System.EventHandler(this.buttonShowComputers_Click);
            this.listBoxInfo.SelectedIndexChanged += new System.EventHandler(this.listBoxInfo_SelectedIndexChanged);
            buttonSetCPU.Click += (sender, e) => ButtonSetDevice_Click<CPU>(sender, e, textBoxCPU, ref countPressingCPU, "CPU.json");
            buttonSetRAM.Click += (sender, e) => ButtonSetDevice_Click<RAM>(sender, e, textBoxRAM, ref countPressingRAM, "RAM.json");
            buttonSetHDD.Click += (sender, e) => ButtonSetDevice_Click<HDD>(sender, e, textBoxHDD, ref countPressingHDD, "HDD.json");
            buttonSetGPU.Click += (sender, e) => ButtonSetDevice_Click<GPU>(sender, e, textBoxGPU, ref countPressingGPU, "GPU.json");
            buttonSetMotherboard.Click += (sender, e) => ButtonSetDevice_Click<Motherboard>(sender, e, textBoxMotherboard, ref countPressingMotherboard, "Motherboard.json");
            buttonSetPowerSupply.Click += (sender, e) => ButtonSetDevice_Click<PowerSupply>(sender, e, textBoxPowerSupply, ref countPressingPowerSupply, "PowerSupply.json");
            this.FormClosing += new FormClosingEventHandler(this.PCcreationForm_FormClosing);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChoiseMakerForm newForm = new ChoiseMakerForm();
            newForm.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void ButtonSetDevice_Click<T>(object sender, EventArgs e, TextBox textBox, ref int countPressing, string fileName) where T : Device
        {
            countPressing++;
            string filePath = Path.Combine(directoryPath, fileName);
            List<T> devices = Device.LoadFromJson<T>(filePath);
            Type deviceType = typeof(T);

            if (countPressing < 2)
            {
                try
                {
                    listBoxInfo.Items.Clear();

                    // Проверяем, есть ли устройства
                    if (devices.Count > 0)
                    {
                        listBox_AddList(listBoxInfo, devices);
                    }
                    else
                    {
                        countPressing--;
                        MessageBox.Show($"Файл JSON пуст или не содержит данных для {typeof(T).Name}.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    countPressing--;
                    MessageBox.Show($"Ошибка при загрузке данных для {typeof(T).Name}: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (countPressing == 2)
            {
                if ((listBoxInfo.SelectedItem is T selectedDevice))
                {
                    textBox.BackColor = Color.Green;
                    textBox.ForeColor = Color.White;
                    textBox.Text = selectedDevice.DisplayName;
                    textBox.Tag = selectedDevice;
                }
            }
            else
            {
                textBox.BackColor = Color.White;
                textBox.Text = string.Empty;
                textBox.Tag = null;
                countPressing = 1;
                listBox_AddList(listBoxInfo, devices);
            }
        }

        private void buttonCreateComputer_Click(object sender, EventArgs e)
        {
            // Проверяем, что все обязательные устройства выбраны
            var cpu = textBoxCPU.Tag as CPU;
            var ram = textBoxRAM.Tag as RAM;
            var hdd = textBoxHDD?.Tag as HDD; // Добавляем проверку для HDD (если текстбокс есть)
            var gpu = textBoxGPU?.Tag as GPU; // Аналогично для GPU
            var motherboard = textBoxMotherboard?.Tag as Motherboard; // Аналогично для материнской платы
            var powerSupply = textBoxPowerSupply?.Tag as PowerSupply; // Аналогично для блока питания

            // Собираем список ошибок, если какие-то компоненты не выбраны
            var errors = new List<string>();
            if (cpu == null) errors.Add("Процессор (CPU)");
            if (ram == null) errors.Add("Оперативная память (RAM)");
            if (hdd == null) errors.Add("Жесткий диск (HDD)");
            if (motherboard == null) errors.Add("Материнская плата");
            if (powerSupply == null) errors.Add("Блок питания");
            // GPU можно сделать необязательными, убрав их из списка ошибок

            if (errors.Count > 0)
            {
                // Если есть ошибки, показываем пользователю список
                MessageBox.Show($"Не выбраны следующие компоненты: {string.Join(", ", errors)}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Создаем новый компьютер с выбранными компонентами
            var newComputer = new Computer(
                displayName: "NEW PC ",
                serialNumber: "3242",
                cpu: cpu,
                ram: ram,
                hdd: hdd,           // HDD может быть null
                gpu: gpu,           // GPU может быть null
                motherboard: motherboard,
                powerSupply: powerSupply
            );

            // Добавляем созданный компьютер в список
            createdComputers.Add(newComputer);

            // Информируем пользователя
            MessageBox.Show($"Компьютер успешно создан с компонентами:\n{newComputer.GetInfo()}", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Обновляем ListBox
            listBox_AddList(listBoxInfo, createdComputers);
        }


        // Метод для отображения всех созданных компьютеров
        private void buttonShowComputers_Click(object sender, EventArgs e)
        {
            listBoxInfo.Items.Clear();

            if (createdComputers.Count > 0)
            {
                listBox_AddList(listBoxInfo, createdComputers);
            }
            else
            {
                MessageBox.Show("Нет созданных компьютеров.", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        private void listBoxInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxInfo.SelectedItem is IFormObject selecetedItem)
            {
                richTextBoxInfo.Text = selecetedItem.GetInfo();
            }
        }

        private void listBox_AddList<T>(System.Windows.Forms.ListBox listBox, List<T> listInfo)
        {
            listBoxInfo.Items.Clear();

            foreach (var device in listInfo)
            {
                listBox.Items.Add(device);
            }

        }

        private void PCcreationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (createdComputers.Count >= 0)
            {
                if (!Directory.Exists(directoryPath))
                {
                    Directory.CreateDirectory(directoryPath);
                }

                string filePath = Path.Combine(directoryPath, "PC.json");

                try
                {
                    Computer.SaveToJson(createdComputers, filePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при сохранении файла: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonDeleteComputer_Click(object sender, EventArgs e)
        {
            if (listBoxInfo.SelectedItem is Computer selectedComputer)
            {
                createdComputers.Remove(selectedComputer);
                listBoxInfo.Items.Remove(selectedComputer);
            }

            MessageBox.Show("Компьютер удалён успешно!");
        }

        private void buttonSorting_Click(object sender, EventArgs e)
        {
            Type typeList = listBoxInfo.Items[0].GetType();

            var cpu = textBoxCPU.Tag as CPU;
            var ram = textBoxRAM?.Tag as RAM;
            var hdd = textBoxHDD?.Tag as HDD; // Добавляем проверку для HDD (если текстбокс есть)
            var gpu = textBoxGPU?.Tag as GPU; // Аналогично для GPU
            var motherboard = textBoxMotherboard?.Tag as Motherboard; // Аналогично для материнской платы
            var powerSupply = textBoxPowerSupply?.Tag as PowerSupply; // Аналогично для блока питания

            List<Device> goodCompatibility = new List<Device>();
            List<Device> mediumCompatibility = new List<Device>();
            List<Device> badCompatibility = new List<Device>();

            Dictionary<string, List<Device>> compatibility = new Dictionary<string, List<Device>>()
            {
                {"good", goodCompatibility },
                {"medium", mediumCompatibility },
                {"bad", badCompatibility },
            };

            switch (typeList.Name)
            {
                case "RAM":

                    break;

                case "HDD":

                    break;

                case "GPU":

                    break;

                case "Motherboard":

                    foreach (Motherboard item in listBoxInfo.Items)
                    {
                        if (cpu.Brand == item.SupportedCPU)
                        {
                            if (cpu.SocketType == item.SocketType)
                            {
                                compatibility["good"].Add(item);
                            }
                            else
                            {
                                compatibility["medium"].Add(item);
                            }
                        }
                        else
                        {
                            compatibility["bad"].Add(item);
                        }
                    }

                    break;

                case "PowerSupply":

                    break;

            }

            listBoxInfo.Items.Clear();
            listBoxInfo.Items.Add("Рекомендованные устройства: ");
            foreach (Device item in compatibility["good"])
            {
                listBoxInfo.Items.Add(item);
            }
            listBoxInfo.Items.Add("Устройства с плохой совместимостью: ");
            foreach (Device item in compatibility["medium"])
            {
                listBoxInfo.Items.Add(item);
            }


        }

        private void listBoxInfo_ChangeColor(object sender, EventArgs e, Dictionary<string, List<Device>> compatibility)
        {
            foreach (KeyValuePair<string, List<Device>> item in compatibility) 
            { 
                if (item.Key == "good")
                {

                }
            }
        }

        private void buttonCheckVirus_Click(object sender, EventArgs e)
        {
            if (listBoxInfo.SelectedItem is Computer selectedComputer)
            {
                if (selectedComputer.Hdd.Condition == "Бывший в употреблении")
                {
                    Random rnd = new Random();
                    int value = rnd.Next(0, 10);
                    if (value <= 3) 
                    {
                        MessageBox.Show("Ваш компьютер заражён вирусом!!!", "Предупрежнение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        MessageBox.Show("Ваш компьютер в целостносте!");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBoxInfo.SelectedItem is Computer selectedComputer)
            {
                selectedComputer.Ram.CleanCache();
                selectedComputer.Hdd.CleanCache();
                MessageBox.Show("Кеш успешно очищен!");
            }
        }
    }
}
