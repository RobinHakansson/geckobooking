﻿$(function () {
    $("#datepicker").datepicker({
        //showOn: "both",
        //buttonImage: "images/calendar.gif",
        //buttonImageOnly: true,
        //showAnim: "fadeIn",
        firstDay: 1,
        showWeek: true,
        altField: ".date",
        altFormat: "yy-mm-dd",
        changeMonth: true,
        changeYear: true,      
        minDate: "-1Y",
        maxDate: "+2Y"
    });
});
