using Terraria.ModLoader;

namespace VacuumBind
{
	public class VacuumBind : Mod {}

    public enum StateEnum
    {
        Manual = 0,
        TimedAutomatic,
        HighDropCount,
    }

    internal class Vac
    {
        public static int timerCap = 600;
        public static int dropCountThreshold = 256;
        public static int debugDrops = 256;
        public static ModKeybind VacKey;
        public static ModKeybind PassiveVacKey;
        public static bool canClientsAuto = false;
        public static void Unload()
        {
            VacKey = null;
            PassiveVacKey = null;
        }
    }

    public class VacKeybinds : ModSystem
    {
        public override void Load()
        {
            Vac.VacKey = KeybindLoader.RegisterKeybind(Mod, "Vacuum Items", "V");
            Vac.PassiveVacKey = KeybindLoader.RegisterKeybind(Mod, "Switch Vacuum Mode", "K");
        }
        public override void Unload() => Vac.Unload();
    }
}