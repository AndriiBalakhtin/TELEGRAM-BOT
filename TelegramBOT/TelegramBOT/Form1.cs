using Telegram.Bot;
using Telegram.Bot.Types;

namespace TelegramBOT
{
    public partial class Form1 : Form
    {
        private readonly TelegramBotClient botClient;

        // This is a free code to use: //--------------//
        // By Andrii Balakhtin in 2025-04-02           //
        // link https://github.com/AndriiBalakhtin     //
        //---------------------------------------------//

        // REQUIRED: //-------------------------------------------------------------------------------------------------------------------------------------------------------------------//
          private readonly string[] userIds = { "User-ID" };   // follow the link https://web.telegram.org/k/#@LeadConverterToolkitBot and use the command /get_my_id (and take the ID)   //
          private readonly string botToken  = "BOT-TOKEN-API"; // folow the link https://web.telegram.org/k/#@BotFather and use the command /newbot (and take the token)                  //
        //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        // DOCS: //------------====------------------------//
        // https://core.telegram.org/api                   //
        // https://core.telegram.org/bots/api              //
        // https://core.telegram.org/bots/api#sendmessage  //
        //-------------------------------------------------//

        public Form1()
        {
            InitializeComponent();
            botClient = new TelegramBotClient(botToken);


        }

        private void UploadFileButton_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new()
            {
                Filter = "Image files (*.png;*.jpeg;*.jpg;*.gif;*.bmp)|*.png;*.jpeg;*.jpg;*.gif;*.bmp|Document files (*.doc;*.docx;*.pdf;*.txt)|*.doc;*.docx;*.pdf;*.txt|Video files (*.mp4;*.avi;*.mov;*.webm)|*.mp4;*.avi;*.mov;*.webm|Audio files (*.mp3;*.wav;*.ogg)|*.mp3;*.wav;*.ogg|Executable files (*.exe)|*.exe|All files (*.*)|*.*"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                SendFileToUsers(filePath);
            }


        }

        private async void SendFileToUsers(string filePath)
        {
            if (userIds.Length == 0)
            {
                MessageBox.Show("Please upload a file with user IDs first.");
                return;
            }

            foreach (string userId in userIds)
            {
                try
                {
                    using FileStream fileStream = new(filePath, FileMode.Open, FileAccess.Read);
                    string fileName = Path.GetFileName(filePath);
                    string fileExtension = Path.GetExtension(filePath).ToLower();

                    if (fileExtension == ".png" || fileExtension == ".jpeg" || fileExtension == ".jpg" || fileExtension == ".bmp")
                    {
                        await botClient.SendPhoto(
                            chatId: userId,
                            photo: new InputFileStream(fileStream, fileName),
                            caption: "Here is your image."
                        );
                    }
                    else if (fileExtension == ".gif")
                    {
                        await botClient.SendAnimation(
                            chatId: userId,
                            animation: new InputFileStream(fileStream, fileName),
                            caption: "Here is your GIF."
                        );
                    }
                    else if (fileExtension == ".doc" || fileExtension == ".docx" || fileExtension == ".pdf" || fileExtension == ".txt" || fileExtension == ".exe")
                    {
                        await botClient.SendDocument(
                            chatId: userId,
                            document: new InputFileStream(fileStream, fileName),
                            caption: "Here is your document."
                        );
                    }
                    else if (fileExtension == ".mp4" || fileExtension == ".avi" || fileExtension == ".mov" || fileExtension == ".webm")
                    {
                        await botClient.SendVideo(
                            chatId: userId,
                            video: new InputFileStream(fileStream, fileName),
                            caption: "Here is your video."
                        );
                    }
                    else if (fileExtension == ".mp3" || fileExtension == ".wav" || fileExtension == ".ogg")
                    {
                        await botClient.SendAudio(
                            chatId: userId,
                            audio: new InputFileStream(fileStream, fileName),
                            caption: "Here is your audio."
                        );
                    }
                    else
                    {
                        await botClient.SendDocument(
                            chatId: userId,
                            document: new InputFileStream(fileStream, fileName),
                            caption: "Here is your file."
                        );
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error sending file to {userId}: {ex.Message}");
                }
            }


            MessageBox.Show("Files sent successfully!");
        }

        private async void SendMessageButton_Click(object sender, EventArgs e)
        {
            if (userIds.Length == 0)
            {
                MessageBox.Show("Please upload a file with user IDs first.");
                return;
            }

            string message = ChatTextBox.Text.Trim();
            if (string.IsNullOrEmpty(message))
            {
                MessageBox.Show("Please enter a message to send.");
                return;
            }

            foreach (string userId in userIds)
            {
                try
                {
                    await botClient.SendMessage(userId, message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error sending message to {userId}: {ex.Message}");
                }
            }


            ChatTextBox.Clear();
        }
    }
}