using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryForForm48;
using DynamicFormGenerator;

namespace WorksPLS
{
    public partial class ChoiseMakerForm : Form
    {
        // Конструктор формы
        public ChoiseMakerForm()
        {
            InitializeComponent();
            InitializeListBox();
        }

        // Метод для добавления элементов в ListBox
        private void InitializeListBox()
        {
            listBox1.Items.Clear(); // Очистить список перед добавлением

            List<string> items = new List<string> { "Процессор CPU", "Оперативная память RAM", "Жесткий диск HDD", "Видеокарта GPU", "Материнская плата MB", "Блок Питания PSU"};

            foreach (var item in items)
            {
                listBox1.Items.Add(item);
            }
        }


        // Обработчик события нажатия кнопки
        private void button1_Click(object sender, EventArgs e)
        {
            // Получаем выбранный элемент из ListBox
            if (listBox1.SelectedItem != null)
            {
                string selectedItem = listBox1.SelectedItem.ToString();

                switch (selectedItem)
                {
                    case "Процессор CPU":
                        CPUCreationForm CPUForm = new CPUCreationForm();
                        CPUForm.Show();
                        break;

                    case "Оперативная память RAM":
                        DynamicForm<RAM> RAMform = new DynamicForm<RAM>();
                        RAMform.Show();
                        break;

                    case "Жесткий диск HDD":
                        DynamicForm<HDD> HDDform = new DynamicForm<HDD>();
                        HDDform.Show();
                        break;

                    case "Видеокарта GPU":
                        DynamicForm<GPU> GPUform = new DynamicForm<GPU>();
                        GPUform.Show();
                        break;

                    case "Материнская плата MB":
                        DynamicForm<Motherboard> Motherboardform = new DynamicForm<Motherboard>();
                        Motherboardform.Show();
                        break;

                    case "Блок Питания PSU":
                        DynamicForm<PowerSupply> PowerSupplyform = new DynamicForm<PowerSupply>();
                        PowerSupplyform.Show();
                        break;

                }
            }
            else
            {
                MessageBox.Show("Выберите элемент из списка!");
            }
        }
    }
}
