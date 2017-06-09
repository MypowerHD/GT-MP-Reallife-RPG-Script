
const mapMarginLeft = API.getScreenResolution().Width / 64;
const mapMarginBottom = API.getScreenResolution().Height / 60;
const mapWidth = API.getScreenResolution().Width / 7.11;
const mapHeight = API.getScreenResolution().Height / 5.71;
const resX = mapMarginLeft + mapWidth + mapMarginLeft;
const resY = API.getScreenResolution().Height - mapHeight - mapMarginBottom;

let browser, lastMoney = -1, lastMoneyString = "";

API.onResourceStart.connect(function() {
    /*browser = API.createCefBrowser(1, 1, true);
    API.setCefBrowserHeadless(browser, true);
    API.waitUntilCefBrowserInit(browser);
    API.loadPageCefBrowser(browser, 'UI/Workaround.html', false);
    API.waitUntilCefBrowserLoaded(browser);*/
});


API.onUpdate.connect(function() {

    const date = new Date();
    const hours = date.getHours() < 10 ? " " + date.getHours() : date.getHours();
    const minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();

    API.drawText(hours + ":" + minutes, resX + 10, resY + 133, 0.5, 255, 255, 255, 200, 0, 1, false, true, 0);

    if (API.getEntitySyncedData(API.getLocalPlayer(), "Money") !== null) {
        let money = Math.round(API.getEntitySyncedData(API.getLocalPlayer(), "Money") * 100) / 100;

        if (money !== lastMoney) {
            /*browser.eval(
                'money = ' + money + '; ' +
                'moneyString = money.toLocaleString("de-DE",{style: "currency",currency: "EUR"});' +
                'resourceCall("setMoneyString", moneyString);'
            );*/
            lastMoney = money;
        }
    }

    API.drawText(lastMoneyString, resX + 20, resY + 165, 0.5, 50, 255, 50, 200, 0, 1, false, true, 0);
});

function setMoneyString(moneyString) {
    lastMoneyString = moneyString;
}