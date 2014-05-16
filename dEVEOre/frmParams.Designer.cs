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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lstOreFollowed = new System.Windows.Forms.ListBox();
            this.cmbSec = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lstOre = new System.Windows.Forms.ListBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cycle (in seconds):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mining yield (in m3):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Refine net yield (in %):";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(474, 218);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCycle
            // 
            this.txtCycle.Location = new System.Drawing.Point(133, 22);
            this.txtCycle.Name = "txtCycle";
            this.txtCycle.Size = new System.Drawing.Size(67, 20);
            this.txtCycle.TabIndex = 5;
            this.txtCycle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtYield
            // 
            this.txtYield.Location = new System.Drawing.Point(133, 48);
            this.txtYield.Name = "txtYield";
            this.txtYield.Size = new System.Drawing.Size(67, 20);
            this.txtYield.TabIndex = 6;
            this.txtYield.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRefineOutput
            // 
            this.txtRefineOutput.Location = new System.Drawing.Point(133, 74);
            this.txtRefineOutput.Name = "txtRefineOutput";
            this.txtRefineOutput.Size = new System.Drawing.Size(67, 20);
            this.txtRefineOutput.TabIndex = 7;
            this.txtRefineOutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "NPC Corp taxes (in %):";
            // 
            // txtTaxes
            // 
            this.txtTaxes.Location = new System.Drawing.Point(133, 101);
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
            this.cmbTimerSetting.Location = new System.Drawing.Point(107, 20);
            this.cmbTimerSetting.Name = "cmbTimerSetting";
            this.cmbTimerSetting.Size = new System.Drawing.Size(44, 21);
            this.cmbTimerSetting.TabIndex = 12;
            this.cmbTimerSetting.SelectedIndexChanged += new System.EventHandler(this.cmbTimerSetting_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(157, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "minutes";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(19, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Update every:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "(this will reset current timer)";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cmbTimerSetting);
            this.groupBox1.Location = new System.Drawing.Point(3, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 69);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Program settings";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtTaxes);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtCycle);
            this.groupBox2.Controls.Add(this.txtRefineOutput);
            this.groupBox2.Controls.Add(this.txtYield);
            this.groupBox2.Location = new System.Drawing.Point(3, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(228, 136);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Player settings";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.lstOreFollowed);
            this.groupBox3.Controls.Add(this.cmbSec);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.lstOre);
            this.groupBox3.Location = new System.Drawing.Point(237, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(312, 211);
            this.groupBox3.TabIndex = 16;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ore settings";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(126, 152);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(59, 23);
            this.button4.TabIndex = 7;
            this.button4.Text = "<<";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Location = new System.Drawing.Point(126, 123);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(59, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "<";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Location = new System.Drawing.Point(126, 94);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(59, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = ">";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(126, 65);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = ">>";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lstOreFollowed
            // 
            this.lstOreFollowed.FormattingEnabled = true;
            this.lstOreFollowed.Location = new System.Drawing.Point(191, 45);
            this.lstOreFollowed.Name = "lstOreFollowed";
            this.lstOreFollowed.Size = new System.Drawing.Size(114, 160);
            this.lstOreFollowed.TabIndex = 3;
            // 
            // cmbSec
            // 
            this.cmbSec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSec.FormattingEnabled = true;
            this.cmbSec.Location = new System.Drawing.Point(106, 17);
            this.cmbSec.Name = "cmbSec";
            this.cmbSec.Size = new System.Drawing.Size(50, 21);
            this.cmbSec.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 20);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Show Ore in sec:";
            // 
            // lstOre
            // 
            this.lstOre.FormattingEnabled = true;
            this.lstOre.Location = new System.Drawing.Point(6, 44);
            this.lstOre.Name = "lstOre";
            this.lstOre.Size = new System.Drawing.Size(114, 160);
            this.lstOre.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(188, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Selected Ore:";
            // 
            // frmParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 247);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmParams";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmParams";
            this.Load += new System.EventHandler(this.frmParams_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lstOre;
        private System.Windows.Forms.ComboBox cmbSec;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lstOreFollowed;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
    }
}