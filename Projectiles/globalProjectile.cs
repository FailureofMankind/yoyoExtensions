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
            yoyoPlayer modPlayer = Main.player[projectile.owner].GetModPlayer<yoyoPlayer>(mod);
            if(projectile.aiStyle == 99)
            {
                if(modPlayer.FossilGloves)
                {
                    if(count % 40 == 0)
                    {
                        Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y, 0, 1, mod.ProjectileType("FossilGloves_effect"), projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f);
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