using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace yoyoExtensions.Projectiles
{
    public class LunarGloves_effect : ModProjectile  
    { 
        public override void SetStaticDefaults()
        {
		    DisplayName.SetDefault("a yeeter");
        }
        int[] arrayOfDusts = new int[] {6, 229, 65, 172};  //solar, vortex, nebula, stardust
        int dustId;
        public override void SetDefaults()
        {
			projectile.CloneDefaults(316);
			aiType = 316;
			projectile.width = 12;
			projectile.height = 12;
			projectile.friendly = true;
			projectile.magic = false;
			projectile.melee = true;
			projectile.penetrate = 1;
			projectile.timeLeft = 180;
            projectile.alpha = 255;	
			projectile.extraUpdates = 5;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            dustId = arrayOfDusts[Main.rand.Next(arrayOfDusts.Length)];
        }

        public override void AI()
        {
            for (int i = 0; i < 4; i++)
            {
                Dust dust = Dust.NewDustDirect(projectile.position, 0, 0, dustId);
                dust.noGravity = true;
                dust.scale = 1.6f;
                dust.velocity *= 0f;
            }
        }
		public override void OnHitNPC(NPC target, int damage, float knockBack, bool crit)
		{
            int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 0, 612, projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
            Main.projectile[a].penetrate = 1;

            target.AddBuff(BuffID.Daybreak, 60*100);
		}
    }
}