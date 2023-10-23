using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace DocterMain.Content.Buffs
{
    public class LaevatainBuff : ModBuff
    {
        public int count;
        public float die = 0.01f;

        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true;
            Main.debuff[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            Main.pvpBuff[Type] = false;
            Main.vanityPet[Type] = false;
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
            BuffID.Sets.LongerExpertDebuff[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            count++;
            player.buffTime[buffIndex] += 1;
            if (count >= 60) {
                count -= 60;
                if (die <= 0.1f) { 
                die += 0.01f;
                }
            }
            int maxHP = player.statLifeMax2;
            player.lifeRegenCount -= (int)(maxHP * die * 120 / 60);
        }
    }
}
