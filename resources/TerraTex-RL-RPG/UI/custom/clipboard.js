function copyToClipboard(text) {
    if (document.queryCommandSupported && document.queryCommandSupported("copy")) {
        var textarea = document.createElement("textarea");
        textarea.textContent = text;
        textarea.style.position = "fixed";  // Prevent scrolling to bottom of page in MS Edge.
        document.body.appendChild(textarea);
        textarea.select();
        try {
            return document.execCommand("copy");  // Security exception may be thrown by some browsers.
        } catch (ex) {
            console.warn("Copy to clipboard failed.", ex);
            return false;
        } finally {
            document.body.removeChild(textarea);
        }
    }
}

$(document).ready(function () {
    $("html").on("click", "a.web", function () {
        const href = $(this).attr("href");
        copyToClipboard(href);
        resourceEval("API.sendNotification(\"" + href + " wurde in dein Zwischenspeicher gelegt. Du kannst es nun im Browser mit Einfügen oder Strg + v nutzen.\");");
    });
   
});