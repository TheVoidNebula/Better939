# Better939
A complett rework from our favorite doggo scp

[![forthebadge](https://forthebadge.com/images/badges/built-with-love.svg)](https://forthebadge.com)[![forthebadge](https://forthebadge.com/images/badges/made-with-c-sharp.svg)](https://forthebadge.com)[![forthebadge](https://forthebadge.com/images/badges/you-didnt-ask-for-this.svg)](https://forthebadge.com)

## Features
* Decide how much Health SCP-939 has
* Decide how much Damage SCP-939 does
* Decide how much Health SCP-939 gets per hit
* Decide if SCP-939 deals poison damage per hit
* SCP-939 can poison humans if they decide to bite one
* SCP-939 lets out a Amnesia, so be careful everyone gets it if you are too close

## Installation
1. [Install Synapse](https://github.com/SynapseSL/Synapse/wiki#hosting-guides)
2. Place the Better939.dll file that you can download [here](https://github.com/TheVoidNebula/Better939/releases) in your plugin directory
3. Restart/Start your server.

## Commands
Command  | Usage | Description 
------------ | ------------ | ------------ | ------------ 
`Decoy` | `.decoy` or `mouse2 (Rightclick)` | Deploy a fake SCP-939 corpse and become for some seconds a ghost

## Config
Name  | Type | Default | Description
------------ | ------------ | ------------- | ------------ 
`IsEnabled` | Boolean | true | Is this plugin enabled?
`Health` | Int | 2200 | With how much health should SCP-939 spawn?
`Damage` | Int | 65 | How much damage should SCP-939 deal per hit?
`SpawnMessage` | String | too long to show here | The spawn message for SCP-939
`EnableScp207Speed` | Boolean | true | Should SCP-939 has SCP-207 speed effects?
`Scp207SpeedMultiplier` | Int | 1 | How much SCP-207 should SCP-939 have? (Between 1 and 4)    
`EnableHealthOnKill` | Boolean | false | Should SCP-939 gain Health on a kill?
`EnableOverheal` | Boolean | false | Should SCP-939 get health higer than his max health?
`HealthOnKill` | Int | true | The Amount of health SCP-939 gains on a kill
`EnablePoisonBite` | Boolean | true | Should SCP-939 give the victim the poison effect?
`PoisonMessage` | String | '[Better939] You have been poisoned by SCP-939\nUse any medical item to stop the poison' | Should SCP-939 give the victim the poison effect?
`HealingItems` | List | 14, 17, 33, 34 | Healing items that when used will heal the user from the poison effect
`HealMessage` | String | '[Better939] You have stopped the poison' | What should be the message when someone who is poisoned heals their poison effect?
`EnableDecoyCommand` | Boolean | true | Should SCP-939 be able to fake his death with a ragdoll?
`DecoyCooldown` | Float | 30f | How long should the cooldown be after the usage of the decoy command?
`DecoyCooldownMessage` | String | '[Better939] You can use your Decoy again' | What should the message be when you can use the decoy command again after the end of the cooldown?
`DecoyInCooldownMessage` | String | '[Better939] You cannot use your decoy yet' | What should the message be when you try to use the decoy command while being in cooldown?
`DecoyMessage` | String | '[Better939] You have enabled your decoy!' | What should the message be when you enable your decoy?
`DecoyTime` | Float | 10f | How long should the decoy be active?
`EnableDecoyDoor` | Boolean | false | Should SCP-939 be able to interact with doors while in door mode? false = not
`DecoyDoorMesssage` | String | '[Better939] You cannot interact while in decoy mode!' | What should the message be when you try to open a door?      
`EnableAreaAmnesia` | Boolean | false | Should humans get the amnesia effect if they are in the close proximity of SCP-939?
`AreaAmnesia` | Int | 10 | The area in which humans get the amnesia effect


## Config.yml
```yml
[Better939]
{
# Should Better939 be enabled?
isEnabled: true
# With how much health should SCP-939 spawn?
health: 2200
# How much damage should SCP-939 deal per hit?
damage: 65
# Should SCP-939 gain Health on a kill?
enableHealthOnKill: true
# Should SCP-939 get health higer than his max health?
enableOverheal: true
# The Amount of health SCP-939 gains on a kill
healthOnKill: 20
# Should SCP-939 give the victim the poison effect?
enablePoisonBite: true
# Should SCP-939 give the victim the poison effect?
poisonMessage: >-
  ::lcb::Better939::rcb:: You have been poisoned by SCP-939

  Use any medical item to stop the poison
# Healing items that when used will heal the user from the poison effect
healingItems:
- 14
- 17
- 33
- 34
# What should be the message when someone who is poisoned heals their poison effect?
healMessage: '::lcb::Better939::rcb:: You have stopped the poison'
# Should SCP-939 be able to fake his death with a ragdoll?
enableDecoyCommand: true
# How long should the cooldown be after the usage of the decoy command?
decoyCooldown: 30
# What should the message be when you can use the decoy command again after the end of the cooldown?
decoyCooldownMessage: '::lcb::Better939::rcb:: You can use your Decoy again'
# What should the message be when you try to use the decoy command while being in cooldown?
decoyInCooldownMessage: '::lcb::Better939::rcb:: You cannot use your decoy yet'
# What should the message be when you enable your decoy?
decoyMessage: '::lcb::Better939::rcb:: You have enabled your decoy!'
# How long should the decoy be active?
decoyTime: 10
# Should humans get the amnesia effect if they are in the close proximity of SCP-939?
enableAreaAmnesia: true
# The area in which humans get the amnesia effect
areaAmnesia: 10
}hMessage: '::lcb::ExplosiveSCPS::rcb:: <color=red>Your death caused a big explosion!</color>'
}
```
