let browser;

API.onServerEventTrigger.connect(function (eventName, args) {
    if (eventName === "startRegister") {
        const resolution = API.getScreenResolution();

        browser = API.createCefBrowser(Math.round(resolution.Width) * 0.7, Math.round(resolution.Height * 0.7), true);
        API.waitUntilCefBrowserInit(browser);

        const x = (resolution.Width * 0.3) / 2;
        const y = (resolution.Height * 0.3) / 2;

        API.setCefBrowserPosition(browser, x, y);
        API.setCefBrowserHeadless(browser, false);
        API.loadPageCefBrowser(browser, 'UI/Register_Login_Profile/Register.html', false);
        API.showCursor(true);
        API.waitUntilCefBrowserLoaded(browser);
        
        // browser.call("setPlayerNickname", args[0]);
        browser.eval("setPlayerNickname(\"" + args[0] + "\");");
    }
});