angular.module("coreModule")
    .filter("bpsDateFormat", ["$filter",
        function ($filter) {
            return function (value) {
                if (value == null) {
                    return '';
                }
                if (typeof (value) === 'string') {
                    return value.replace(/([A-Z][a-z]*)/g, ' $1 ').trim();
                }
                else {
                    return $filter('date')(value, bps.constants.ViewDateFormat);
                }
            }
        }
    ]);