namespace WindowsFormsProjekt
{
    partial class PlayerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.tbName = new System.Windows.Forms.Label();
            this.tbPosition = new System.Windows.Forms.Label();
            this.tbShirtNumber = new System.Windows.Forms.Label();
            this.tbCaptian = new System.Windows.Forms.Label();
            this.pbFavourite = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavourite)).BeginInit();
            this.SuspendLayout();
            // 
            // pbImage
            // 
            this.pbImage.BackColor = System.Drawing.SystemColors.Window;
            this.pbImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbImage.Location = new System.Drawing.Point(3, 3);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(100, 120);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.White;
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(109, 3);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(189, 23);
            this.tbName.TabIndex = 5;
            this.tbName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbPosition
            // 
            this.tbPosition.BackColor = System.Drawing.Color.White;
            this.tbPosition.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPosition.Location = new System.Drawing.Point(109, 54);
            this.tbPosition.Name = "tbPosition";
            this.tbPosition.Size = new System.Drawing.Size(189, 23);
            this.tbPosition.TabIndex = 6;
            this.tbPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbShirtNumber
            // 
            this.tbShirtNumber.BackColor = System.Drawing.Color.White;
            this.tbShirtNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbShirtNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbShirtNumber.Location = new System.Drawing.Point(322, 54);
            this.tbShirtNumber.Name = "tbShirtNumber";
            this.tbShirtNumber.Size = new System.Drawing.Size(88, 23);
            this.tbShirtNumber.TabIndex = 7;
            this.tbShirtNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbCaptian
            // 
            this.tbCaptian.BackColor = System.Drawing.Color.White;
            this.tbCaptian.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCaptian.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCaptian.Location = new System.Drawing.Point(109, 100);
            this.tbCaptian.Name = "tbCaptian";
            this.tbCaptian.Size = new System.Drawing.Size(189, 23);
            this.tbCaptian.TabIndex = 8;
            this.tbCaptian.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbFavourite
            // 
            this.pbFavourite.Location = new System.Drawing.Point(397, 95);
            this.pbFavourite.Name = "pbFavourite";
            this.pbFavourite.Size = new System.Drawing.Size(30, 30);
            this.pbFavourite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbFavourite.TabIndex = 9;
            this.pbFavourite.TabStop = false;
            // 
            // PlayerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.pbFavourite);
            this.Controls.Add(this.tbCaptian);
            this.Controls.Add(this.tbShirtNumber);
            this.Controls.Add(this.tbPosition);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.pbImage);
            this.Name = "PlayerControl";
            this.Size = new System.Drawing.Size(430, 128);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFavourite)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.PictureBox pbImage;
        public System.Windows.Forms.Label tbName;
        public System.Windows.Forms.Label tbPosition;
        public System.Windows.Forms.Label tbShirtNumber;
        public System.Windows.Forms.Label tbCaptian;
        public System.Windows.Forms.PictureBox pbFavourite;
    }
}
