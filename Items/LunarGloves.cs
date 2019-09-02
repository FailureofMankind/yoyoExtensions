using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yoyoExtensions.Items
{
	public class LunarGloves : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lunar Gloves");
			Tooltip.SetDefault("Yoyos release homing lasers that explode on hit\nYoyos inflict On Fire, Frostburn, Poisoned, Venom, Cursed Inferno, Ichor and Daybroken on hit\n15% increased melee damage");
		}
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 22;
            item.value = 10000;
            item.rare = 10;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.meleeDamage += 0.15f;
			yoyoPlayer modplayer = player.GetModPlayer<yoyoPlayer>(mod);
            modplayer.LunarGloves = true;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FossilOre, 10);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}