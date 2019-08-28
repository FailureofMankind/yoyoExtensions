using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yoyoExtensions.Projectiles
{
	public class FossilGloves_effect : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.aiStyle = 2;
			projectile.friendly = true;
			projectile.penetrate = 2;
			projectile.melee = true;
		}
		public override void AI()
		{
            projectile.rotation++;

            Dust dust = Dust.NewDustDirect(projectile.Center, projectile.width, projectile.height, 32);
            dust.noGravity = true;
            dust.scale = 0.7f;
            dust.velocity = projectile.velocity;
		}
        public override void Kill(int timeLeft)
        {
			Main.PlaySound(SoundID.Item10, projectile.position);
        }
	}
}
