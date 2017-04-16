namespace Oyun
{
    partial class Main
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Score = new System.Windows.Forms.Label();
            this.gameInfo = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.Label();
            this.update = new System.Windows.Forms.Timer(this.components);
            this.getPlane = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Teal;
            this.panel1.Controls.Add(this.Score);
            this.panel1.Controls.Add(this.gameInfo);
            this.panel1.Controls.Add(this.status);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(748, 55);
            this.panel1.TabIndex = 4;
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Font = new System.Drawing.Font("Berlin Sans FB", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score.ForeColor = System.Drawing.Color.Lime;
            this.Score.Location = new System.Drawing.Point(663, 17);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(47, 17);
            this.Score.TabIndex = 2;
            this.Score.Text = "04547";
            // 
            // gameInfo
            // 
            this.gameInfo.AutoSize = true;
            this.gameInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameInfo.ForeColor = System.Drawing.Color.White;
            this.gameInfo.Location = new System.Drawing.Point(3, 3);
            this.gameInfo.Name = "gameInfo";
            this.gameInfo.Size = new System.Drawing.Size(369, 45);
            this.gameInfo.TabIndex = 0;
            this.gameInfo.Text = "Oyunu başlatmak için ENTER tuşuna basın.\r\nUçaksavar\'ı hareket ettirmek için SAĞ v" +
    "e SOL yön tuşlarını kullanın.\r\nAteş etmek için BOŞLUK tuşunu basın.\r\n";
            // 
            // status
            // 
            this.status.AutoSize = true;
            this.status.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.status.Location = new System.Drawing.Point(535, 17);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(124, 15);
            this.status.TabIndex = 1;
            this.status.Text = "Oyun başladı |  Skor : ";
            // 
            // update
            // 
            this.update.Interval = 250;
            this.update.Tick += new System.EventHandler(this.update_Tick);
            // 
            // getPlane
            // 
            this.getPlane.Interval = 1000;
            this.getPlane.Tick += new System.EventHandler(this.getPlane_Tick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MediumTurquoise;
            this.ClientSize = new System.Drawing.Size(744, 421);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(760, 460);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(760, 460);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Uçak Savar";
            this.Load += new System.EventHandler(this.Main_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Score;
        private System.Windows.Forms.Label gameInfo;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.Timer update;
        private System.Windows.Forms.Timer getPlane;
    }
}

