$(document).ready(function(){
    
    var today = new Date();
    var month = (today.getMonth() + 1);
    var date = today.getDate();

    if (month < 10)
    {
        month = "0" + month;
    }

    if (date < 10)
    {
        date = "0" + date;
    }

    document.getElementById("date").innerHTML = today.getFullYear() + "-" + month + "-" + date;
});