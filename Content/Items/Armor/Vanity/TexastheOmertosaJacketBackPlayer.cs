using Terraria.ModLoader;

public class TexastheOmertosaJacketBackPlayer : ModPlayer
{
	public bool vanityEquipped;

	public override void ResetEffects()
	{
		vanityEquipped = false;
	}

	public override void FrameEffects()
	{
		if (vanityEquipped)
		{
			((ModPlayer)this).Player.back = EquipLoader.GetEquipSlot(((ModType)this).Mod, "TexastheOmertosaJacketBack", (EquipType)5);
		}
	}
}