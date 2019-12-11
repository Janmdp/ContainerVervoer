namespace ContainerVervoer
{
    partial class Form1
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
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDownLength = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownMaxWeight = new System.Windows.Forms.NumericUpDown();
            this.buttonCreateShip = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxCargoType = new System.Windows.Forms.ComboBox();
            this.buttonAddContainer = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownWeight = new System.Windows.Forms.NumericUpDown();
            this.listBoxContainers = new System.Windows.Forms.ListBox();
            this.listBoxStacks = new System.Windows.Forms.ListBox();
            this.listBoxRows = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxWeight)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWeight)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Location = new System.Drawing.Point(318, 136);
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownHeight.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(318, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hoogte in containers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(318, 161);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Breedte in ccontainers";
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Location = new System.Drawing.Point(318, 184);
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownWidth.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(318, 209);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "Lengte in containers";
            // 
            // numericUpDownLength
            // 
            this.numericUpDownLength.Location = new System.Drawing.Point(318, 232);
            this.numericUpDownLength.Name = "numericUpDownLength";
            this.numericUpDownLength.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownLength.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(318, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "Maximumgewicht";
            // 
            // numericUpDownMaxWeight
            // 
            this.numericUpDownMaxWeight.Increment = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownMaxWeight.Location = new System.Drawing.Point(318, 280);
            this.numericUpDownMaxWeight.Maximum = new decimal(new int[] {
            -727379969,
            232,
            0,
            0});
            this.numericUpDownMaxWeight.Minimum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDownMaxWeight.Name = "numericUpDownMaxWeight";
            this.numericUpDownMaxWeight.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownMaxWeight.TabIndex = 6;
            this.numericUpDownMaxWeight.Value = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            // 
            // buttonCreateShip
            // 
            this.buttonCreateShip.Location = new System.Drawing.Point(321, 324);
            this.buttonCreateShip.Name = "buttonCreateShip";
            this.buttonCreateShip.Size = new System.Drawing.Size(110, 23);
            this.buttonCreateShip.TabIndex = 8;
            this.buttonCreateShip.Text = "Maak ship";
            this.buttonCreateShip.UseVisualStyleBackColor = true;
            this.buttonCreateShip.Click += new System.EventHandler(this.buttonCreateShip_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(805, 468);
            this.tabControl1.TabIndex = 9;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.numericUpDownHeight);
            this.tabPage1.Controls.Add(this.buttonCreateShip);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.numericUpDownWidth);
            this.tabPage1.Controls.Add(this.numericUpDownMaxWeight);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.numericUpDownLength);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(797, 439);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.listBoxContainers);
            this.tabPage2.Controls.Add(this.listBoxStacks);
            this.tabPage2.Controls.Add(this.listBoxRows);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(797, 439);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxCargoType);
            this.groupBox1.Controls.Add(this.buttonAddContainer);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.numericUpDownWeight);
            this.groupBox1.Location = new System.Drawing.Point(6, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 209);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create Container";
            // 
            // comboBoxCargoType
            // 
            this.comboBoxCargoType.FormattingEnabled = true;
            this.comboBoxCargoType.Location = new System.Drawing.Point(19, 111);
            this.comboBoxCargoType.Name = "comboBoxCargoType";
            this.comboBoxCargoType.Size = new System.Drawing.Size(121, 24);
            this.comboBoxCargoType.TabIndex = 28;
            // 
            // buttonAddContainer
            // 
            this.buttonAddContainer.Location = new System.Drawing.Point(19, 160);
            this.buttonAddContainer.Name = "buttonAddContainer";
            this.buttonAddContainer.Size = new System.Drawing.Size(120, 23);
            this.buttonAddContainer.TabIndex = 26;
            this.buttonAddContainer.Text = "Add Container";
            this.buttonAddContainer.UseVisualStyleBackColor = true;
            this.buttonAddContainer.Click += new System.EventHandler(this.buttonAddContainer_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 17);
            this.label5.TabIndex = 25;
            this.label5.Text = "Weight";
            // 
            // numericUpDownWeight
            // 
            this.numericUpDownWeight.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownWeight.Location = new System.Drawing.Point(19, 63);
            this.numericUpDownWeight.Maximum = new decimal(new int[] {
            120000,
            0,
            0,
            0});
            this.numericUpDownWeight.Minimum = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            this.numericUpDownWeight.Name = "numericUpDownWeight";
            this.numericUpDownWeight.Size = new System.Drawing.Size(120, 22);
            this.numericUpDownWeight.TabIndex = 21;
            this.numericUpDownWeight.Value = new decimal(new int[] {
            4000,
            0,
            0,
            0});
            // 
            // listBoxContainers
            // 
            this.listBoxContainers.FormattingEnabled = true;
            this.listBoxContainers.ItemHeight = 16;
            this.listBoxContainers.Location = new System.Drawing.Point(552, 45);
            this.listBoxContainers.Name = "listBoxContainers";
            this.listBoxContainers.Size = new System.Drawing.Size(189, 244);
            this.listBoxContainers.TabIndex = 20;
            // 
            // listBoxStacks
            // 
            this.listBoxStacks.FormattingEnabled = true;
            this.listBoxStacks.ItemHeight = 16;
            this.listBoxStacks.Location = new System.Drawing.Point(390, 45);
            this.listBoxStacks.Name = "listBoxStacks";
            this.listBoxStacks.Size = new System.Drawing.Size(120, 244);
            this.listBoxStacks.TabIndex = 19;
            this.listBoxStacks.SelectedIndexChanged += new System.EventHandler(this.listBoxStacks_SelectedIndexChanged);
            // 
            // listBoxRows
            // 
            this.listBoxRows.FormattingEnabled = true;
            this.listBoxRows.ItemHeight = 16;
            this.listBoxRows.Location = new System.Drawing.Point(227, 45);
            this.listBoxRows.Name = "listBoxRows";
            this.listBoxRows.Size = new System.Drawing.Size(120, 244);
            this.listBoxRows.TabIndex = 18;
            this.listBoxRows.SelectedIndexChanged += new System.EventHandler(this.listBoxRows_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(829, 492);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxWeight)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWeight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDownHeight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDownLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxWeight;
        private System.Windows.Forms.Button buttonCreateShip;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonAddContainer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownWeight;
        private System.Windows.Forms.ListBox listBoxContainers;
        private System.Windows.Forms.ListBox listBoxStacks;
        private System.Windows.Forms.ListBox listBoxRows;
        private System.Windows.Forms.ComboBox comboBoxCargoType;
    }
}

