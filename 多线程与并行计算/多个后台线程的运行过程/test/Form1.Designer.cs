namespace test {
    partial class Form1 {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent() {
            this.btnStart1 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtResult1 = new System.Windows.Forms.TextBox();
            this.btnStart2 = new System.Windows.Forms.Button();
            this.txtResult2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStart1
            // 
            this.btnStart1.Location = new System.Drawing.Point(12, 3);
            this.btnStart1.Name = "btnStart1";
            this.btnStart1.Size = new System.Drawing.Size(75, 23);
            this.btnStart1.TabIndex = 0;
            this.btnStart1.Text = "start1";
            this.btnStart1.UseVisualStyleBackColor = true;
            this.btnStart1.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(12, 61);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtResult1
            // 
            this.txtResult1.Location = new System.Drawing.Point(93, 5);
            this.txtResult1.Name = "txtResult1";
            this.txtResult1.Size = new System.Drawing.Size(100, 21);
            this.txtResult1.TabIndex = 2;
            // 
            // btnStart2
            // 
            this.btnStart2.Location = new System.Drawing.Point(12, 32);
            this.btnStart2.Name = "btnStart2";
            this.btnStart2.Size = new System.Drawing.Size(75, 23);
            this.btnStart2.TabIndex = 3;
            this.btnStart2.Text = "start2";
            this.btnStart2.UseVisualStyleBackColor = true;
            this.btnStart2.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtResult2
            // 
            this.txtResult2.Location = new System.Drawing.Point(93, 32);
            this.txtResult2.Name = "txtResult2";
            this.txtResult2.Size = new System.Drawing.Size(100, 21);
            this.txtResult2.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 117);
            this.Controls.Add(this.txtResult2);
            this.Controls.Add(this.btnStart2);
            this.Controls.Add(this.txtResult1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnStart1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnStart1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtResult1;
        private System.Windows.Forms.Button btnStart2;
        private System.Windows.Forms.TextBox txtResult2;
    }
}

