$(function () {
    $("#datepicker").datepicker({
        //showOn: "both",
        //buttonImage: "images/calendar.gif",
        //buttonImageOnly: true,
        //showAnim: "fadeIn",
        onSelect: function() {
            //$("form").submit();
            //$(".date").val();
        },
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
