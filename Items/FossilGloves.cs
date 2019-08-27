using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yoyoExtensions.Items
{
	public class FossilGloves : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fossil Gloves");
			Tooltip.SetDefault("Yoyos periodically drop dust particles that damage enemies");
		}
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 34;
            item.value = 10000;
            item.rare = 3;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			yoyoPlayer modplayer = player.GetModPlayer<yoyoPlayer>(mod);
            modplayer.FossilGloves = true;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FossilOre, 16);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    
    }
}