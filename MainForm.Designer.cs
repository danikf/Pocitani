namespace Počítání
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelExample = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.TextBox();
            this.labelMoney = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imageListShop = new System.Windows.Forms.ImageList(this.components);
            this.buttonChicco = new System.Windows.Forms.Button();
            this.pictureBoxMonster = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonGiraffe = new System.Windows.Forms.Button();
            this.buttonZobo = new System.Windows.Forms.Button();
            this.buttonCimca = new System.Windows.Forms.Button();
            this.labelX = new System.Windows.Forms.Label();
            this.buttonTucnacek = new System.Windows.Forms.Button();
            this.labelEquals = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMonster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelExample
            // 
            this.labelExample.BackColor = System.Drawing.Color.Transparent;
            this.labelExample.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelExample.Location = new System.Drawing.Point(4, 13);
            this.labelExample.Name = "labelExample";
            this.labelExample.Size = new System.Drawing.Size(410, 81);
            this.labelExample.TabIndex = 0;
            this.labelExample.Text = "76 + 29 = X";
            // 
            // buttonOK
            // 
            this.buttonOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonOK.Location = new System.Drawing.Point(771, 12);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(81, 83);
            this.buttonOK.TabIndex = 2;
            this.buttonOK.TabStop = false;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // textBox
            // 
            this.textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox.Location = new System.Drawing.Point(527, 12);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(238, 83);
            this.textBox.TabIndex = 1;
            // 
            // labelMoney
            // 
            this.labelMoney.BackColor = System.Drawing.Color.White;
            this.labelMoney.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMoney.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelMoney.Location = new System.Drawing.Point(100, 387);
            this.labelMoney.Margin = new System.Windows.Forms.Padding(0);
            this.labelMoney.Name = "labelMoney";
            this.labelMoney.Size = new System.Drawing.Size(763, 96);
            this.labelMoney.TabIndex = 4;
            this.labelMoney.Text = "0 Kč";
            this.labelMoney.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(400, 336);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(463, 51);
            this.panel1.TabIndex = 6;
            // 
            // imageListShop
            // 
            this.imageListShop.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListShop.ImageStream")));
            this.imageListShop.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListShop.Images.SetKeyName(0, "Čiko náhled.png");
            this.imageListShop.Images.SetKeyName(1, "Žirafka náhled.png");
            this.imageListShop.Images.SetKeyName(2, "Zobo náhled.png");
            this.imageListShop.Images.SetKeyName(3, "Čimča náhled.png");
            this.imageListShop.Images.SetKeyName(4, "Tučňáček náhled.png");
            // 
            // buttonChicco
            // 
            this.buttonChicco.Enabled = false;
            this.buttonChicco.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonChicco.ImageIndex = 0;
            this.buttonChicco.ImageList = this.imageListShop;
            this.buttonChicco.Location = new System.Drawing.Point(437, 129);
            this.buttonChicco.Name = "buttonChicco";
            this.buttonChicco.Size = new System.Drawing.Size(80, 70);
            this.buttonChicco.TabIndex = 7;
            this.buttonChicco.Text = "Čiko";
            this.buttonChicco.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonChicco.UseVisualStyleBackColor = true;
            this.buttonChicco.Visible = false;
            // 
            // pictureBoxMonster
            // 
            this.pictureBoxMonster.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxMonster.ImageLocation = "Obrázky/Čiko.png";
            this.pictureBoxMonster.Location = new System.Drawing.Point(0, 96);
            this.pictureBoxMonster.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxMonster.Name = "pictureBoxMonster";
            this.pictureBoxMonster.Size = new System.Drawing.Size(400, 291);
            this.pictureBoxMonster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxMonster.TabIndex = 5;
            this.pictureBoxMonster.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ImageLocation = "Obrázky/mince.jpg";
            this.pictureBox1.Location = new System.Drawing.Point(0, 383);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // buttonGiraffe
            // 
            this.buttonGiraffe.Enabled = false;
            this.buttonGiraffe.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonGiraffe.ImageIndex = 1;
            this.buttonGiraffe.ImageList = this.imageListShop;
            this.buttonGiraffe.Location = new System.Drawing.Point(601, 129);
            this.buttonGiraffe.Name = "buttonGiraffe";
            this.buttonGiraffe.Size = new System.Drawing.Size(80, 70);
            this.buttonGiraffe.TabIndex = 8;
            this.buttonGiraffe.Text = "Žirafka";
            this.buttonGiraffe.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonGiraffe.UseVisualStyleBackColor = true;
            this.buttonGiraffe.Visible = false;
            // 
            // buttonZobo
            // 
            this.buttonZobo.Enabled = false;
            this.buttonZobo.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonZobo.ImageIndex = 2;
            this.buttonZobo.ImageList = this.imageListShop;
            this.buttonZobo.Location = new System.Drawing.Point(687, 129);
            this.buttonZobo.Name = "buttonZobo";
            this.buttonZobo.Size = new System.Drawing.Size(80, 70);
            this.buttonZobo.TabIndex = 9;
            this.buttonZobo.Text = "Zobo";
            this.buttonZobo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonZobo.UseVisualStyleBackColor = true;
            this.buttonZobo.Visible = false;
            // 
            // buttonCimca
            // 
            this.buttonCimca.Enabled = false;
            this.buttonCimca.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonCimca.ImageIndex = 3;
            this.buttonCimca.ImageList = this.imageListShop;
            this.buttonCimca.Location = new System.Drawing.Point(772, 129);
            this.buttonCimca.Name = "buttonCimca";
            this.buttonCimca.Size = new System.Drawing.Size(80, 70);
            this.buttonCimca.TabIndex = 10;
            this.buttonCimca.Text = "Čimča";
            this.buttonCimca.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonCimca.UseVisualStyleBackColor = true;
            this.buttonCimca.Visible = false;
            // 
            // labelX
            // 
            this.labelX.BackColor = System.Drawing.Color.Transparent;
            this.labelX.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelX.Location = new System.Drawing.Point(420, 13);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(54, 81);
            this.labelX.TabIndex = 11;
            this.labelX.Text = "x";
            // 
            // buttonTucnacek
            // 
            this.buttonTucnacek.Enabled = false;
            this.buttonTucnacek.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.buttonTucnacek.ImageIndex = 4;
            this.buttonTucnacek.ImageList = this.imageListShop;
            this.buttonTucnacek.Location = new System.Drawing.Point(519, 129);
            this.buttonTucnacek.Name = "buttonTucnacek";
            this.buttonTucnacek.Size = new System.Drawing.Size(80, 70);
            this.buttonTucnacek.TabIndex = 12;
            this.buttonTucnacek.Text = "Tučňáček";
            this.buttonTucnacek.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonTucnacek.UseVisualStyleBackColor = true;
            this.buttonTucnacek.Visible = false;
            // 
            // labelEquals
            // 
            this.labelEquals.BackColor = System.Drawing.Color.Transparent;
            this.labelEquals.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelEquals.Location = new System.Drawing.Point(462, 13);
            this.labelEquals.Name = "labelEquals";
            this.labelEquals.Size = new System.Drawing.Size(55, 81);
            this.labelEquals.TabIndex = 13;
            this.labelEquals.Text = "=";
            // 
            // MainForm
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Počítání.Properties.Resources.Gradient;
            this.ClientSize = new System.Drawing.Size(864, 483);
            this.Controls.Add(this.buttonTucnacek);
            this.Controls.Add(this.buttonCimca);
            this.Controls.Add(this.buttonZobo);
            this.Controls.Add(this.buttonGiraffe);
            this.Controls.Add(this.buttonChicco);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBoxMonster);
            this.Controls.Add(this.labelMoney);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.labelExample);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.labelEquals);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Počítání";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMonster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelExample;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelMoney;
        private System.Windows.Forms.PictureBox pictureBoxMonster;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonChicco;
        private System.Windows.Forms.ImageList imageListShop;
        private System.Windows.Forms.Button buttonGiraffe;
        private System.Windows.Forms.Button buttonZobo;
        private System.Windows.Forms.Button buttonCimca;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Button buttonTucnacek;
        private System.Windows.Forms.Label labelEquals;
    }
}

