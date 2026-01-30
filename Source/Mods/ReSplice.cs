using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Verse;

namespace Multiplayer.Compat.Mods
{
    [MpCompatFor("ReSplice.XOTR.Core")]
    public class ReSplice
    {
        private static Type GeneCentrifuge;
        private static Type XenogermDuplicator;
        private static Type ArchiteRefuelableType;
        private static Type DarkArchiteSpikeType;

        public ReSplice(ModContentPack mod)
        {
            LongEventHandler.ExecuteWhenFinished(LatePatch);
            GeneCentrifuge = AccessTools.TypeByName("ReSpliceCore.Building_GeneCentrifuge");
            XenogermDuplicator = AccessTools.TypeByName("ReSpliceCore.Building_XenogermDuplicator");
            ArchiteRefuelableType = AccessTools.TypeByName("ReSpliceCore.CompArchiteRefuelable");
            DarkArchiteSpikeType = AccessTools.TypeByName("ReSpliceCore.DarkArchiteSpike");
        }
        private static void LatePatch()
        {
            MpCompat.RegisterLambdaMethod(GeneCentrifuge, "GetGizmos", 0, 1, 2, 3);
            MpCompat.RegisterLambdaMethod(XenogermDuplicator, "GetGizmos", 0, 1, 2, 3, 4);
            MpCompat.RegisterLambdaMethod(ArchiteRefuelableType, "CompGetGizmosExtra", 0);
            MpCompat.RegisterLambdaMethod(DarkArchiteSpikeType, "GetFloatMenuOptions", 0);
            MpCompat.RegisterLambdaMethod(DarkArchiteSpikeType, "GetGizmos", 0, 1, 2, 3);
        }
    }
}
