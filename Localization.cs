using Terraria.Localization;

namespace VacuumBind
{
    public class Localization
    {
        /// <summary> Shorthand for Language.GetTextValue("Mods.VacuumBind." + partialPath), includes overloads for 1-3 additional system.objects </summary>
        public static string GetTrans(string partialPath)
        {
            return Language.GetTextValue("Mods.VacuumBind." + partialPath);
        }
        public static string GetTrans(string partialPath, object args0)
        {
            return Language.GetTextValue("Mods.VacuumBind." + partialPath, args0);
        }
        public static string GetTrans(string partialPath, object args0, object args1)
        {
            return Language.GetTextValue("Mods.VacuumBind." + partialPath, args0, args1);
        }
        public static string GetTrans(string partialPath, object args0, object args1, object args2)
        {
            return Language.GetTextValue("Mods.VacuumBind." + partialPath, args0, args1, args2);
        }
    }
}
