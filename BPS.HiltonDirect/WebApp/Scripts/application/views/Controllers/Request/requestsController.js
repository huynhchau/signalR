angular.module("controllerModule")
    .controller("requestsController",
    ["$scope", "localizationService", "requestService", "notificationService", "$state", "$rootScope", "dashboardService",
        function ($scope, localizationService, requestService, notificationService, $state, $rootScope, dashboardService) {
            var listCommands = ["edit-request", "remove-request"];
            var menuActions = {
                "edit-request": {
                    Title: localizationService.getLocalizationByKey("edit_request"),
                    Action: function (item) {
                        $state.go($scope.stateName, { sID: item.Id });
                    },
                    HasPermission: false
                },
                "remove-request": {
                    Title: localizationService.getLocalizationByKey("remove_request"),
                    Action: function (item) {
                        notificationService.confirm(localizationService.getLocalizationByKey("request_delete_confirmation")).then(function (result) {
                            if (result == true) {
                                requestService.removeRequest(item.Id, function () {
                                    var index = $scope.browseItems.indexOf(item);
                                    $scope.browseItems.splice(index, 1);
                                }, function (error) {
                                    notificationService.error(error);
                                });
                            }
                        });
                    },
                    HasPermission: false
                },
            };

            $scope.hasPermission = false;
            $scope.stateName = "direct-form";

            $scope.sort = {
                predicate: 'Id',
                reverse: false
            };

            $scope.browseFilter = localizationService.getLocalizationByKey("browse_filter");

            $scope.query = "";
            $scope.filterFn = function (item) {
                return (angular.lowercase(item.SPR.Name + "").indexOf(angular.lowercase($scope.query || '')) !== -1 ||
                    angular.lowercase(item.Admin1.Name + "").indexOf(angular.lowercase($scope.query) || '') !== -1);
            };

            $scope.hasPermission = false;

            var errorHandler = function (error) {
                notificationService.error(error.ErrorMessage);
            };

            $scope.init = function () {
                $scope.getData();
                dashboardService.initialize();

                $scope.$on(bps.constants.signalR.onConnected, function (event, args) {
                    console.log("connectionId", args.connectionId);
                });

                $scope.$on(bps.constants.signalR.broadcastGetRequests, function (event, args) {
                    $scope.getData();
                });
            }

            $scope.getData = function () {
                requestService.getRequests(function (data) {
                    console.log(data);
                    $scope.hasPermission = data.HasPermission;
                    $.each(data.Data.BrowseItems, function (index, itm) {
                        itm.menuItems = [];
                        itm.Admin1 = itm.Admin1 || {};
                        itm.SPR = itm.SPR || {};
                        angular.forEach(listCommands, function (item) {

                            if ($scope.hasPermission || menuActions[item].HasPermission === true) {
                                itm.menuItems.push(menuActions[item]);
                            }
                        });
                    });

                    $scope.browseItems = data.Data.BrowseItems;
                    bps.utils.safeApply($scope);
                }, errorHandler);
            }

            var addRequest = function (data) {
                $scope.browseItems = data;
            };

            $scope.showEditForm = function (item) {
                $state.go($scope.stateName, { sID: item.Id });
            }

            $scope.createRequest = function () {
                $state.go($scope.stateName);
            }

            $scope.init();
        }
    ]);