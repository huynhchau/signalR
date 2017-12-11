
angular.module("serviceModule", []);

(function () {
    angular.module('serviceModule').provider('context',
        function contextProvider() {

            var initContext = [
                '$http', '$rootScope', '$q', '$window', '$locale',
                function ($http, $rootScope, $q, $window, $locale) {
                    $rootScope.appContext = {};

                    var loadAngularLocaleValues = function () {
                        var filePath = ngo.constants.angulari18 + "en-fi.js";

                        return $http.get(filePath).then(function (resp) {
                            $locale.DATETIME_FORMATS = resp.data.DATETIME_FORMATS;
                            $locale.NUMBER_FORMATS = resp.data.NUMBER_FORMATS;
                            $locale.id = resp.data.id;
                        });
                    };

                    var promise = loadAngularLocaleValues
                                    .then(function () {
                                        console.log("$locale", $locale);
                                    });

                    return {
                        contextLoaded: promise,
                    };
                }
            ];

            this.$get = initContext;
        });
})();