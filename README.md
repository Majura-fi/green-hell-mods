# Green Hell Mods Collection

This project contains multiple Unity Mod Manager mods for the **Green Hell** game.

## Creative Mode

Instant building. Place buildings down and they are instantly built. Works on palisades, fences and bridges too!

Note about version 1.0.1: Re-did the logic and felt comfortable to set myself as an author, since I came up with a different solutions.

Note about version 1.0.0: This version contains code made by [Wisnoskij](https://github.com/wisnoskij/GreenHell.CreativeMode). Didn't have energy to fix UI part, so left it out. Does not build multipart structures, such as palisades, fences or bridges.

## Eternal Fire

Torches, camp fires and forges never run out fuel. You can get campfire ash by harvesting charcoal and using the Mud Charcoal Furnace.

## Fast Growing Trees

This mod accelerates the growth of trees, making them grow fully in approximately 41 seconds in real time. This ensures that players will never run out of trees to chop down, as they can focus on cutting down three or four trees at a time while others grow back.

## Sensible Leeches

The game code contains two different chances for leeches, one when the player is in water and other one when the player is NOT in water. Sadly, both of these values are at 50%. This mod reduces dry-land chance from 50% to 5%.

## Sensible Centipedes (Only in Spirits of Amazonia)

Centipedes can spawn on heavy objects. The spawn rate depends on how long a heavy object has been on the ground. Each heavy object has a different spawn chance, but all chances caps on 50%.

This mod changes this cap to be 10%. It basically takes the original spawn chance and uses it as a ratio for the new spawn chance. The spawn rate changes as follows:
- 10% => 2%
- 20% => 4%
- 30% => 6%
- 40% => 8%
- 50% => 10%

## Super Planter

All planter boxes are always watered and fertilized.

## Make It Rain

The rain chance is controlled with four flags:
- High: 100%
- Medium: 50%
- Low: ??
- None: 0%

For some reason devs have left out the Low chance, meaning that some areas will never see rain. This happens at least in the area where you arrive after the air field. This mod makes sure that there is at least 25% chance for rain with low-chance areas.

For more information about the rain zones, check the rain map below.
![rainmap](https://github.com/user-attachments/assets/94890a68-debe-4b20-981a-133cb726f6a9)

## MoreEXP

Multiplies incoming exp by 100. You will get max skills very quickly.
