using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using System;
using Terraria;
using terraguardians;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.DataStructures;

namespace DocterMain.Content.Items.Weapons
{
    internal class ExusiaiVector : ModItem
    {
        public override void SetStaticDefaults()
        {
            CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
        }

        public override bool CanUseItem(Player player)
        {
            if(player is Companion)
            {
                return true;
            }
            return false;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 28;
            Item.useTime = 7;
            Item.useAnimation = 7;

            Item.useStyle = ItemUseStyleID.Shoot;

            Item.autoReuse = true;

            Item.UseSound = SoundID.Item41;

            Item.DamageType = DamageClass.Ranged;
            Item.damage = 7;
            Item.knockBack = 3f;
            Item.noMelee = true;

            Item.shoot = ProjectileID.Bullet;
            Item.shootSpeed = 5f;

            Item.useAmmo = AmmoID.Bullet;

        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4f, 2f);
        }
    }
}
