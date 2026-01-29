using HarmonyLib;
using Multiplayer.API;
using Verse;
using System;
using System.Collections.Generic;
using System.Linq;
using RimWorld;

namespace Multiplayer.Compat
{
    [MpCompatFor("Aelanna.GetOutOfMyChair")]
    public class GetOutOfMyChair
    {
        private static Type commandChairOwnerType;
        private static AccessTools.FieldRef<object, Building> chairOwnerChairField;
        private static FastInvokeHandler getCommandForChairOwner;

        private static Type commandChairUseModeType;
        private static AccessTools.FieldRef<object, Building> chairUseModeChairField;
        private static FastInvokeHandler getCommandForChairUseMode;

        private static Type commandTableUseModeType;

        private static Type chairUtilityType;

        private static FastInvokeHandler clearChairOwnerCache;
        private static FastInvokeHandler clearChairUseModeCache;
        private static FastInvokeHandler clearTableUseModeCache;

        public GetOutOfMyChair(ModContentPack mod)
        {
            chairUtilityType = AccessTools.TypeByName("GetOutOfMyChair.ChairUtility");

            commandChairOwnerType = AccessTools.TypeByName("GetOutOfMyChair.Command_ChairOwner");
            chairOwnerChairField = AccessTools.FieldRefAccess<Building>(commandChairOwnerType, "chair");

            commandChairUseModeType = AccessTools.TypeByName("GetOutOfMyChair.Command_ChairUseMode");
            chairUseModeChairField = AccessTools.FieldRefAccess<Building>(commandChairUseModeType, "chair");

            commandTableUseModeType = AccessTools.TypeByName("GetOutOfMyChair.Command_TableUseMode");

            clearChairOwnerCache = MethodInvoker.GetHandler(
                AccessTools.Method(commandChairOwnerType, "ClearCachedCommand"));
            clearChairUseModeCache = MethodInvoker.GetHandler(
                AccessTools.Method(commandChairUseModeType, "ClearCachedCommand"));
            clearTableUseModeCache = MethodInvoker.GetHandler(
                AccessTools.Method(commandTableUseModeType, "ClearCachedCommand"));

            MP.RegisterSyncMethod(chairUtilityType, "SetUseMode")
                .SetPostInvoke((obj, args) => ClearChairUseModeCache());

            getCommandForChairOwner = MethodInvoker.GetHandler(
                AccessTools.Method(commandChairOwnerType, "GetCommandFor"));

            MP.RegisterSyncWorker<object>(SyncCommandChairOwner, commandChairOwnerType);
            MP.RegisterSyncMethod(commandChairOwnerType, "SetOwner")
                .SetPostInvoke((obj, args) => ClearChairOwnerCache());

            getCommandForChairUseMode = MethodInvoker.GetHandler(
                AccessTools.Method(commandChairUseModeType, "GetCommandFor"));

            MP.RegisterSyncWorker<object>(SyncCommandChairUseMode, commandChairUseModeType);
        }

        private static void ClearChairOwnerCache()
        {
            clearChairOwnerCache(null, null);
        }

        private static void ClearChairUseModeCache()
        {
            clearChairUseModeCache(null, null);
            clearTableUseModeCache(null, null);
        }

        private static void SyncCommandChairOwner(SyncWorker sync, ref object obj)
        {
            if (sync.isWriting)
            {
                sync.Write(chairOwnerChairField(obj));
            }
            else
            {
                var chair = sync.Read<Building>();
                obj = getCommandForChairOwner(null, chair);
            }
        }

        private static void SyncCommandChairUseMode(SyncWorker sync, ref object obj)
        {
            if (sync.isWriting)
            {
                sync.Write(chairUseModeChairField(obj));
            }
            else
            {
                var chair = sync.Read<Building>();
                obj = getCommandForChairUseMode(null, chair);
            }
        }
    }
}