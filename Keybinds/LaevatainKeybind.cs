using DocterMain.Content.Items.Weapons;
using Terraria.ModLoader;

namespace DocterMain.Keybinds
{
    public class LaevatainKeybind : ModSystem
    {
        public static ModKeybind LaevatainKey { get; private set; }

        public override void Load()
        {
            LaevatainKey = KeybindLoader.RegisterKeybind(Mod, "黄昏", "X");
        }

        public override void Unload()
        {
            LaevatainKey = null;
        }
    }
}
