using CommonProject.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CommonProject
{
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();

        }

        public void LoadDeviceNames()
        {
            cbbSerialPort.DataSource = SerialPort.GetPortNames();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            LoadDeviceNames();
            var comport = RegeditHelper.GetValueRegistryKey(REGEDIT.CommonRegeditConfig, REGEDIT.PortName);
            cbbSerialPort.Text = comport;
        }

        private void btnSaveChanged_Click(object sender, EventArgs e)
        {
            var flag = string.IsNullOrEmpty(cbbSerialPort.Text);
            if (flag)
            {
                MessageBox.Show("Chưa chọn ComPort!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            flag = string.IsNullOrEmpty(txtRun.Text);
            if (flag)
            {
                MessageBox.Show("Chưa cài đặt tín hiệu OK!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            flag = string.IsNullOrEmpty(txtStop.Text);
            if (flag)
            {
                MessageBox.Show("Chưa cài đặt tín hiệu NG!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            flag = txtRun.Text == txtStop.Text;
            if (flag)
            {
                MessageBox.Show("Tín hiệu không hợp lệ!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }

            RegeditHelper.WriteRegistry(REGEDIT.CommonRegeditConfig, REGEDIT.PortName, cbbSerialPort.Text);
            RegeditHelper.WriteRegistry(REGEDIT.CommonRegeditConfig, REGEDIT.SignalOK, txtRun.Text);
            RegeditHelper.WriteRegistry(REGEDIT.CommonRegeditConfig, REGEDIT.SignalNG, txtStop.Text);
            MessageBox.Show("Save success!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }


        private void lblRefreshCOMPorts_Click(object sender, EventArgs e)
        {
            
        }


        private void btnTestSend_Click(object sender, EventArgs e)
        {
            CommPort comm = CommPort.Instance;
            comm.StatusChanged += OnStatusChanged;
            comm.Open(cbbSerialPort.Text);
            try
            {
                comm.Send(txtRun.Text);
                MessageBox.Show("Gửi thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception comException)
            {
                MessageBox.Show(comException.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void OnStatusChanged(string param)
        {
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            CommPort comm = CommPort.Instance;
            comm.StatusChanged += OnStatusChanged;
            comm.Open(cbbSerialPort.Text);
            try
            {
                comm.Send(txtStop.Text);
                MessageBox.Show("Gửi thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception comException)
            {
                MessageBox.Show(comException.Message, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

    }
}
