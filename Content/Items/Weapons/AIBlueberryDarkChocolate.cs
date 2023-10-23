using System;
using DocterMain.Content.Projectiles;
using Terraria;
using Terraria.Audio;
using terraguardians;
using Terraria.ID;
using Terraria.ModLoader;

namespace DocterMain.Content.Items.Weapons
{
	public class AIBlueberryDarkChocolate : ModItem
	{



        public override void SetDefaults()
		{
			Item.damage = 170;
            Item.DamageType = DamageClass.Melee;
            Item.width = 66;
			Item.height = 70;
			Item.useTime = 28;
			Item.useAnimation = 28;
			Item.channel = true;
			Item.noUseGraphic = true;
			Item.noMelee = true;
			Item.useStyle = 5;
			Item.knockBack = 6;
			Item.value = Item.buyPrice(0, 22, 50, 0);
			Item.rare = 9;
			Item.UseSound = AIBlueberryDarkChocolateSound;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<AIBlueberryDarkChocolateProjectile>();
			//Item.shoot = Mod.ProjectileType("BlueberryDarkChocolateProjectile");
			Item.shootSpeed = 2f;
		}

		public override bool CanUseItem(Player player)
    	{
            return player is Companion;
    	}

		SoundStyle AIBlueberryDarkChocolateSound = new SoundStyle("DocterMain/Sounds/AIBlueberryDarkChocolateSound") with
		{
			Volume = 0.5f,
			PitchVariance = 0.3f,
			MaxInstances = 0,
			//SoundLimitBehavior = SoundLimitBehavior.ReplaceOldest
		};

    }
}

//using Terraria;
//using Terraria.ID;
//using Terraria.ModLoader;

//namespace ArknightsWeapons.Items
//{
//    public class BlueberryDarkChocolate : ModItem
//    {
       
//        public override void SetDefaults()
//        {
//            Item.width = 20;
//            Item.height = 20;
//            Item.maxStack = 999;
//            Item.value = 100;
//            Item.rare = ItemRarityID.Blue;
//            // Set other Item.X values here
//        }

//        public override void AddRecipes()
//        {
//            // Recipes here. See Basic Recipe Guide
//        }
//    }
//}