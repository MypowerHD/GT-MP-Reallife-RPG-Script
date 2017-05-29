let browser;
function setFingerPrint(result, components) {
    API.triggerServerEvent("onClientResourceStarted", result, components);
    API.destroyCefBrowser(browser);
}

API.onResourceStart.connect(function () {
    //API.triggerServerEvent("onClientResourceStarted");

    browser = API.createCefBrowser(1,1, true);
    API.waitUntilCefBrowserInit(browser);
    API.setCefBrowserHeadless(browser, true);
    API.loadPageCefBrowser(browser, 'UI/Register_Login_Profile/GetFingerprint.html', false);
});

