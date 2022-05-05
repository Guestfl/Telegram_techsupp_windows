using Telegram.Bot; // U need 16.0.2 version! Other libraries are all new
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using System.Collections.ObjectModel;
using Telegram.Bot.Args;
using Newtonsoft.Json;

// There is almost no foolproof here!

namespace Support_bot
{
    public partial class Form1 : Form
    {
        struct BotUpdate
        {
            public long id;
            public string? username;
            public string text;
            public DateTime date;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private ChatId ChoosenUser;
        // change path if use on ur pc!
        private string? dir = ""; // make a folder and add here it's path!
        TelegramBotClient BotClient;
        static List<BotUpdate> botUpdates = new List<BotUpdate>(); // It would be nice to get rid of the shared variables

        [Obsolete]
        private void Form1_Load(object sender, EventArgs e)
        {
            // change token!
            BotClient = new TelegramBotClient(""); // add here ur API TOKEN
            BotClient.OnMessage += BotClient_OnMessage;
            BotClient.OnCallbackQuery += BotClient_OnCallbackQuary;
            BotClient.StartReceiving();
            BotClient.StopReceiving();

        }

        [Obsolete]
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            BotClient.StopReceiving();
        }

        [Obsolete]
        private void BotClient_OnCallbackQuary(object? sender, CallbackQueryEventArgs e)
        {
            throw new NotImplementedException();
        }

        [Obsolete]
        private void BotClient_OnMessage(object sender, MessageEventArgs update)
        {
            botUpdates.Clear();
            string? botUpdatesString;

            // For Messaging 
            var chatId = update.Message.Chat.Id;
            var messageText = update.Message.Text;
            var username = update.Message.Chat.FirstName + " " + update.Message.Chat.LastName;
            var date = update.Message.Date;

            // For files 
            var _botUpdate = new BotUpdate
            {
                id = update.Message.Chat.Id,
                username = update.Message.Chat.FirstName + " " + update.Message.Chat.LastName,
                text = update.Message.Text,
                date = update.Message.Date,
            };

            string UserFile = $"{dir + "\\" + chatId}.json";


            // If user write first time - make json and add him to chat.
            if (!System.IO.File.Exists(UserFile))
            {
                FileStream create = System.IO.File.Create(UserFile);
                create.Close();
                Users.Invoke(() => Users.Items.Add(username));
            }

            //Read all saved updates

            try
            {
                botUpdatesString = System.IO.File.ReadAllText(UserFile);

                botUpdates = JsonConvert.DeserializeObject<List<BotUpdate>>(botUpdatesString) ?? botUpdates;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading or deserializing {ex}");
            }


            // You can get rid of large structures (if-else)
            if (ChoosenUser != null)
            {
                if (!Notifications.Items.Contains(username) && (ChoosenUser.ToString() != chatId.ToString()))
                {
                    Notifications.Invoke(() => Notifications.Items.Add(username));
                }

                if (ChoosenUser.ToString() == chatId.ToString())
                {
                    Messages.Invoke(() => Messages.Items.Add(date + "  " + username + "  " + messageText));
                }
            } else
            {
                if (!Notifications.Items.Contains(username))
                {
                    Notifications.Invoke(() => Notifications.Items.Add(username));
                }

            }


            botUpdates.Add(_botUpdate);

            botUpdatesString = JsonConvert.SerializeObject(botUpdates);

            System.IO.File.WriteAllText(UserFile, botUpdatesString);

            botUpdates.Clear();

        }

        [Obsolete]
        private void Label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        [Obsolete]
        private void Button1_Click(object sender, EventArgs e)
        {

            BotClient.StartReceiving();

            string[] JsonFiles = ProcessDirectory(dir);

          
            void FillUsersList()
            {
                foreach (string JsonFile in JsonFiles)
                {

                    string? botUpdatesString = System.IO.File.ReadAllText(JsonFile);

                    botUpdates = JsonConvert.DeserializeObject<List<BotUpdate>>(botUpdatesString) ?? botUpdates;

                    BotUpdate botUpdate = botUpdates[0];

                    if (!Users.Items.Contains(botUpdate.username))
                    {
                        Users.Invoke(() => Users.Items.Add(botUpdate.username));
                    }
                }
            }


            FillUsersList();
        }

