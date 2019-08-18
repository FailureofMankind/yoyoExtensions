using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yoyoExtensions.Items
{
	public class YoyoExperience : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Yoyo Experience");
			Tooltip.SetDefault("'Show your yoyo expertise!'\nDropped by enemies hit by yoyos\nCan also be used as good source of revenue!");
		}
        public override void SetDefaults()
        {
            item.width = 16;
            item.height = 16;
            item.value = 100 * 25;
            item.rare = 1;
        }
    }
}