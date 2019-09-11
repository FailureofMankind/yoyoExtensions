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
			Tooltip.SetDefault("Yoyos have a chance to restore health and mana!\nThis effect has a 2 second cooldown\n7% increased melee damage");
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
            player.meleeDamage += 0.07f;
			yoyoPlayer modplayer = player.GetModPlayer<yoyoPlayer>(mod);
            modplayer.StickyFingas = true;
            if(modplayer.StickyFingasCooldown < 120)
            {
                modplayer.StickyFingasCooldown++;
            }
        }
    }
}