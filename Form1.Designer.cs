namespace Support_bot
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
            this.Users = new System.Windows.Forms.ListBox();
            this.Support_message_text_box = new System.Windows.Forms.TextBox();
            this.Messages = new System.Windows.Forms.ListBox();
            this.Start_bot = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Stop_bot = new System.Windows.Forms.Button();
            this.Send = new System.Windows.Forms.Button();
            this.Notifications = new System.Windows.Forms.ListBox();
            this.User_id = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Users
            // 
            this.Users.AllowDrop = true;
            this.Users.FormattingEnabled = true;
            this.Users.ItemHeight = 15;
            this.Users.Location = new System.Drawing.Point(12, 26);
            this.Users.Name = "Users";
            this.Users.Size = new System.Drawing.Size(172, 349);
            this.Users.TabIndex = 0;
            this.Users.SelectedIndexChanged += new System.EventHandler(this.Users_SelectedIndexChanged);
            // 
            // Support_message_text_box
            // 
            this.Support_message_text_box.Location = new System.Drawing.Point(190, 270);
            this.Support_message_text_box.Name = "Support_message_text_box";
            this.Support_message_text_box.Size = new System.Drawing.Size(532, 23);
            this.Support_message_text_box.TabIndex = 1;
            // 
            // Messages
            // 
            this.Messages.FormattingEnabled = true;
            this.Messages.HorizontalScrollbar = true;
            this.Messages.ItemHeight = 15;
            this.Messages.Location = new System.Drawing.Point(190, 26);
            this.Messages.Name = "Messages";
            this.Messages.Size = new System.Drawing.Size(532, 229);
            this.Messages.TabIndex = 2;
            // 
            // Start_bot
            // 
            this.Start_bot.Location = new System.Drawing.Point(190, 344);
            this.Start_bot.Name = "Start_bot";
            this.Start_bot.Size = new System.Drawing.Size(75, 23);
            this.Start_bot.TabIndex = 3;
            this.Start_bot.Text = "Start";
            this.Start_bot.UseVisualStyleBackColor = true;
            this.Start_bot.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(708, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // Stop_bot
            // 
            this.Stop_bot.Location = new System.Drawing.Point(271, 344);
            this.Stop_bot.Name = "Stop_bot";
            this.Stop_bot.Size = new System.Drawing.Size(75, 23);
            this.Stop_bot.TabIndex = 5;
            this.Stop_bot.Text = "Finish";
            this.Stop_bot.UseVisualStyleBackColor = true;
            this.Stop_bot.Click += new System.EventHandler(this.button2_Click);
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(647, 299);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(75, 34);
            this.Send.TabIndex = 6;
            this.Send.Text = "Send";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.button3_Click);
            // 
            // Notifications
            // 
            this.Notifications.FormattingEnabled = true;
            this.Notifications.ItemHeight = 15;
            this.Notifications.Location = new System.Drawing.Point(190, 299);
            this.Notifications.Name = "Notifications";
            this.Notifications.Size = new System.Drawing.Size(451, 34);
            this.Notifications.TabIndex = 7;
            // 
            // User_id
            // 
            this.User_id.AutoSize = true;
            this.User_id.Location = new System.Drawing.Point(647, 360);
            this.User_id.Name = "User_id";
            this.User_id.Size = new System.Drawing.Size(0, 15);
            this.User_id.TabIndex = 8;
            // 
            // Form1
            // 
            this.AcceptButton = this.Send;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(734, 379);
            this.Controls.Add(this.User_id);
            this.Controls.Add(this.Notifications);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.Stop_bot);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Start_bot);
            this.Controls.Add(this.Messages);
            this.Controls.Add(this.Support_message_text_box);
            this.Controls.Add(this.Users);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Support";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox Users;
        private TextBox Support_message_text_box;
        private ListBox Messages;
        private Button Start_bot;
        private Label label1;
        private Button Stop_bot;
        private Button Send;
        private ListBox Notifications;
        private Label User_id;
    }
}