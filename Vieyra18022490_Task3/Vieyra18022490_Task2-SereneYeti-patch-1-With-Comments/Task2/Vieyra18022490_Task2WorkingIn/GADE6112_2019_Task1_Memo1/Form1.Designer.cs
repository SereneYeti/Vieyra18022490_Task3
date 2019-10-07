namespace Vieyra18022490_Task2
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
            this.components = new System.ComponentModel.Container();
            this.grpMap = new System.Windows.Forms.GroupBox();
            this.lblRound = new System.Windows.Forms.Label();
            this.btnPause = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtInfo = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnRead = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblResources = new System.Windows.Forms.Label();
            this.trbWidth = new System.Windows.Forms.TrackBar();
            this.trbHeight = new System.Windows.Forms.TrackBar();
            this.btnChangeSize = new System.Windows.Forms.Button();
            this.lblWidth = new System.Windows.Forms.Label();
            this.lblHeight = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trbWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMap
            // 
            this.grpMap.Location = new System.Drawing.Point(759, 88);
            this.grpMap.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.grpMap.Name = "grpMap";
            this.grpMap.Padding = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.grpMap.Size = new System.Drawing.Size(1896, 1135);
            this.grpMap.TabIndex = 0;
            this.grpMap.TabStop = false;
            // 
            // lblRound
            // 
            this.lblRound.AutoSize = true;
            this.lblRound.Location = new System.Drawing.Point(11, 11);
            this.lblRound.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblRound.Name = "lblRound";
            this.lblRound.Size = new System.Drawing.Size(114, 32);
            this.lblRound.TabIndex = 1;
            this.lblRound.Text = "Round: ";
            // 
            // btnPause
            // 
            this.btnPause.Location = new System.Drawing.Point(260, 1087);
            this.btnPause.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(200, 55);
            this.btnPause.TabIndex = 2;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.BtnPause_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(17, 1087);
            this.btnStart.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(200, 55);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // txtInfo
            // 
            this.txtInfo.Location = new System.Drawing.Point(17, 88);
            this.txtInfo.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.txtInfo.Multiline = true;
            this.txtInfo.Name = "txtInfo";
            this.txtInfo.Size = new System.Drawing.Size(716, 960);
            this.txtInfo.TabIndex = 4;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // btnRead
            // 
            this.btnRead.Location = new System.Drawing.Point(260, 1180);
            this.btnRead.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(200, 55);
            this.btnRead.TabIndex = 5;
            this.btnRead.Text = "Read";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.BtnRead_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(17, 1180);
            this.btnSave.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(200, 55);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // lblResources
            // 
            this.lblResources.AutoSize = true;
            this.lblResources.Location = new System.Drawing.Point(532, 1087);
            this.lblResources.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.lblResources.Name = "lblResources";
            this.lblResources.Size = new System.Drawing.Size(150, 32);
            this.lblResources.TabIndex = 7;
            this.lblResources.Text = "Resources";
            // 
            // trbWidth
            // 
            this.trbWidth.Location = new System.Drawing.Point(17, 1257);
            this.trbWidth.Maximum = 1500;
            this.trbWidth.Minimum = 50;
            this.trbWidth.Name = "trbWidth";
            this.trbWidth.Size = new System.Drawing.Size(443, 114);
            this.trbWidth.TabIndex = 8;
            this.trbWidth.Value = 50;
            this.trbWidth.Scroll += new System.EventHandler(this.TrbWidth_Scroll);
            // 
            // trbHeight
            // 
            this.trbHeight.Location = new System.Drawing.Point(17, 1339);
            this.trbHeight.Maximum = 1500;
            this.trbHeight.Minimum = 50;
            this.trbHeight.Name = "trbHeight";
            this.trbHeight.Size = new System.Drawing.Size(443, 114);
            this.trbHeight.TabIndex = 9;
            this.trbHeight.Value = 50;
            this.trbHeight.Scroll += new System.EventHandler(this.TrbHeight_Scroll);
            // 
            // btnChangeSize
            // 
            this.btnChangeSize.Location = new System.Drawing.Point(17, 1459);
            this.btnChangeSize.Name = "btnChangeSize";
            this.btnChangeSize.Size = new System.Drawing.Size(443, 71);
            this.btnChangeSize.TabIndex = 10;
            this.btnChangeSize.Text = "Change Map Size";
            this.btnChangeSize.UseVisualStyleBackColor = true;
            this.btnChangeSize.Click += new System.EventHandler(this.BtnChangeSize_Click);
            // 
            // lblWidth
            // 
            this.lblWidth.AutoSize = true;
            this.lblWidth.Location = new System.Drawing.Point(497, 1257);
            this.lblWidth.Name = "lblWidth";
            this.lblWidth.Size = new System.Drawing.Size(88, 32);
            this.lblWidth.TabIndex = 11;
            this.lblWidth.Text = "Width";
            // 
            // lblHeight
            // 
            this.lblHeight.AutoSize = true;
            this.lblHeight.Location = new System.Drawing.Point(497, 1339);
            this.lblHeight.Name = "lblHeight";
            this.lblHeight.Size = new System.Drawing.Size(98, 32);
            this.lblHeight.TabIndex = 12;
            this.lblHeight.Text = "Height";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2869, 1662);
            this.Controls.Add(this.lblHeight);
            this.Controls.Add(this.lblWidth);
            this.Controls.Add(this.btnChangeSize);
            this.Controls.Add(this.trbHeight);
            this.Controls.Add(this.trbWidth);
            this.Controls.Add(this.lblResources);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.txtInfo);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.lblRound);
            this.Controls.Add(this.grpMap);
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trbWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMap;
        private System.Windows.Forms.Label lblRound;
        private System.Windows.Forms.Button btnPause;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtInfo;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblResources;
        private System.Windows.Forms.TrackBar trbWidth;
        private System.Windows.Forms.TrackBar trbHeight;
        private System.Windows.Forms.Button btnChangeSize;
        private System.Windows.Forms.Label lblWidth;
        private System.Windows.Forms.Label lblHeight;
    }
}

