namespace LabaLaba
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            contextMenuStrip1 = new ContextMenuStrip(components);
            textBox1 = new TextBox();
            button1 = new Button();
            textBox2 = new TextBox();
            pictureBox1 = new PictureBox();
            textBox3 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            textBox4 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // textBox1
            // 
            textBox1.AccessibleName = "CoolName";
            textBox1.Location = new Point(12, 32);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(234, 23);
            textBox1.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(12, 276);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 2;
            button1.Text = "Считать";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.AccessibleName = "CoolName";
            textBox2.Location = new Point(12, 92);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(234, 23);
            textBox2.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Location = new Point(334, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(542, 511);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Paint += Paint;
            this.Controls.Add(pictureBox1);
            pictureBox1.BringToFront();
            // 
            // textBox3
            // 
            textBox3.AccessibleName = "CoolName";
            textBox3.Location = new Point(12, 155);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(234, 23);
            textBox3.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 12);
            label1.Name = "label1";
            label1.Size = new Size(15, 15);
            label1.TabIndex = 6;
            label1.Text = "A";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 74);
            label2.Name = "label2";
            label2.Size = new Size(14, 15);
            label2.TabIndex = 7;
            label2.Text = "B";
            // 
            // textBox4
            // 
            textBox4.AccessibleName = "CoolName";
            textBox4.Location = new Point(12, 214);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(234, 23);
            textBox4.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 137);
            label3.Name = "label3";
            label3.Size = new Size(13, 15);
            label3.TabIndex = 9;
            label3.Text = "E";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 196);
            label4.Name = "label4";
            label4.Size = new Size(27, 15);
            label4.TabIndex = 10;
            label4.Text = "F(x)";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 351);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 13;
            label6.Text = "label6";
            // 
            // button2
            // 
            button2.Location = new Point(116, 276);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 14;
            button2.Text = "Сброос";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(877, 535);
            Controls.Add(button2);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(pictureBox1);
            Controls.Add(textBox2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ContextMenuStrip contextMenuStrip1;
        private TextBox textBox1;
        private Button button1;
        private TextBox textBox2;
        private PictureBox pictureBox1;
        private TextBox textBox3;
        private Label label1;
        private Label label2;
        private TextBox textBox4;
        private Label label3;
        private Label label4;
        private Label label6;
        private Button button2;
    }
}
