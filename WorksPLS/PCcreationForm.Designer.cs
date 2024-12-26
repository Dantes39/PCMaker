namespace WorksPLS
{
    partial class PCcreationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.richTextBoxArray1 = new Microsoft.VisualBasic.Compatibility.VB6.RichTextBoxArray(this.components);
            this.richTextBoxInfo = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listBoxInfo = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCPU = new System.Windows.Forms.TextBox();
            this.buttonSetCPU = new System.Windows.Forms.Button();
            this.buttonSetRAM = new System.Windows.Forms.Button();
            this.textBoxRAM = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonCreateComputer = new System.Windows.Forms.Button();
            this.buttonShowComputers = new System.Windows.Forms.Button();
            this.buttonSetHDD = new System.Windows.Forms.Button();
            this.textBoxHDD = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonSetGPU = new System.Windows.Forms.Button();
            this.textBoxGPU = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonSetMotherboard = new System.Windows.Forms.Button();
            this.textBoxMotherboard = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonSetPowerSupply = new System.Windows.Forms.Button();
            this.textBoxPowerSupply = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonDeleteComputer = new System.Windows.Forms.Button();
            this.buttonSorting = new System.Windows.Forms.Button();
            this.buttonCheckVirus = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.richTextBoxArray1)).BeginInit();
            this.SuspendLayout();
            // 
            // richTextBoxInfo
            // 
            this.richTextBoxInfo.Location = new System.Drawing.Point(838, 93);
            this.richTextBoxInfo.Name = "richTextBoxInfo";
            this.richTextBoxInfo.Size = new System.Drawing.Size(309, 480);
            this.richTextBoxInfo.TabIndex = 0;
            this.richTextBoxInfo.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label1.Location = new System.Drawing.Point(21, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(312, 36);
            this.label1.TabIndex = 1;
            this.label1.Text = "Сборка Компьютера";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // listBoxInfo
            // 
            this.listBoxInfo.FormattingEnabled = true;
            this.listBoxInfo.ItemHeight = 16;
            this.listBoxInfo.Location = new System.Drawing.Point(479, 93);
            this.listBoxInfo.Name = "listBoxInfo";
            this.listBoxInfo.Size = new System.Drawing.Size(309, 484);
            this.listBoxInfo.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(28, 598);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(413, 49);
            this.button1.TabIndex = 3;
            this.button1.Text = "Добавить устройство";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label2.Location = new System.Drawing.Point(27, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Процессор CPU";
            // 
            // textBoxCPU
            // 
            this.textBoxCPU.Location = new System.Drawing.Point(29, 103);
            this.textBoxCPU.Name = "textBoxCPU";
            this.textBoxCPU.ReadOnly = true;
            this.textBoxCPU.Size = new System.Drawing.Size(283, 22);
            this.textBoxCPU.TabIndex = 5;
            // 
            // buttonSetCPU
            // 
            this.buttonSetCPU.Location = new System.Drawing.Point(350, 103);
            this.buttonSetCPU.Name = "buttonSetCPU";
            this.buttonSetCPU.Size = new System.Drawing.Size(92, 23);
            this.buttonSetCPU.TabIndex = 6;
            this.buttonSetCPU.Text = "Выбрать";
            this.buttonSetCPU.UseVisualStyleBackColor = true;
            // 
            // buttonSetRAM
            // 
            this.buttonSetRAM.Location = new System.Drawing.Point(350, 172);
            this.buttonSetRAM.Name = "buttonSetRAM";
            this.buttonSetRAM.Size = new System.Drawing.Size(92, 23);
            this.buttonSetRAM.TabIndex = 9;
            this.buttonSetRAM.Text = "Выбрать";
            this.buttonSetRAM.UseVisualStyleBackColor = true;
            // 
            // textBoxRAM
            // 
            this.textBoxRAM.Location = new System.Drawing.Point(29, 172);
            this.textBoxRAM.Name = "textBoxRAM";
            this.textBoxRAM.ReadOnly = true;
            this.textBoxRAM.Size = new System.Drawing.Size(283, 22);
            this.textBoxRAM.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label3.Location = new System.Drawing.Point(27, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(285, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Оперативная Память RAM";
            // 
            // buttonCreateComputer
            // 
            this.buttonCreateComputer.Location = new System.Drawing.Point(27, 524);
            this.buttonCreateComputer.Name = "buttonCreateComputer";
            this.buttonCreateComputer.Size = new System.Drawing.Size(414, 49);
            this.buttonCreateComputer.TabIndex = 10;
            this.buttonCreateComputer.Text = "Создать компьтер";
            this.buttonCreateComputer.UseVisualStyleBackColor = true;
            // 
            // buttonShowComputers
            // 
            this.buttonShowComputers.Location = new System.Drawing.Point(477, 29);
            this.buttonShowComputers.Name = "buttonShowComputers";
            this.buttonShowComputers.Size = new System.Drawing.Size(311, 49);
            this.buttonShowComputers.TabIndex = 11;
            this.buttonShowComputers.Text = "Показать компьтеры";
            this.buttonShowComputers.UseVisualStyleBackColor = true;
            // 
            // buttonSetHDD
            // 
            this.buttonSetHDD.Location = new System.Drawing.Point(350, 245);
            this.buttonSetHDD.Name = "buttonSetHDD";
            this.buttonSetHDD.Size = new System.Drawing.Size(92, 23);
            this.buttonSetHDD.TabIndex = 14;
            this.buttonSetHDD.Text = "Выбрать";
            this.buttonSetHDD.UseVisualStyleBackColor = true;
            // 
            // textBoxHDD
            // 
            this.textBoxHDD.Location = new System.Drawing.Point(29, 245);
            this.textBoxHDD.Name = "textBoxHDD";
            this.textBoxHDD.ReadOnly = true;
            this.textBoxHDD.Size = new System.Drawing.Size(283, 22);
            this.textBoxHDD.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label4.Location = new System.Drawing.Point(27, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 25);
            this.label4.TabIndex = 12;
            this.label4.Text = "Жёсткий Диск HDD";
            // 
            // buttonSetGPU
            // 
            this.buttonSetGPU.Location = new System.Drawing.Point(350, 319);
            this.buttonSetGPU.Name = "buttonSetGPU";
            this.buttonSetGPU.Size = new System.Drawing.Size(92, 23);
            this.buttonSetGPU.TabIndex = 17;
            this.buttonSetGPU.Text = "Выбрать";
            this.buttonSetGPU.UseVisualStyleBackColor = true;
            // 
            // textBoxGPU
            // 
            this.textBoxGPU.Location = new System.Drawing.Point(29, 319);
            this.textBoxGPU.Name = "textBoxGPU";
            this.textBoxGPU.ReadOnly = true;
            this.textBoxGPU.Size = new System.Drawing.Size(283, 22);
            this.textBoxGPU.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label5.Location = new System.Drawing.Point(27, 286);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(183, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Видеокарта GPU";
            // 
            // buttonSetMotherboard
            // 
            this.buttonSetMotherboard.Location = new System.Drawing.Point(350, 394);
            this.buttonSetMotherboard.Name = "buttonSetMotherboard";
            this.buttonSetMotherboard.Size = new System.Drawing.Size(92, 23);
            this.buttonSetMotherboard.TabIndex = 20;
            this.buttonSetMotherboard.Text = "Выбрать";
            this.buttonSetMotherboard.UseVisualStyleBackColor = true;
            // 
            // textBoxMotherboard
            // 
            this.textBoxMotherboard.Location = new System.Drawing.Point(29, 394);
            this.textBoxMotherboard.Name = "textBoxMotherboard";
            this.textBoxMotherboard.ReadOnly = true;
            this.textBoxMotherboard.Size = new System.Drawing.Size(283, 22);
            this.textBoxMotherboard.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label6.Location = new System.Drawing.Point(27, 361);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(253, 25);
            this.label6.TabIndex = 18;
            this.label6.Text = "Материнская Плата MB";
            // 
            // buttonSetPowerSupply
            // 
            this.buttonSetPowerSupply.Location = new System.Drawing.Point(349, 470);
            this.buttonSetPowerSupply.Name = "buttonSetPowerSupply";
            this.buttonSetPowerSupply.Size = new System.Drawing.Size(92, 23);
            this.buttonSetPowerSupply.TabIndex = 23;
            this.buttonSetPowerSupply.Text = "Выбрать";
            this.buttonSetPowerSupply.UseVisualStyleBackColor = true;
            // 
            // textBoxPowerSupply
            // 
            this.textBoxPowerSupply.Location = new System.Drawing.Point(28, 470);
            this.textBoxPowerSupply.Name = "textBoxPowerSupply";
            this.textBoxPowerSupply.ReadOnly = true;
            this.textBoxPowerSupply.Size = new System.Drawing.Size(283, 22);
            this.textBoxPowerSupply.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.label7.Location = new System.Drawing.Point(26, 437);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(204, 25);
            this.label7.TabIndex = 21;
            this.label7.Text = "Блок Питания PSU";
            // 
            // buttonDeleteComputer
            // 
            this.buttonDeleteComputer.Location = new System.Drawing.Point(479, 598);
            this.buttonDeleteComputer.Name = "buttonDeleteComputer";
            this.buttonDeleteComputer.Size = new System.Drawing.Size(311, 49);
            this.buttonDeleteComputer.TabIndex = 24;
            this.buttonDeleteComputer.Text = "Удалить компьютер";
            this.buttonDeleteComputer.UseVisualStyleBackColor = true;
            this.buttonDeleteComputer.Click += new System.EventHandler(this.buttonDeleteComputer_Click);
            // 
            // buttonSorting
            // 
            this.buttonSorting.Location = new System.Drawing.Point(479, 666);
            this.buttonSorting.Name = "buttonSorting";
            this.buttonSorting.Size = new System.Drawing.Size(311, 49);
            this.buttonSorting.TabIndex = 25;
            this.buttonSorting.Text = "Рекомендация деталей";
            this.buttonSorting.UseVisualStyleBackColor = true;
            this.buttonSorting.Click += new System.EventHandler(this.buttonSorting_Click);
            // 
            // buttonCheckVirus
            // 
            this.buttonCheckVirus.Location = new System.Drawing.Point(838, 598);
            this.buttonCheckVirus.Name = "buttonCheckVirus";
            this.buttonCheckVirus.Size = new System.Drawing.Size(309, 49);
            this.buttonCheckVirus.TabIndex = 26;
            this.buttonCheckVirus.Text = "Проверить компьтер на вирусы";
            this.buttonCheckVirus.UseVisualStyleBackColor = true;
            this.buttonCheckVirus.Click += new System.EventHandler(this.buttonCheckVirus_Click);
            // 
            // PCcreationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1237, 741);
            this.Controls.Add(this.buttonCheckVirus);
            this.Controls.Add(this.buttonSorting);
            this.Controls.Add(this.buttonDeleteComputer);
            this.Controls.Add(this.buttonSetPowerSupply);
            this.Controls.Add(this.textBoxPowerSupply);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.buttonSetMotherboard);
            this.Controls.Add(this.textBoxMotherboard);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonSetGPU);
            this.Controls.Add(this.textBoxGPU);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonSetHDD);
            this.Controls.Add(this.textBoxHDD);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.buttonShowComputers);
            this.Controls.Add(this.buttonCreateComputer);
            this.Controls.Add(this.buttonSetRAM);
            this.Controls.Add(this.textBoxRAM);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonSetCPU);
            this.Controls.Add(this.textBoxCPU);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBoxInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxInfo);
            this.Name = "PCcreationForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.richTextBoxArray1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Microsoft.VisualBasic.Compatibility.VB6.RichTextBoxArray richTextBoxArray1;
        private System.Windows.Forms.RichTextBox richTextBoxInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBoxInfo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCPU;
        private System.Windows.Forms.Button buttonSetCPU;
        private System.Windows.Forms.Button buttonSetRAM;
        private System.Windows.Forms.TextBox textBoxRAM;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonCreateComputer;
        private System.Windows.Forms.Button buttonShowComputers;
        private System.Windows.Forms.Button buttonSetHDD;
        private System.Windows.Forms.TextBox textBoxHDD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonSetGPU;
        private System.Windows.Forms.TextBox textBoxGPU;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button buttonSetMotherboard;
        private System.Windows.Forms.TextBox textBoxMotherboard;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonSetPowerSupply;
        private System.Windows.Forms.TextBox textBoxPowerSupply;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonDeleteComputer;
        private System.Windows.Forms.Button buttonSorting;
        private System.Windows.Forms.Button buttonCheckVirus;
    }
}