        private string[] ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            //foreach (string fileName in fileEntries)
            //    ProcessFile(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory);

            string[] Files = fileEntries.Concat(subdirectoryEntries).ToArray();

            return Files;

        }

        // private static void ProcessFile(string path)
        // {
        //     // Support_message_text_box.Text = ("Processed file '{0}'." + path);
        // }

        [Obsolete]
        private void button2_Click(object sender, EventArgs e)
        {
            BotClient.StopReceiving();
        }


        // Would be better if u could see message only if u send him to telegram
        private void button3_Click(object sender, EventArgs e)
        {
            if (ChoosenUser == null)
                return;
            if (Support_message_text_box.Text == "")
                return;

            var _botUpdate = new BotUpdate
            {
                id = 0,
                username = "Support",
                text = Support_message_text_box.Text,
                date = DateTime.UtcNow,
            };

            string UserFile = $"{dir + "\\" + ChoosenUser}.json";

            string? botUpdatesString;

            botUpdates.Clear();

            try
            {
                botUpdatesString = System.IO.File.ReadAllText(UserFile);

                botUpdates = JsonConvert.DeserializeObject<List<BotUpdate>>(botUpdatesString) ?? botUpdates;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading or deserializing {ex}");
            }

            BotClient.SendTextMessageAsync(ChoosenUser, Support_message_text_box.Text);
            Messages.Items.Add(DateTime.UtcNow + "  " + "Support" + "  " + Support_message_text_box.Text);

            botUpdates.Add(_botUpdate);

            botUpdatesString = JsonConvert.SerializeObject(botUpdates);

            System.IO.File.WriteAllText(UserFile, botUpdatesString);

            botUpdates.Clear();

            Support_message_text_box.Clear();
        }

        private void Users_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Foolproof on clicking on Users text box
            if (Users.SelectedItems.Count == 0)
                return;

            Messages.Items.Clear();
            string[] JsonFiles = ProcessDirectory(dir);
            string? ActiveUserJson = changeactiveuserip();
            FillChatWithUser(ActiveUserJson);
            makeMessageReadenInNottification(ActiveUserJson);


            void FillChatWithUser(string UserFile)
            {
                string? botUpdatesString = System.IO.File.ReadAllText(UserFile);
                botUpdates = JsonConvert.DeserializeObject<List<BotUpdate>>(botUpdatesString) ?? botUpdates;
                foreach (BotUpdate botUpdate in botUpdates)
                {
                    Messages.Invoke(() => Messages.Items.Add(botUpdate.date + "  " + botUpdate.username + "  " + botUpdate.text));
                }

            }

             void makeMessageReadenInNottification(string? JsonFile)
            {
                string? botUpdatesString = System.IO.File.ReadAllText(ActiveUserJson);
                botUpdates = JsonConvert.DeserializeObject<List<BotUpdate>>(botUpdatesString) ?? botUpdates;
                BotUpdate botUpdate = botUpdates[0];

                if (!Notifications.Items.Contains(botUpdate.username))
                {
                    return;
                }

                if (Notifications.Items.Contains(botUpdate.username))
                {
                   Notifications.Items.Remove(botUpdate.username);
                }
            }


            // Return file with active user and change choosenuser
            string changeactiveuserip()
            {
                foreach (string JsonFile in JsonFiles)
                {
                    string? SelectedName = Users.SelectedItem.ToString();
                    string? botUpdatesString = System.IO.File.ReadAllText(JsonFile);

                    botUpdates = JsonConvert.DeserializeObject<List<BotUpdate>>(botUpdatesString) ?? botUpdates;

                    BotUpdate botUpdate = botUpdates[0];

                    if (botUpdate.username == SelectedName)
                    {
                        ChatId NextChoosenUser = botUpdate.id;
                        ChoosenUser = NextChoosenUser;
                        return JsonFile;
                    }
                }
                return "no file";
            }
        }
    }
}