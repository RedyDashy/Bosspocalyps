﻿using System;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AshModAdditions
{
    public static class Helpers
    {
        internal const string PLACEHOLDER = nameof(AshModAdditions) + "/placeholder";

        public static float Progress1toM11(float progress) => 1f - Math.Abs(1f - progress * 2f);
        public static float Progress(float val, float min, float max) => 1f / (max - min) * (val - min);
        public static float Progress(float val, float min, float max, float progressScale) => progressScale / (max - min) * (val - min);

        // Code from absolute aquarian
        public static bool InForest(this Player player) => player.ZoneOverworldHeight &&
            !(player.ZoneDungeon ||
            player.ZoneCorrupt ||
            player.ZoneCrimson ||
            player.ZoneHoly ||
            player.ZoneSnow ||
            player.ZoneUndergroundDesert ||
            player.ZoneGlowshroom ||
            player.ZoneMeteor ||
            player.ZoneBeach ||
            player.ZoneDesert);

        /// <summary>
        /// Finds the closest npc to the specified position
        /// </summary>
        /// <param name="position"></param>
        /// <returns>The NPC index + 1, if no NPC is found, 0 is returned</returns>
        public static int ClosestHostileNPCTo(Vector2 position, float minDistance = -1)
        {
            int npcs = Main.npc.Length - 1;
            float closestDistance = -1;
            int npct = 0;
            for(int i = 0; i < npcs; i++)
            {
                NPC npc = Main.npc[i];

                float distSQ = npc.DistanceSQ(position);
                if (! (npc?.active is true && npc.CanBeChasedBy() && (minDistance == -1 || npc.WithinRange(position, minDistance)) ))
                    continue;

                if(closestDistance == -1 || distSQ < closestDistance)
                {
                    closestDistance = distSQ;
                    npct = npc.whoAmI + 1;
                }
            }
            return npct;
        }

        public static int NewNPC<T>(int X, int Y, int Type, int Start = 0, float ai0 = 0, float ai1 = 0, float ai2 = 0, float ai3 = 0, int Target = 255) where T : ModNPC => NPC.NewNPC(X, Y, ModContent.NPCType<T>(), Start, ai0, ai1, ai2, ai3, Target);
        public static int NewNPC<T>(out T modnpc, int X, int Y, int Type, int Start = 0, float ai0 = 0, float ai1 = 0, float ai2 = 0, float ai3 = 0, int Target = 255) where T : ModNPC
        {
            int npc = NPC.NewNPC(X, Y, ModContent.NPCType<T>(), Start, ai0, ai1, ai2, ai3, Target);
            modnpc = Main.npc[npc].modNPC as T;
            return npc;

        }

        public static NPC NewNPCDirect<T>(Point position, int Start = 0, float ai0 = 0, float ai1 = 0, float ai2 = 0, float ai3 = 0, int Target = 255) where T : ModNPC => Main.npc[NPC.NewNPC(position.X, position.Y, ModContent.NPCType<T>(), Start, ai0, ai1, ai2, ai3, Target)];
        public static NPC NewNPCDirect<T>(Vector2 position, int Start = 0, float ai0 = 0, float ai1 = 0, float ai2 = 0, float ai3 = 0, int Target = 255) where T : ModNPC => Main.npc[NPC.NewNPC((int)position.X, (int)position.Y, ModContent.NPCType<T>(), Start, ai0, ai1, ai2, ai3, Target)];
        public static NPC NewNPCDirect<T>(int X, int Y, int Start = 0, float ai0 = 0, float ai1 = 0, float ai2 = 0, float ai3 = 0, int Target = 255) where T : ModNPC => Main.npc[NPC.NewNPC(X, Y, ModContent.NPCType<T>(), Start, ai0, ai1, ai2, ai3, Target)];
        public static NPC NewNPCDirect<T>(out T modNPC, Point position, int Start = 0, float ai0 = 0, float ai1 = 0, float ai2 = 0, float ai3 = 0, int Target = 255) where T : ModNPC => NewNPCDirect(out modNPC, position.X, position.Y, Start, ai0, ai1, ai2, ai3, Target);
        public static NPC NewNPCDirect<T>(out T modNPC, Vector2 position, int Start = 0, float ai0 = 0, float ai1 = 0, float ai2 = 0, float ai3 = 0, int Target = 255) where T : ModNPC => NewNPCDirect(out modNPC, (int)position.X, (int)position.Y, Start, ai0, ai1, ai2, ai3, Target);
        public static NPC NewNPCDirect<T>(out T modNPC, int X, int Y, int Start = 0, float ai0 = 0, float ai1 = 0, float ai2 = 0, float ai3 = 0, int Target = 255) where T : ModNPC
        {
            NPC npc = Main.npc[NPC.NewNPC(X, Y, ModContent.NPCType<T>(), Start, ai0, ai1, ai2, ai3, Target)];
            modNPC = npc.modNPC as T;
            return npc;
        }

        public static void AddIngredient<T>(this ModRecipe recipe, int stack = 1) where T : ModItem
        {
            recipe.AddIngredient(ModContent.ItemType<T>(), stack);
        }

        public static void AddTile<T>(this ModRecipe recipe) where T : ModTile
        {
            recipe.AddTile(ModContent.TileType<T>());
        }
    }
}
