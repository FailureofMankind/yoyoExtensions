using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameContent;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Localization;

namespace yoyoExtensions.Projectiles
{
    public class globalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        int count;
        public override void AI(Projectile projectile)
        {
            count++;
            int projdmg;

            yoyoPlayer modPlayer = Main.player[projectile.owner].GetModPlayer<yoyoPlayer>(mod);
            if(projectile.aiStyle == 99 && !projectile.counterweight)
            {
                if(modPlayer.FossilGloves)
                {
                    if(count % 40 == 0)
                    {
                        projdmg = (int)(projectile.damage - (projectile.damage*0.4));
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 1, mod.ProjectileType("FossilGloves_effect"), projdmg, projectile.knockBack, Main.myPlayer, 0f, 0f);
                    }
                }
                if(modPlayer.LunarGloves)
                {
                    if(count % 20 == 0)
                    {
                        projdmg = (int)(projectile.damage - (projectile.damage*0.5));
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next(-5, 5), Main.rand.Next(-5, 5), mod.ProjectileType("LunarGloves_effect"), projdmg, projectile.knockBack, Main.myPlayer, 0f, 0f);
                    }
                }
                if(modPlayer.MagmaGloves)
                {
                    if(count % 40 == 0)
                    {
                        projdmg = (int)(projectile.damage - (projectile.damage*0.4));
                        int magmaglovesProj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next(-5, 5), Main.rand.Next(-5, 5), 400, projdmg, projectile.knockBack, Main.myPlayer, 0f, 0f);
                        Main.projectile[magmaglovesProj].ranged = false;
                        Main.projectile[magmaglovesProj].melee = true;
                    }
                }
                if(modPlayer.SporeGloves)
                {
                    if(count % 15 == 0)
                    {
                        projdmg = (int)(projectile.damage - (projectile.damage*0.7));
                        int magmaglovesProj = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, Main.rand.Next(-3, 3), Main.rand.Next(-3, 3), 228, projdmg, 1, Main.myPlayer, 0f, 0f);
                    }
                }
            }

            if(count >= 9999)
            {
                count = 0;
            }
        }
    }
}