using DiscordRPC;
using DiscordRPC.Logging;

namespace BookRP
{
    public class DiscordRP
    {
        public DiscordRpcClient client = new("1380604010574381096");

        public void Initialize()
        {
            if (client.IsInitialized) return;

            client.Logger = new ConsoleLogger() { Level = LogLevel.Warning };

            client.OnReady += (sender, e) =>
            {
                Console.WriteLine("Received Ready from user {0}", e.User.Username);
            };

            client.OnPresenceUpdate += (sender, e) =>
            {
                Console.WriteLine("Received Update! {0}", e.Presence);
            };

            client.Initialize();
        }

        public void UpdatePresence(RichPresence presense)
        {
            if (client == null || !client.IsInitialized) return;
            client.SetPresence(presense);
        }

        public void ClearPresense()
        {
            if (client == null || !client.IsInitialized) return;
            client.ClearPresence();
        }
    }
}
