using Terraria.ModLoader;
using terraguardians;
using Terraria;
using System.Collections.Generic;
using System.Linq;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.Audio;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;
using Terraria.ModLoader.IO;
using DocterMain.Companions;
using Microsoft.Xna.Framework.Graphics;

namespace DocterMain
{
	public class NpcMod : GlobalNPC
	{
        private const int PlaceACEScoutOnKingSlimeValue = -50;
        private static int TrappedACEScoutKingSlime = -1;

        public static void OnReloadWorld()
        {
            TrappedACEScoutKingSlime = -1;
        }
        public override void SetDefaults(NPC npc)
        {
            switch(npc.type)
            {
                case NPCID.KingSlime:
                    if (!terraguardians.WorldMod.HasMetCompanion(5, this.Mod.Name) && !terraguardians.MainMod.HasCompanionInWorld(5, this.Mod.Name) && Main.rand.NextFloat() < 0.4f)
                    {
                        TrappedACEScoutKingSlime = PlaceACEScoutOnKingSlimeValue;
                    }
                    break;
            }
        }
    
        public override bool PreAI(NPC npc)
        {
            if (npc.type == Terraria.ID.NPCID.BlueSlime && npc.ai[1] == 0)
            {
                int NearestPlayer = npc.FindClosestPlayer();
                //Makes so if Gaomon haven't been met, and neither there's its companion npc in the world, the Digivice can spawn in a slime.
                if (NearestPlayer > -1 && !terraguardians.WorldMod.HasMetCompanion(DigimonContainer.Docter, Mod.Name) && !terraguardians.WorldMod.HasCompanionNPCSpawned(DigimonContainer.Docter, Mod.Name) && Main.rand.Next(10) == 0)
                {
                    npc.netUpdate = true;
                }
            }
            if (npc.type == NPCID.KingSlime && TrappedACEScoutKingSlime == PlaceACEScoutOnKingSlimeValue)
            {
                TrappedACEScoutKingSlime = npc.whoAmI;
            }
            else if (TrappedACEScoutKingSlime == npc.whoAmI && npc.type != NPCID.KingSlime)
            {
                TrappedACEScoutKingSlime = -1;
            }
            return base.PreAI(npc);
        }
        public override void OnKill(NPC npc)
        {
            if (npc.whoAmI == TrappedACEScoutKingSlime)
            {
                TrappedACEScoutKingSlime = -1;
                if (!terraguardians.MainMod.HasCompanionInWorld(5, this.Mod.Name) && !terraguardians.MainMod.HasCompanionInWorld(6, this.Mod.Name))
                {
                    Companion ACE = WorldMod.SpawnCompanionNPC(5, this.Mod.Name);
                    Companion Scout = WorldMod.SpawnCompanionNPC(6, this.Mod.Name);
                    if (ACE != null)
                        ACE.AddBuff(BuffID.Slimed, 10 * 60);
                    if (Scout != null)
                        Scout.AddBuff(BuffID.Slimed, 10 * 60);
                }
                if (!terraguardians.MainMod.HasCompanionInWorld(5, this.Mod.Name) && terraguardians.MainMod.HasCompanionInWorld(6, this.Mod.Name))
                {
                    Companion ACE = WorldMod.SpawnCompanionNPC(5, this.Mod.Name);
                    if (ACE != null)
                        ACE.AddBuff(BuffID.Slimed, 10 * 60);
                }
                if (terraguardians.MainMod.HasCompanionInWorld(5, this.Mod.Name) && !terraguardians.MainMod.HasCompanionInWorld(6, this.Mod.Name))
                {
                    Companion Scout = WorldMod.SpawnCompanionNPC(6, this.Mod.Name);
                    if (Scout != null)
                        Scout.AddBuff(BuffID.Slimed, 10 * 60);
                }
            }
            if (npc.type == Terraria.ID.NPCID.TownCat && !terraguardians.WorldMod.HasMetCompanion(8, this.Mod.Name) && !terraguardians.WorldMod.HasCompanionNPCSpawned(8, this.Mod.Name))
            {
                terraguardians.WorldMod.SpawnCompanionNPC(8, this.Mod.Name);
                Main.NewText("Jessica was knocked back to the prototype.", 255, 255, 0);
            }
        }
        public bool CanTalkAboutCompanion(uint ID, string ModID = "")
        {
            return WorldMod.HasMetCompanion(ID, ModID) && WorldMod.HasCompanionNPCSpawned(ID, ModID);
        }
        public override void GetChat(NPC npc, ref string chat)
        {
            if (Main.rand.NextDouble() >= 0.25)
                return;
            List<string> PossibleMessages = new List<string>();
            switch (npc.type)
            {
                case Terraria.ID.NPCID.Guide:
                    if (CanTalkAboutCompanion(3u, "DocterMain"))
                    {
                        PossibleMessages.Add("I feel that " + WorldMod.GetCompanionNpcName(3u, "DocterMain") + " is very strange, her eyes seem to want to kill me.");
                    }
                    break;
            }
            if (PossibleMessages.Count > 0)
            {
                chat = PossibleMessages[Main.rand.Next(PossibleMessages.Count)];
            }
        }
    }
}