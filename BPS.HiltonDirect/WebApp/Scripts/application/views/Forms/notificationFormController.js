angular.module('controllerModule')
    .controller('notificationFormController', ['$scope', '$modalInstance', 'params', 'localizationService', '$timeout',
        function ($scope, $modalInstance, params, localizationService, $timeout) {

            if (params.formTitle && param.formTitle.trim().length > 0) {
                $scope.formTitle = params.formTitle
            } else {
                if (params.type == bps.constants.InformationDialogType.Error) {
                    $scope.formTitle = localizationService.getLocalizationByKey("dialog_error");
                } else if (params.type == bps.constants.InformationDialogType.Warning) {
                    $scope.formTitle = localizationService.getLocalizationByKey("dialog_warning");
                } else if (params.type == bps.constants.InformationDialogType.Confirmation) {
                    $scope.formTitle = localizationService.getLocalizationByKey("dialog_confirm");
                } else {
                    $scope.formTitle = localizationService.getLocalizationByKey("dialog_info");
                }
            }

            $scope.isOkCancel = params.isOkCancelButton == null ? false : params.isOkCancelButton;

            $scope.classText = "";

            // Bind class name based on type of dialog
            if (params.type == bps.constants.InformationDialogType.Error) {
                $scope.className = "dialog-error";
                $scope.iconClass = "fa fa-exclamation-triangle";
                $scope.classText = "error";
            } else if (params.type == bps.constants.InformationDialogType.Warning) {
                $scope.className = "dialog-warning";
                $scope.iconClass = "fa fa-exclamation-triangle";
            }
            else if (params.type == bps.constants.InformationDialogType.Confirmation) {
                $scope.className = "dialog-warning";
                $scope.iconClass = "fa fa-exclamation-triangle";
            } else {
                $scope.className = "dialog-info";
                $scope.iconClass = "fa fa-info-circle";
            }

            $scope.message = localizationService.getLocalizationByKey(params.message);
            $scope.details = false;
            // if there is a list of error controls
            var errorControls = params.errorControls;
            if (errorControls) {
                $timeout(function () {
                    var lstControls = [];
                    // Required
                    buildListErrorControls("required");
                    // date
                    buildListErrorControls("date");
                    // pattern
                    buildListErrorControls("pattern");
                    $scope.details = lstControls.length > 0;
                    lstControls = lstControls.sort();
                    $.each(lstControls, function (i, msg) {
                        $("#error-details").append(("<li>{0}</li>").format(msg));

                    });

                    function buildListErrorControls(errorType) {
                        if (errorControls[errorType] && errorControls[errorType].length > 0) {
                            $.each(errorControls[errorType], function (i, ctrl) {
                                if (ctrl.ErrorMessage) {
                                    if ($.inArray(ctrl.ErrorMessage, lstControls) == -1) {
                                        lstControls.push(ctrl.ErrorMessage);
                                    }
                                }
                            });
                        };
                    }
                });
            }


            $scope.close = function () {
                $modalInstance.close(true);

            };

            $scope.cancel = function () {
                $modalInstance.dismiss('cancel');
            };
        }]
);