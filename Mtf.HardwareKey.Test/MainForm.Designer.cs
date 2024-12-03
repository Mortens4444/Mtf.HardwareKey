


namespace Mtf.HardwareKey.Test
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnCreateHardwareKey = new Button();
            btnDispose = new Button();
            btnReadCells = new Button();
            btnWriteCell = new Button();
            dgvMemoryMap = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewTextBoxColumn();
            Column9 = new DataGridViewTextBoxColumn();
            Column10 = new DataGridViewTextBoxColumn();
            Column11 = new DataGridViewTextBoxColumn();
            Column12 = new DataGridViewTextBoxColumn();
            Column13 = new DataGridViewTextBoxColumn();
            Column14 = new DataGridViewTextBoxColumn();
            Column15 = new DataGridViewTextBoxColumn();
            Column16 = new DataGridViewTextBoxColumn();
            toolTip = new ToolTip(components);
            tbValue = new TextBox();
            btnWriteBit = new Button();
            cbCell = new ComboBox();
            chkBit = new CheckBox();
            cbAccessCode = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvMemoryMap).BeginInit();
            SuspendLayout();
            // 
            // btnCreateHardwareKey
            // 
            btnCreateHardwareKey.Location = new Point(12, 12);
            btnCreateHardwareKey.Name = "btnCreateHardwareKey";
            btnCreateHardwareKey.Size = new Size(129, 23);
            btnCreateHardwareKey.TabIndex = 0;
            btnCreateHardwareKey.Text = "Create HardwareKey";
            btnCreateHardwareKey.UseVisualStyleBackColor = true;
            btnCreateHardwareKey.Click += BtnCreateHardwareKey_Click;
            // 
            // btnDispose
            // 
            btnDispose.Location = new Point(12, 41);
            btnDispose.Name = "btnDispose";
            btnDispose.Size = new Size(129, 23);
            btnDispose.TabIndex = 1;
            btnDispose.Text = "Dispose";
            btnDispose.UseVisualStyleBackColor = true;
            btnDispose.Click += BtnDispose_Click;
            // 
            // btnReadCells
            // 
            btnReadCells.Location = new Point(147, 12);
            btnReadCells.Name = "btnReadCells";
            btnReadCells.Size = new Size(75, 23);
            btnReadCells.TabIndex = 2;
            btnReadCells.Text = "Read cells";
            btnReadCells.UseVisualStyleBackColor = true;
            btnReadCells.Click += BtnReadCells_Click;
            // 
            // btnWriteCell
            // 
            btnWriteCell.Location = new Point(254, 12);
            btnWriteCell.Name = "btnWriteCell";
            btnWriteCell.Size = new Size(75, 23);
            btnWriteCell.TabIndex = 3;
            btnWriteCell.Text = "Write cell";
            btnWriteCell.UseVisualStyleBackColor = true;
            btnWriteCell.Click += BtnWriteCell_Click;
            // 
            // dgvMemoryMap
            // 
            dgvMemoryMap.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvMemoryMap.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMemoryMap.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3, Column4, Column5, Column6, Column7, Column8, Column9, Column10, Column11, Column12, Column13, Column14, Column15, Column16 });
            dgvMemoryMap.Location = new Point(12, 79);
            dgvMemoryMap.Name = "dgvMemoryMap";
            dgvMemoryMap.Size = new Size(1657, 350);
            dgvMemoryMap.TabIndex = 4;
            // 
            // Column1
            // 
            Column1.HeaderText = "0x00";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.HeaderText = "0x01";
            Column2.Name = "Column2";
            // 
            // Column3
            // 
            Column3.HeaderText = "0x02";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "0x03";
            Column4.Name = "Column4";
            // 
            // Column5
            // 
            Column5.HeaderText = "0x04";
            Column5.Name = "Column5";
            // 
            // Column6
            // 
            Column6.HeaderText = "0x05";
            Column6.Name = "Column6";
            // 
            // Column7
            // 
            Column7.HeaderText = "0x06";
            Column7.Name = "Column7";
            // 
            // Column8
            // 
            Column8.HeaderText = "0x07";
            Column8.Name = "Column8";
            // 
            // Column9
            // 
            Column9.HeaderText = "0x08";
            Column9.Name = "Column9";
            // 
            // Column10
            // 
            Column10.HeaderText = "0x09";
            Column10.Name = "Column10";
            // 
            // Column11
            // 
            Column11.HeaderText = "0x0A";
            Column11.Name = "Column11";
            // 
            // Column12
            // 
            Column12.HeaderText = "0x0B";
            Column12.Name = "Column12";
            // 
            // Column13
            // 
            Column13.HeaderText = "0x0C";
            Column13.Name = "Column13";
            // 
            // Column14
            // 
            Column14.HeaderText = "0x0D";
            Column14.Name = "Column14";
            // 
            // Column15
            // 
            Column15.HeaderText = "0x0E";
            Column15.Name = "Column15";
            // 
            // Column16
            // 
            Column16.HeaderText = "0x0F";
            Column16.Name = "Column16";
            // 
            // tbValue
            // 
            tbValue.BackColor = Color.Silver;
            tbValue.Location = new Point(335, 12);
            tbValue.Name = "tbValue";
            tbValue.Size = new Size(100, 23);
            tbValue.TabIndex = 5;
            // 
            // btnWriteBit
            // 
            btnWriteBit.Location = new Point(254, 41);
            btnWriteBit.Name = "btnWriteBit";
            btnWriteBit.Size = new Size(75, 23);
            btnWriteBit.TabIndex = 6;
            btnWriteBit.Text = "Write bit";
            btnWriteBit.UseVisualStyleBackColor = true;
            btnWriteBit.Click += BtnWriteBit_Click;
            // 
            // cbCell
            // 
            cbCell.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCell.FormattingEnabled = true;
            cbCell.Location = new Point(335, 41);
            cbCell.Name = "cbCell";
            cbCell.Size = new Size(79, 23);
            cbCell.TabIndex = 7;
            // 
            // chkBit
            // 
            chkBit.AutoSize = true;
            chkBit.Location = new Point(420, 45);
            chkBit.Name = "chkBit";
            chkBit.Size = new Size(15, 14);
            chkBit.TabIndex = 8;
            chkBit.UseVisualStyleBackColor = true;
            // 
            // cbAccessCode
            // 
            cbAccessCode.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAccessCode.FormattingEnabled = true;
            cbAccessCode.Location = new Point(441, 12);
            cbAccessCode.Name = "cbAccessCode";
            cbAccessCode.Size = new Size(128, 23);
            cbAccessCode.TabIndex = 9;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(64, 64, 64);
            ClientSize = new Size(1681, 441);
            Controls.Add(cbAccessCode);
            Controls.Add(chkBit);
            Controls.Add(cbCell);
            Controls.Add(btnWriteBit);
            Controls.Add(tbValue);
            Controls.Add(dgvMemoryMap);
            Controls.Add(btnWriteCell);
            Controls.Add(btnReadCells);
            Controls.Add(btnDispose);
            Controls.Add(btnCreateHardwareKey);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)dgvMemoryMap).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnCreateHardwareKey;
        private Button btnDispose;
        private Button btnReadCells;
        private Button btnWriteCell;
        private DataGridView dgvMemoryMap;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewTextBoxColumn Column8;
        private DataGridViewTextBoxColumn Column9;
        private DataGridViewTextBoxColumn Column10;
        private DataGridViewTextBoxColumn Column11;
        private DataGridViewTextBoxColumn Column12;
        private DataGridViewTextBoxColumn Column13;
        private DataGridViewTextBoxColumn Column14;
        private DataGridViewTextBoxColumn Column15;
        private DataGridViewTextBoxColumn Column16;
        private ToolTip toolTip;
        private TextBox tbValue;
        private Button btnWriteBit;
        private ComboBox cbCell;
        private CheckBox chkBit;
        private ComboBox cbAccessCode;
    }
}
