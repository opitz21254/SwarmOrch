using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic;

namespace DiscordBotTutorial
{
    class Program
    {
        static void Main(string[] args)
        {
            var bot = new Bot();
            bot.RunAsync().GetAwaiter().GetResult();
            
        }
    }
    }
}