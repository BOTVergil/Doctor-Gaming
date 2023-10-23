using System.Collections.Generic;
using DocterMain.Items;
using Terraria;
using Terraria.ModLoader;

public class givebag : ModPlayer
{
	public override IEnumerable<Item> AddStartingItems(bool mediumCoreDeath)
	{
		return (IEnumerable<Item>)(object)new Item[4]
		{
			new Item(ModContent.ItemType<BlueDigivice>(), 1, 0),
			new Item(ModContent.ItemType<ExusiaiDigivice>(), 1, 0),
			new Item(ModContent.ItemType<TexastheOmertosaDigivice>(), 1, 0),
			new Item(ModContent.ItemType<WDigivice>(), 1, 0)
		};
	}
}
