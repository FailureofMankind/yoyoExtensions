using Terraria;
using Terraria.ModLoader;
using yoyoExtensions.NPCs;

namespace yoyoExtensions.Buffs
{
	public class elementalGloveRed : ModBuff
	{
		public override void SetDefaults() {
			DisplayName.SetDefault("Red");
			Main.debuff[Type] = true;
			Main.pvpBuff[Type] = true;
			Main.buffNoSave[Type] = true;
			longerExpertDebuff = true;
		}
		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<yoyoGlobalNPC>().ElementalGlovesRed = true;
		}
	}
}