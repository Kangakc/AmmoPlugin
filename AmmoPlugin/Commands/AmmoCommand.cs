using System.Collections.Generic;
using System.Linq;
using Rocket.API;
using Rocket.Unturned.Chat;
using Rocket.Unturned.Player;
using SDG.Unturned;

namespace AmmoPlugin.Commands;

public class AmmoCommand : IRocketCommand
{ 
    public AllowedCaller AllowedCaller => AllowedCaller.Player;

    public string Name => "ammo";

    public string Help => "This will provide you ammo for the weapon that is currently equipped.";

    public string Syntax => "/ammo [amount]";

    public List<string> Aliases => new() { "a" };
    public List<string> Permissions => new() { "ac.ammo" };

    public void Execute(IRocketPlayer caller, string[] command)
    {
        if (caller is not UnturnedPlayer player)
        {
            return;
        }

        var equipment_page = player.Player.equipment.equippedPage;
        var equipped_x = player.Player.equipment.equipped_x;
        var equipped_y = player.Player.equipment.equipped_y;

        if (player.Player.equipment.isEquipped != true)
        {
            return;
        }
            
        var item_index = player.Player.inventory.getIndex(equipment_page, equipped_x, equipped_y);
        var item = player.Player.inventory.getItem(equipment_page, item_index);
            
        if (item.GetAsset() is not ItemGunAsset gun_asset)
        {
            UnturnedChat.Say(caller, "Please call this command with a gun equipped.");
            return;
        }

        Attachments.parseFromItemState(item.item.metadata, out _, out _, out _, out _, out var magazine);
        if (magazine == 0)
        {
            var mags = new List<ItemMagazineAsset>();
            Assets.find(mags);
            foreach (var mag in mags.Where(mag => mag.calibers.Any(caliber => gun_asset.magazineCalibers.Contains(caliber))))
            {
                player.Player.inventory.forceAddItem(new Item(mag.id, true), true);
                UnturnedChat.Say(caller, "You have received a magazine.");
                return;
            }

            UnturnedChat.Say(caller, "No magazines found");
            return;
        }
        player.Player.inventory.forceAddItem(new Item(magazine, true), true);
        UnturnedChat.Say(caller, "You have received a magazine.");
    }
}