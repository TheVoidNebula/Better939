using CustomPlayerEffects;
using MEC;
using Synapse.Api;
using Synapse.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Better939
{
    [CommandInformation(
        Name = "decoy",
        Aliases = new[] { "dec" },
        Description = "Fake your death",
        Permission = "",
        Platforms = new[] { Platform.ClientConsole },
        Usage = ".decoy"
        )]
    public class DecoyCommand : ISynapseCommand
    {

        public static HashSet<Player> inCooldown = new HashSet<Player>();
        public static HashSet<Player> inDecoyMode = new HashSet<Player>();

        public CommandResult Execute(CommandContext context)
        {
            var result = new CommandResult();
            Player player = context.Player;

            if (EventHandlers.is939(player))
            {
                if (!inCooldown.Contains(player)) 
                {
                    EventHandlers.Coroutines.Add(Timing.RunCoroutine(Decoy(player)));
                    EventHandlers.Coroutines.Add(Timing.RunCoroutine(DecoyCooldown(player)));
                    result.Message = "[Better939] You successfully enabled your decoy!";
                    result.State = CommandResultState.Ok;
                    return result;
                }
                else
                {
                    player.GiveTextHint(Plugin.Config.DecoyInCooldownMessage);
                    result.Message = "[Better939] You are currently in the cooldown and cannot use the decoy yet!";
                    result.State = CommandResultState.Error;
                    return result;
                }
            }
            else
            {
                result.Message = "[Better939] You can only run this command as SCP-939!";
                result.State = CommandResultState.Error;
                return result;
            }
        }

        public static IEnumerator<float> Decoy(Player player)
        {
            inDecoyMode.Add(player);
            inCooldown.Add(player);
            player.SendBroadcast(5, Plugin.Config.DecoyMessage);
            Synapse.Api.Ragdoll rag = new Synapse.Api.Ragdoll(player.RoleType, player.Position, Quaternion.identity, Vector3.zero, new PlayerStats.HitInfo(), false, player);
            player.GodMode = true;
            player.Invisible = true;
            player.PlayerEffectsController.EnableEffect<Disabled>(Plugin.Config.DecoyTime);
            Map.Get.AnnounceScpDeath("9 3 9");
            if (Map.Get.Nuke.Detonated)
            {
                yield return Timing.WaitForSeconds(0.1f);
                player.Hurt(99999);
            }
            yield return Timing.WaitForSeconds(Plugin.Config.DecoyTime);
            if (rag != null) rag.Destroy();
            player.GodMode = false;
            player.Invisible = false;
            inDecoyMode.Remove(player);
        }

        public static IEnumerator<float> DecoyCooldown(Player player)
        {
            yield return Timing.WaitForSeconds(Plugin.Config.DecoyCooldown);
            inCooldown.Remove(player);
            player.SendBroadcast(5, Plugin.Config.DecoyCooldownMessage);
        }
    }
}
