var ns = bps.ns("bps.constants");

ns.InformationDialogType = {
    Information: "Information",
    Error: "Error",
    Warning: "Warning",
    Confimration: "Confirmation"
};

ns.DateFormat = "ddMMyyyy";
ns.DateTimeFormat = "ddMMyyyy HH:mm:ss";
ns.ServerDateTimeFormat = "dd/MM/yyyy HH:mm:ss";
ns.ServerDateFormat = "MM/dd/yyyy";
ns.ViewDateFormat = "dd MMM yyyy";
ns.Resources = {
    WaitingTextKey: "waiting_text"
};

ns.angulari18 = "/Scripts/libraries/i18n/angular-locale_";
ns.MaxLength = 22;

ns.RequestType = function () {
    return {
        eChannel: 1,
        Inbound: 2,
        NSO: 3
    }
}();

ns.signalR = function () {
    return {
        dashboardHubName: "dashboards",
        reloadRequestList: "displayStatus",
        onConnected : "signalRConnected",
        broadcastGetRequests: "broadcastGetRequests",
        getAllRequests : "getAllRequests"
    }
}();
