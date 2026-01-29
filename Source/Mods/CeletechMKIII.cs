using HarmonyLib;
using System;
using Verse;
using Multiplayer.API;

namespace Multiplayer.Compat
{
    [MpCompatFor("TOT.CeleTech.MKIII")]
    public class CeletechMKIII
    {
        private static Type ARSARadar;
        private static Type CMCTurretGun;
        private static Type CMCTurretGunMainBattery;
        private static Type FRShield;
        private static Type WeaponModificationBench;
        private static Type AccessoryContainerType;
        private static Type DroneMovementType;
        private static Type FullProjectileInterceptorType;
        private static Type FunnelHaulerType;
        private static Type FunnelProgrammerType;
        private static Type AbilityEffect_SelfSkipType;
        private static Type AbilityEffect_AoEFistType;
        private static Type AbilityEffect_AntiInvType;
        private static Type TradeConsole;
        private static Type SecondaryVerbType;
        private static Type SecondaryVerbReworkType;
        private static Type UsableByTurretType;
        private static Type ApparelHediffAdderType;
        private static Type CMCShieldType;
        private static Type FloatingGunReworkType;
        private static Type TraderShuttleType;
        private static Type UAVType;

        public CeletechMKIII(ModContentPack mod)
        {
            LongEventHandler.ExecuteWhenFinished(LatePatch);
            ARSARadar = AccessTools.TypeByName("TOT_DLL_test.Building_AESARadar");
            CMCTurretGun = AccessTools.TypeByName("TOT_DLL_test.Building_CMCTurretGun");
            CMCTurretGunMainBattery = AccessTools.TypeByName("TOT_DLL_test.Building_CMCTurretGun_MainBattery");
            FRShield = AccessTools.TypeByName("TOT_DLL_test.Building_FRShield");
            WeaponModificationBench = AccessTools.TypeByName("TOT_DLL_test.Building_WeaponModificationBench");
            AccessoryContainerType = AccessTools.TypeByName("TOT_DLL_test.CompAccessoryContainer");
            DroneMovementType = AccessTools.TypeByName("TOT_DLL_test.CompDroneMovement");
            FullProjectileInterceptorType = AccessTools.TypeByName("TOT_DLL_test.CompFullProjectileInterceptor");
            FunnelHaulerType = AccessTools.TypeByName("TOT_DLL_test.CompFunnelHauler");
            FunnelProgrammerType = AccessTools.TypeByName("TOT_DLL_test.CompFunnelProgrammer");
            TradeConsole = AccessTools.TypeByName("TOT_DLL_test.Building_TradeConsole");
            AbilityEffect_SelfSkipType = AccessTools.TypeByName("TOT_DLL_test.CompAbilityEffect_SelfSkip");
            AbilityEffect_AoEFistType = AccessTools.TypeByName("TOT_DLL_test.CompAbilityEffect_AoEFist");
            AbilityEffect_AntiInvType = AccessTools.TypeByName("TOT_DLL_test.CompAbilityEffect_AntiInv");
            SecondaryVerbType = AccessTools.TypeByName("TOT_DLL_test.CompSecondaryVerb");
            SecondaryVerbReworkType = AccessTools.TypeByName("TOT_DLL_test.CompSecondaryVerb_Rework");
            UsableByTurretType = AccessTools.TypeByName("TOT_DLL_test.CompUsableByTurret");
            ApparelHediffAdderType = AccessTools.TypeByName("TOT_DLL_test.Comp_ApparelHediffAdder");
            CMCShieldType = AccessTools.TypeByName("TOT_DLL_test.Comp_CMCShield");
            FloatingGunReworkType = AccessTools.TypeByName("TOT_DLL_test.Comp_FloatingGunRework");
            TraderShuttleType = AccessTools.TypeByName("TOT_DLL_test.Comp_TraderShuttle");
            UAVType = AccessTools.TypeByName("TOT_DLL_test.Comp_UAV");
        }
        private static void LatePatch()
        {
            MpCompat.RegisterLambdaMethod(ARSARadar, "GetGizmos", 0, 1, 2);
            MpCompat.RegisterLambdaMethod(CMCTurretGun, "GetGizmos", 0, 1, 2, 3);
            MpCompat.RegisterLambdaMethod(CMCTurretGunMainBattery, "GetGizmos", 0, 1);
            MpCompat.RegisterLambdaMethod(WeaponModificationBench, "GetGizmos", 0, 1, 2);
            MpCompat.RegisterLambdaMethod(TradeConsole, "GetGizmos", 0, 1, 2);

            MpCompat.RegisterLambdaMethod(WeaponModificationBench, "GetFloatMenuOptions", 0);
            MpCompat.RegisterLambdaMethod(AccessoryContainerType, "CompGetGizmosExtra", 0, 1);
            MpCompat.RegisterLambdaMethod(DroneMovementType, "CacheGizmos", 0, 1, 2, 3, 4, 5, 6, 7, 8);
            MpCompat.RegisterLambdaMethod(FullProjectileInterceptorType, "CompGetGizmosExtra", 0, 1);
            MpCompat.RegisterLambdaMethod(FunnelHaulerType, "CompGetGizmosExtra", 0);
            MpCompat.RegisterLambdaMethod(FunnelProgrammerType, "CompFloatMenuOptions", 0);
            MpCompat.RegisterLambdaMethod(AbilityEffect_SelfSkipType, "GetPreCastActions", 0);
            MpCompat.RegisterLambdaMethod(AbilityEffect_AoEFistType, "GetPreCastActions", 0);
            MpCompat.RegisterLambdaMethod(AbilityEffect_AntiInvType, "GetPreCastActions", 0);
            MpCompat.RegisterLambdaMethod(UsableByTurretType, "CompFloatMenuOptions", 0);
            MpCompat.RegisterLambdaMethod(ApparelHediffAdderType, "GetGizmo", 0);
            MpCompat.RegisterLambdaMethod(CMCShieldType, "CompDrawWornExtras", 0);
            MpCompat.RegisterLambdaMethod(FloatingGunReworkType, "GetGizmos", 0, 1, 2, 3, 4);
            MpCompat.RegisterLambdaMethod(TraderShuttleType, "CompFloatMenuOptions", 0);
            MpCompat.RegisterLambdaMethod(UAVType, "GetGizmos", 0);

            MP.RegisterSyncMethod(CMCShieldType, "Break");
            MP.RegisterSyncMethod(SecondaryVerbType, "SwitchVerb");
            MP.RegisterSyncMethod(SecondaryVerbReworkType, "SwitchVerb");
            MP.RegisterSyncMethod(TraderShuttleType, "SendAway");
        }
    }
}
