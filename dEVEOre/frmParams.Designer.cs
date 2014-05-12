namespace dEVEOre
{
    partial class frmParams
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCycle = new System.Windows.Forms.TextBox();
            this.txtYield = new System.Windows.Forms.TextBox();
            this.txtRefineOutput = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTaxes = new System.Windows.Forms.TextBox();
            this.cmbTimerSetting = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cycle (in seconds):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mining yield (in m3):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 118);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Refine net yield (in %):";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(118, 168);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCycle
            // 
            this.txtCycle.Location = new System.Drawing.Point(126, 63);
            this.txtCycle.Name = "txtCycle";
            this.txtCycle.Size = new System.Drawing.Size(67, 20);
            this.txtCycle.TabIndex = 5;
            this.txtCycle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtYield
            // 
            this.txtYield.Location = new System.Drawing.Point(126, 89);
            this.txtYield.Name = "txtYield";
            this.txtYield.Size = new System.Drawing.Size(67, 20);
            this.txtYield.TabIndex = 6;
            this.txtYield.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRefineOutput
            // 
            this.txtRefineOutput.Location = new System.Drawing.Point(126, 115);
            this.txtRefineOutput.Name = "txtRefineOutput";
            this.txtRefineOutput.Size = new System.Drawing.Size(67, 20);
            this.txtRefineOutput.TabIndex = 7;
            this.txtRefineOutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 145);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "NPC Corp taxes (in %):";
            // 
            // txtTaxes
            // 
            this.txtTaxes.Location = new System.Drawing.Point(126, 142);
            this.txtTaxes.Name = "txtTaxes";
            this.txtTaxes.Size = new System.Drawing.Size(67, 20);
            this.txtTaxes.TabIndex = 9;
            this.txtTaxes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cmbTimerSetting
            // 
            this.cmbTimerSetting.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTimerSetting.FormattingEnabled = true;
            this.cmbTimerSetting.Items.AddRange(new object[] {
            "10",
            "30",
            "60"});
            this.cmbTimerSetting.Location = new System.Drawing.Point(100, 12);
            this.cmbTimerSetting.Name = "cmbTimerSetting";
            this.cmbTimerSetting.Size = new System.Drawing.Size(44, 21);
            this.cmbTimerSetting.TabIndex = 12;
            this.cmbTimerSetting.SelectedIndexChanged += new System.EventHandler(this.cmbTimerSetting_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(150, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "minutes";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Update every:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "(this will reset current timer)";
            // 
            // frmParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 200);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbTimerSetting);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTaxes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRefineOutput);
            this.Controls.Add(this.txtYield);
            this.Controls.Add(this.txtCycle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmParams";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dEVEOre - Parameters";
            this.Load += new System.EventHandler(this.frmParams_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtCycle;
        private System.Windows.Forms.TextBox txtYield;
        private System.Windows.Forms.TextBox txtRefineOutput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtTaxes;
        private System.Windows.Forms.ComboBox cmbTimerSetting;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
    }
}