

$(document).ready(function () {
    if ($("#menu").width() < 1300) {
        $("#logo-box").hide();
    }
    else {
        $("#logo-box").css("display", "inline-block");
    }

        var totalWidth = 0;
        var menu = $('#menu-list');
        var menuWidth = menu.innerWidth();

        menu.find('li').each(function () {
            totalWidth += $(this).outerWidth();
            if (totalWidth > menuWidth) {
                $("#collapsed-menu-box").slideToggle("fast");
                $(this).before("<li class=\"menu-item dots\" style=\"display:inline-block;\"><a class=\"ellipse\">&hellip;</a></li>");
                $("ul#collapsed-menu-list").append($(".dots").nextAll());                
                return false; // Abort loop
            }
        });


        $(".ellipse").click(function () {
            $("#collapsed-menu-box").slideToggle("fast");
            //$("#collapsed-menu-box").toggleClass("visible");
    });
});

var item_index = 3;

$(window).resize(function () {
    if ($("#menu").width() < 1550) {
        $("#logo-box").hide();
    }
    else {
        $("#logo-box").css("display", "inline-block");
    }

    
    //if ($("#menu").width() < 1000) {

    //    $("ul#collapsed-menu-list").append($("#menu-list li:nth-last-child("+item_index+")"));
    //    item_index++;
    //    alert("moved");

    //}
});



$(document).on("scroll", function () {
    if ($(document).scrollTop() > 50) {
        $("header").removeClass("full").addClass("small");
    } else {
        $("header").removeClass("small").addClass("full");
    }

    
});

