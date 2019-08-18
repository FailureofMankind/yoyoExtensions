using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameContent;
using Terraria.GameContent.UI;
using Terraria.GameInput;
using Terraria.Graphics.Capture;
using Terraria.Graphics.Effects;
using Terraria.Localization;
using Terraria.Graphics.Shaders;
using yoyoExtensions.Items;
// using yoyoExtensions.NPCs;

namespace yoyoExtensions
{
    public class yoyoPlayer : ModPlayer
    {
        // variable space
        public bool HallowedGloves;
        public bool SuperYoyoBag;
        public bool TractionGloves;
        public bool StickyFingas;
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~v
        public override void ResetEffects()
        {
            HallowedGloves = false;
            SuperYoyoBag = false;
            TractionGloves = false;
            StickyFingas = false;
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
        }
        public override void OnHitNPCWithProj(Projectile projectile, NPC target, int damage, float knockback, bool crit)
		{
            if(projectile.aiStyle == 99)
            {
                if(StickyFingas)
                {
                    if(player.channel)
                    {
                        projectile.position.X = target.Center.X;
                        projectile.position.Y = target.Center.Y;
                    }
                }
                if(TractionGloves && projectile.type == 541)    //wooden yoyo id
                {
                    target.immune[projectile.owner] = 5;
                    if(player.channel)
                    {
                        projectile.velocity *= -1;
                    }
                }
                if(HallowedGloves)
                {
                    int projNum = player.ownedProjectileCounts[projectile.type];
                    if(projNum < 5)
                    {
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, Main.rand.Next(-3, 3), Main.rand.Next(-3, 3), projectile.type, projectile.damage, projectile.knockBack, Main.myPlayer, 0f, 0f); //Spawning a projectile
                    }
                }
                if(SuperYoyoBag)
                {
                    Vector2 velocityShoot = target.Center - player.Center;
                    float magnitude = Magnitude(velocityShoot);
                    if(magnitude > 0)
                    {
                        velocityShoot *= 25f / magnitude;
                    } 
                    else
                    {
                        velocityShoot = new Vector2(0f, 10f);
                    }            
                    int laser = Projectile.NewProjectile(target.Center.X, target.Center.Y, velocityShoot.X, velocityShoot.Y, 88, (int)(projectile.damage / 4), 5, player.whoAmI, 0f, 0f);
                    Main.projectile[laser].tileCollide = false;
                    Main.projectile[laser].timeLeft = 240;
                    Main.projectile[laser].magic = false;
                    Main.projectile[laser].melee = true;
                    Main.projectile[laser].penetrate = 1;
                }
            }

        }
        public override void PostHurt(bool pvp, bool quiet, double damage, int hitDirection, bool crit)
        {

        }
        public override void SetupStartInventory(IList<Item> startItem)
        {            
            Item item = new Item();
            item.SetDefaults(3278);
            item.stack = 1;
            startItem.Add(item);
        }
        /*public override void UpdateBadLifeRegen()
        {
            if(septic_curse == true)
            {
                player.defense -= 5;
                
                player.meleeDamage *= 0.50f;
                player.rangedDamage *= 0.50f;
                player.magicDamage *= 0.50f;
                player.summonDamage *= 0.50f;
                player.thrownDamage *= 0.50f;
            }
            

        }*/


        //chunks of useful stuff
        private float Magnitude(Vector2 mag)
        {
            return (float)Math.Sqrt(mag.X * mag.X + mag.Y * mag.Y);
        }
    }
}