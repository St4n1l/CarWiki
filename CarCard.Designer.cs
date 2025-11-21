using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace CarWiki
{
    partial class CarCard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (disposing && pictureBox1 != null && pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }
            base.Dispose(disposing);
        }


        private void InitializeComponent()
        {
            yearLabel = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            yearValueLabel = new Label();
            makeValueLabel = new Label();
            modelValueLabel = new Label();
            horsepowerValueLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();

            yearLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            yearLabel.AutoSize = true;
            yearLabel.Location = new Point(132, 296);
            yearLabel.Name = "yearLabel";
            yearLabel.Size = new Size(40, 20);
            yearLabel.TabIndex = 0;
            yearLabel.Text = "Year:";

            label2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(132, 321);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 1;
            label2.Text = "Make:";
            label2.Click += label2_Click;
  
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(132, 346);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 2;
            label3.Text = "Model:";
 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(132, 371);
            label4.Name = "label4";
            label4.Size = new Size(93, 20);
            label4.TabIndex = 3;
            label4.Text = "Horsepower:";
        
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(425, 281);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
      
            yearValueLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            yearValueLabel.AutoSize = true;
            yearValueLabel.Location = new Point(192, 296);
            yearValueLabel.Name = "yearValueLabel";
            yearValueLabel.Size = new Size(50, 20);
            yearValueLabel.TabIndex = 5;
     
            makeValueLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            makeValueLabel.AutoSize = true;
            makeValueLabel.Location = new Point(192, 321);
            makeValueLabel.Name = "makeValueLabel";
            makeValueLabel.Size = new Size(50, 20);
            makeValueLabel.TabIndex = 6;
            makeValueLabel.Text = "label1";
          
            modelValueLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            modelValueLabel.AutoSize = true;
            modelValueLabel.Location = new Point(192, 346);
            modelValueLabel.Name = "modelValueLabel";
            modelValueLabel.Size = new Size(50, 20);
            modelValueLabel.TabIndex = 7;
            modelValueLabel.Text = "label1";
         
            horsepowerValueLabel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            horsepowerValueLabel.AutoSize = true;
            horsepowerValueLabel.Location = new Point(232, 371);
            horsepowerValueLabel.Name = "horsepowerValueLabel";
            horsepowerValueLabel.Size = new Size(50, 20);
            horsepowerValueLabel.TabIndex = 8;
            horsepowerValueLabel.Text = "label1";
  
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(horsepowerValueLabel);
            Controls.Add(modelValueLabel);
            Controls.Add(makeValueLabel);
            Controls.Add(yearValueLabel);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(yearLabel);
            Name = "CarCard";
            Size = new Size(425, 414);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        private Label yearLabel;
        private Label label2;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox1;
        private Label yearValueLabel;
        private Label makeValueLabel;
        private Label modelValueLabel;
        private Label horsepowerValueLabel;

        public void Bind(Car car)
        {
            yearValueLabel.Text = car.year.ToString();
            makeValueLabel.Text = car.make;
            modelValueLabel.Text = car.model;
            horsepowerValueLabel.Text = car.horsePower.ToString();

            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
                pictureBox1.Image = null;
            }

            var rawPath = car.imagePath;
            var resolvedPath = rawPath;
            if (!string.IsNullOrWhiteSpace(rawPath))
            {
                resolvedPath = Environment.ExpandEnvironmentVariables(rawPath.Trim().Trim('"'));
                if (!Path.IsPathRooted(resolvedPath))
                {
                    resolvedPath = Path.Combine(System.Windows.Forms.Application.StartupPath, resolvedPath);
                }
            }

            if (!string.IsNullOrWhiteSpace(resolvedPath) && File.Exists(resolvedPath))
            {
                try
                {
                    using (var fs = new FileStream(resolvedPath, FileMode.Open, FileAccess.Read, FileShare.Read))
                    using (var original = Image.FromStream(fs, useEmbeddedColorManagement: false, validateImageData: false))
                    {
                        int maxW = pictureBox1.ClientSize.Width;
                        int maxH = pictureBox1.ClientSize.Height;
                        if (maxW < 50) maxW = 300;
                        if (maxH < 50) maxH = 180;
                        double ratio = Math.Min((double)maxW / original.Width, (double)maxH / original.Height);
                        int targetW = Math.Max(1, (int)(original.Width * ratio));
                        int targetH = Math.Max(1, (int)(original.Height * ratio));

                        using (var resized = new Bitmap(targetW, targetH))
                        using (var g = Graphics.FromImage(resized))
                        {
                            g.CompositingQuality = CompositingQuality.HighQuality;
                            g.SmoothingMode = SmoothingMode.HighQuality;
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            g.DrawImage(original, 0, 0, targetW, targetH);
                            pictureBox1.Image = new Bitmap(resized);
                        }
                    }
                }
                catch
                {
                    pictureBox1.Image = null;
                }
            }
            else
            {
                pictureBox1.Image = null;
            }
        }
    }
}
