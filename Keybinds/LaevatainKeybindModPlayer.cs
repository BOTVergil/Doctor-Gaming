using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using Terraria;
using Terraria.GameInput;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;


namespace DocterMain.Keybinds
{
   
    public class LaevatainKeybindModPlayer : ModPlayer
    {
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (Keybinds.LaevatainKeybind.LaevatainKey.JustPressed && Player.HeldItem.type == ModContent.ItemType<Content.Items.Weapons.Laevatain>())
            {
                if (Player.HasBuff(ModContent.BuffType<Content.Buffs.LaevatainBuff>()) == false)
                {
                    Player.AddBuff(ModContent.BuffType<Content.Buffs.LaevatainBuff>(),2);
                }
            }
        }
        public override void PostUpdateMiscEffects()
        {
            if (Player.HasBuff(ModContent.BuffType<Content.Buffs.LaevatainBuff>()) == true && Player.HeldItem.type == ModContent.ItemType<Content.Items.Weapons.Laevatain>())
            {
                Player.GetDamage(DamageClass.Generic) += 4f;
            }
        }
        public override void OnRespawn()
        {
            ModContent.GetInstance<Content.Buffs.LaevatainBuff>().die = 0.01f;
        }
    }
}

