using Terraria;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Terraria.ID;
using DocterMain.Content.Items.Armor.Vanity;

namespace DocterMain.Content.Items.Armor.Vanity
{
	// See also: ExampleCostume
	public class TexastheOmertosaJacketBack : ModItem
	{
		public string LocalizationCategory => "Items.Accessories";
		public override void Load()
		{
		if (Main.netMode != 2)
		{
				EquipLoader.AddEquipTexture(((ModType)this).Mod, "DocterMain/Content/Items/Armor/Vanity/TexastheOmertosaJacketBack_Back", (EquipType)5, (ModItem)(object)this, (string)null, (EquipTexture)null);
		}
		}
		public override void SetStaticDefaults() {
			// DisplayName.SetDefault("Arknights Neng's Jacket");
			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 1;
		}

		public override void SetDefaults() {
			Item.width = 30;
			Item.height = 22;
			Item.rare = ItemRarityID.Blue;
			Item.accessory = true;
			Item.vanity = true;
		}

		public override void UpdateVanity(Player player)
		{
		player.GetModPlayer<TexastheOmertosaJacketBackPlayer>().vanityEquipped = true;
		}

	public override void UpdateAccessory(Player player, bool hideVisual)
	{
		if (!hideVisual)
		{
			player.GetModPlayer<TexastheOmertosaJacketBackPlayer>().vanityEquipped = true;
		}
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
