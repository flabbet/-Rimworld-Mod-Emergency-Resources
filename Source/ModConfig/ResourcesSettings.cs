using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RimWorld;
using Verse;

namespace Emergency_Resources.ModConfig
{
    public class ResourcesSettings : ModSettings
    {
        public List<Tuple<ThingDef, int>> ResourcesSet;


        public override void ExposeData()
        {
            Scribe_Collections.Look(ref ResourcesSet, "ResourcesSet", LookMode.Reference);
            base.ExposeData();
        }
    }
}
