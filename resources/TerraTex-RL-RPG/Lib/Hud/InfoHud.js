
const mapMarginLeft = API.getScreenResolution().Width / 64;
const mapMarginBottom = API.getScreenResolution().Height / 60;
const mapWidth = API.getScreenResolution().Width / 7.11;
const mapHeight = API.getScreenResolution().Height / 5.71;
const resX = mapMarginLeft + mapWidth + mapMarginLeft;
const resY = API.getScreenResolution().Height - mapHeight - mapMarginBottom;

let lastMoney = -1, lastMoneyString = "";

API.onUpdate.connect(function() {

    const date = new Date();
    const hours = date.getHours() < 10 ? " " + date.getHours() : date.getHours();
    const minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();

    API.drawText(hours + ":" + minutes, resX + 10, resY + 133, 0.5, 255, 255, 255, 200, 0, 1, false, true, 0);

    if (API.getEntitySyncedData(API.getLocalPlayer(), "Money") !== null) {
        let money = API.getEntitySyncedData(API.getLocalPlayer(), "Money");

        if (money !== lastMoney) {
            lastMoneyString = money.toFixed(2).replace(/\./g, ",").replace(/./g, function (c, i, a) {
                return i && c !== "," && ((a.length - i) % 3 === 0) ? '.' + c : c;
            });
            lastMoneyString += " €";
            lastMoney = money;
        }
    }

    API.drawText(lastMoneyString, resX + 20, resY + 165, 0.5, 50, 255, 50, 200, 0, 1, false, true, 0);
});