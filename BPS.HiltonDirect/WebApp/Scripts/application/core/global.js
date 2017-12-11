var bps = bps || {};

bps.ns = function (namespace) {
    var parts = namespace.split('.'),
               parent = bps,
               i,
               max;

    if (parts[0] === "bps") {
        parts = parts.slice(1);
    }
    for (i = 0, max = parts.length; i < max; i++) {
        if (typeof parent[parts[i]] === "undefined") {
            parent[parts[i]] = {};
        }
        parent = parent[parts[i]];
    }
    return parent;
};

bps.typewatch = (function () {
    var timer = 0;
    return function (callback, ms) {
        clearTimeout(timer);
        timer = setTimeout(callback, ms);
    };
})();

(function () {
    window.bpsTemplateCache = new Cache(-1, false, new Cache.SessionStorageCacheStorage("bpsTemplates"));
})();

bps.getTemplate = function (key) {
    var tmpl = window.bpsTemplateCache.getItem(key.toLowerCase());
    if (!tmpl) {
        console.log("bps Template Cache - Missing template - " + key.toLowerCase());
        return "Template missing";
    }

    return tmpl;
};

bps.ns("bps.utils");

bps.utils.isNull = function (obj) {
    if ((obj === 0) || (obj === false))
        return false;
    return (!obj || typeof obj === 'undefined' || obj === null);
};

bps.utils.isNullOrEmpty = function (obj) {
    return bps.utils.isNull(obj) || obj === '';
};

bps.utils.safeApply = function ($scope, callback) {
    if (bps.utils.isNull($scope) || bps.utils.isNull(callback))
        return;

    var phase = $scope.$root.$$phase;
    if (phase == '$apply' || phase == '$digest') {
        if (callback && (typeof (callback) === 'function')) {
            callback();
        }
    } else {
        $scope.$apply(callback);
    }
};

bps.utils.getDatepickerOptions = function () {
    return {
        startingDay: 1,
        changeYear: true,
        changeMonth: true
    };
};

bps.utils.getPropertyRecursive = function (obj, propNames) {
    if (propNames.length === 1)
        return obj[propNames[0]];
    else {
        var propName = propNames.splice(0, 1)[0];
        return bps.utils.getPropertyRecursive(obj[propName], propNames);
    }
};

bps.utils.trimStart = function (str, chr) {
    var rgxtrim = (!chr) ? new RegExp('^\\s+') : new RegExp('^' + chr + '+');
    return str.replace(rgxtrim, '');
};


bps.utils.trimEnd = function (str, chr) {
    var rgxtrim = (!chr) ? new RegExp('\\s+$') : new RegExp(chr + '+$');
    return str.replace(rgxtrim, '');
};

bps.utils.getParameterByName = function (name) {
    name = name.replace(/[\[]/, "\\\[").replace(/[\]]/, "\\\]");
    var regex = new RegExp("[\\?&]" + name + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results == null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
};

bps.utils.formatDate = function (date) {
    if (typeof date.getMonth === 'function')
        return date.format(bps.constants.DateFormat);
    else
        return date;
};

bps.utils.formatDateTime = function (date) {
    if (date != null) {
        if (typeof date.getMonth === 'function')
            return date.format(bps.constants.DateTimeFormat);
        else
            return date;
    }
};

bps.utils.normalizeDateString = function (date, filter) {
    if (angular.isDate(date)) {
        return filter('date')(date, bps.constants.ServerDateFormat);
    }
    return date;
};

bps.utils.reloadPage = function () {
    var href = window.location.href;
    window.location = href.substring(0, href.indexOf('#'));
};

bps.utils.getShortText = function (originalText, maxLength) {
    if (!originalText) {
        return "";
    }
    else {
        if (originalText.length > maxLength) {
            return originalText.substring(0, maxLength).trim() + "...";
        }
        return originalText;
    }
};

bps.utils.getTinymceOptions = function () {
    return {
        content_css: [_bpsEnvironment.appUrl + "/Content/bootstrap.css",
            _bpsEnvironment.appUrl + "/Content/bootstrap-custom.css",
            _bpsEnvironment.appUrl + "/Content/Site.css"]
    };
};

bps.utils.signalRServerPath = function () {
    return _bpsEnvironment.appUrl + "/signalr/";
};

bps.ns("bps.utils.array");
bps.utils.array.getElementsWithout = function (array, propertyName, value) {
    return array.filter(function (item) {
        var propChain = propertyName.split('.');

        return bps.utils.getPropertyRecursive(item, propChain) !== value;
    });
};

bps.utils.array.getElementsWith = function (array, propertyName, value) {
    return array.filter(function (item) {
        var propChain = propertyName.split('.');

        return bps.utils.getPropertyRecursive(item, propChain) === value;
    });
};

bps.utils.array.getElementWith = function (array, propertyName, value) {
    var arr = bps.utils.array.getElementsWith(array, propertyName, value);

    return arr[0];
};

bps.utils.array.indexOfObject = function (array, propertyName, value) {
    for (var i = 0, len = array.length; i < len; i++) {
        if (propertyName) {
            if (array[i][propertyName] === value) {
                return i;
            }
        }
        else {
            if (array[i] === value) {
                return i;
            }
        }
    }
    return -1;
};

bps.utils.array.hasElementWith = function (array, propertyName, value) {
    return array.filter(function (item) {
        var propChain = propertyName.split('.');

        return bps.utils.getPropertyRecursive(item, propChain) === value;
    }).length > 0;
};

String.prototype.format = function () {
    var s = this,
            i = arguments.length;
    while (i--) {
        s = s.replace(new RegExp('\\{' + i + '\\}', 'gm'), arguments[i]);
    };
    return s;
};

Date.prototype.addDays = function (days) {
    var dat = new Date(this.valueOf());
    dat.setDate(dat.getDate() + days);
    return dat;
}