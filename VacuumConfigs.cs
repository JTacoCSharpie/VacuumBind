using Terraria.ModLoader.Config;
using System.ComponentModel;


namespace VacuumBind
{
	public class Client : ModConfig
	{
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Range(1, 600)]
        [DefaultValue(10)]
            public int timerCap;
        [Range(0, 399)]
        [DefaultValue(256)]
            public int dropCountThreshold;
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

    [BackgroundColor(30, 15, 15, 150)]
    public class Server : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ServerSide;

        [BackgroundColor(100, 50, 50, 255)]
        [DefaultValue(true)]
        public bool canClientsAuto;

        public override void OnChanged()
        {
            Vac.canClientsAuto = canClientsAuto;
        }
    }
}