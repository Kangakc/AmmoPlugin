using Rocket.Core.Logging;
using Rocket.Core.Plugins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmmoPlugin
{
    public class MainPlugin : RocketPlugin
    {
        protected override void Load()
        {
            Logger.Log("fortnitesyndrome");
            base.Load();

        }
    }


}

