namespace TelegramBOT
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
            ChatTextBox = new TextBox();
            UploadFileButton = new Button();
            SendMessageButton = new Button();
            SuspendLayout();
            // 
            // ChatTextBox
            // 
            ChatTextBox.Location = new Point(51, 19);
            ChatTextBox.Multiline = true;
            ChatTextBox.Name = "ChatTextBox";
            ChatTextBox.Size = new Size(332, 36);
            ChatTextBox.TabIndex = 0;
            // 
            // UploadFileButton
            // 
            UploadFileButton.BackgroundImage = Properties.Resources.UploadFile;
            UploadFileButton.BackgroundImageLayout = ImageLayout.Zoom;
            UploadFileButton.Location = new Point(12, 19);
            UploadFileButton.Name = "UploadFileButton";
            UploadFileButton.Size = new Size(33, 36);
            UploadFileButton.TabIndex = 1;
            UploadFileButton.UseVisualStyleBackColor = true;
            UploadFileButton.Click += UploadFileButton_Click;
            // 
            // SendMessageButton
            // 
            SendMessageButton.BackgroundImage = Properties.Resources.SendMessage;
            SendMessageButton.BackgroundImageLayout = ImageLayout.Zoom;
            SendMessageButton.Location = new Point(346, 24);
            SendMessageButton.Name = "SendMessageButton";
            SendMessageButton.Size = new Size(26, 23);
            SendMessageButton.TabIndex = 2;
            SendMessageButton.UseVisualStyleBackColor = true;
            SendMessageButton.Click += SendMessageButton_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(390, 67);
            Controls.Add(SendMessageButton);
            Controls.Add(UploadFileButton);
            Controls.Add(ChatTextBox);
            Name = "Form1";
            Text = "Bot";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox ChatTextBox;
        private Button UploadFileButton;
        private Button SendMessageButton;
    }
}
