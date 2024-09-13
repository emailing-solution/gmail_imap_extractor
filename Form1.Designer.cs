namespace gmail_imap
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
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
            host = new TextBox();
            label1 = new Label();
            label2 = new Label();
            accounts = new RichTextBox();
            label3 = new Label();
            extract_from = new Button();
            port = new TextBox();
            extract_bounce = new Button();
            SuspendLayout();
            // 
            // host
            // 
            host.Location = new Point(79, 16);
            host.Name = "host";
            host.Size = new Size(339, 25);
            host.TabIndex = 0;
            host.Text = "imap.gmail.com";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 19);
            label1.Name = "label1";
            label1.Size = new Size(42, 17);
            label1.TabIndex = 2;
            label1.Text = "Host :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(34, 52);
            label2.Name = "label2";
            label2.Size = new Size(39, 17);
            label2.TabIndex = 3;
            label2.Text = "Port :";
            // 
            // accounts
            // 
            accounts.Location = new Point(79, 82);
            accounts.Name = "accounts";
            accounts.Size = new Size(339, 308);
            accounts.TabIndex = 4;
            accounts.Text = "";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 85);
            label3.Name = "label3";
            label3.Size = new Size(67, 17);
            label3.TabIndex = 5;
            label3.Text = "Accounts :";
            // 
            // extract_from
            // 
            extract_from.Location = new Point(79, 397);
            extract_from.Name = "extract_from";
            extract_from.Size = new Size(339, 26);
            extract_from.TabIndex = 6;
            extract_from.Text = "EXTRACT FROM";
            extract_from.UseVisualStyleBackColor = true;
            extract_from.Click += Extract_From;
            // 
            // port
            // 
            port.Location = new Point(79, 49);
            port.Name = "port";
            port.Size = new Size(339, 25);
            port.TabIndex = 7;
            port.Text = "993";
            port.KeyPress += port_KeyPress;
            // 
            // extract_bounce
            // 
            extract_bounce.Location = new Point(79, 429);
            extract_bounce.Name = "extract_bounce";
            extract_bounce.Size = new Size(339, 26);
            extract_bounce.TabIndex = 8;
            extract_bounce.Text = "EXTRACT BOUNCE";
            extract_bounce.UseVisualStyleBackColor = true;
            extract_bounce.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(431, 469);
            Controls.Add(extract_bounce);
            Controls.Add(port);
            Controls.Add(extract_from);
            Controls.Add(label3);
            Controls.Add(accounts);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(host);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EXTRACTOR";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox host;
        private Label label1;
        private Label label2;
        private RichTextBox accounts;
        private Label label3;
        private Button extract_from;
        private TextBox port;
        private Button extract_bounce;
    }
}