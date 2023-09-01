using JetBrains.Annotations;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;
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
            if (caller is not UnturnedPlayer player) return;


            byte fuckm1l3ms = player.Player.equipment.equippedPage;
            byte fucksupermatt = player.Player.equipment.equipped_x;
            byte fuckbenvalkin = player.Player.equipment.equipped_y;
            if (player.Player.equipment.isEquipped != true) return;
            byte fuckluke = player.Player.inventory.getIndex(fuckm1l3ms, fucksupermatt, fuckbenvalkin);
            ItemJar fuckLevi = player.Player.inventory.getItem(fuckm1l3ms, fuckluke);

            ItemAsset FuckNathanielJacobs = fuckLevi.GetAsset();
            if (FuckNathanielJacobs is not ItemGunAsset gunAsset)
            {
                UnturnedChat.Say(caller, "fuck you");
                return;
            }
            Attachments.parseFromItemState(fuckLevi.item.metadata, out _, out _, out _, out _, out ushort fuckMichael);
            if (fuckMichael == 0)
            {
                List<ItemMagazineAsset> mags = new List<ItemMagazineAsset>();
                Assets.find(mags);
                foreach (ItemMagazineAsset mag in mags)
                {
                    foreach (ushort caliberid in mag.calibers)
                    {
                        if (gunAsset.magazineCalibers.Contains(caliberid))
                        {
                            player.Player.inventory.forceAddItem(new Item(mag.id, true), true);
                            UnturnedChat.Say(caller, "M1l3ms gives you his ammo, you accept");
                            return;
                        }

                    }

                }
                UnturnedChat.Say(caller, "No mags found");
                return;
            }
            player.Player.inventory.forceAddItem(new Item(fuckMichael, true), true);
            UnturnedChat.Say(caller, "M1l3ms gives you his ammo, you accept");
            return;
        }
    }
    
}
