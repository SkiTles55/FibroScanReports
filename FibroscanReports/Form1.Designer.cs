namespace FibroscanReports
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ChoiseDirButton = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.ChoiseFileButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.outputLog = new System.Windows.Forms.RichTextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ChoiseDirButton
            // 
            this.ChoiseDirButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChoiseDirButton.Location = new System.Drawing.Point(32, 78);
            this.ChoiseDirButton.Name = "ChoiseDirButton";
            this.ChoiseDirButton.Size = new System.Drawing.Size(180, 50);
            this.ChoiseDirButton.TabIndex = 0;
            this.ChoiseDirButton.Text = "Открыть папку";
            this.ChoiseDirButton.UseVisualStyleBackColor = true;
            this.ChoiseDirButton.Click += new System.EventHandler(this.ChoiseDirButton_Click);
            // 
            // ChoiseFileButton
            // 
            this.ChoiseFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ChoiseFileButton.Location = new System.Drawing.Point(32, 12);
            this.ChoiseFileButton.Name = "ChoiseFileButton";
            this.ChoiseFileButton.Size = new System.Drawing.Size(180, 50);
            this.ChoiseFileButton.TabIndex = 2;
            this.ChoiseFileButton.Text = "Открыть файл";
            this.ChoiseFileButton.UseVisualStyleBackColor = true;
            this.ChoiseFileButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "report";
            this.openFileDialog1.Filter = "FibroscanReport (*.fibx)|*.fibx";
            // 
            // outputLog
            // 
            this.outputLog.Location = new System.Drawing.Point(12, 146);
            this.outputLog.Name = "outputLog";
            this.outputLog.ReadOnly = true;
            this.outputLog.Size = new System.Drawing.Size(220, 150);
            this.outputLog.TabIndex = 3;
            this.outputLog.Text = "";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 309);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 47);
            this.label1.TabIndex = 4;
            this.label1.Text = "БУЗОО \"Инфекционная клиническая больница № 1 имени Далматова Д.М.\"";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 356);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(220, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Разработчик: Худяков Д.С.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 384);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputLog);
            this.Controls.Add(this.ChoiseFileButton);
            this.Controls.Add(this.ChoiseDirButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "FibroScan Reports";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ChoiseDirButton;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button ChoiseFileButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.RichTextBox outputLog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

