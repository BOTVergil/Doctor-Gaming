using Microsoft.Xna.Framework;
using Terraria.GameContent.Creative;
using System;
using Terraria;
using Terraria.ID;
using terraguardians;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Audio;
using Terraria.DataStructures;

namespace DocterMain.Content.Items.Weapons
{
    public class WGrenadelauncher : ModItem
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
        Item.useTime = 38;
        Item.useAnimation = 38;

        Item.useStyle = ItemUseStyleID.Shoot;

        Item.autoReuse = true;

        Item.UseSound = SoundID.Item61;

        Item.DamageType = DamageClass.Ranged;
        Item.damage = 8;
        Item.knockBack = 3f;
        Item.noMelee = true;

        Item.shoot = ProjectileID.GrenadeIII;
        Item.shootSpeed = 45f;

        Item.useAmmo = AmmoID.Rocket;

        }

        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-4f, 2f);
        }
    }
}