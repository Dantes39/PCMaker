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

namespace WorksPLS
{
    public partial class RAMCreationForm : Form
    {
        public RAMCreationForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string directoryPath = Path.Combine(Application.StartupPath, "FormFiles");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, "RAM.json");
            List<RAM> rams = new List<RAM>();

            for (int i = 0; i < 5; i++)
            {
                RAM newRam = new RAM("Rock", "433", 8*i, 4*i, "DDR4", "Intel", "Новое", "23131");
                rams.Add(newRam);
            }

            RAM.SaveToJson(rams, filePath);
            MessageBox.Show("Всё воркает!!!");
            
        }
    }
}
