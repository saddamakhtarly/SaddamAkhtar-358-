




$(".form-control").blur(function () {
    var check = $(this).data("evs-validate");
    if (check === "empty") {
        if ($(this).val().length === 0) {
            $(this).parent().addClass("has-error");
            $(this).parent().removeClass("has-success");
            $(this).next().remove();
            $(this).parent().append("<span class='form-control-feedback'><span class='glyphicon glyphicon-warning-sign'></span></span>");
        }
        else {
            $(this).parent().addClass("has-success");
            $(this).parent().removeClass("has-error");
            $(this).next().remove();
            $(this).parent().append("<span class='form-control-feedback'><span class='glyphicon glyphicon-check'></span></span>");
        }
    }
});

$(".evs-imgswap").hover(function () {
    var main = $(this).attr("src");
    var alt = $(this).data("evs-altsrc");
    $(this).attr("src", alt);
    $(this).data("evs-altsrc", main);
});

$(".img-thumbnail").mouseenter(function () {
    var eltname = $(this).parents(".evs-thumnail-wraper").data("evs-target");
    $(eltname).attr("src", $(this).attr("src"));
});

//function evs(elt, attrname, attrvalue) {
//    if (attrvalue === null) {
//        return elt.attr("data-evs" + attrname);
//    }
//    else {
//        elt.attr("data-evs" + attrname, attrvalue);
//    }    
//}