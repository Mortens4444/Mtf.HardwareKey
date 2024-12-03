using Mtf.HardwareKey.Enums;
using Mtf.HardwareKey.Interfaces;
using Mtf.HardwareKey.Models;
using Mtf.MessageBoxes;

namespace Mtf.HardwareKey.Test
{
    public partial class MainForm : Form
    {
        private IHardwareKey? hardwareKey;

        public MainForm()
        {
            InitializeComponent();

            cbCell.DataSource = Enum.GetValues(typeof(Bit));
            cbCell.SelectedIndex = 0;

            cbAccessCode.DataSource = Enum.GetValues(typeof(SentinelSuperProAccessCode));
            cbAccessCode.SelectedIndex = 0;
        }

        private void BtnCreateHardwareKey_Click(object sender, EventArgs e)
        {
            try
            {
                hardwareKey = new HardwareKey(HardwareKeyDeveloper.Test1);
                InfoBox.Show("Success", "Hardware key created");
            }
            catch (Exception ex)
            {
                ErrorBox.Show(ex);
            }
        }

        private void BtnReadCells_Click(object sender, EventArgs e)
        {
            if (hardwareKey != null)
            {
                dgvMemoryMap.Rows.Clear();
                for (ushort i = 0; i <= MemoryAddress.MaxAddress; i++)
                {
                    var address = (MemoryAddress)i;
                    var rowIndex = i / 16;
                    var columnIndex = i % 16;
                    var dataType = MemoryAddress.GetDataType(hardwareKey.DeveloperId, i);

                    try
                    {
                        if (columnIndex == 0)
                        {
                            dgvMemoryMap.Rows.Add();
                            dgvMemoryMap.Rows[rowIndex].HeaderCell.Value = $"0x{(i & 0xFFF0):X2}";
                        }
                        if (i <= 0x07 || i >= 0xF0)
                        {
                            dgvMemoryMap.Rows[rowIndex].Cells[columnIndex].Style.BackColor = Color.LightCoral;
                        }

                        var cellValue = hardwareKey.ReadCellValue(address);
                        dgvMemoryMap.Rows[rowIndex].Cells[columnIndex].Value = $"0x{cellValue:X4}";
                        dgvMemoryMap.Rows[rowIndex].Cells[columnIndex].ToolTipText = $"{dataType}{Environment.NewLine}{cellValue}";
                    }
                    catch
                    {
                        dgvMemoryMap.Rows[rowIndex].Cells[columnIndex].Value = $"N/A";
                        dgvMemoryMap.Rows[rowIndex].Cells[columnIndex].ToolTipText = dataType.ToString();
                    }
                }
            }
            else
            {
                ErrorBox.Show("Error", "Create a hardware key first");
            }
        }

        private void BtnWriteCell_Click(object sender, EventArgs e)
        {
            if (hardwareKey != null)
            {
                try
                {
                    var newValue = Convert.ToUInt16(tbValue.Text);
                    for (int i = 0; i < dgvMemoryMap.SelectedCells.Count; i++)
                    {
                        var selectedCell = dgvMemoryMap.SelectedCells[i];
                        var address = (ushort)(selectedCell.RowIndex * 16 + selectedCell.ColumnIndex);
                        hardwareKey.WriteCellValue(address, newValue, (SentinelSuperProAccessCode)cbAccessCode.SelectedItem);
                    }
                }
                catch (Exception ex)
                {
                    ErrorBox.Show(ex);
                }
            }
            else
            {
                ErrorBox.Show("Error", "Create a hardware key first");
            }
        }

        private void BtnWriteBit_Click(object sender, EventArgs e)
        {
            if (hardwareKey != null)
            {
                try
                {
                    for (int i = 0; i < dgvMemoryMap.SelectedCells.Count; i++)
                    {
                        var selectedCell = dgvMemoryMap.SelectedCells[i];
                        var address = (ushort)(selectedCell.RowIndex * 16 + selectedCell.ColumnIndex);
                        hardwareKey.WriteBit(address, (Bit)cbCell.SelectedItem, chkBit.Checked);
                    }
                }
                catch (Exception ex)
                {
                    ErrorBox.Show(ex);
                }
            }
            else
            {
                ErrorBox.Show("Error", "Create a hardware key first");
            }
        }

        private void BtnDispose_Click(object sender, EventArgs e)
        {
            if (hardwareKey != null)
            {
                hardwareKey.Dispose();
                hardwareKey = null;
            }
            else
            {
                ErrorBox.Show("Error", "Create a hardware key first");
            }
        }
    }
}
