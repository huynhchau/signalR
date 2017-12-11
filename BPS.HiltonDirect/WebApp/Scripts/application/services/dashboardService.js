(function () {
    angular.module('serviceModule')
        .factory("dashboardService", ['$rootScope', function ($rootScope) {

            var _hubConnection = $.hubConnection();
            var _dashboardHubProxy = undefined;

            var connectedToSignalR = function () {
                console.debug('connected to signalR, connection ID =' + _hubConnection.id);
                $rootScope.$broadcast(bps.constants.signalR.onConnected, { connectionId: _hubConnection.id });
            }

            var broadcastGetRequests = function () {
                console.log("broadcastGetRequests");
                $rootScope.$broadcast(bps.constants.signalR.broadcastGetRequests);
            }

            var initialize = function () {
                _dashboardHubProxy = _hubConnection.createHubProxy(bps.constants.signalR.dashboardHubName);
                _dashboardHubProxy.on(bps.constants.signalR.reloadRequestList, broadcastGetRequests);

                _hubConnection.start()
                    .done(connectedToSignalR)
                    .fail(function () { console.error('Error connecting to signalR'); });
            };

            function getAllRequestsAsync() {

                var deferred = $q.defer();

                _dashboardHubProxy.invoke(bps.constants.signalR.getAllRequests)
                   .done(function (data) {
                       deferred.resolve(data);
                   });

                return deferred.promise;
            }

            return {
                initialize: initialize,
                connectedToSignalR: connectedToSignalR,
                getAllRequestsAsync: getAllRequestsAsync
            };
        }])
})();