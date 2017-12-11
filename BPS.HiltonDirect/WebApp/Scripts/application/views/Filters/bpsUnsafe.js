angular.module("coreModule")
    .filter('bpsUnsafe', ["$sce", function ($sce) {
        return function (val) {
            return $sce.trustAsHtml(val);
        };
    }]);