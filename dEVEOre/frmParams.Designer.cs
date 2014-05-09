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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtCycle = new System.Windows.Forms.TextBox();
            this.txtYield = new System.Windows.Forms.TextBox();
            this.txtRefineOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Edit to your character\'s skills/equipment:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Cycle (in seconds):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Yield (in m3):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Refine output (in %):";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(166, 129);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtCycle
            // 
            this.txtCycle.Location = new System.Drawing.Point(141, 41);
            this.txtCycle.Name = "txtCycle";
            this.txtCycle.Size = new System.Drawing.Size(100, 20);
            this.txtCycle.TabIndex = 5;
            this.txtCycle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtYield
            // 
            this.txtYield.Location = new System.Drawing.Point(141, 67);
            this.txtYield.Name = "txtYield";
            this.txtYield.Size = new System.Drawing.Size(100, 20);
            this.txtYield.TabIndex = 6;
            this.txtYield.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtRefineOutput
            // 
            this.txtRefineOutput.Location = new System.Drawing.Point(141, 93);
            this.txtRefineOutput.Name = "txtRefineOutput";
            this.txtRefineOutput.Size = new System.Drawing.Size(100, 20);
            this.txtRefineOutput.TabIndex = 7;
            this.txtRefineOutput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 162);
            this.Controls.Add(this.txtRefineOutput);
            this.Controls.Add(this.txtYield);
            this.Controls.Add(this.txtCycle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmParams";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dEVEOre - Parameters";
            this.Load += new System.EventHandler(this.frmParams_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtCycle;
        private System.Windows.Forms.TextBox txtYield;
        private System.Windows.Forms.TextBox txtRefineOutput;
    }
}