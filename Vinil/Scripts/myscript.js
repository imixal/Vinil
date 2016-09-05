$(document).ready(function () {
    basket(); basketview(); addbasketclick();
    var min = +$("#amount").attr("min");
    var max = +$("#amount").attr("max");
    $(function () {
        $("#slider-range").slider({
            range: true,
            min: min,
            max: max,
            values: [min, max],
            slide: function (event, ui) {
                $("#amount").val("$" + ui.values[0] + " - $" + ui.values[1]);
                min = ui.values[0]; max = ui.values[1];

                
            }
        });
        $("#amount").val("$" + $("#slider-range").slider("values", 0) +
          " - $" + $("#slider-range").slider("values", 1));
    });
    $(".panel-control").change(function () {
        var styles = [];
        var artists = []
        var albums = [];
        var sort = "";
        var count;
        var page = 1;
        $("input[data-style]:checkbox:checked").each(function () {
            styles.unshift($(this).attr("data-style"));
        });
        $("input[data-artist]:checkbox:checked").each(function () {
            artists.unshift($(this).attr("data-artist"));
        });
        $("input[data-album]:checkbox:checked").each(function () {
            albums.unshift($(this).attr("data-album"));
        });
        sort = $("#Order option:selected").val();
        count = $("#Count option:selected").val();
        $("#vinilsView").empty();
        $.get("/Home/UpdatebySettings", { 'priseMin': min, 'priseMax': max, 'style': styles.toString(), 'artist': artists.toString(), 'album': albums.toString(), 'sort':sort, 'count':count, 'page':page})
        .done(function (data) {
            $("#vinilsView").html(data);
            $(basket());
            $(addbasketclick());
        });
        //$(".control-bar-wrapper").empty();
        //$.get("/Home/UpdatePagenator").done(function (data) {
        //    $(".control-bar-wrapper").html(data);
        //    $("#Count").change(function () {
        //        $(".panel-control").trigger("change")
        //    });
        //});
        

    });
    $("#slider-range").click(function () {
        $(".panel-control").trigger("change")});
    
    $("#Order").change(function () {
        $(".panel-control").trigger("change")
    });
    $("#Count2").change(function () {
        var temp = $("#Count2 #Order option:selected").val();
        $("#Order :contains('" + temp + "')").attr("selected", "selected");
        $(".panel-control").trigger("change")
    });
    $("#Count").change(function () {
        $(".panel-control").trigger("change")
    });
    $("#Count2").change(function () {
        var temp = $("#Count2 #Count option:selected").val();
        $("#Count :contains('" + temp + "')").attr("selected", "selected");
        $(".panel-control").trigger("change")
    });

});
function basket() {
    $(".vinil").mouseenter(function () {
        $(".basket", this).stop().animate({ top: '-5px' }, "fast")
    }).mouseleave(function () {
        $(".basket").stop().animate({ top: '-55px' }, "fast")
    });
};
function basketview() {
    $("#basket").click(function () {
        if ($("#basketview").css("right")!="0px") {
            $("#basketview").stop().animate({ right: '0px' }, "fast");
        }
        else {
            $("#basketview").stop().animate({ right: '-300px' }, "fast");
        }
    });
};
function addbasketclick(){
    $(".vinil").click(function () {
        var Name = $("h2", this).text();
        var Image = $("img", this).attr("src");
        addbasket(Name, Image);
        removeclick();
    });
};
function addbasket(name, image) {
    $("#basketview").append('<div class="mini-vinil"><img class="img-responsive" width="60" src="' + image + '" /><p>' + name + '</p><span class="glyphicon glyphicon-remove"></span></div>');
   
};
function removeclick() {
    $(".glyphicon-remove").click(function () {
       $(this).parent().detach();
    });
};
