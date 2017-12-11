angular.module("serviceModule", []);
angular.module("directivesModule", []);
angular.module("coreModule", []);
angular.module("controllerModule", ['serviceModule', 'directivesModule', 'ui.tinymce', 'ngSanitize', 'ui.select', 'blockUI', 'angularFileUpload', 'dialogs']);
angular.module('rootModule', ['serviceModule', 'controllerModule', 'directivesModule', 'coreModule', 'ui.router', 'ui.bootstrap', 'ui.bootstrap.showErrors', 'angularFileUpload']);
angular.module('rootModule')
    .run(['localizationService', '$rootScope', '$state', '$stateParams', '$templateCache', '$q', '$location', '$http', '$locale',
        function (localizationService, $rootScope, $state, $stateParams, $templateCache, $q, $location, $http, $locale) {
            $rootScope.$rootScope = $rootScope;
            $rootScope.$state = $state;
            $rootScope.$stateParams = $stateParams;

            var deferred = $q.defer();
            $rootScope.resourcesLoaded = deferred.promise;

            localizationService.getResource().then(function (data) {
                if (!$rootScope.appContext) {
                    $rootScope.appContext = {};
                }

                $rootScope.appContext.resources = data;
                $rootScope.loadEntityDone = true;
                deferred.resolve();
                console.log("$rootScope.appContext rootModule", $rootScope.appContext);
            });

            var filePath = bps.constants.angulari18 + "en-us.js";

            $http.get(filePath).then(function (resp) {
                $locale.DATETIME_FORMATS = resp.data.DATETIME_FORMATS;
                $locale.NUMBER_FORMATS = resp.data.NUMBER_FORMATS;
                $locale.id = resp.data.id;
            });

            var template = $templateCache.get("template/modal/window.html");
            template = template.replace("<div class=\"modal-dialog\" ", "<div class=\"modal-dialog\" bps-draggable ");
            $templateCache.put("template/modal/window.html", template);

        }]);

angular.module('rootModule')
    .config(['$stateProvider', '$urlRouterProvider', 'contextProvider', 'datepickerConfig', 'datepickerPopupConfig', '$locationProvider',
        function ($stateProvider, $urlRouterProvider, contextProvider, datepickerConfig, datepickerPopupConfig, $locationProvider) {

    //Config for date picker
    datepickerConfig.startingDay = 1;
    datepickerConfig.showWeeks = false;
    datepickerPopupConfig.showButtonBar = false;
    datepickerConfig.minDate = new Date();
            
    $urlRouterProvider.otherwise('/');

    $stateProvider
        .state("start", {
            url: "/",
            template: bps.getTemplate("/views/Controllers/Start/start.html"),
            controller: 'startController',
        })
        .state("requests", {
            url: "/requests",
            template: bps.getTemplate("/views/Controllers/Request/requests.html"),
            controller: 'requestsController',
        })
        .state("direct-form", {
            url: "/direct-form/:sID",
            template: bps.getTemplate("/views/Forms/hiltonDirectForm.html"),
            controller: 'hiltonDirectFormController',
        })
        .state("direct-form.echannel", {
            template: bps.getTemplate("/views/Forms/eChannelForm.html"),
        })
        .state("direct-form.inbound", {
            template: bps.getTemplate("/views/Forms/inboundForm.html"),
        })
        .state("direct-form.nso", {
            template: bps.getTemplate("/views/Forms/nsoForm.html"),
        });
}]);