using System.Collections.Generic;
using RimWorld;
using Verse;

namespace Emergency_Resources
{
    public class VerbEmergencyRadio : Verb
    {
        private readonly List<Thing> _emergencyResourcesList = new List<Thing>()
        {
            ExtendedThingMaker.MakeThingWithAmount(ThingDefOf.Steel, 300),
            ExtendedThingMaker.MakeThingWithAmount(ThingDefOf.WoodLog, 500),
            ExtendedThingMaker.MakeThingWithAmount(ThingDefOf.MealSurvivalPack, 50),
            ExtendedThingMaker.MakeThingWithAmount(ThingDefOf.ComponentIndustrial, 50),
            ExtendedThingMaker.MakeThingWithAmount(ThingDefOf.MedicineIndustrial, 50),
        };

        protected override bool TryCastShot()
        {
            if (currentTarget.HasThing && currentTarget.Thing.Map != caster.Map)
                return false;
            Map target = caster.Map;
            IntVec3 intVec3 = currentTarget.Cell;
            DropPodUtility.DropThingsNear(intVec3, target, _emergencyResourcesList, 110, false, true);
            if (EquipmentSource != null && !EquipmentSource.Destroyed)
                EquipmentSource.Destroy();
            return true;
        }
    }
}
