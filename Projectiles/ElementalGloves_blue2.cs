using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yoyoExtensions.Projectiles
{
	public class ElementalGloves_blue2 : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 2;
			projectile.friendly = true;
			projectile.penetrate = -1;
            projectile.timeLeft = 240;
			projectile.melee = true;
		}
		public override void AI()
		{
            projectile.rotation++;

            Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 132);
            dust.noGravity = true;
            dust.scale = 0.7f;
            dust.velocity = projectile.velocity * -0.5f;
		}
        public override void Kill(int timeLeft)
        {
			Main.PlaySound(SoundID.Item10, projectile.position);
        }
	}
}
