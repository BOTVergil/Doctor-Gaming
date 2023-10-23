using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;

namespace DocterMain.Content.Items.Armor.Vanity
{
	// See also: ExampleCostume
	[AutoloadEquip(EquipType.Head)]
	public class TexastheOmertosahat : ModItem
	{
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Arknights W's Hat");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
			bool flag = Main.netMode == 2;
			if (!flag)
			{
				int equipSlotHead = EquipLoader.GetEquipSlot(base.Mod, this.Name, EquipType.Head);
				ArmorIDs.Head.Sets.DrawHead[equipSlotHead] = false;
			}
		}


		public override void SetDefaults() {
			Item.width = 22;
			Item.height = 24;
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
