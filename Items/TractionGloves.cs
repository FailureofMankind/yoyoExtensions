using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yoyoExtensions.Items
{
	public class TractionGloves : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Traction Gloves");
			Tooltip.SetDefault("10% increased melee criticial strike chance\nStrengthens Wooden Yoyo!");
		}
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 34;
            item.value = 100*35;
            item.rare = 1;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			player.meleeCrit += 10;
			yoyoPlayer modplayer = player.GetModPlayer<yoyoPlayer>(mod);
            modplayer.TractionGloves = true;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Wood, 2);
			recipe.AddIngredient(ItemID.Gel, 10);
			recipe.AddTile(TileID.WorkBenches);
			recipe.AddTile(TileID.Torches);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}