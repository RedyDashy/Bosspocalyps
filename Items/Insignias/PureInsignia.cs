﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using AshModAdditions.Items.Materials;
using AshModAdditions.Tiles;

namespace AshModAdditions.Items.Insignias
{
    class PureInsignia : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pure Insignia");
            Tooltip.SetDefault(@"+5% all damage when in the Forest
20 defense when in the Forest
+3% damage reduction when in the Forest
+40% running speed when in the Forest
+20% melee speed when in the Forest
+3 life regen when in the Forest");
        }

        public override void SetDefaults()
        {
            item.material = true;
            item.width = 30;
            item.height = 28;
        }

        public override void UpdateInventory(Player player)
        {
            if (player.InForest())
            {
                player.GetModPlayer<AshModPlayer>().PureInsignia = true;
                player.allDamage += 0.05f;
                player.statDefense += 20;
                player.accRunSpeed += 0.4f;
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient<EmptyInsignia>();
            recipe.AddIngredient(ItemID.Wood, 10);
            recipe.AddIngredient(ItemID.Gel, 5);
            recipe.AddIngredient(ItemID.GreenSolution, 5);
            // recipe.AddTile<LuminiteAnvilTile>();
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
