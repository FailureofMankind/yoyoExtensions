using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yoyoExtensions.Items
{
	public class HallowedGloves : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hallowed Gloves");
			Tooltip.SetDefault("Allows you to use 4 yoyos at a time!");
		}
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 22;
            item.value = 10000*3;
            item.rare = 6;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			yoyoPlayer modplayer = player.GetModPlayer<yoyoPlayer>(mod);
            modplayer.HallowedGloves = true;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.HallowedBar, 5);
			recipe.AddIngredient(ItemID.SoulofMight, 3);
			recipe.AddIngredient(ItemID.SoulofSight, 3);
			recipe.AddIngredient(ItemID.SoulofFright, 3);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    
    }
}