using Terraria.ModLoader.Config;
using System.ComponentModel;


namespace VacuumBind
{
    [Label("$Mods.VacuumBind.Configs.ClientClassName")]
	public class Client : ModConfig
	{
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Label("$Mods.VacuumBind.Configs.TimerInterval")]
        [Tooltip("$Mods.VacuumBind.Configs.TimerIntervalDesc")]
        [Range(1, 600)]
        [DefaultValue(10)]
            public int timerCap;
        [Label("$Mods.VacuumBind.Configs.HDCThreshold")]
        [Tooltip("$Mods.VacuumBind.Configs.HDCThresholdDesc")]
        [Range(0, 399)]
        [DefaultValue(256)]
            public int dropCountThreshold;
        [Label("$Mods.VacuumBind.Configs.DisplayDrops")]
        [Tooltip("$Mods.VacuumBind.Configs.DisplayDropsDesc")]
        [Range(0, 404)]
        [DefaultValue(256)]
            public int debugDrops;

        public override void OnChanged()
        {
            Vac.timerCap = timerCap * 60;
            Vac.dropCountThreshold = dropCountThreshold;
            Vac.debugDrops = debugDrops;
        }
    }

    [Label("$Mods.VacuumBind.Configs.ServerClassName")]
    [BackgroundColor(30, 15, 15, 150)]
    public class Server : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [BackgroundColor(100, 50, 50, 255)]
        [Label("$Mods.VacuumBind.Configs.DisableAuto")]
        [Tooltip("$Mods.VacuumBind.Configs.DisableAutoDesc")]
        [DefaultValue(true)]
        public bool canClientsAuto;

        public override void OnChanged()
        {
            Vac.canClientsAuto = canClientsAuto;
        }
    }
}