using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yoyoExtensions.Items
{
	public class SporeGloves : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spore Gloves");
			Tooltip.SetDefault("Yoyos periodically release spore clouds which do 30% of yoyo projectile damage\nYoyos inflict Poisoned debuf");
		}
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 22;
            item.value = 10000;
            item.rare = 2;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			yoyoPlayer modplayer = player.GetModPlayer<yoyoPlayer>(mod);
            modplayer.SporeGloves = true;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.JungleSpores, 6);
			recipe.AddIngredient(ItemID.RichMahogany, 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    
    }
}