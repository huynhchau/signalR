var bps = bps || {};

bps.bootstraper = function () {
    function init() {
        bootstrapBPSAngularApp();
    }

    function bootstrapBPSAngularApp() {
        preloadTemplates().then(function () {
            var el = jQuery("[data-app]");
            var module = el.data("app");

            angular.bootstrap(el[0], [module]);
        });
    }

    function preloadTemplates() {
        var q = jQuery.Deferred();

        if (!window.bpsTemplateCache.size() || _bpsEnvironment.debug) {
            jQuery.ajax({
                url: _bpsEnvironment.appUrl + "/api/template/gettemplates",
                dataType: 'json',
                crossDomain: true
            }).done(function (data) {
                console.log("templates", data);
                jQuery.each(data.Data, function (idx, t) {
                    bpsTemplateCache.setItem(t.Id.toLowerCase(), t.Template);
                });
                console.log("Templates loaded, cache size: ", window.bpsTemplateCache.size());

                q.resolve();
            });
        }
        else
            q.resolve();

        return q.promise();
    }

    return {
        init: init
    }
}();