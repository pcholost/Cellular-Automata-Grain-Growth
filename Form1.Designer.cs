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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxInclusion = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.inclusionsAfter = new System.Windows.Forms.Button();
            this.inclusionsAmountNum = new System.Windows.Forms.NumericUpDown();
            this.inclusionsBefore = new System.Windows.Forms.Button();
            this.sizeInclusionsNum = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.probabilityUpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.controlStep = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.generateWithStructureBtn = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.selectGrainsButton = new System.Windows.Forms.Button();
            this.singleStructureStepButton = new System.Windows.Forms.Button();
            this.checkBoxSelection = new System.Windows.Forms.CheckBox();
            this.grainsAmountToSelectionNum = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.selectedBordersBtn = new System.Windows.Forms.Button();
            this.selectBorderGrainBtn = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.GBNumeric = new System.Windows.Forms.NumericUpDown();
            this.generateBoundaryBtn = new System.Windows.Forms.Button();
            this.sizeXDimensionNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.sizeYDimensionNum = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.grainsAmountNum = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.speedNum = new System.Windows.Forms.NumericUpDown();
            this.singleStepButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inclusionsAmountNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeInclusionsNum)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityUpDown)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grainsAmountToSelectionNum)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GBNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeXDimensionNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeYDimensionNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grainsAmountNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedNum)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Location = new System.Drawing.Point(1044, 302);
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
            this.checkBox1.Text = "absorbing / periodic";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxInclusion);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.inclusionsAfter);
            this.groupBox3.Controls.Add(this.inclusionsAmountNum);
            this.groupBox3.Controls.Add(this.inclusionsBefore);
            this.groupBox3.Controls.Add(this.sizeInclusionsNum);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Location = new System.Drawing.Point(1044, 160);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(368, 125);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Inclusions";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // checkBoxInclusion
            // 
            this.checkBoxInclusion.AutoSize = true;
            this.checkBoxInclusion.Location = new System.Drawing.Point(133, 99);
            this.checkBoxInclusion.Name = "checkBoxInclusion";
            this.checkBoxInclusion.Size = new System.Drawing.Size(106, 17);
            this.checkBoxInclusion.TabIndex = 8;
            this.checkBoxInclusion.Text = "Square / Circular";
            this.checkBoxInclusion.UseVisualStyleBackColor = true;
            this.checkBoxInclusion.CheckedChanged += new System.EventHandler(this.checkBoxInclusion_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Type of Inclusion";
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
            // inclusionsAmountNum
            // 
            this.inclusionsAmountNum.Location = new System.Drawing.Point(133, 23);
            this.inclusionsAmountNum.Name = "inclusionsAmountNum";
            this.inclusionsAmountNum.Size = new System.Drawing.Size(114, 20);
            this.inclusionsAmountNum.TabIndex = 5;
            this.inclusionsAmountNum.ValueChanged += new System.EventHandler(this.inclusionsAmountNum_ValueChanged);
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
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.probabilityUpDown);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.controlStep);
            this.groupBox4.Location = new System.Drawing.Point(1044, 369);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(368, 49);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Shape Control";
            // 
            // probabilityUpDown
            // 
            this.probabilityUpDown.Location = new System.Drawing.Point(133, 21);
            this.probabilityUpDown.Name = "probabilityUpDown";
            this.probabilityUpDown.Size = new System.Drawing.Size(114, 20);
            this.probabilityUpDown.TabIndex = 9;
            this.probabilityUpDown.ValueChanged += new System.EventHandler(this.probabilityUpDown_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Probability [%]";
            // 
            // controlStep
            // 
            this.controlStep.Location = new System.Drawing.Point(253, 21);
            this.controlStep.Name = "controlStep";
            this.controlStep.Size = new System.Drawing.Size(109, 20);
            this.controlStep.TabIndex = 12;
            this.controlStep.Text = "Control Single Step";
            this.controlStep.UseVisualStyleBackColor = true;
            this.controlStep.Click += new System.EventHandler(this.controlStep_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.generateWithStructureBtn);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.selectGrainsButton);
            this.groupBox5.Controls.Add(this.singleStructureStepButton);
            this.groupBox5.Controls.Add(this.checkBoxSelection);
            this.groupBox5.Controls.Add(this.grainsAmountToSelectionNum);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Location = new System.Drawing.Point(1044, 434);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(368, 103);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Grains selection";
            this.groupBox5.Enter += new System.EventHandler(this.groupBox5_Enter);
            // 
            // generateWithStructureBtn
            // 
            this.generateWithStructureBtn.Location = new System.Drawing.Point(179, 77);
            this.generateWithStructureBtn.Name = "generateWithStructureBtn";
            this.generateWithStructureBtn.Size = new System.Drawing.Size(183, 20);
            this.generateWithStructureBtn.TabIndex = 15;
            this.generateWithStructureBtn.Text = "Generate with selected Structure";
            this.generateWithStructureBtn.UseVisualStyleBackColor = true;
            this.generateWithStructureBtn.Click += new System.EventHandler(this.generateWithStructureBtn_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Amount of grains";
            // 
            // selectGrainsButton
            // 
            this.selectGrainsButton.Location = new System.Drawing.Point(6, 77);
            this.selectGrainsButton.Name = "selectGrainsButton";
            this.selectGrainsButton.Size = new System.Drawing.Size(167, 20);
            this.selectGrainsButton.TabIndex = 13;
            this.selectGrainsButton.Text = "Select Grains from Structure";
            this.selectGrainsButton.UseVisualStyleBackColor = true;
            this.selectGrainsButton.Click += new System.EventHandler(this.selectGrainsButton_Click);
            // 
            // singleStructureStepButton
            // 
            this.singleStructureStepButton.Location = new System.Drawing.Point(230, 51);
            this.singleStructureStepButton.Name = "singleStructureStepButton";
            this.singleStructureStepButton.Size = new System.Drawing.Size(120, 20);
            this.singleStructureStepButton.TabIndex = 9;
            this.singleStructureStepButton.Text = "Single Growth Step";
            this.singleStructureStepButton.UseVisualStyleBackColor = true;
            this.singleStructureStepButton.Click += new System.EventHandler(this.singleStructureStepButton_Click);
            // 
            // checkBoxSelection
            // 
            this.checkBoxSelection.AutoSize = true;
            this.checkBoxSelection.Location = new System.Drawing.Point(110, 24);
            this.checkBoxSelection.Name = "checkBoxSelection";
            this.checkBoxSelection.Size = new System.Drawing.Size(152, 17);
            this.checkBoxSelection.TabIndex = 9;
            this.checkBoxSelection.Text = "Substructure / Dual Phase";
            this.checkBoxSelection.UseVisualStyleBackColor = true;
            this.checkBoxSelection.CheckedChanged += new System.EventHandler(this.CheckBox2_CheckedChanged);
            // 
            // grainsAmountToSelectionNum
            // 
            this.grainsAmountToSelectionNum.Location = new System.Drawing.Point(110, 51);
            this.grainsAmountToSelectionNum.Name = "grainsAmountToSelectionNum";
            this.grainsAmountToSelectionNum.Size = new System.Drawing.Size(114, 20);
            this.grainsAmountToSelectionNum.TabIndex = 9;
            this.grainsAmountToSelectionNum.ValueChanged += new System.EventHandler(this.grainsAmountToSelectionNum_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 25);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Type of selection";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.selectedBordersBtn);
            this.groupBox6.Controls.Add(this.selectBorderGrainBtn);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.GBNumeric);
            this.groupBox6.Controls.Add(this.generateBoundaryBtn);
            this.groupBox6.Location = new System.Drawing.Point(1044, 557);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(368, 77);
            this.groupBox6.TabIndex = 16;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Borders";
            // 
            // selectedBordersBtn
            // 
            this.selectedBordersBtn.Location = new System.Drawing.Point(222, 45);
            this.selectedBordersBtn.Name = "selectedBordersBtn";
            this.selectedBordersBtn.Size = new System.Drawing.Size(128, 20);
            this.selectedBordersBtn.TabIndex = 17;
            this.selectedBordersBtn.Text = "Show selected borders";
            this.selectedBordersBtn.UseVisualStyleBackColor = true;
            this.selectedBordersBtn.Click += new System.EventHandler(this.selectedBordersBtn_Click);
            // 
            // selectBorderGrainBtn
            // 
            this.selectBorderGrainBtn.Location = new System.Drawing.Point(222, 19);
            this.selectBorderGrainBtn.Name = "selectBorderGrainBtn";
            this.selectBorderGrainBtn.Size = new System.Drawing.Size(128, 20);
            this.selectBorderGrainBtn.TabIndex = 16;
            this.selectBorderGrainBtn.Text = "Select Border Grain";
            this.selectBorderGrainBtn.UseVisualStyleBackColor = true;
            this.selectBorderGrainBtn.Click += new System.EventHandler(this.selectBorderGrainBtn_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 21);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(45, 13);
            this.label11.TabIndex = 16;
            this.label11.Text = "GB Size";
            // 
            // GBNumeric
            // 
            this.GBNumeric.Location = new System.Drawing.Point(68, 19);
            this.GBNumeric.Name = "GBNumeric";
            this.GBNumeric.Size = new System.Drawing.Size(114, 20);
            this.GBNumeric.TabIndex = 16;
            this.GBNumeric.ValueChanged += new System.EventHandler(this.GBNumeric_ValueChanged);
            // 
            // generateBoundaryBtn
            // 
            this.generateBoundaryBtn.Location = new System.Drawing.Point(9, 45);
            this.generateBoundaryBtn.Name = "generateBoundaryBtn";
            this.generateBoundaryBtn.Size = new System.Drawing.Size(127, 20);
            this.generateBoundaryBtn.TabIndex = 16;
            this.generateBoundaryBtn.Text = "Generate Boundaries";
            this.generateBoundaryBtn.UseVisualStyleBackColor = true;
            this.generateBoundaryBtn.Click += new System.EventHandler(this.generateBoundaryBtn_Click);
            // 
            // sizeXDimensionNum
            // 
            this.sizeXDimensionNum.Location = new System.Drawing.Point(133, 20);
            this.sizeXDimensionNum.Name = "sizeXDimensionNum";
            this.sizeXDimensionNum.Size = new System.Drawing.Size(114, 20);
            this.sizeXDimensionNum.TabIndex = 1;
            this.sizeXDimensionNum.ValueChanged += new System.EventHandler(this.sizeXDimension_ValueChanged);
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
            // sizeYDimensionNum
            // 
            this.sizeYDimensionNum.Location = new System.Drawing.Point(133, 49);
            this.sizeYDimensionNum.Name = "sizeYDimensionNum";
            this.sizeYDimensionNum.Size = new System.Drawing.Size(114, 20);
            this.sizeYDimensionNum.TabIndex = 2;
            this.sizeYDimensionNum.ValueChanged += new System.EventHandler(this.sizeYDimension_ValueChanged);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Amount of grains";
            // 
            // grainsAmountNum
            // 
            this.grainsAmountNum.Location = new System.Drawing.Point(133, 80);
            this.grainsAmountNum.Name = "grainsAmountNum";
            this.grainsAmountNum.Size = new System.Drawing.Size(114, 20);
            this.grainsAmountNum.TabIndex = 7;
            this.grainsAmountNum.ValueChanged += new System.EventHandler(this.grainsAmount_ValueChanged);
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
            // speedNum
            // 
            this.speedNum.Location = new System.Drawing.Point(133, 110);
            this.speedNum.Name = "speedNum";
            this.speedNum.Size = new System.Drawing.Size(114, 20);
            this.speedNum.TabIndex = 9;
            this.speedNum.ValueChanged += new System.EventHandler(this.speed_ValueChanged);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 658);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inclusionsAmountNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeInclusionsNum)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.probabilityUpDown)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grainsAmountToSelectionNum)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GBNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeXDimensionNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeYDimensionNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grainsAmountNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedNum)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown sizeInclusionsNum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button inclusionsBefore;
        private System.Windows.Forms.NumericUpDown inclusionsAmountNum;
        private System.Windows.Forms.Button inclusionsAfter;
        private System.Windows.Forms.CheckBox checkBoxInclusion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown probabilityUpDown;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button controlStep;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown grainsAmountToSelectionNum;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox checkBoxSelection;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button selectGrainsButton;
        private System.Windows.Forms.Button singleStructureStepButton;
        private System.Windows.Forms.Button generateWithStructureBtn;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button generateBoundaryBtn;
        private System.Windows.Forms.Button selectBorderGrainBtn;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown GBNumeric;
        private System.Windows.Forms.Button selectedBordersBtn;
        private System.Windows.Forms.NumericUpDown sizeXDimensionNum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown sizeYDimensionNum;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown grainsAmountNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown speedNum;
        private System.Windows.Forms.Button singleStepButton;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

