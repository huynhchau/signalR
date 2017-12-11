angular.module("controllerModule").controller('hiltonDirectFormController',
    ['$scope', 'requestService', '$rootScope', '$window', 'blockUI', 'localizationService',
        'notificationService', '$filter', '$compile', '$state', 
    function ($scope, requestService, $rootScope, $window, blockUI, localizationService, notificationService,
        $filter, $compile, $state) {

        var formBlock = blockUI.instances.get('formBlock');

        $scope.form = {
            type: {}
        };
        $scope.request = {};
        $scope.lookup = {};
        $scope.dateOptions = bps.utils.getDatepickerOptions();
        $scope.sID;
        $scope.tinymceOptions = bps.utils.getTinymceOptions();
        
        var errorHandler = function (error) {
            formBlock.stop();
            notificationService.error(error.ErrorMessage);
        };

        $scope.datepickers = {
            dueDateOpened: false,
            decisionDateOpened: false
        };

        $scope.dueDateOpen = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();

            $scope.datepickers.dueDateOpened = true;
        };

        $scope.decisionDateOpen = function ($event) {
            $event.preventDefault();
            $event.stopPropagation();

            $scope.datepickers.decisionDateOpened = true;
        };

        $scope.init = function () {
            formBlock.start();
            var response = function (result) {
                $scope.request = result.Data;
                $scope.lookup = result.Lookup;
                if ($scope.request.Id > 0) {
                    $scope.form.type = bps.utils.array.getElementWith($scope.lookup.RequestTypes, "Id", $scope.request.Type);
                }
                else {
                    $scope.form.type = $scope.lookup.RequestTypes[0];
                }
                
                $scope.loadForm();
                bps.utils.safeApply();
                formBlock.stop();
            };
            
            if (!bps.utils.isNull($rootScope.$stateParams.sID)) {
                $scope.sID = $rootScope.$stateParams.sID;
                $rootScope.$stateParams.sID = null;
            }

            requestService.getRequestById($scope.sID || 0, response, errorHandler);
        };

        function normalizeData(item) {
            var itemToUpdate = angular.copy(item);

            itemToUpdate.Type = $scope.form.type.Id;
            itemToUpdate.TaskDueDate = bps.utils.normalizeDateString(itemToUpdate.TaskDueDate, $filter);
            itemToUpdate.DecisionDueDate = bps.utils.normalizeDateString(itemToUpdate.DecisionDueDate, $filter);

            return itemToUpdate;
        }

        $scope.addOrUpdateRequest = function () {
            var obj = normalizeData($scope.request);
            if (!obj.Id || obj.Id <= 0) {
                return requestService.addRequest(obj, function (data) {
                    $scope.request = data.Data;
                }, errorHandler);
            }
            else {
                return requestService.updateRequest(obj, function (data) {
                    }, errorHandler);
            }
        };

        $scope.getShortText = function (originalText, maxLength) {
            maxLength = maxLength || bps.constants.MaxLength;
            return bps.utils.getShortText(originalText, maxLength);
        };

        $scope.cancel = function () {
            $scope.request = {};
        }

        $scope.submit = function () {
            $scope.$broadcast('show-errors-check-validity');
            $scope.$broadcast('check-error-message');

            formBlock.start(localizationService.getLocalizationByKey(bps.constants.Resources.WaitingTextKey));

            if (!$scope.form.sform.$invalid) {
                $scope.addOrUpdateRequest();
            }
            else {
                formBlock.stop();

                // Date format
                if ($scope.form.sform.$error.date && !$scope.form.sform.$error.required) {
                    notificationService.error(localizationService.getLocalizationByKey("form_invalid_date_format_msg"), $scope.form.sform.$error);
                }
                else {
                    notificationService.error(localizationService.getLocalizationByKey("form_invalid"), $scope.form.sform.$error);
                }
            }
        };

        $scope.loadForm = function () {
            var state = "direct-form";
            
            if ($scope.form.type.Id == bps.constants.RequestType.eChannel) {
                state += ".echannel";
                if (!$scope.sID) {
                    $scope.request.EchannelRequest = { Id: 0 };
                }
            }
            else if ($scope.form.type.Id == bps.constants.RequestType.Inbound) {
                state += ".inbound";
                if (!$scope.sID) {
                    $scope.request.DirectLeadRequest = { Id: 0 };
                }
            }
            else {
                state += ".nso";
                if (!$scope.sID) {
                    $scope.request.DirectLeadRequest = { Id: 0 };
                }
            }

            if ($scope.sID) {
                $state.go(state, { sID: $scope.sID });
            }
            else
                $state.go(state);
        };

        $scope.init();
    }
    ]);