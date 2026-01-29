using System;
using HarmonyLib;
using Verse;

namespace Multiplayer.Compat
{
    [MpCompatFor("Mlie.ThisIsMine")]
    public class ThisIsMine
    {
        private static Type CompBelongType;

        public ThisIsMine(ModContentPack mod)
        {
            CompBelongType = AccessTools.TypeByName("ThisIsMine.CompCanBelongToRoomOwners");

            MpCompat.RegisterLambdaMethod(CompBelongType, "CompGetGizmosExtra", 0, 1, 2, 3);
        }
    }
}
