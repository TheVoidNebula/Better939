using Synapse.Config;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Better939
{
    public class Config : AbstractConfigSection
    {

        [Description("Should Better939 be enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("With how much health should SCP-939 spawn?")]
        public int Health { get; set; } = 2200;

        [Description("How much damage should SCP-939 deal per hit?")]
        public int Damage { get; set; } = 65;

        [Description("The spawn message for SCP-939?")]
        public string SpawnMessage { get; set; } = "[Better939] You are <color=red>SCP-939</color>!" +
            "\n\nYou gain health as you <color=red>kill humans</color>.\n\nYour bite <color=red>poisons humans</color>." +
            "\n\nYou have a <color=red>active</color> ability which you can enable with a rightclick or with .decoy in console." +
            "\n\nYou also also have a <color=red>passive</color> ability in which humans get amnesia when they get to close to you.";

        [Description("Should SCP-939 has SCP-207 speed effects?")]
        public bool EnableScp207Speed { get; set; } = true;

        [Description("How much SCP-207 should SCP-939 have? (Between 1 and 4)")]
        public int Scp207SpeedMultiplier { get; set; } = 1;

        [Description("Should SCP-939 gain Health on a kill?")]
        public bool EnableHealthOnKill { get; set; } = true;

        [Description("Should SCP-939 get health higer than his max health?")]
        public bool EnableOverheal { get; set; } = false;

        [Description("The Amount of health SCP-939 gains on a kill")]
        public int HealthOnKill { get; set; } = 20;

        [Description("Should SCP-939 give the victim the poison effect?")]
        public bool EnablePoisonBite { get; set; } = true;

        [Description("Should SCP-939 give the victim the poison effect?")]
        public string PoisonMessage { get; set; } = "[Better939] You have been poisoned by SCP-939\nUse any medical item to stop the poison";

        [Description("Healing items that when used will heal the user from the poison effect")]
        public List<int> HealingItems { get; set; } = new List<int>() { 14, 17, 33, 34 };

        [Description("What should be the message when someone who is poisoned heals their poison effect?")]
        public string HealMessage { get; set; } = "[Better939] You have stopped the poison";

        [Description("Should SCP-939 be able to fake his death with a ragdoll?")]
        public bool EnableDecoyCommand { get; set; } = true;

        [Description("How long should the cooldown be after the usage of the decoy command?")]
        public float DecoyCooldown { get; set; } = 120f;

        [Description("What should the message be when you can use the decoy command again after the end of the cooldown?")]
        public string DecoyCooldownMessage { get; set; } = "[Better939] You can use your Decoy again";

        [Description("What should the message be when you try to use the decoy command while being in cooldown?")]
        public string DecoyInCooldownMessage { get; set; } = "[Better939] You cannot use your decoy yet";

        [Description("What should the message be when you enable your decoy?")]
        public string DecoyMessage { get; set; } = "[Better939] You have enabled your decoy!";

        [Description("How long should the decoy be active?")]
        public float DecoyTime { get; set; } = 10f;

        [Description("Should SCP-939 be able to interact with doors while in door mode? false = not")]
        public bool EnableDecoyDoor { get; set; } = false;

        [Description("What should the message be when you try to open a door?")]
        public string DecoyDoorMesssage { get; set; } = "[Better939] You cannot interact while in decoy mode!";

        [Description("Should humans get the amnesia effect if they are in the close proximity of SCP-939?")]
        public bool EnableAreaAmnesia { get; set; } = false;

        [Description("The area in which humans get the amnesia effect")]
        public int AreaAmnesia { get; set; } = 10;
    }
}
