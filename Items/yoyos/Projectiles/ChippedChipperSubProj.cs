using System;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace yoyoExtensions.Items.yoyos.Projectiles
{
	public class ChippedChipperSubProj : ModProjectile
	{
		public override void SetDefaults()
		{
			projectile.width = 8;
			projectile.height = 8;
			projectile.aiStyle = 0;
            aiType = ProjectileID.Bullet;
			projectile.friendly = true;
			projectile.penetrate = 4;
			projectile.melee = true;
            projectile.timeLeft = 180;
		}
        float speed = 7f;
        int count = 0;
		public override void AI()
		{
            count++;
			if (projectile.localAI[0] == 0f)
			{
				AdjustMagnitude(ref projectile.velocity);
				projectile.localAI[0] = 1f;
			}
			Vector2 move = Vector2.Zero;
			float distance = 400f;
			bool target = false;
			for (int k = 0; k < 200; k++)
			{
				if (Main.npc[k].active && Main.npc[k].CanBeChasedBy(this))
				{
					Vector2 newMove = Main.npc[k].Center - projectile.Center;
					float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
					if (distanceTo < distance && count > 60)
					{
						move = newMove;
						distance = distanceTo;
						target = true;
					}
				}
			}
			if (target)
			{
				AdjustMagnitude(ref move);
				projectile.velocity = (2 * projectile.velocity + move);
				AdjustMagnitude(ref projectile.velocity);
			}

            projectile.rotation++;

            Dust dust = Dust.NewDustDirect(projectile.position, projectile.width, projectile.height, 90);
            dust.noGravity = true;
            dust.scale = 0.7f;
            dust.velocity = projectile.velocity * -0.3f;
		}
		private void AdjustMagnitude(ref Vector2 vector)
		{
			float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
			if (magnitude > speed)
			{
				vector *= speed / magnitude;
			}
		}    
        public override bool OnTileCollide(Vector2 oldVelocity)
		{
			if (projectile.velocity.X != oldVelocity.X)
			{
				projectile.velocity.X = -oldVelocity.X;
			}
			if (projectile.velocity.Y != oldVelocity.Y)
			{
				projectile.velocity.Y = -oldVelocity.Y;
			}
			
			return false;
		}
	}
}
