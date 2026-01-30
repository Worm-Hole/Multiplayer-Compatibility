using HarmonyLib;
using System;
using Verse;

namespace Multiplayer.Compat
{

    [MpCompatFor("RedMattis.GeneExtractor")]
    public class GeneExtractorTiers
    {
        private static Type GeneExtractorTier;

        public GeneExtractorTiers(ModContentPack mod)
        {
            LongEventHandler.ExecuteWhenFinished(LatePatch);
            GeneExtractorTier = AccessTools.TypeByName("GeneExtractorTiers.Building_GeneExtractorTier");
        }
        private static void LatePatch()
        {
            MpCompat.RegisterLambdaMethod(GeneExtractorTier, "GetFloatMenuOptions", 0, 1);
            MpCompat.RegisterLambdaMethod(GeneExtractorTier, "GetGizmos", 0, 1, 2, 3, 4, 5, 6);
        }
    }
}
