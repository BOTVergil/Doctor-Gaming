using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace DocterMain.Content.Items.Armor.Vanity
{
	// See also: ExampleCostume
	[AutoloadEquip(EquipType.Body)]
	public class WJacket : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Arknights W's Jacket");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			bool flag = Main.netMode == 2;
			if (!flag)
			{
				int equipSlotBody = EquipLoader.GetEquipSlot(base.Mod, this.Name, EquipType.Body);
				ArmorIDs.Body.Sets.HidesTopSkin[equipSlotBody] = true;
				ArmorIDs.Body.Sets.HidesArms[equipSlotBody] = true;
			}
		}

		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 22;
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
