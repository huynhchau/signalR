(function () {
    angular.module('serviceModule')
        .factory("requestService", ['ajaxService',"$rootScope",
            function (ajaxService, $rootScope) {

                var getRequestById = function (id, callback, errorHandler) {
                    ajaxService.callService("GET", "api/Request/GetRequestById", { id: id }, function (result) {
                        callback(result);
                    }, errorHandler);
                };

                var addRequest = function (request, callback, errorHandler) {
                    ajaxService.callService("POST", "api/Request/AddRequest", request, function (result) {
                        callback(result);
                    }, errorHandler);
                };

                var updateRequest = function (request, callback, errorHandler) {
                    ajaxService.callService("POST", "api/Request/UpdateRequest", request, function (result) {
                        callback(result);
                    }, errorHandler);
                };

                var getRequests = function (callback, errorHandler) {
                    ajaxService.callService("GET", "api/Request/GetRequests", null, function (result) {
                        callback(result);
                    }, errorHandler);
                };

                var removeRequest = function (id, callback, errorHandler) {
                    ajaxService.callService("POST", "api/Request/RemoveRequest", { id: id }, function (result) {
                        callback(result.Data);
                    }, errorHandler);
                };

                return {
                    getRequestById: getRequestById,
                    addRequest: addRequest,
                    updateRequest: updateRequest,
                    getRequests: getRequests,
                    removeRequest: removeRequest,
                };
            }
        ])
})();