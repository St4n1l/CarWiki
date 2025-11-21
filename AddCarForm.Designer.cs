namespace CarWiki
{
    partial class AddCarForm
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
            ImageLabel = new Label();
            modelLabel = new Label();
            makeLabel = new Label();
            yearLabel = new Label();
            horsePowerLabel = new Label();
            horsePowerTextBox = new RichTextBox();
            makeTextBox = new RichTextBox();
            yearTextBox = new RichTextBox();
            modelTextBox = new RichTextBox();
            button1 = new Button();
            button2 = new Button();
            imageTextBox = new RichTextBox();
            SuspendLayout();
            // 
            // ImageLabel
            // 
            ImageLabel.AutoSize = true;
            ImageLabel.Location = new Point(347, 106);
            ImageLabel.Name = "ImageLabel";
            ImageLabel.Size = new Size(83, 20);
            ImageLabel.TabIndex = 0;
            ImageLabel.Text = "Image Path";
            // 
            // modelLabel
            // 
            modelLabel.AutoSize = true;
            modelLabel.Location = new Point(358, 185);
            modelLabel.Name = "modelLabel";
            modelLabel.Size = new Size(52, 20);
            modelLabel.TabIndex = 1;
            modelLabel.Text = "Model";
            // 
            // makeLabel
            // 
            makeLabel.AutoSize = true;
            makeLabel.Location = new Point(362, 251);
            makeLabel.Name = "makeLabel";
            makeLabel.Size = new Size(45, 20);
            makeLabel.TabIndex = 2;
            makeLabel.Text = "Make";
            // 
            // yearLabel
            // 
            yearLabel.AutoSize = true;
            yearLabel.Location = new Point(358, 310);
            yearLabel.Name = "yearLabel";
            yearLabel.Size = new Size(37, 20);
            yearLabel.TabIndex = 3;
            yearLabel.Text = "Year";
            // 
            // horsePowerLabel
            // 
            horsePowerLabel.AutoSize = true;
            horsePowerLabel.ForeColor = Color.Black;
            horsePowerLabel.Location = new Point(340, 359);
            horsePowerLabel.Name = "horsePowerLabel";
            horsePowerLabel.Size = new Size(90, 20);
            horsePowerLabel.TabIndex = 4;
            horsePowerLabel.Text = "Horsepower";
            // 
            // horsePowerTextBox
            // 
            horsePowerTextBox.Location = new Point(275, 382);
            horsePowerTextBox.Margin = new Padding(3, 4, 3, 4);
            horsePowerTextBox.Name = "horsePowerTextBox";
            horsePowerTextBox.Size = new Size(222, 25);
            horsePowerTextBox.TabIndex = 5;
            horsePowerTextBox.Text = "";
            // 
            // makeTextBox
            // 
            makeTextBox.Location = new Point(275, 275);
            makeTextBox.Margin = new Padding(3, 4, 3, 4);
            makeTextBox.Name = "makeTextBox";
            makeTextBox.Size = new Size(222, 25);
            makeTextBox.TabIndex = 6;
            makeTextBox.Text = "";
            // 
            // yearTextBox
            // 
            yearTextBox.Location = new Point(275, 334);
            yearTextBox.Margin = new Padding(3, 4, 3, 4);
            yearTextBox.Name = "yearTextBox";
            yearTextBox.Size = new Size(222, 25);
            yearTextBox.TabIndex = 7;
            yearTextBox.Text = "";
            // 
            // modelTextBox
            // 
            modelTextBox.Location = new Point(275, 221);
            modelTextBox.Margin = new Padding(3, 4, 3, 4);
            modelTextBox.Name = "modelTextBox";
            modelTextBox.Size = new Size(222, 25);
            modelTextBox.TabIndex = 8;
            modelTextBox.Text = "";
            // 
            // button1
            // 
            button1.DialogResult = DialogResult.OK;
            button1.Location = new Point(194, 462);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(75, 29);
            button1.TabIndex = 9;
            button1.Text = "Ok";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.DialogResult = DialogResult.Cancel;
            button2.Location = new Point(504, 462);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(75, 29);
            button2.TabIndex = 10;
            button2.Text = "Cancel";
            button2.UseVisualStyleBackColor = true;
            // 
            // imageTextBox
            // 
            imageTextBox.Location = new Point(275, 141);
            imageTextBox.Margin = new Padding(3, 4, 3, 4);
            imageTextBox.Name = "imageTextBox";
            imageTextBox.Size = new Size(222, 25);
            imageTextBox.TabIndex = 11;
            imageTextBox.Text = "";
            // 
            // AddCarForm
            // 
            AcceptButton = button1;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = button2;
            ClientSize = new Size(800, 562);
            Controls.Add(imageTextBox);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(modelTextBox);
            Controls.Add(yearTextBox);
            Controls.Add(makeTextBox);
            Controls.Add(horsePowerTextBox);
            Controls.Add(horsePowerLabel);
            Controls.Add(yearLabel);
            Controls.Add(makeLabel);
            Controls.Add(modelLabel);
            Controls.Add(ImageLabel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "AddCarForm";
            Text = "AddCarForm";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ImageLabel;
        private System.Windows.Forms.Label modelLabel;
        private System.Windows.Forms.Label makeLabel;
        private System.Windows.Forms.Label yearLabel;
        private System.Windows.Forms.Label horsePowerLabel;
        private System.Windows.Forms.RichTextBox horsePowerTextBox;
        private System.Windows.Forms.RichTextBox makeTextBox;
        private System.Windows.Forms.RichTextBox yearTextBox;
        private System.Windows.Forms.RichTextBox modelTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RichTextBox imageTextBox;
    }
}