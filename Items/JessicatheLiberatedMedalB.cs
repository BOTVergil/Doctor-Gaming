using Terraria.ModLoader;
using Terraria;
using terraguardians;

namespace DocterMain.Items
{
    public class JessicatheLiberatedMedalB : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Seems to invoke something.");
        }

        private bool UseItem(Player player)
        {
            return player.whoAmI == Main.myPlayer && PlayerMod.PlayerHasCompanion(player, 8, this.Mod.Name)  //Player doesn't have Docter in their companion list
            && 
            terraguardians.WorldMod.HasCompanionNPCSpawned(8, this.Mod.Name) //Docter is not a companion npc in the world.
             && 
            terraguardians.WorldMod.HasMetCompanion(8, this.Mod.Name) //Docter has never been met in this world.
             && 
            EliteSystem.JessicatheLiberatedEliteA;
        }

        public override bool CanUseItem(Player player)
        {
            if (EliteSystem.JessicatheLiberatedEliteA && !EliteSystem.JessicatheLiberatedEliteB)
            {
                Main.NewText("The elite level of Jessica the Liberated has been increased to 2.");
                Item.SetDefaults(0);
                EliteSystem.JessicatheLiberatedEliteB = true;
                return true;
            }
            if (EliteSystem.JessicatheLiberatedEliteA && EliteSystem.JessicatheLiberatedEliteB)
            {
                Main.NewText("Jessica the Liberated Elite level has reached 2.");
                return false;
            }
            if (!EliteSystem.JessicatheLiberatedEliteA)
            {
                Main.NewText("Please first elevate the Elite level of Jessica the Liberated to 1.");
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
