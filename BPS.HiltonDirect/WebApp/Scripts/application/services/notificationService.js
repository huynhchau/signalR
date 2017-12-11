angular.module('serviceModule').factory("notificationService", ['$modal',
    function ($modal) {
        var svc = {};

        svc.error = function (error, errorControlList) {
            var modalInstance = $modal.open({
                template: bps.getTemplate("/Views/Forms/notificationForm.html"),
                controller: 'notificationFormController',
                backdrop: 'static',
                size: 'sm',
                resolve: {
                    params: function () {
                        var message = null;
                        // Argument is string
                        if (angular.isString(error)) {
                            message = error;
                        }
                        else if (angular.isObject(error)) { // Argument is object
                            // Has statusText
                            if (angular.isDefined(error.statusText)) {
                                message = error.statusText;
                            } else if (error.hasOwnProperty("ErrorMessage")) {
                                message = error.ErrorMessage;
                            } else if (error.hasOwnProperty("message")) {
                                message = error.message;
                            } else if (typeof error.get_message == 'function') {
                                message = error.get_message();
                            }
                            //  else {
                            //      Continue for other object types  
                            //  }
                        }

                        // Default if not find error message
                        if (message === null) {
                            message = angular.toJson(error);
                        }

                        return {
                            message: message,
                            type: bps.constants.InformationDialogType.Error,
                            errorControls: errorControlList
                        };
                    }
                }
            });

            return modalInstance.result;
        };

        svc.warn = function (message, isOkCancelButton) {
            var modalInstance = $modal.open({
                template: bps.getTemplate("/Views/Forms/notificationForm.html"),
                controller: 'notificationFormController',
                backdrop: 'static',
                size: 'sm',
                resolve: {
                    params: function () {
                        return {
                            message: message,
                            type: bps.constants.InformationDialogType.Warning,
                            isOkCancelButton: isOkCancelButton
                        };
                    }
                }
            });

            return modalInstance.result;
        };

        svc.confirm = function (message) {
            var modalInstance = $modal.open({
                template: bps.getTemplate("/Views/Forms/notificationForm.html"),
                controller: 'notificationFormController',
                backdrop: 'static',
                size: 'sm',
                resolve: {
                    params: function () {
                        return {
                            message: message,
                            type: bps.constants.InformationDialogType.Confirmation,
                            isOkCancelButton: true
                        };
                    }
                }
            });

            return modalInstance.result;
        };

        svc.info = function (message) {
            var modalInstance = $modal.open({
                template: bps.getTemplate("/Views/Forms/notificationForm.html"),
                controller: 'notificationFormController',
                backdrop: 'static',
                size: 'sm',
                resolve: {
                    params: function () {
                        return {
                            message: message,
                            type: bps.constants.InformationDialogType.Information
                        };
                    }
                }
            });

            return modalInstance.result;
        };

        svc.input = function (title, message) {
            var modalInstance = $modal.open({
                template: bps.getTemplate("/Views/Forms/inputForm.html"),
                controller: 'inputFormController',
                backdrop: 'static',
                size: 'sm',
                resolve: {
                    params: function () {
                        return {
                            message: message,
                            title: title
                        };
                    }
                }
            });

            return modalInstance.result;
        };

        return svc;
    }]
);