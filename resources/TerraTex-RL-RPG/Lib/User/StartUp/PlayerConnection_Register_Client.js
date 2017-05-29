let browser;

API.onServerEventTrigger.connect(function (eventName) {
    if (eventName === "startRegister") {
        const resolution = API.getScreenResolution();
        
        browser = API.createCefBrowser(Math.round(resolution.Width) * 0.7, Math.round(resolution.Height * 0.7), true);
        API.waitUntilCefBrowserInit(browser);

        const x = (resolution.Width * 0.3) / 2;
        const y = (resolution.Height * 0.3) / 2;

        API.setCefBrowserPosition(browser, x, y);
        //API.setCefBrowserHeadless(browser, true);
        API.loadPageCefBrowser(browser, 'UI/Register_Login_Profile/Register.html', false);
        API.showCursor(true);

        API.sendNotification("Browser should be loaded on: " + x + " " + y);
    }
});