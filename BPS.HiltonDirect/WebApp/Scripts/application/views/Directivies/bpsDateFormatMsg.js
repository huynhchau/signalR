angular.module('directivesModule').directive('bpsDateFormatMsg', ['localizationService', '$timeout', 
function (localizationService, $timeout) {
    return {
        restrict: 'A',
        require: 'ngModel',
        compile: function (element) {
            // Add message area
            $(element[0]).parent().after('<div class="error-text date-format"></div>');

            // Update styles
            $(element[0]).parent("p").css("margin-bottom", "0px");

            // Watch
            return function (scope, elem, attr, ngModel) {
                function validateMessage() {
                    var msg = "";
                    if (ngModel.$error.date) {
                        msg = localizationService.getLocalizationByKey("invalid_date_format_msg");
                    }
                    $(elem[0]).parent().parent().find(".error-text.date-format").html(msg);
                }

                function hideMessageIfValid(value) {
                    if (!ngModel.$error.date) {
                        $(elem[0]).parent().parent().find(".error-text.date-format").html("");
                    }
                }

                elem.on("blur", function (e) {
                    $timeout(function () {
                        validateMessage();
                    }, 100);
                });

                scope.$watch(function () {
                    return ngModel.$viewValue;
                }, hideMessageIfValid);

            };
        }
    };
}]);