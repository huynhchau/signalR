(function () {
    angular.module('serviceModule')
        .factory("resourceStringService", ['$q', '$rootScope', 'localStorageService', 'ajaxService',
            function ($q, $rootScope, localStorageService, ajaxService) {

                var getAllResourceStrings = function () {

                    var deferred = $q.defer();

                    var success = function (data) {
                        deferred.resolve(data);
                    };

                    var fail = function () {
                        deferred.reject();
                    };

                    ajaxService.doGet("/api/ResourceString/GetAllResourceStrings")
                        .then(function (data) {
                            success(data);
                        }).catch(fail);

                    return deferred.promise;
                };

                return {
                    getAllResourceStrings: getAllResourceStrings,
                };
            }
        ]);
})();