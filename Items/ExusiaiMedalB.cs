using Terraria.ModLoader;
using Terraria;
using terraguardians;

namespace DocterMain.Items
{
    public class ExusiaiMedalB : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Seems to invoke something.");
        }

        private bool UseItem(Player player)
        {
            return player.whoAmI == Main.myPlayer && PlayerMod.PlayerHasCompanion(player, 2, this.Mod.Name)  //Player doesn't have Docter in their companion list
            && 
            terraguardians.WorldMod.HasCompanionNPCSpawned(2, this.Mod.Name) //Docter is not a companion npc in the world.
             && 
            terraguardians.WorldMod.HasMetCompanion(2, this.Mod.Name) //Docter has never been met in this world.
             && 
            EliteSystem.NengEliteA;
        }

        public override bool CanUseItem(Player player)
        {
            if (EliteSystem.NengEliteA && !EliteSystem.NengEliteB)
            {
                Main.NewText("The elite level of Exusiai has been increased to 2.");
                Item.SetDefaults(0);
                EliteSystem.NengEliteB = true;
                return true;
            }
            if (EliteSystem.NengEliteA && EliteSystem.NengEliteB)
            {
                Main.NewText("Exusiai Elite level has reached 2.");
                return false;
            }
            if (!EliteSystem.NengEliteA)
            {
                Main.NewText("Please first elevate the Elite level of Exusiai to 1.");
                return false;
            }
            return false;
        }

        public override void SetDefaults()
        {
            Item.UseSound = Terraria.ID.SoundID.Item4;
            Item.useStyle = 4;
            Item.useTurn = false;
            Item.useAnimation = 5;
            Item.useTime = 5;
            Item.maxStack = 1;
            Item.consumable = true;
            Item.value = Terraria.Item.buyPrice(0, 1);
            Item.width = 22;
            Item.height = 22;
            Item.rare = 2;
            Item.value = 1;
        }
    }
}
