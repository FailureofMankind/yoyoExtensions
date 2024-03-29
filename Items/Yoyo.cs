cusing Terraria.ID;
using Terraria.ModLoader;

namespace yoyoExtensions.Items
{
	public class Yoyo : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("SwordYo");
			Tooltip.SetDefault("xd");
		}
		public override void SetDefaults()
		{
			item.damage = 2;
			item.melee = true;
			item.width = 40;
			item.height = 40;
			item.useTime = 20;
			item.useAnimation = 20;
			item.channel = true;
			item.noMelee = true;
			item.noUseGraphic = true;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = 10000;
			item.rare = 2;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = mod.ProjectileType($"YoyoProj");//string interpolation i tihnk
		}
	}
}
