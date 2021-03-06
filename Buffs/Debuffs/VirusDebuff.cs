﻿using Terraria;
using Terraria.ModLoader;
using Bosspocalyps.NPCs;

namespace Bosspocalyps.Buffs.Debuffs
{
    public class VirusDebuff : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Virus");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<BGlobalNPC>().VirusDebuff = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.GetModPlayer<BosspocalypsModPlayer>().VirusDebuff = true;
        }
    }
}
