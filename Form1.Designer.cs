namespace CA
{
    partial class Form1
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
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.sizeXDimensionNum = new System.Windows.Forms.NumericUpDown();
            this.sizeYDimensionNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.singleStepButton = new System.Windows.Forms.Button();
            this.speedNum = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.grainsAmountNum = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.inclusionsBefore = new System.Windows.Forms.Button();
            this.sizeInclusionsNum = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.inclusionsAmountNum = new System.Windows.Forms.NumericUpDown();
            this.inclusionsAfter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeXDimensionNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeYDimensionNum)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grainsAmountNum)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sizeInclusionsNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inclusionsAmountNum)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(6, 4);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1032, 630);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // sizeXDimensionNum
            // 
            this.sizeXDimensionNum.Location = new System.Drawing.Point(133, 20);
            this.sizeXDimensionNum.Name = "sizeXDimensionNum";
            this.sizeXDimensionNum.Size = new System.Drawing.Size(114, 20);
            this.sizeXDimensionNum.TabIndex = 1;
            this.sizeXDimensionNum.ValueChanged += new System.EventHandler(this.sizeXDimension_ValueChanged);
            // 
            // sizeYDimensionNum
            // 
            this.sizeYDimensionNum.Location = new System.Drawing.Point(133, 49);
            this.sizeYDimensionNum.Name = "sizeYDimensionNum";
            this.sizeYDimensionNum.Size = new System.Drawing.Size(114, 20);
            this.sizeYDimensionNum.TabIndex = 2;
            this.sizeYDimensionNum.ValueChanged += new System.EventHandler(this.sizeYDimension_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dimension X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Dimension Y";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clearButton);
            this.groupBox1.Controls.Add(this.singleStepButton);
            this.groupBox1.Controls.Add(this.speedNum);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.grainsAmountNum);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.submitButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.sizeYDimensionNum);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.sizeXDimensionNum);
            this.groupBox1.Location = new System.Drawing.Point(1044, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 140);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Set a dimensions and grains amount";
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(253, 80);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(109, 20);
            this.clearButton.TabIndex = 11;
            this.clearButton.Text = "Clear all";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // singleStepButton
            // 
            this.singleStepButton.Location = new System.Drawing.Point(253, 49);
            this.singleStepButton.Name = "singleStepButton";
            this.singleStepButton.Size = new System.Drawing.Size(109, 20);
            this.singleStepButton.TabIndex = 10;
            this.singleStepButton.Text = "Single Step";
            this.singleStepButton.UseVisualStyleBackColor = true;
            this.singleStepButton.Click += new System.EventHandler(this.singleStep_Click);
            // 
            // speedNum
            // 
            this.speedNum.Location = new System.Drawing.Point(133, 110);
            this.speedNum.Name = "speedNum";
            this.speedNum.Size = new System.Drawing.Size(114, 20);
            this.speedNum.TabIndex = 9;
            this.speedNum.ValueChanged += new System.EventHandler(this.speed_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Speed\r\n";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // grainsAmountNum
            // 
            this.grainsAmountNum.Location = new System.Drawing.Point(133, 80);
            this.grainsAmountNum.Name = "grainsAmountNum";
            this.grainsAmountNum.Size = new System.Drawing.Size(114, 20);
            this.grainsAmountNum.TabIndex = 7;
            this.grainsAmountNum.ValueChanged += new System.EventHandler(this.grainsAmount_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Amount of grains";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(253, 20);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(109, 20);
            this.submitButton.TabIndex = 5;
            this.submitButton.Text = "Generate";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Location = new System.Drawing.Point(1044, 257);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(368, 49);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Border Conditions";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(7, 20);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(120, 17);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "periodic / absorbing";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.inclusionsAfter);
            this.groupBox3.Controls.Add(this.inclusionsAmountNum);
            this.groupBox3.Controls.Add(this.inclusionsBefore);
            this.groupBox3.Controls.Add(this.sizeInclusionsNum);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(1044, 151);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(368, 100);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Inclusions";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // inclusionsBefore
            // 
            this.inclusionsBefore.Location = new System.Drawing.Point(254, 23);
            this.inclusionsBefore.Name = "inclusionsBefore";
            this.inclusionsBefore.Size = new System.Drawing.Size(109, 20);
            this.inclusionsBefore.TabIndex = 4;
            this.inclusionsBefore.Text = "Generate Before";
            this.inclusionsBefore.UseVisualStyleBackColor = true;
            this.inclusionsBefore.Click += new System.EventHandler(this.inclusionsBefore_Click);
            // 
            // sizeInclusionsNum
            // 
            this.sizeInclusionsNum.Location = new System.Drawing.Point(133, 62);
            this.sizeInclusionsNum.Name = "sizeInclusionsNum";
            this.sizeInclusionsNum.Size = new System.Drawing.Size(114, 20);
            this.sizeInclusionsNum.TabIndex = 3;
            this.sizeInclusionsNum.ValueChanged += new System.EventHandler(this.sizeInclusionsNum_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 64);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Size of inclusions";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Amount of inclusions";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // inclusionsAmountNum
            // 
            this.inclusionsAmountNum.Location = new System.Drawing.Point(133, 23);
            this.inclusionsAmountNum.Name = "inclusionsAmountNum";
            this.inclusionsAmountNum.Size = new System.Drawing.Size(114, 20);
            this.inclusionsAmountNum.TabIndex = 5;
            this.inclusionsAmountNum.ValueChanged += new System.EventHandler(this.inclusionsAmountNum_ValueChanged);
            // 
            // inclusionsAfter
            // 
            this.inclusionsAfter.Location = new System.Drawing.Point(253, 60);
            this.inclusionsAfter.Name = "inclusionsAfter";
            this.inclusionsAfter.Size = new System.Drawing.Size(109, 20);
            this.inclusionsAfter.TabIndex = 6;
            this.inclusionsAfter.Text = "Generate After";
            this.inclusionsAfter.UseVisualStyleBackColor = true;
            this.inclusionsAfter.Click += new System.EventHandler(this.inclusionsAfter_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 658);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeXDimensionNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeYDimensionNum)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grainsAmountNum)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sizeInclusionsNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inclusionsAmountNum)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.NumericUpDown sizeXDimensionNum;
        private System.Windows.Forms.NumericUpDown sizeYDimensionNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.NumericUpDown grainsAmountNum;
        private System.Windows.Forms.NumericUpDown speedNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button singleStepButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown sizeInclusionsNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button inclusionsBefore;
        private System.Windows.Forms.NumericUpDown inclusionsAmountNum;
        private System.Windows.Forms.Button inclusionsAfter;
    }
}

