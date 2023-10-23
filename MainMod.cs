using Terraria;
using Terraria.Audio;
using Terraria.IO;
using Terraria.ID;
using Terraria.GameContent;
using Terraria.ModLoader;
using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using terraguardians;
using ArknightsMod;

namespace DocterMain
{
	public class MainMod : Mod
	{
		public static Groups.DigimonGroup digimonGroup; //Custom companion group, so you can distinguish companions of a certain type by their group.
		public static Player GetLocalPlayer { get { return terraguardians.MainMod.GetLocalPlayer; } }
		public override void Load()
		{
			digimonGroup = new Groups.DigimonGroup(); //Creating the companion group, so I can assign it to companions.
		}

		public override void Unload()
		{
			digimonGroup = null;
		}

		public override void PostSetupContent()
		{
			terraguardians.MainMod.AddCompanionDB(new DigimonContainer(), this); //Adding the companion container I made to the companion database. That will control the companions list of the mod. Check DigimonContainer.cs.

		}
	}
}