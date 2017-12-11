var bps = bps || {};

bps.ns = function (namespace) {
    var parts = namespace.split('.'),
               parent = bps,
               i,
               max;

    if (parts[0] === "bps") {
        parts = parts.slice(1);
    }
    for (i = 0, max = parts.length; i < max; i++) {
        if (typeof parent[parts[i]] === "undefined") {
            parent[parts[i]] = {};
        }
        parent = parent[parts[i]];
    }
    return parent;
};

bps.typewatch = (function () {
    var timer = 0;
    return function (callback, ms) {
        clearTimeout(timer);
        timer = setTimeout(callback, ms);
    };
})();

(function () {
    window.bpsTemplateCache = new Cache(-1, false, new Cache.SessionStorageCacheStorage("bpsTemplates"));
})();

bps.getTemplate = function (key) {
    var tmpl = window.bpsTemplateCache.getItem(key.toLowerCase());
    if (!tmpl) {
        console.log("bps Template Cache - Missing template - " + key.toLowerCase());
        return "Template missing";
    }

    return tmpl;
};