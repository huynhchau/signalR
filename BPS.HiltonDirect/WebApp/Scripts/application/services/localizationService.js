/*
 * <summary>
 *  Serving localization functionallity
 * </summary>
 */

(function () {
    angular.module("serviceModule").factory("localizationService", ['localStorageService', '$q', 'resourceStringService', '$rootScope',
        function (localStorageService, $q, resourceStringService, $rootScope) {
            var service = {};

            service.getModificationInfo = function (obj) {
                if (obj) {
                    var template = service.getLocalizationByKey("modified_info");
                    var createdBy = (typeof obj.CreatedBy) === "string" ? obj.CreatedBy : obj.CreatedBy.Name;
                    var modifiedBy = (typeof obj.ModifiedBy) === "string" ? obj.ModifiedBy : obj.ModifiedBy.Name;
                    var createdDate = (typeof obj.CreatedDate) === "string" ? obj.CreatedDate : bps.utils.formatDateTime(obj.CreatedDate);
                    var modifiedDate = (typeof obj.ModifiedDate) === "string" ? obj.ModifiedDate : bps.utils.formatDateTime(obj.ModifiedDate);

                    return template.format(createdDate, createdBy, modifiedDate, modifiedBy);
                }
                return "";
            };

            service.getResource = function (serverOnly) {

                var deferred = $q.defer();

                function getResourceFromServer() {
                    resourceStringService.getAllResourceStrings().then(function (data) {
                        localStorageService.set("resources", data.Data.Resources);
                        deferred.resolve(data.Data.Resources);
                    });
                }

                if (serverOnly || !localStorageService.hasKey("resources")) {
                    getResourceFromServer();
                }
                else {
                    if (localStorageService.hasKey("resources")) {
                        var resources = localStorageService.get("resources");
                        var storageLanguageId = localStorageService.get("languageId");

                        if (!resources || resources.length <= 0) {
                            getResourceFromServer();
                        }
                        else {
                            deferred.resolve(resources);
                        }
                    }
                }
                return deferred.promise;
            };

            service.getLocalizationByKey = function (key, dictionary) {
                var content = $rootScope.appContext == null || $rootScope.appContext.resources == null || $rootScope.appContext.resources[key] == null ? key : $rootScope.appContext.resources[key];
                if (!dictionary || dictionary == null) {
                    return content;
                }

                if (content && dictionary && content.length > 0) {
                    if (dictionary.length > 0) {//dictionary is string
                        var obj = JSON.parse(dictionary);
                        obj.params.forEach(function (item) {
                            content = replaceAll(content, item.key, item.value.trim());
                        });
                    }
                    else if (dictionary.params.length > 0) //dictionary is object
                    {
                        dictionary.params.forEach(function (item) {
                            content = replaceAll(content, item.key, item.value);
                        });
                    }
                }

                return content;
            };

            /* Format of string to localize: resourceString|#bpsSep#|Arg 1|#bpsSep#|Arg 2 */
            service.parseLocalizedString = function (localizedString) {
                try {
                    if (localizedString.indexOf(bps.constants.Separator) > -1) {
                        var arr = localizedString.split(bps.constants.Separator);

                        var keyValue = service.getLocalizationByKey(arr[0]);
                        var args = arr.slice(1, arr.length);

                        return keyValue.format.apply(keyValue, args);
                    }
                    else {
                        return service.getLocalizationByKey(localizedString);
                    }
                }
                catch (error) { }

                return localizedString;
            };

            function replaceAll(inSource, inToReplace, inReplaceWith) {
                var outString = inSource;
                while (true) {
                    var idx = outString.indexOf(inToReplace);
                    if (idx === -1) {
                        break;
                    }
                    outString = outString.replace(inToReplace, inReplaceWith);
                }
                return outString;
            };

            return service;
        }]);
})();