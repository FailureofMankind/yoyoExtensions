using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yoyoExtensions.Items
{
	public class yoyoThrownMode : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Yoyo Thrown Mode Toggler");
			Tooltip.SetDefault("WIP, only changes projectile type, not item type");
		}
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.value = 0;
            item.rare = 1;
            item.maxStack = 1;
        }
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
        public override void UpdateInventory(Player player)
        {
            yoyoPlayer modplayer = player.GetModPlayer<yoyoPlayer>(mod);
            modplayer.yoyoThrownMode = true;            
        }        
    }    
}