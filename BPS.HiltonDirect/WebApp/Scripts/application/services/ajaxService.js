(function () {
    angular.module('serviceModule')
        .factory('ajaxService', ['$q', '$rootScope', 'notificationService', '$http', '$log',
            function ($q, $rootScope, notificationService, $http, $log) {

                var service = {};

                var doHttp = function (apiPath, parameters, requestedHeaders, action, dataType) {
                    var deferred = $q.defer();
                    var headers = {};
                    requestedHeaders = requestedHeaders || {};

                    var fullPath = getFullApiPath(apiPath);
                    var request = { method: action, url: fullPath, headers: headers };
                    var ajaxDataType = (dataType !== undefined) ? dataType : "application/json";

                    if (action === "GET") {
                        request.params = parameters;
                    }
                    else {
                        request.method = "POST";
                        request.data = parameters;
                    }

                    request.headers["Content-Type"] = "application/x-www-form-urlencoded; charset=UTF-8"; //always overwrite the content type?

                    var appendParams = {
                        PFPAction: action,
                        ContentType: ajaxDataType
                    };

                    request.params = request.params || {};
                    jQuery.extend(request.params, appendParams);

                    var start = new Date().getTime();

                    $http(request)
                        .success(function (data) {
                            if (data.HasError) {
                                $log.log((new Date().getTime() - start) + "ms  " + action + "@ " + apiPath + " - Error: " + data.ErrorMessage);
                                deferred.reject(data);
                            }
                            else {
                                $log.log((new Date().getTime() - start) + "ms  " + action + "@ " + apiPath);
                                deferred.resolve(data);
                            }
                        })
                        .error(function (data, status, headers, config) {
                            var msg = getErrorMessage(data, status, headers, config);
                            $log.error((new Date().getTime() - start) + "ms  " + action + "@ " + apiPath + " - Error: " + msg);
                            deferred.reject(msg);
                        });

                    return deferred.promise;
                }

                function getFullApiPath(apiPath) {
                    console.log(apiPath);
                    if (apiPath.toLowerCase().indexOf("http") == 0) {
                        return apiPath;
                    }
                    else {
                        return _bpsEnvironment.appUrl + "/" + bps.utils.trimStart(apiPath, '/');
                    }
                }

                function getErrorMessage(data, status, headers, config) {
                    var msg = { status: status, message: data };
                    if (data == null) {
                        msg.message = "Unexpected error is occurred";
                    }
                    if (data != undefined && data.Message != undefined) {
                        msg = { status: status, message: data.Message };
                    }
                    return msg;
                }

                function handleException(error) {
                    if (error.ErrorMessage) {
                        notificationService.error(error.ErrorMessage);
                    } else {
                        notificationService.error(error);
                    }
                };

                service.doGet = function (apiPath, parameters, headers, dataType) {
                    return doHttp(apiPath, parameters, headers, "GET", dataType);
                };

                service.doPost = function (apiPath, parameters, headers, dataType) {
                    return doHttp(apiPath, parameters, headers, "POST", dataType);
                };

                service.callService = function (method, serviceUrl, params, callback, errorHandler) {

                    if (method == "GET" || method == "get") {
                        service.doGet(serviceUrl, params).then(function (result) {
                            if (callback != undefined) {
                                callback(result);
                            }
                        }).catch(function (error) {
                            if (errorHandler && (typeof (errorHandler) === 'function')) {
                                errorHandler(error);
                            }
                            else {
                                handleException(error);
                            }
                        });
                    }
                    else {
                        service.doPost(serviceUrl, params).then(function (result) {
                            if (callback != undefined) {
                                callback(result);
                            }
                        }).catch(function (error) {
                            if (errorHandler && (typeof (errorHandler) === 'function')) {
                                errorHandler(error);
                            }
                            else {
                                handleException(error);
                            }
                        });
                    }
                };

                return service;
            }]);
})();