using RimWorld;
using System.Collections.Generic;
using System.Reflection;
using Verse;
using Verse.AI.Group;
using System;
using RimWorld.Planet;

namespace TradingSpot
{
    public class TradingSpot : Building
    {
        private int count = 0;
        private readonly bool hasHospitality;

        public TradingSpot()
        {
            if (Current.Game.CurrentMap != null)
            {
                foreach (Building b in Current.Game.CurrentMap.listerBuildings.allBuildingsColonist)
                {
                    if (b.def.defName.Equals("TradingSpot"))
                    {
                        b.Destroy(DestroyMode.Vanish);
                        Messages.Message("TradingSpot.AlreadyOnMap".Translate(), MessageTypeDefOf.NegativeEvent);
                        break;
                    }
                }
            }

            foreach (ModMetaData d in ModsConfig.ActiveModsInLoadOrder)
            {
                this.hasHospitality = false;
                if (d.Name.EqualsIgnoreCase("hospitality"))
                {
                    this.hasHospitality = true;
                    break;
                }
            }
        }

        public override void Tick()
        {
            base.Tick();
            ++this.count;
            if (this.count % 60 == 1)
            {
                this.count = 0;
                List<Lord> lords = base.Map.lordManager.lords;
                IntVec3 position = base.Position;
                foreach (var lord in lords)
                {
                    if (lord.LordJob is LordJob_TradeWithColony || this.CheckVisitor(lord.LordJob))
                    {
                        FieldInfo chillSpotFI = lord.LordJob.GetType().GetField("chillSpot", BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                        chillSpotFI.SetValue(lord.LordJob, position);                        LordToil curLordToil = lord.CurLordToil;
                        LordToil_Travel lordToil_Travel = curLordToil as LordToil_Travel;
                        if (lordToil_Travel != null)
                        {
                            if (lordToil_Travel.FlagLoc != position)
                            {
                                lordToil_Travel.SetDestination(position);
                                lordToil_Travel.UpdateAllDuties();
                            }
                        }
                        else
                        {
                            LordToil_DefendPoint lordToil_DefendPoint = curLordToil as LordToil_DefendPoint;
                            if (lordToil_DefendPoint != null)
                            {
                                if (lordToil_DefendPoint.FlagLoc != position)
                                {
                                    lordToil_DefendPoint.SetDefendPoint(position);
                                    lordToil_DefendPoint.UpdateAllDuties();
                                }
                            }
                        }
                    }
                }            }
        }

        private bool CheckVisitor(LordJob lordJob)
        {
            if (hasHospitality)
                return false;
            
            var mod = LoadedModManager.GetMod<SettingsController>();
            if (mod == null || mod.settings == null || !mod.settings.VisitorsGoToTradeSpot)
                return false;
                
            if (lordJob is LordJob_VisitColony)
                return true;            return false;
        }
    }
    
    public class WorldComp : WorldComponent
    {
        public WorldComp(World world) : base(world) { }
        public override void FinalizeInit()
        {
            base.FinalizeInit();
            var mod = LoadedModManager.GetMod<SettingsController>();
            if (mod != null && mod.settings != null)
            {
                mod.settings.ApplyWorkSetting();
            }
        }
    }
}