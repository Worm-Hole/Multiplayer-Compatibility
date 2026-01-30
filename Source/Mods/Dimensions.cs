using HarmonyLib;
using System;
using Verse;

namespace Multiplayer.Compat
{
    [MpCompatFor("KB.PocketDimension")]
    public class Dimensions
    {
        private static Type PocketDimensionBox;

        public Dimensions(ModContentPack mod)
        {
            LongEventHandler.ExecuteWhenFinished(LatePatch);
            PocketDimensionBox = AccessTools.TypeByName("KB_PocketDimension.Building_PocketDimensionBox");
        }
        private static void LatePatch()
        {
            MpCompat.RegisterLambdaMethod(PocketDimensionBox, "GetGizmos", 0, 1, 2, 3);
        }
    }
}
