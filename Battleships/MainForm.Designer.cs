namespace SeaBattle
{
    partial class MainForm
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
            pbxSelf = new PictureBox();
            pbxEnemy = new PictureBox();
            txtIP = new TextBox();
            txtPort = new TextBox();
            btnHost = new Button();
            btnConnect = new Button();
            lblStatus = new Label();
            btnRandomPlace = new Button();
            ((System.ComponentModel.ISupportInitialize)pbxSelf).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbxEnemy).BeginInit();
            SuspendLayout();
            // 
            // pbxSelf
            // 
            pbxSelf.BackColor = Color.White;
            pbxSelf.Location = new Point(49, 128);
            pbxSelf.Name = "pbxSelf";
            pbxSelf.Size = new Size(301, 301);
            pbxSelf.TabIndex = 0;
            pbxSelf.TabStop = false;
            pbxSelf.Paint += pbxSelf_Paint;
            // 
            // pbxEnemy
            // 
            pbxEnemy.BackColor = Color.White;
            pbxEnemy.Location = new Point(390, 128);
            pbxEnemy.Name = "pbxEnemy";
            pbxEnemy.Size = new Size(301, 301);
            pbxEnemy.TabIndex = 1;
            pbxEnemy.TabStop = false;
            pbxEnemy.Paint += pbxEnemy_Paint;
            pbxEnemy.MouseDown += pbxEnemy_MouseDown;
            // 
            // txtIP
            // 
            txtIP.Location = new Point(49, 12);
            txtIP.Name = "txtIP";
            txtIP.Size = new Size(125, 27);
            txtIP.TabIndex = 2;
            txtIP.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(49, 45);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(125, 27);
            txtPort.TabIndex = 3;
            txtPort.Text = "8888";
            // 
            // btnHost
            // 
            btnHost.Location = new Point(390, 12);
            btnHost.Name = "btnHost";
            btnHost.Size = new Size(118, 29);
            btnHost.TabIndex = 4;
            btnHost.Text = "Создать игру";
            btnHost.UseVisualStyleBackColor = true;
            btnHost.Click += btnHost_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(390, 47);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(118, 29);
            btnConnect.TabIndex = 5;
            btnConnect.Text = "Подключиться";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(568, 15);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(146, 20);
            lblStatus.TabIndex = 6;
            lblStatus.Text = "Расставьте корабли";
            // 
            // btnRandomPlace
            // 
            btnRandomPlace.Location = new Point(49, 93);
            btnRandomPlace.Name = "btnRandomPlace";
            btnRandomPlace.Size = new Size(142, 29);
            btnRandomPlace.TabIndex = 7;
            btnRandomPlace.Text = "Авто-расстановка";
            btnRandomPlace.UseVisualStyleBackColor = true;
            btnRandomPlace.Click += btnRandomPlace_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 470);
            Controls.Add(btnRandomPlace);
            Controls.Add(lblStatus);
            Controls.Add(btnConnect);
            Controls.Add(btnHost);
            Controls.Add(txtPort);
            Controls.Add(txtIP);
            Controls.Add(pbxEnemy);
            Controls.Add(pbxSelf);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)pbxSelf).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbxEnemy).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbxSelf;
        private PictureBox pbxEnemy;
        private TextBox txtIP;
        private TextBox txtPort;
        private Button btnHost;
        private Button btnConnect;
        private Label lblStatus;
        private Button btnRandomPlace;
    }
}