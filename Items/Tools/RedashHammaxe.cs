﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Bosspocalyps.Items.Materials;

namespace Bosspocalyps.Items.Tools
{
    public class RedashHammaxe : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Redash Hammaxe");
        }

        public override void SetDefaults()
        {
            item.melee  = true;
            item.autoReuse = true;
            item.damage = 20;
            item.axe = 30;
            item.hammer = 200;
            item.useTime = 20;
            item.useAnimation = 20;
            item.knockBack = 4f;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.UseSound = SoundHelper.ItemSwing;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient<RedashBar>(18);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
