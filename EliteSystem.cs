using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

public class EliteSystem : ModSystem
{
	internal static bool _TexastheOmertosaEliteA;

	internal static bool _TexastheOmertosaEliteB;

	internal static bool _WEliteA;

	internal static bool _WEliteB;

	internal static bool _NengEliteA;

	internal static bool _NengEliteB;

	internal static bool _JessicatheLiberatedEliteA;

	internal static bool _JessicatheLiberatedEliteB;
	


public static bool JessicatheLiberatedEliteA
	{
		get
		{
			return _JessicatheLiberatedEliteA;
		}
		set
		{
			if (!value)
			{
				_JessicatheLiberatedEliteA = false;
			}
			else
			{
				NPC.SetEventFlagCleared(ref _JessicatheLiberatedEliteA, -1);
			}
		}
	}

	public static bool JessicatheLiberatedEliteB
	{
		get
		{
			return _JessicatheLiberatedEliteB;
		}
		set
		{
			if (!value)
			{
				_JessicatheLiberatedEliteB = false;
			}
			else
			{
				NPC.SetEventFlagCleared(ref _JessicatheLiberatedEliteB, -1);
			}
		}
	}

	public static bool TexastheOmertosaEliteA
	{
		get
		{
			return _TexastheOmertosaEliteA;
		}
		set
		{
			if (!value)
			{
				_TexastheOmertosaEliteA = false;
			}
			else
			{
				NPC.SetEventFlagCleared(ref _TexastheOmertosaEliteA, -1);
			}
		}
	}

	public static bool TexastheOmertosaEliteB
	{
		get
		{
			return _TexastheOmertosaEliteB;
		}
		set
		{
			if (!value)
			{
				_TexastheOmertosaEliteB = false;
			}
			else
			{
				NPC.SetEventFlagCleared(ref _TexastheOmertosaEliteB, -1);
			}
		}
	}
	public static bool WEliteA
	{
		get
		{
			return _WEliteA;
		}
		set
		{
			if (!value)
			{
				_WEliteA = false;
			}
			else
			{
				NPC.SetEventFlagCleared(ref _WEliteA, -1);
			}
		}
	}

	public static bool WEliteB
	{
		get
		{
			return _WEliteB;
		}
		set
		{
			if (!value)
			{
				_WEliteB = false;
			}
			else
			{
				NPC.SetEventFlagCleared(ref _WEliteB, -1);
			}
		}
	}
	public static bool NengEliteA
	{
		get
		{
			return _NengEliteA;
		}
		set
		{
			if (!value)
			{
				_NengEliteA = false;
			}
			else
			{
				NPC.SetEventFlagCleared(ref _NengEliteA, -1);
			}
		}
	}

	public static bool NengEliteB
	{
		get
		{
			return _NengEliteB;
		}
		set
		{
			if (!value)
			{
				_NengEliteB = false;
			}
			else
			{
				NPC.SetEventFlagCleared(ref _NengEliteB, -1);
			}
		}
	}

	internal static void ResetAllFlags()
	{
		TexastheOmertosaEliteA = false;
		TexastheOmertosaEliteB = false;
		WEliteA = false;
		WEliteB = false;
		NengEliteA = false;
		NengEliteB = false;
		JessicatheLiberatedEliteA = false;
		JessicatheLiberatedEliteB = false;
	}

	public override void OnWorldLoad()
	{
		ResetAllFlags();
	}

	public override void OnWorldUnload()
	{
		ResetAllFlags();
	}

	public override void SaveWorldData(TagCompound tag)
	{
		List<string> downed = new List<string>();
		if (TexastheOmertosaEliteA)
		{
			downed.Add("TexastheOmertosaEliteA");
		}
		if (TexastheOmertosaEliteB)
		{
			downed.Add("TexastheOmertosaEliteB");
		}
		if (WEliteA)
		{
			downed.Add("WEliteA");
		}
		if (WEliteB)
		{
			downed.Add("WEliteB");
		}
		if (JessicatheLiberatedEliteA)
		{
			downed.Add("JessicatheLiberatedEliteA");
		}
		if (JessicatheLiberatedEliteB)
		{
			downed.Add("JessicatheLiberatedEliteB");
		}
		if (NengEliteA)
		{
			downed.Add("NengEliteA");
		}
		if (NengEliteB)
		{
			downed.Add("NengEliteB");
		}
		tag["downedFlags"] = downed;
	}

	public override void LoadWorldData(TagCompound tag)
	{
		IList<string> list = tag.GetList<string>("downedFlags");
		TexastheOmertosaEliteA = list.Contains("TexastheOmertosaEliteA");
		TexastheOmertosaEliteB = list.Contains("TexastheOmertosaEliteB");
		WEliteA = list.Contains("WEliteA");
		WEliteB = list.Contains("WEliteB");
		JessicatheLiberatedEliteA = list.Contains("JessicatheLiberatedEliteA");
		JessicatheLiberatedEliteB = list.Contains("JessicatheLiberatedEliteB");
		NengEliteA = list.Contains("NengEliteA");
		NengEliteB = list.Contains("NengEliteB");
	}
}
