using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using RimWorld;
using Verse;
using UnityEngine;

namespace Emergency_Resources.ModConfig
{
    public class EmergencyResourcesMod : Mod
    {
        private ResourcesSettings _settings;

        public EmergencyResourcesMod(ModContentPack content) : base(content)
        {
            _settings = GetSettings<ResourcesSettings>();
            _settings.ResourcesSet = new List<Tuple<ThingDef, int>>
            {
                new Tuple<ThingDef, int>(ThingDefOf.Steel, 300),
                new Tuple<ThingDef, int>(ThingDefOf.WoodLog, 500),
                new Tuple<ThingDef, int>(ThingDefOf.MealSurvivalPack, 50),
                new Tuple<ThingDef, int>(ThingDefOf.ComponentIndustrial, 50),
                new Tuple<ThingDef, int>(ThingDefOf.MedicineIndustrial, 50)
            };
        }

        public override void DoSettingsWindowContents(Rect rect)
        {
            Listing_Standard list = new Listing_Standard();
            list.Begin(rect);
            Text.Font = GameFont.Medium;
            list.Label("Emergency Resources Settings");
            Text.Font = GameFont.Small;
            LoadCurrentSet(ref list);
            list.End();
            base.DoSettingsWindowContents(rect);
        }

        private void LoadCurrentSet(ref Listing_Standard section)
        {
            Log.Message(_settings.ResourcesSet[0].Item1.defName);
            foreach (var set in _settings.ResourcesSet)
            {
                section.Label(set.Item1.label);
            }
        }


        private void PopulateDefs(ref Listing_Standard listing)
        {
            var thingDefs = DefDatabase<ThingDef>.AllDefs;
            foreach (var thing in thingDefs)
            {
                listing.ButtonText(thing.defName);
            }
        }

        public override string SettingsCategory()
        {
            return "Emergency Resources";
        }
    }
}
