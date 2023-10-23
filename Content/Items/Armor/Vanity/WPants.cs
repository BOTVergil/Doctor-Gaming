using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace DocterMain.Content.Items.Armor.Vanity
{
	// See also: ExampleCostume
	[AutoloadEquip(EquipType.Legs)]
	public class WPants : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Arknights W's Pants");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			bool flag = Main.netMode == 2;
			if (!flag)
			{
				int equipSlotLeg = EquipLoader.GetEquipSlot(base.Mod, this.Name, EquipType.Legs);
				ArmorIDs.Legs.Sets.HidesBottomSkin[equipSlotLeg] = true;
			}
		}

		public override void SetDefaults() {
			Item.width = 22;
			Item.height = 18;
			Item.rare = ItemRarityID.Blue;
			Item.vanity = true;
		}

		//public override void AddRecipes()
		//{
		//    Recipe recipe = CreateRecipe();
		//    recipe.AddRecipeGroup(RecipeGroupID.Wood, 2);
		//    recipe.AddTile(TileID.WorkBenches);
		//    recipe.Register();
		//}
	}
}
