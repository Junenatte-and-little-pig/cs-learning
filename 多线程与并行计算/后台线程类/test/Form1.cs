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
            id += 1;
            wr.id = id;
            wr.nStart = new Random().Next(1,1000)*100;
            wr.nEnd = new Random().Next(1,1000) * 1000;
            bgWork = new ClsBgWorker(wr);
            bgWork.Complete += new ClsBgWorker.CompleteHandler(DoComplete);
            lstRange.Items.Add(wr.id.ToString() + '\t' + wr.nStart.ToString() + '\t' + wr.nEnd.ToString());
            bgWork.Run();
        }
        private void btnCancel_Click(object sender, EventArgs e) {
            bgWork.Cancel();
        }
        private void DoComplete(bool cancel,WorkResult result) {
            if (cancel)
                return;
            lstResult.Items.Add(result.id.ToString() + '\t' + result.result.ToString());
        }
    }
}
