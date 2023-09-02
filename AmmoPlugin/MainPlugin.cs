using Rocket.Core.Logging;
using Rocket.Core.Plugins;

namespace AmmoPlugin;

public class MainPlugin : RocketPlugin
{
    protected override void Load()
    {
        Logger.Log("Loading AmmoPlugin Made By: Kangakc");
    }
}