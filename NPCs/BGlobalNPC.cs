﻿using System;
using Terraria;
using Terraria.GameContent.Events;
using Terraria.ID;
using Terraria.ModLoader;
using Bosspocalyps.Items.Equippables;
using Bosspocalyps.Items.Materials;
using Bosspocalyps.Items.Weapons.Melee;
using Bosspocalyps.Items.Weapons.Ranged;
using Bosspocalyps.Items.Weapons.Magic;

namespace Bosspocalyps.NPCs
{
    public partial class BGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity => true;

        public override void ResetEffects(NPC npc)
        {
            ResetDebuffs();
        }

        public override void NPCLoot(NPC npc)
        {
            switch (npc.type)
            {
                case NPCID.EyeofCthulhu:
                    if (Main.rand.NextBool(5)) // 20%
                        Item.NewItem(npc.getRect(), ModContent.ItemType<WindBreaker>());
                    break;

                case NPCID.EaterofWorldsHead:
                case NPCID.EaterofWorldsBody:
                case NPCID.EaterofWorldsTail:
                    break;

                case NPCID.Hellbat:
                    if (Main.rand.NextBool(50)) // 2%
                        Item.NewItem(npc.getRect(), ModContent.ItemType<Firewhacker>());
                    break;

                case NPCID.UndeadMiner:
                    if (Main.rand.NextBool(50)) // 2% (100 / 2 == 50 / 1)
                        Item.NewItem(npc.getRect(), ModContent.ItemType<SafetyGlove>());
                    break;

                case NPCID.Mummy:
                case NPCID.DarkMummy:
                case NPCID.LightMummy:
                    if(Main.rand.NextBool(5)) // 20% or 1/5
                        Item.NewItem(npc.getRect(), ModContent.ItemType<Scroll>());
                    break;

                case NPCID.BrainofCthulhu:
                    if (Main.rand.Next(100) <= 12) // 12%
                        Item.NewItem(npc.getRect(), ModContent.ItemType<RoseSaber>());
                    break;

                case NPCID.IceGolem:
                    Item.NewItem(npc.getRect(), ModContent.ItemType<FrozenHeroBlade>(), Main.rand.Next(1, 3));
                    break;

                case NPCID.BloodZombie:
                case NPCID.Drippler:
                case NPCID.TheGroom:
                case NPCID.TheBride:
                    if (Main.hardMode)
                        Item.NewItem(npc.getRect(), ModContent.ItemType<UnholyBlood>(), Main.rand.Next(5, 11));
                    break;

                case NPCID.WallofFlesh:
                        Item.NewItem(npc.getRect(), ModContent.ItemType<CombiniteBar>(), Main.rand.Next(6, 11));
                    break;

                case NPCID.Spazmatism:
                    Item.NewItem(npc.getRect(), ModContent.ItemType<CursedEye>(), 1);
                    goto case NPCID.Retinazer;
                case NPCID.Retinazer:
                    Item.NewItem(npc.getRect(), ModContent.ItemType<UnholiteBar>(), Main.rand.Next(5, 8));
                    break;

                case NPCID.MoonLordCore:
                    BWorld.IridiumGen = true;
                    break;
            }
        }

        public override void SetupShop(int type, Chest shop, ref int nextSlot)
        {
            switch (type)
            {
                case NPCID.Cyborg:
                    shop.item[nextSlot++].SetDefaults(ModContent.ItemType<RoseSaber>());
                    break;
            }
        }
    }
}
