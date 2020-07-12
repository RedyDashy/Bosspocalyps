﻿using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using AshModAdditions.Items.Materials;
using Microsoft.Xna.Framework;

namespace AshModAdditions.Items.Weapons.Ranged
{
    class CrystaliteBow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crystalite bow");
        }

        public override void SetDefaults()
        {
            item.autoReuse = true;
            item.ranged = true;
            item.noMelee = true;
            item.damage = 30;
            item.useTime = 15;
            item.useAnimation = 15;
            item.shoot = 10;
            item.shootSpeed = 4;
            item.scale = 0.5f;
            item.width = 73;
            item.height = 104;

            item.useStyle = ItemUseStyleID.HoldingOut;
            item.useAmmo = AmmoID.Arrow;

            Item c = new Item(); // TODO REMOVE THIS 
            c.CloneDefaults(ItemID.SilverBow);
            item.UseSound = c.UseSound;
        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient<CrystaliteBar>(10);
            recipe.AddTile(TileID.Anvils);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
