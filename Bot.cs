using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
Newtonsoft.Json;
System.IO;
System.Text;
System.Threading.Tasks;



namespace DiscordBotTutorial
{
    public class Bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }

        public async Task RunAsync()
        {
            var json = string.Empty;


            using (var fs = file.openRead("config.json"))
            using (var sr = new StreamReader(fs, new UT8Encoding(false)))
                json = await sr.ReadToEndAsynch().ConfigureAwait(false);

            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);

            var config = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                LogLevel = LogLevel.Debug,
                UseInternalLogHandler = true
            };
            Client = new DiscordClient(config);

            Client.Ready += OnClientReady;

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.Prefix },
                EnableDms = false,
                EnableMentionPrefix = true
            };
            Commands = Client.UseCommandsNext(commandsConfig);

            await Client.ConnectAsync();

            await Task.Delay(-1);
        }

        privte Task = OnClientReady(ReadyEventArgs e)
            {
                //put custom code here - log to console the bots on
                return Task.CompletedTask;
    }
}
    }
