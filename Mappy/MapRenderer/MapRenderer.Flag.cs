﻿using System.Numerics;
using FFXIVClientStructs.FFXIV.Client.UI.Agent;
using Mappy.Classes;

namespace Mappy.MapRenderer;

public partial class MapRenderer {
    private unsafe void DrawFlag() {
        if (AgentMap.Instance()->IsFlagMarkerSet is not 0 && AgentMap.Instance()->FlagMapMarker.TerritoryId == AgentMap.Instance()->CurrentTerritoryId) {
            ref var flagMarker = ref AgentMap.Instance()->FlagMapMarker;
            
            DrawHelpers.DrawMapMarker(new MarkerInfo {
                Position = new Vector2(flagMarker.XFloat, flagMarker.YFloat) * Scale * DrawHelpers.GetMapScaleFactor() + DrawHelpers.GetCombinedOffsetVector() * Scale,
                IconId = flagMarker.MapMarker.IconId,
                Offset = DrawPosition,
                Scale = Scale,
                Clicked = () => AgentMap.Instance()->IsFlagMarkerSet = 0,
            });
        }
    }
}