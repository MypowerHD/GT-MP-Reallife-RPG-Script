declare namespace GrandTheftMultiplayer.Client.Networking {

	interface IStreamedItem {
		RemoteHandle: number;
		LocalOnly: boolean;
		StreamedIn: boolean;
		readonly Position: GrandTheftMultiplayer.Shared.Math.Vector3;
		EntityType: number;
		Dimension: number;
		AttachedTo: GrandTheftMultiplayer.Shared.Attachment;
		Attachables: System.Collections.Generic.List<number>;
		PositionMovement: GrandTheftMultiplayer.Shared.Movement;
		RotationMovement: GrandTheftMultiplayer.Shared.Movement;
	}

	class SyncPed {
		readonly MainVehicle: GTA.Vehicle;
		readonly VehicleHash: number;
		readonly Snapshot: any;
		readonly Speed: number;
		readonly AverageLatency: number;
		readonly LastUpdateReceived: number;
		readonly TicksSinceLastUpdate: number;
		readonly DataLatency: number;
		readonly VehicleMods: System.Collections.Generic.Dictionary<number, number>;
		readonly VehicleVelocity: GTA.Math.Vector3;
		readonly PedVelocity: GTA.Math.Vector3;
		readonly Position: GTA.Math.Vector3;
		readonly VehicleRotation: GTA.Math.Vector3;
		readonly Rotation: GTA.Math.Vector3;
		readonly IsRagdoll: boolean;
		readonly DEBUG_STEP: number;
		readonly IsReloading: boolean;
		LocalHandle: number;
		readonly IsInVehicle: boolean;
	}

}
