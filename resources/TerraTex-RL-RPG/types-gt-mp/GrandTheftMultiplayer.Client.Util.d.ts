declare namespace GrandTheftMultiplayer.Client.Util {

	enum HandleType {
		GameHandle = 0,
		LocalHandle = 1,
		NetHandle = 2
	}

	class LocalHandle {
		readonly Raw: number;
		readonly Value: number;
		readonly IsNull: boolean;
		constructor(handle: number);
		constructor(handle: number, localId: GrandTheftMultiplayer.Client.Util.HandleType);
		Properties<T>(): any;
		Equals(obj: any): boolean;
		GetHashCode(): number;
		ToString(): string;
	}

}
