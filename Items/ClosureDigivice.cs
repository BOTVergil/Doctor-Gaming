using Terraria.ModLoader;
using Terraria;
using terraguardians;

namespace DocterMain.Items
{
    public class ClosureDigivice : ModItem
    {
        public override void SetStaticDefaults()
        {
            // Tooltip.SetDefault("Seems to invoke something.");
        }

        private bool UseItem(Player player)
        {
            return player.whoAmI == Main.myPlayer && !PlayerMod.PlayerHasCompanion(player, 7, this.Mod.Name)  //Player doesn't have Docter in their companion list
            && 
            !terraguardians.WorldMod.HasCompanionNPCSpawned(7, this.Mod.Name) //Docter is not a companion npc in the world.
             && 
            !terraguardians.WorldMod.HasMetCompanion(7, this.Mod.Name); //Docter has never been met in this world.
        }

        public override bool CanUseItem(Player player)
        {
            if (UseItem(player))
            {
                //This script makes so the item spawns Docter on the player position.
                Companion tg = 
                terraguardians.WorldMod.SpawnCompanionNPC(player.Bottom, DigimonContainer.Closure, Mod.Name); //Spawns Docter as a companion npc, on the position of the player (Companion spawn orientation is based on the bottom position, so aim for the feet)
                // int npcPos = NPC.NewNPC((int)player.Center.X, (int)player.position.Y, ModContent.NPCType<CompanionNPCs.DocterNPC>());
                for (int d = 0; d < 20; d++)
                {
                    Dust.NewDust(tg.Center, tg.width, tg.height, Terraria.ID.DustID.Electric);
                }
                Main.NewText("After using It, the Digivice broke, and a creature came out.(Please equip he with clothing manually)");
                Item.SetDefaults(0);
                return true;
            }
            Main.NewText("There is already a Closure.");
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
