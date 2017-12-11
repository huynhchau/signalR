angular.module('directivesModule').directive('bpsFormHandleValidation', ['$interpolate', function ($interpolate) {
    return {
        restrict: 'A',
        require: '^form',
        link: function (scope, el, attrs, formCtrl) {
            scope.$on('check-error-message', function () {
                if (formCtrl.$error) {
                    // required
                    handleErrorMessage("required");
                    handleErrorMessage("pattern");
                    handleErrorMessage("date");
                }

                function handleErrorMessage(type) {
                    var ctrls = formCtrl.$error[type];
                    if (ctrls && ctrls.length > 0) {
                        formCtrl.$error[type] = $.map(formCtrl.$error[type], function (ctrl) {
                            if (ctrl.$name && !ctrl.ErrorMessage) {

                                var domForm = $(("form[name='{0}']").format(formCtrl.$name));

                                var domElement = $(domForm).find(("[name='{0}']").format(ctrl.$name));
                                var parent = $(domElement).closest("[show-errors]");
                                var msg = $interpolate($(parent).attr('error-message') || '')(scope);
                                if (!msg) {
                                    msg = $(parent).find("label.control-label").text();
                                }

                                // Remove asterisk
                                msg = $.trim(msg);
                                if (msg.indexOf("*") == msg.length - 1) {
                                    msg = msg.substring(0, msg.length - 1);
                                }

                                ctrl.ErrorMessage = msg;
                            }
                            return ctrl;
                        });
                    }
                }
            });
        }
    };
}]);