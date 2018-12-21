using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace test {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
        private ClsBgWorker bgWork;
        static int id=0;
        private void btnStart_Click(object sender, EventArgs e) {
            WorkRange wr = new WorkRange();
            id = id == 0 ? 1 : 0;
            wr.id = id;
            wr.nStart = new Random().Next(1,1000)*100;
            wr.nEnd = new Random().Next(1,1000) * 1000;
            bgWork = new ClsBgWorker(wr,this);
            bgWork.Complete += new ClsBgWorker.CompleteHandler(DoComplete);
            bgWork.SendMessage += new ClsBgWorker.MessageHandler(SendMessage);
            if (id == 1) {
                lstRange.Items.Clear();
            } else if (id == 0) {
                lstResult.Items.Clear();
            }
            bgWork.Run();
        }
        private void btnCancel_Click(object sender, EventArgs e) {
            bgWork.Cancel();
        }
        private void DoComplete(bool cancel,WorkResult result) {
            if (cancel)
                return;
            if (id == 1) {
                lstRange.Items.Add(result.result.ToString());
            } else if (id == 0) {
                lstResult.Items.Add(result.result.ToString());
            }
        }
        private void SendMessage(int id,string msg) {
            if (id == 1) {
                lstRange.Items.Add(msg);
            }else if (id == 0) {
                lstResult.Items.Add(msg);
            }
        }
    }
}
