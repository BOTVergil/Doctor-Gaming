using DocterMain.Content.Projectiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using terraguardians;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;


namespace DocterMain.Content.Items.Weapons
{
    public class Laevatain:ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 46;
            Item.height = 96;
            Item.maxStack = 1;
            Item.value = Item.sellPrice(1);
            Item.rare = ItemRarityID.Red;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.damage = 200;
            //击退
            Item.knockBack = 5f;
            //暴击
            Item.crit = 30;
            Item.mana = 4;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.DamageType = DamageClass.Magic;
            Item.noMelee = false;
            Item.shoot = ProjectileID.TerraBeam;
            //Item.UseSound = SoundID.Item78;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0, 0f);
        }

        public override bool CanUseItem(Player player)
    	{
            return player is Companion;
    	}

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            foreach (var npc in Main.npc)
            {
                if (npc.active && !npc.friendly && npc.lifeMax >= 2 && Main.MouseWorld.Distance(npc.Center) <= 100)
                {
                    Projectile.NewProjectile(source, new Vector2(npc.Center.X, npc.Center.Y), new Vector2(0f, 0f), ModContent.ProjectileType<LaevatainProj>(), damage, knockback, player.whoAmI);
                }
            }
            return false;
        }

    }
}
