angular.module("directivesModule")
    .directive('bpsConfirmAction', ['localizationService', 'notificationService',
        function (localizationService, notificationService) {
            return {
                restrict: 'A',
                scope: {
                    bpsConfirmActive: '@',
                    bpsConfirmAction: '&',
                    bpsConfirmTwice: '@',
                    bpsDialogMessageProvider: '&'
                },
                link: function (scope, element, attr) {
                    function getConfigMessage() {
                        var configMsg = "";
                        var reconfigMsg = "";

                        if (attr.bpsConfirmMessage) {
                            var confirmMess = attr.bpsConfirmMessage.split("|");
                            configMsg = localizationService.getLocalizationByKey(confirmMess[0]);
                            if (confirmMess.length > 1 && confirmMess[1] && confirmMess[1].length > 0) {
                                var obj = JSON.parse(confirmMess[1]);
                                obj.params.forEach(function (item) {
                                    configMsg = configMsg.replace(item.key, item.value.trim());
                                });
                            }
                        }

                        if (attr.bpsReconfirmMessage) {
                            var reconfirmMess = attr.bpsReconfirmMessage.split("|");
                            reconfigMsg = localizationService.getLocalizationByKey(confirmMess[0]);
                            if (confirmMess.length > 1 && confirmMess[1] && confirmMess[1].length > 0) {
                                var obj = JSON.parse(confirmMess[1]);
                                obj.params.forEach(function (item) {
                                    reconfigMsg = reconfigMsg.replace(item.key, item.value.trim());
                                });
                            }
                        }

                        var msg = configMsg || "Are you sure?";
                        var remsg = reconfigMsg || "Are you really sure?";

                        var config = {
                            msg: msg,
                            remsg: remsg
                        };

                        return config;
                    }

                    element.bind('click', function (event) {
                        if (scope.bpsConfirmActive == 'true') {
                            var config = getConfigMessage();

                            if (attr['bpsDialogMessageProvider']) {
                                config.msg = scope.bpsDialogMessageProvider();
                            }
                            var dlg = notificationService.confirm(config.msg);

                            dlg.then(function (btn) {
                                if (scope.bpsConfirmTwice == 'true') {
                                    var dlg1 = notificationService.confirm(config.remsg);
                                    dlg1.then(function (btn1) {
                                        scope.bpsConfirmAction();
                                    }, function (btn) {
                                        /*Todo: Do some cancel action*/
                                    });
                                }
                                else {
                                    scope.bpsConfirmAction();
                                }

                            }, function (btn) {
                                /*Todo: Do some cancel action*/
                            });
                        }
                    });
                }
            };
        }]);