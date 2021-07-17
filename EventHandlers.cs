using CustomPlayerEffects;
using MEC;
using Synapse;
using Synapse.Api;
using Synapse.Api.Events.SynapseEventArguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Better939
{
    public class EventHandlers
    {
        public static List<CoroutineHandle> Coroutines = new List<CoroutineHandle>();
        public EventHandlers()
        {
            Server.Get.Events.Round.RoundEndEvent += OnRoundEnd;
            Server.Get.Events.Player.PlayerSetClassEvent += OnSetClass;
            Server.Get.Events.Player.PlayerLeaveEvent += OnLeave;
            Server.Get.Events.Player.PlayerDeathEvent += OnDeath;
            Server.Get.Events.Player.PlayerDamageEvent += OnDamage;
            Server.Get.Events.Player.PlayerItemUseEvent += OnItemInteract;
            Server.Get.Events.Player.PlayerKeyPressEvent += OnKeyPress;
            Server.Get.Events.Map.DoorInteractEvent += OnDoorInteract;
        }

        public static bool is939(Player player)
        {
            if (player.RoleType == RoleType.Scp93953 || player.RoleType == RoleType.Scp93989)
                return true;
            else
                return false;
        }

        public void OnRoundEnd() => Timing.KillCoroutines(Coroutines.ToArray());
  
        

        public void OnSetClass(PlayerSetClassEventArgs ev)
        {
            Player player = ev.Player;
            if (DecoyCommand.inCooldown.Contains(player))
                DecoyCommand.inCooldown.Remove(player);

            if (DecoyCommand.inDecoyMode.Contains(player))
                DecoyCommand.inDecoyMode.Remove(player);
            if (ev.Role == RoleType.Scp93953 || ev.Role == RoleType.Scp93989)
            {
                player.Health = Plugin.Config.Health;
                player.MaxHealth = Plugin.Config.Health;
                player.GiveTextHint(Plugin.Config.SpawnMessage, 10);
                if(Plugin.Config.EnableAreaAmnesia)
                    Coroutines.Add(Timing.RunCoroutine(StartAreaAmnesia(player)));
                if (Plugin.Config.EnableScp207Speed)
                    Timing.CallDelayed(1f, () => player.PlayerEffectsController.EnableEffect<Scp207>(Plugin.Config.Scp207SpeedMultiplier - 1));
            }
        }

        public void OnLeave(PlayerLeaveEventArgs ev)
        {
            Player player = ev.Player;
            if (DecoyCommand.inCooldown.Contains(player))
                DecoyCommand.inCooldown.Remove(player);

            if (DecoyCommand.inDecoyMode.Contains(player))
                DecoyCommand.inDecoyMode.Remove(player);
        }

        public void OnKeyPress(PlayerKeyPressEventArgs ev)
        {
            Player player = ev.Player;   
            if(ev.KeyCode == KeyCode.Mouse2 && is939(player) && !DecoyCommand.inDecoyMode.Contains(player))
            {
                Coroutines.Add(Timing.RunCoroutine(DecoyCommand.Decoy(player)));
                Coroutines.Add(Timing.RunCoroutine(DecoyCommand.DecoyCooldown(player)));
            }
            else if (ev.KeyCode == KeyCode.Mouse2 && is939(player) && DecoyCommand.inDecoyMode.Contains(player))
                player.GiveTextHint(Plugin.Config.DecoyInCooldownMessage);
            
        }

        public void OnDeath(PlayerDeathEventArgs ev)
        {
            Player killer = ev.Killer;
            Player victim = ev.Victim;
            float missingHealthKiller = killer.MaxHealth - killer.Health;
            if (is939(killer))
            {
                if (Plugin.Config.EnableHealthOnKill)
                {
                    if (Plugin.Config.EnableOverheal && missingHealthKiller < Plugin.Config.HealthOnKill)
                        killer.Health += Plugin.Config.HealthOnKill;
                   else if (!Plugin.Config.EnableOverheal || missingHealthKiller > Plugin.Config.HealthOnKill)
                        killer.Health += killer.MaxHealth;
                }       
            }

            if (DecoyCommand.inCooldown.Contains(victim))
                DecoyCommand.inCooldown.Remove(victim);

            if (DecoyCommand.inDecoyMode.Contains(victim))
                DecoyCommand.inDecoyMode.Remove(victim);
        }

        public void OnDamage(PlayerDamageEventArgs ev)
        {
            Player attacker = ev.Killer;
            Player victim = ev.Victim;

            if (is939(attacker))
            {
                if (Plugin.Config.EnablePoisonBite)
                {
                    victim.PlayerEffectsController.EnableEffect<Poisoned>();
                    victim.GiveTextHint(Plugin.Config.PoisonMessage);
                }
                ev.DamageAmount = Plugin.Config.Damage;

                if (DecoyCommand.inDecoyMode.Contains(attacker))
                    ev.Allow = false;
                else
                    ev.Allow = true;
            }

            if (is939(victim) && Plugin.Config.EnableScp207Speed && ev.HitInfo.GetDamageType() == DamageTypes.Scp207)
                ev.Allow = false;
            else
                ev.Allow = true;
        }

        public void OnItemInteract(PlayerItemInteractEventArgs ev)
        {
            if(Plugin.Config.EnablePoisonBite && ev.Player.PlayerEffectsController.GetEffect<Poisoned>().Enabled && Plugin.Config.HealingItems.Contains(ev.CurrentItem.ID) && ev.State == ItemInteractState.Finalizing)
            {
                ev.Player.PlayerEffectsController.DisableEffect<Poisoned>();
                ev.Player.GiveTextHint(Plugin.Config.HealMessage);
            }
        }

        public void OnDoorInteract(DoorInteractEventArgs ev)
        {
            Player player = ev.Player;

            if (DecoyCommand.inDecoyMode.Contains(player) && !Plugin.Config.EnableDecoyDoor && is939(player))
            {
                ev.Allow = false;
                player.GiveTextHint(Plugin.Config.DecoyDoorMesssage);
            }
            else
                ev.Allow = true;
                
        }

        public IEnumerator<float> StartAreaAmnesia(Player player)
        {
            while (is939(player) && !DecoyCommand.inDecoyMode.Contains(player))
            {
                foreach (Player players in Server.Get.Players)
                {
                    if(players != player && players.Team != Team.SCP)
                    {
                        if (Vector3.Distance(players.Position, player.Position) <= Plugin.Config.AreaAmnesia)
                            players.PlayerEffectsController.EnableEffect<Amnesia>(3);
                    }
                }
                yield return Timing.WaitForSeconds(2f);
                yield return Timing.WaitForOneFrame;
            }
        }
    }
}
