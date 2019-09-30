using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yoyoExtensions.Items
{
	public class ElementalGloves : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Elemental Gloves");
			Tooltip.SetDefault("Yoyos inflict On Fire, Poisoned and Frostburn\nYoyos leave a trail of elemental dust that gives random buffs based on type to the player on impact with enemies");
		}
        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 22;
            item.value = 10000*2;
            item.rare = 5;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
			yoyoPlayer modplayer = player.GetModPlayer<yoyoPlayer>(mod);
            modplayer.ElementalGloves = true;
        }

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(null, "FossilGloves");
			recipe.AddIngredient(null, "MagmaGloves");
			recipe.AddIngredient(null, "SporeGloves");
			recipe.AddIngredient(null, "Bone_GloveYoyo");
			recipe.AddTile(TileID.DemonAltar);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
    }
}