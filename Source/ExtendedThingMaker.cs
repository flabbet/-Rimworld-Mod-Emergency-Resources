using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;

namespace Emergency_Resources
{
    public static class ExtendedThingMaker
    {
        public static Thing MakeThingWithAmount(ThingDef def, int stackCount)
        {
            Thing thing = ThingMaker.MakeThing(def);
            thing.stackCount = stackCount;
            return thing;
        }
    }
}
