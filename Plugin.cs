using Synapse.Api.Plugin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better939
{
    [PluginInformation(
        Author = "TheVoidNebula",
        Description = "A complett rework from our favorite doggo scp.",
        LoadPriority = 0,
        Name = "Better939",
        SynapseMajor = 2,
        SynapseMinor = 6,
        SynapsePatch = 0,
        Version = "1.0"
        )]
    public class Plugin : AbstractPlugin
    {
        [Synapse.Api.Plugin.Config(section = "Better939")]
        public static Config Config;
        public override void Load()
        {
            SynapseController.Server.Logger.Info("Better939 loaded!");

            new EventHandlers();
        }

        public override void ReloadConfigs()
        {

        }
    }
}
