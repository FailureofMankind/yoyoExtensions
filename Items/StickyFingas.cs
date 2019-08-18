using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yoyoExtensions.Items
{
	public class StickyFingas : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Magic Gloves");
			Tooltip.SetDefault("Locks yoyos into enemies!\n7% increased melee damage");
		}
        public override void SetDefaults()
        {
            item.width = 34;
            item.height = 34;
            item.value = 10000*2;
            item.rare = 5;
            item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.meleeDamage += 0.07f;
			yoyoPlayer modplayer = player.GetModPlayer<yoyoPlayer>(mod);
            modplayer.StickyFingas = true;
        }
    }
}