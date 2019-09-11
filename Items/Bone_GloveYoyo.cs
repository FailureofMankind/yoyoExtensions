using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yoyoExtensions.Items
{
	public class Bone_GloveYoyo : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bone Glove (Yoyo)");
			Tooltip.SetDefault("'There are 27 bones in each of your hands... what are you gonna do with them?...'\nUpon hitting enemies, your bones animate and burst out of your body\nThis, however, doesn't hurt you, but is indeed painful...\nYoyos inflict Frostburn");
		}
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 22;
            item.value = 10000;
            item.rare = 3;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			yoyoPlayer modplayer = player.GetModPlayer<yoyoPlayer>(mod);
            modplayer.Bone_GloveYoyo = true;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.Bone, 27);
			recipe.AddIngredient(null, "TractionGloves");
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    
    }
}