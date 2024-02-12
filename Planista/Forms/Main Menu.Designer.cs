namespace Planista
{
    partial class MainMenu
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.bStart = new System.Windows.Forms.Button();
            this.bClose = new System.Windows.Forms.Button();
            this.bChooseData = new System.Windows.Forms.Button();
            this.bSettings = new System.Windows.Forms.Button();
            this.tTime = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tObject = new System.Windows.Forms.TextBox();
            this.bResetData = new System.Windows.Forms.Button();
            this.tDataList = new System.Windows.Forms.RichTextBox();
            this.bChangeView = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tGeneration = new System.Windows.Forms.TextBox();
            this.progressBar = new TextProgressBar();
            this.SuspendLayout();
            // 
            // bStart
            // 
            this.bStart.Enabled = false;
            this.bStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold);
            this.bStart.Location = new System.Drawing.Point(16, 25);
            this.bStart.Margin = new System.Windows.Forms.Padding(4);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(533, 123);
            this.bStart.TabIndex = 0;
            this.bStart.Text = "Rozpocznij";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // bClose
            // 
            this.bClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold);
            this.bClose.Location = new System.Drawing.Point(16, 418);
            this.bClose.Margin = new System.Windows.Forms.Padding(4);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(533, 123);
            this.bClose.TabIndex = 1;
            this.bClose.Text = "Wyłącz";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // bChooseData
            // 
            this.bChooseData.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold);
            this.bChooseData.Location = new System.Drawing.Point(16, 156);
            this.bChooseData.Margin = new System.Windows.Forms.Padding(4);
            this.bChooseData.Name = "bChooseData";
            this.bChooseData.Size = new System.Drawing.Size(533, 123);
            this.bChooseData.TabIndex = 2;
            this.bChooseData.Text = "Dodaj dane";
            this.bChooseData.UseVisualStyleBackColor = true;
            this.bChooseData.Click += new System.EventHandler(this.bChooseData_Click);
            // 
            // bSettings
            // 
            this.bSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold);
            this.bSettings.Location = new System.Drawing.Point(16, 287);
            this.bSettings.Margin = new System.Windows.Forms.Padding(4);
            this.bSettings.Name = "bSettings";
            this.bSettings.Size = new System.Drawing.Size(533, 123);
            this.bSettings.TabIndex = 3;
            this.bSettings.Text = "Ustawienia";
            this.bSettings.UseVisualStyleBackColor = true;
            this.bSettings.Click += new System.EventHandler(this.bSettings_Click);
            // 
            // tTime
            // 
            this.tTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.tTime.Location = new System.Drawing.Point(1011, 31);
            this.tTime.Margin = new System.Windows.Forms.Padding(4);
            this.tTime.Name = "tTime";
            this.tTime.Size = new System.Drawing.Size(231, 34);
            this.tTime.TabIndex = 5;
            this.tTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tTime.TextChanged += new System.EventHandler(this.tTime_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label1.Location = new System.Drawing.Point(557, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 39);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ogranicznik czasowy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label2.Location = new System.Drawing.Point(557, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(335, 39);
            this.label2.TabIndex = 7;
            this.label2.Text = "Obiekty na pokolenie";
            // 
            // tObject
            // 
            this.tObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.tObject.Location = new System.Drawing.Point(1011, 70);
            this.tObject.Margin = new System.Windows.Forms.Padding(4);
            this.tObject.Name = "tObject";
            this.tObject.ShortcutsEnabled = false;
            this.tObject.Size = new System.Drawing.Size(231, 34);
            this.tObject.TabIndex = 8;
            this.tObject.Text = "100";
            this.tObject.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tObject.TextChanged += new System.EventHandler(this.tObject_TextChanged);
            // 
            // bResetData
            // 
            this.bResetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.bResetData.Location = new System.Drawing.Point(903, 418);
            this.bResetData.Margin = new System.Windows.Forms.Padding(4);
            this.bResetData.Name = "bResetData";
            this.bResetData.Size = new System.Drawing.Size(339, 123);
            this.bResetData.TabIndex = 9;
            this.bResetData.Text = "Resetuj dane";
            this.bResetData.UseVisualStyleBackColor = true;
            this.bResetData.Click += new System.EventHandler(this.bResetData_Click);
            // 
            // tDataList
            // 
            this.tDataList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tDataList.Location = new System.Drawing.Point(564, 156);
            this.tDataList.Name = "tDataList";
            this.tDataList.ReadOnly = true;
            this.tDataList.Size = new System.Drawing.Size(678, 254);
            this.tDataList.TabIndex = 10;
            this.tDataList.Text = "";
            // 
            // bChangeView
            // 
            this.bChangeView.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold);
            this.bChangeView.Location = new System.Drawing.Point(564, 418);
            this.bChangeView.Margin = new System.Windows.Forms.Padding(4);
            this.bChangeView.Name = "bChangeView";
            this.bChangeView.Size = new System.Drawing.Size(339, 123);
            this.bChangeView.TabIndex = 11;
            this.bChangeView.Text = "Zmień widok";
            this.bChangeView.UseVisualStyleBackColor = true;
            this.bChangeView.Click += new System.EventHandler(this.bChangeView_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.label3.Location = new System.Drawing.Point(557, 104);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(217, 39);
            this.label3.TabIndex = 12;
            this.label3.Text = "Ilość pokoleń";
            // 
            // tGeneration
            // 
            this.tGeneration.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.tGeneration.Location = new System.Drawing.Point(1011, 109);
            this.tGeneration.Margin = new System.Windows.Forms.Padding(4);
            this.tGeneration.Name = "tGeneration";
            this.tGeneration.ShortcutsEnabled = false;
            this.tGeneration.Size = new System.Drawing.Size(231, 34);
            this.tGeneration.TabIndex = 13;
            this.tGeneration.Text = "100";
            this.tGeneration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tGeneration.TextChanged += new System.EventHandler(this.tGeneration_TextChanged);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(16, 548);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1226, 36);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 14;
            this.progressBar.Visible = false;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 592);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.tGeneration);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.bChangeView);
            this.Controls.Add(this.tDataList);
            this.Controls.Add(this.bResetData);
            this.Controls.Add(this.tObject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tTime);
            this.Controls.Add(this.bSettings);
            this.Controls.Add(this.bChooseData);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.bStart);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(2554, 1318);
            this.MinimumSize = new System.Drawing.Size(1061, 481);
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Planer";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.Resize += new System.EventHandler(this.MainMenu_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Button bChooseData;
        private System.Windows.Forms.Button bSettings;
        private System.Windows.Forms.TextBox tTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tObject;
        private System.Windows.Forms.Button bResetData;
        private System.Windows.Forms.RichTextBox tDataList;
        private System.Windows.Forms.Button bChangeView;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tGeneration;
        private TextProgressBar progressBar;
    }
}

