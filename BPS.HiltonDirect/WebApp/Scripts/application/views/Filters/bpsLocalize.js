angular.module("coreModule")
    .filter("bpsLocalize", ["localizationService",
        function (localizationService) {
            return function (input, state, dictionary) {
                if (input == null) {
                    return '';
                }

                var key = bps.utils.isNullOrEmpty(state) ? input : input + "__" + state;
                var content = localizationService.getLocalizationByKey(key);

                if (content && content.length > 0) {
                    if (dictionary && dictionary.length > 0) {
                        var obj = JSON.parse(dictionary);
                        obj.params.forEach(function (item) {
                            content = content.replace(item.key, item.value.trim());
                        });
                    }
                }
                return content;
            }
        }
    ]);

/*{{"comment_modified_by" | ibLocalize:'state':'{"params": [{"key":"[modifyBy]","value":"' + comment.ModifiedBy.Name +'"}, {"key":"[modifyDate]","value":"' + (comment.Modified | date:'MMM d, y h:mm a') +'"}]}'}}*/