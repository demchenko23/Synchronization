namespace Synchronization
{
    partial class SynchronizationView
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeViewPhone = new System.Windows.Forms.TreeView();
            this.tboxPhonePath = new System.Windows.Forms.TextBox();
            this.btn_OpenPhone = new System.Windows.Forms.Button();
            this.treeViewComputer = new System.Windows.Forms.TreeView();
            this.tboxComputerPath = new System.Windows.Forms.TextBox();
            this.btn_Synchronization = new System.Windows.Forms.Button();
            this.btn_OpenComputer = new System.Windows.Forms.Button();
            this.radioBtn_All = new System.Windows.Forms.RadioButton();
            this.radioBtn_PC = new System.Windows.Forms.RadioButton();
            this.radioBtn_CP = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // treeViewPhone
            // 
            this.treeViewPhone.CheckBoxes = true;
            this.treeViewPhone.Location = new System.Drawing.Point(12, 41);
            this.treeViewPhone.Name = "treeViewPhone";
            this.treeViewPhone.Size = new System.Drawing.Size(269, 218);
            this.treeViewPhone.TabIndex = 18;
            this.treeViewPhone.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewPhone_AfterCheck);
            this.treeViewPhone.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeViewPhone_AfterExpand);
            // 
            // tboxPhonePath
            // 
            this.tboxPhonePath.Location = new System.Drawing.Point(109, 15);
            this.tboxPhonePath.Name = "tboxPhonePath";
            this.tboxPhonePath.Size = new System.Drawing.Size(172, 20);
            this.tboxPhonePath.TabIndex = 16;
            // 
            // btn_OpenPhone
            // 
            this.btn_OpenPhone.Location = new System.Drawing.Point(12, 12);
            this.btn_OpenPhone.Name = "btn_OpenPhone";
            this.btn_OpenPhone.Size = new System.Drawing.Size(91, 23);
            this.btn_OpenPhone.TabIndex = 15;
            this.btn_OpenPhone.Text = "Open Phone";
            this.btn_OpenPhone.UseVisualStyleBackColor = true;
            this.btn_OpenPhone.Click += new System.EventHandler(this.button_OpenPhone_Click);
            // 
            // treeViewComputer
            // 
            this.treeViewComputer.CheckBoxes = true;
            this.treeViewComputer.Location = new System.Drawing.Point(287, 41);
            this.treeViewComputer.Name = "treeViewComputer";
            this.treeViewComputer.Size = new System.Drawing.Size(270, 218);
            this.treeViewComputer.TabIndex = 22;
            this.treeViewComputer.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeViewComputer_AfterCheck);
            this.treeViewComputer.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.treeViewComputer_AfterExpand);
            // 
            // tboxComputerPath
            // 
            this.tboxComputerPath.Location = new System.Drawing.Point(385, 14);
            this.tboxComputerPath.Name = "tboxComputerPath";
            this.tboxComputerPath.Size = new System.Drawing.Size(172, 20);
            this.tboxComputerPath.TabIndex = 21;
            // 
            // btn_Synchronization
            // 
            this.btn_Synchronization.Location = new System.Drawing.Point(287, 264);
            this.btn_Synchronization.Name = "btn_Synchronization";
            this.btn_Synchronization.Size = new System.Drawing.Size(270, 21);
            this.btn_Synchronization.TabIndex = 20;
            this.btn_Synchronization.Text = "Synchronization";
            this.btn_Synchronization.UseVisualStyleBackColor = true;
            this.btn_Synchronization.Click += new System.EventHandler(this.button_Synchronization_Click);
            // 
            // btn_OpenComputer
            // 
            this.btn_OpenComputer.Location = new System.Drawing.Point(287, 12);
            this.btn_OpenComputer.Name = "btn_OpenComputer";
            this.btn_OpenComputer.Size = new System.Drawing.Size(91, 23);
            this.btn_OpenComputer.TabIndex = 19;
            this.btn_OpenComputer.Text = "Open Computer";
            this.btn_OpenComputer.UseVisualStyleBackColor = true;
            this.btn_OpenComputer.Click += new System.EventHandler(this.button_OpenComputer_Click);
            // 
            // radioBtn_All
            // 
            this.radioBtn_All.AutoSize = true;
            this.radioBtn_All.Location = new System.Drawing.Point(12, 268);
            this.radioBtn_All.Name = "radioBtn_All";
            this.radioBtn_All.Size = new System.Drawing.Size(36, 17);
            this.radioBtn_All.TabIndex = 23;
            this.radioBtn_All.TabStop = true;
            this.radioBtn_All.Text = "All";
            this.radioBtn_All.UseVisualStyleBackColor = true;
            // 
            // radioBtn_PC
            // 
            this.radioBtn_PC.AutoSize = true;
            this.radioBtn_PC.Location = new System.Drawing.Point(54, 268);
            this.radioBtn_PC.Name = "radioBtn_PC";
            this.radioBtn_PC.Size = new System.Drawing.Size(110, 17);
            this.radioBtn_PC.TabIndex = 24;
            this.radioBtn_PC.TabStop = true;
            this.radioBtn_PC.Text = "Phone->Computer";
            this.radioBtn_PC.UseVisualStyleBackColor = true;
            // 
            // radioBtn_CP
            // 
            this.radioBtn_CP.AutoSize = true;
            this.radioBtn_CP.Location = new System.Drawing.Point(170, 268);
            this.radioBtn_CP.Name = "radioBtn_CP";
            this.radioBtn_CP.Size = new System.Drawing.Size(110, 17);
            this.radioBtn_CP.TabIndex = 25;
            this.radioBtn_CP.TabStop = true;
            this.radioBtn_CP.Text = "Computer->Phone";
            this.radioBtn_CP.UseVisualStyleBackColor = true;
            // 
            // SynchronizationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 305);
            this.Controls.Add(this.radioBtn_CP);
            this.Controls.Add(this.radioBtn_PC);
            this.Controls.Add(this.radioBtn_All);
            this.Controls.Add(this.treeViewComputer);
            this.Controls.Add(this.tboxComputerPath);
            this.Controls.Add(this.btn_Synchronization);
            this.Controls.Add(this.btn_OpenComputer);
            this.Controls.Add(this.treeViewPhone);
            this.Controls.Add(this.tboxPhonePath);
            this.Controls.Add(this.btn_OpenPhone);
            this.Name = "SynchronizationView";
            this.Text = "Synchronization For Phone";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeViewPhone;
        private System.Windows.Forms.TextBox tboxPhonePath;
        private System.Windows.Forms.Button btn_OpenPhone;
        private System.Windows.Forms.TreeView treeViewComputer;
        private System.Windows.Forms.TextBox tboxComputerPath;
        private System.Windows.Forms.Button btn_Synchronization;
        private System.Windows.Forms.Button btn_OpenComputer;
        private System.Windows.Forms.RadioButton radioBtn_All;
        private System.Windows.Forms.RadioButton radioBtn_PC;
        private System.Windows.Forms.RadioButton radioBtn_CP;
    }
}

