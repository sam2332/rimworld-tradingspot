﻿using HarmonyLib;
using RimWorld;
using System.Reflection;
using UnityEngine;
using Verse;

namespace TradingSpot
{
    [StaticConstructorOnStartup]
    class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.tradingspot.rimworld.mod");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            
            // Apply work setting on startup
            LongEventHandler.ExecuteWhenFinished(() =>
            {
                var mod = LoadedModManager.GetMod<SettingsController>();
                if (mod != null && mod.settings != null)
                {
                    mod.settings.ApplyWorkSetting();
                }
            });
        }
    }

    public class SettingsController : Mod
    {
        public Settings settings;

        public SettingsController(ModContentPack content) : base(content)
        {
            this.settings = GetSettings<Settings>();
        }

        public override string SettingsCategory()
        {
            return "TradingSpot";
        }        public override void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard l = new Listing_Standard();
            l.Begin(new Rect(inRect.x, inRect.y, 300, 100));
            l.CheckboxLabeled("TradingSpot.VisitorsGoToTradeSpot".Translate(), ref settings.VisitorsGoToTradeSpot);
            l.CheckboxLabeled("TradingSpot.RequiresWorkToPlace".Translate(), ref settings.RequiresWorkToPlace);
            l.End();
        }        public override void WriteSettings()
        {
            base.WriteSettings();
            settings.ApplyWorkSetting();
        }
    }

    public class Settings : ModSettings
    {
        public bool VisitorsGoToTradeSpot = true;
        public bool RequiresWorkToPlace = true;

        public override void ExposeData()
        {
            base.ExposeData();

            Scribe_Values.Look<bool>(ref VisitorsGoToTradeSpot, "TradingSpot.VisitorsGotoTradeSpot", true, false);
            Scribe_Values.Look<bool>(ref RequiresWorkToPlace, "TradingSpot.RequiresWorkToPlace", true, false);
        }

        public void ApplyWorkSetting()
        {
            if (DefOf.TradingSpot != null)
            {
                foreach (var s in DefOf.TradingSpot.statBases)
                {
                    if (s.stat == StatDefOf.WorkToBuild)
                    {
                        s.value = (RequiresWorkToPlace) ? 10 : 0;
                        break;
                    }
                }
            }
        }
    }

    [RimWorld.DefOf]
    public static class DefOf
    {
        public static ThingDef TradingSpot;
    }
}
