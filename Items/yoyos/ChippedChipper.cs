using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yoyoExtensions.Items.yoyos
{
	public class ChippedChipper : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Chipped Chipper");
			Tooltip.SetDefault("'Chippin' away enthusiastically...'\nYoyo breaks into several homing shards on impact with enemies");

			// These are all related to gamepad controls and don't seem to affect anything else
			ItemID.Sets.Yoyo[item.type] = true;
			ItemID.Sets.GamepadExtraRange[item.type] = 15;
			ItemID.Sets.GamepadSmartQuickReach[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.useStyle = 5;
			item.width = 32;
			item.height = 30;
			item.useAnimation = 35;
			item.useTime = 35;
			item.shootSpeed = 20f;
			item.knockBack = 3f;
			item.damage = 20;
			item.rare = 5;

			item.melee = true;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;

			item.UseSound = SoundID.Item1;
			item.value = Item.sellPrice(gold: 3);
			item.shoot = mod.ProjectileType("ChippedChipperProj");
		}

	}
}
