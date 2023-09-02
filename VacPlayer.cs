using static VacuumBind.Localization;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ModLoader.IO;

namespace VacuumBind
{
    public class VacuumPlayer : ModPlayer
    {
        int timer = 0;
        int vacState = (int)StateEnum.Manual;

        public override void PreUpdate()
        {
            if (Vac.canClientsAuto && (vacState == (int)StateEnum.TimedAutomatic || vacState == (int)StateEnum.HighDropCount))
            {
                timer++;
                if (timer >= Vac.timerCap)
                {
                    timer = 0;
                    if (vacState == (int)StateEnum.TimedAutomatic)
                    {
                        Suck(Main.LocalPlayer.whoAmI);
                    }
                    else
                    {
                        int count = 0;
                        for (int c = 0; c < Main.maxItems; c++)
                        {
                            if (!Main.item[c].IsAir)
                            {
                                count++;
                            }
                        }
                        if (count > Vac.dropCountThreshold)
                        {
                            Suck(Main.LocalPlayer.whoAmI);
                        }
                        if (count > Vac.debugDrops)
                        {
                            Main.NewText(GetTrans("UI.ItemsCollected", count));
                        }
                    }
                }
            }
        }

        private static void Suck(int whoAmI)
        {
            bool sync = (Main.netMode != NetmodeID.SinglePlayer);
            Vector2 pos = new((int)Main.player[whoAmI].position.X, (int)Main.player[whoAmI].position.Y);
            for (int i = 0; i < Main.maxItems; i++)
            {
                if (Main.item[i].active)
                {
                    Main.item[i].position = pos;
                    if (sync)
                    {
                        NetMessage.SendData(MessageID.SyncItem, -1, -1, null, i, Main.item[i].netID, 0f, 0f, 0);
                    }
                }
            }
        }

        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if (Vac.VacKey.JustReleased)
            {
                Suck(Main.LocalPlayer.whoAmI);
            }

            if (Vac.PassiveVacKey.JustPressed)
            {
                if (vacState == (int)StateEnum.Manual)
                { vacState = (int)StateEnum.TimedAutomatic; }
                else if (vacState == (int)StateEnum.TimedAutomatic)
                { vacState = (int)StateEnum.HighDropCount; }
                else
                { vacState = (int)StateEnum.Manual; }
                Main.NewText(GetTrans("UI." + Enum.GetName(typeof(StateEnum), vacState)));
            }
        }
        public override void SaveData(TagCompound tag)
        {
            if (vacState > 0)
            {
                tag["VacuumBindEnumState"] = vacState;
            }
        }
        public override void LoadData(TagCompound tag) => vacState = tag.GetInt("VacuumBindEnumState");
    }
}
