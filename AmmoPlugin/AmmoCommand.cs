using Rocket.API;
using Rocket.Unturned.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmmoPlugin
{
    public class AmmoCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player; // Dont let the console call the command, only the player.

        public string Name => "ammo";  // Setting the name of the command as "ammo".

        public string Help => "ammo give ammo dumbass"; // When /help ammo, this shall print.

        public string Syntax => "/ammo [amount]"; // <> is required and [] is optional

        public List<string> Aliases { get; } = new List<string>() { "a" }; // By using { get; } you create a property of the list rather than creating a new list.
        public List<string> Permissions { get; } = new List<string>() { "ac.ammo" }; // ac.ammo is the code/id of the permisson group allowed to use the /ammo command

        public void Execute(IRocketPlayer caller, string[] command) // when /ammo is used, the following string is thrown along with the name of the player who used the command
        {
            UnturnedChat.Say(caller, "M1l3ms gives you his ammo, you accept");
            return;
        }
    }
}
