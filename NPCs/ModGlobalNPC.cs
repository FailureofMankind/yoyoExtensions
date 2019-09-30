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

namespace yoyoExtensions.Items
{
    public class ModGlobalNPC : GlobalNPC
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }        
        public bool brokenArmorMod;
        public override void ResetEffects(NPC npc)
        {
            brokenArmorMod = false;
		}    
        public override void DrawEffects(NPC npc, ref Color drawColor)
		{
        }
        public override void PostAI(NPC npc)
        {
            if(brokenArmorMod)
            {
                
            }
        }     
        public override void NPCLoot(NPC npc)
        {
            if(npc.type == NPCID.Mimic && Main.rand.Next(6) == 1)
            {
                Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("StickyFingas"), 1);
            }
        }
    }
}