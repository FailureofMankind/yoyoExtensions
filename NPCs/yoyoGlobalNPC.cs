using System.IO;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.World.Generation;
using Microsoft.Xna.Framework;
using Terraria.GameContent.Generation;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;
using Microsoft.Xna.Framework.Graphics;

namespace yoyoExtensions.NPCs
{
    public class yoyoGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }
        
        public bool ElementalGlovesRed;
        public override void ResetEffects(NPC npc)
        {
            ElementalGlovesRed = false;
		}
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if(ElementalGlovesRed)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                npc.lifeRegen -= 10;
                if (damage < 2)
                {
                    damage = 2;
                }
            }
        }            
        public override void DrawEffects(NPC npc, ref Color drawColor)
		{
            if(ElementalGlovesRed)
            {
                if (Main.rand.Next(13) == 0)
                {
                    int dust = Dust.NewDust(npc.position - new Vector2(2f, 2f), npc.width + 4, npc.height + 4, 130, npc.velocity.X * 0.4f, npc.velocity.Y * 0.4f, 100, default(Color), 3.5f);
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity *= 1.8f;
                    Main.dust[dust].velocity.Y -= 0.5f;
                    if (Main.rand.Next(4) == 0)
                    {
                        Main.dust[dust].noGravity = false;
                        Main.dust[dust].scale *= 0.5f;
                    }
                }
                Lighting.AddLight(npc.position, 0.8f, 0.1f, 0.2f);
            }
        }
        public override void PostAI(NPC npc)
        {
        }     

        public override void NPCLoot(NPC npc)
        {
            if(npc.type == NPCID.Mimic && Main.rand.Next(6) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StickyFingas"), 1);
            }
            if(npc.lifeMax > 50 && Main.rand.Next(100) == 0 && Main.player[Player.FindClosest(npc.position, npc.width, npc.height)].ZoneDungeon)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("ChippedChipper"), 1);
            }
            if(npc.lifeMax > 50 && Main.rand.Next(1000) == 0)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("Yoyo"), 1);
            }            
        }
    }
}