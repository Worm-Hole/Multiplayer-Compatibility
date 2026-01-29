using HarmonyLib;
using System;
using Verse;

namespace Multiplayer.Compat
{
    [MpCompatFor("Vanya.Polarisbloc.CoreLab.tmp")]
    public class Polarisbloc
    {
        private static Type Thermostat;
        private static Type IdeoCodeType;
        private static Type MomeryResterType;
        private static Type TraitreleaserType;
        private static Type ConvertCombatChipType;
        private static Type ReleaseTraitType;
        private static Type PolarisShieldBelt_IIType;

        public Polarisbloc(ModContentPack mod)
        {
            LongEventHandler.ExecuteWhenFinished(LatePatch);
            Thermostat = AccessTools.TypeByName("Polarisbloc.Building_Thermostat");
            IdeoCodeType = AccessTools.TypeByName("Polarisbloc.CompIdeoCode");
            MomeryResterType = AccessTools.TypeByName("Polarisbloc.CompMomeryRester");
            TraitreleaserType = AccessTools.TypeByName("Polarisbloc.CompTraitreleaser");
            ConvertCombatChipType = AccessTools.TypeByName("Polarisbloc.CompUseEffect_ConvertCombatChip");
            ReleaseTraitType = AccessTools.TypeByName("Polarisbloc.CompUseEffect_ReleaseTrait");
            PolarisShieldBelt_IIType = AccessTools.TypeByName("Polarisbloc.PolarisShieldBelt_II");
        }
        private static void LatePatch()
        {
            MpCompat.RegisterLambdaMethod(Thermostat, "GetGizmos", 0, 1, 2);
            MpCompat.RegisterLambdaMethod(IdeoCodeType, "CompGetGizmosExtra", 0);
            MpCompat.RegisterLambdaMethod(IdeoCodeType, "CompFloatMenuOptions", 0, 1, 2);
            MpCompat.RegisterLambdaMethod(MomeryResterType, "CompGetGizmosExtra", 0, 1, 2, 3, 4);
            MpCompat.RegisterLambdaMethod(TraitreleaserType, "CompGetGizmosExtra", 0, 1);
            MpCompat.RegisterLambdaMethod(ConvertCombatChipType, "GetDiaOptions", 0);
            MpCompat.RegisterLambdaMethod(ReleaseTraitType, "GenRemoveTraitMenuOptions", 0);
            MpCompat.RegisterLambdaMethod(PolarisShieldBelt_IIType, "GetWornGizmos", 0, 1);
        }
    }
}
