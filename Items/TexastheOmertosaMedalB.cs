using Terraria.ModLoader;
using Terraria;
using terraguardians;

namespace DocterMain.Items
{
    public class TexastheOmertosaMedalB : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Seems to invoke something.");
        }

        private bool UseItem(Player player)
        {
            return player.whoAmI == Main.myPlayer && PlayerMod.PlayerHasCompanion(player, 3, this.Mod.Name)  //Player doesn't have Docter in their companion list
            && 
            terraguardians.WorldMod.HasCompanionNPCSpawned(3, this.Mod.Name) //Docter is not a companion npc in the world.
             && 
            terraguardians.WorldMod.HasMetCompanion(3, this.Mod.Name) //Docter has never been met in this world.
             && 
            EliteSystem.TexastheOmertosaEliteA;
        }

        public override bool CanUseItem(Player player)
        {
            if (EliteSystem.TexastheOmertosaEliteA && !EliteSystem.TexastheOmertosaEliteB)
            {
                Main.NewText("The elite level of Texas the Omertosa has been increased to 2.");
                Item.SetDefaults(0);
                EliteSystem.TexastheOmertosaEliteB = true;
                return true;
            }
            if (EliteSystem.TexastheOmertosaEliteA && EliteSystem.TexastheOmertosaEliteB)
            {
                Main.NewText("Texas the Omertosa Elite level has reached 2.");
                return false;
            }
            if (!EliteSystem.TexastheOmertosaEliteA)
            {
                Main.NewText("Please first elevate the Elite level of Texas the Omertosa to 1.");
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
