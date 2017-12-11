
angular.module('directivesModule')
    .directive('bpsContextMenu', ['$state', 'localizationService',
        function ($state, localizationService) {
            var dropDownClass = "dropdown";
            var dropUpClass = "dropup";
            var dropdownMenu_padding = 5;
            var itemHeight = 24.57;

            return {
                restrict: 'A',
                template: bps.getTemplate("/views/Directivies/bpsContextMenu.html"),
                scope: {
                    bpsContextMenu: '='
                },
                link: function (scope, element, attrs) {

                    scope.$watch('bpsContextMenu', function () {
                        if (scope.bpsContextMenu) {
                            scope.obj = scope.bpsContextMenu;

                            /*set Context Menu Position*/
                            if (scope.items == null || scope.items.length != scope.bpsContextMenu.menuItems.length) {
                                setContextMenuPosition(scope.bpsContextMenu.menuItems.length);
                            }

                            scope.items = scope.bpsContextMenu.menuItems;
                        }
                    }, true);

                    scope.status = {
                        isOpen: false
                    };

                    scope.additionalAction = function (e) {
                        /*Hide the dropdown menu when user click the command*/
                        var el = e.target || e.srcElement;
                        if (el.nodeName === 'A' && el.parentNode.nodeName === "LI") {
                            scope.status.isOpen = false;
                        }

                        /*
                        *use this to skip the parents' click event
                        *in-case the ecb directive is added to a parents (ex: tr) 
                        *with already have the click event on it. 
                        ***ex: tr with the click event to open the display form when clicked, 
                        ***    and this tr have a td that have ecb menu inside.
                        ***    when we click on the ecb td it only show the display form instead of display the ecb menu,
                        ***    the ecbStopPropagation will alow to open the ecb menu even in this case.
                        */
                        e.stopPropagation();
                    };

                    function setContextMenuPosition(numOfItems) {
                        /*================== Context Menu position ===============================
                         *=== display the dropdown menu on the bottom or top of this directive ===
                         *========================================================================
                         */
                        var bpsContextMenuHolder = element.find('div[name="bpsContextMenu"]');
                        //var dropdownMenu = bpsContextMenuHolder.find("ul.dropdown-menu");
                        var bpsContextMenuHolder_Bottom = bpsContextMenuHolder[0].getBoundingClientRect().bottom;
                        var body_Bottom = document.body.getBoundingClientRect().bottom;
                        var dropdownMenu_height = numOfItems * itemHeight + dropdownMenu_padding;

                        if (bpsContextMenuHolder_Bottom + dropdownMenu_height > body_Bottom) {
                            /*add class dropup*/
                            /*don't has dropUpClass add, otherwise skip*/
                            if (!bpsContextMenuHolder.hasClass(dropUpClass)) {
                                /*remove dropdownClass if exist */
                                if (bpsContextMenuHolder.hasClass(dropDownClass)) {
                                    bpsContextMenuHolder.removeClass(dropDownClass);
                                }
                                bpsContextMenuHolder.addClass(dropUpClass);
                            }
                        } else {
                            /*don't has dropDownClass add, otherwise skip*/
                            if (!bpsContextMenuHolder.hasClass(dropDownClass)) {
                                /*remove dropdownClass if exist */
                                if (bpsContextMenuHolder.hasClass(dropUpClass)) {
                                    bpsContextMenuHolder.removeClass(dropUpClass);
                                }
                                bpsContextMenuHolder.addClass(dropDownClass);
                            }
                        }
                        /*================== End of - Context Menu position =====================*/
                    };
                }
            }
        }]);