/// <reference path="index.d.ts" />

declare const API: GrandTheftMultiplayer.Client.Javascript.ScriptContext;
declare const host: Microsoft.ClearScript.HostFunctions;
import Keys = System.Windows.Forms.Keys;
import Point = System.Drawing.Point;
import PointF = System.Drawing.PointF;
import Size = System.Drawing.Size;
import LocalHandle = GrandTheftMultiplayer.Client.Util.LocalHandle;
import menuControl = NativeUI.UIMenu.MenuControls;
import Vector3 = GrandTheftMultiplayer.Shared.Math.Vector3;

declare var resource: any;

declare interface IConnectedEvent {
    disconnect(): void;
}

declare interface IEvent<THandler> {
    connect(handler: THandler): IConnectedEvent;
}

declare module Enums {
    export const enum Controls {}
}