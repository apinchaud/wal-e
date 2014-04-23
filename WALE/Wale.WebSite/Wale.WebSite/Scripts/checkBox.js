$(function () {


    function envoieServer(listTerm)
    {
        var chaine = "";
        for (var j = 0; j < listTerm.length;++j) chaine+=listTerm[j]+"_"
        $.ajax({
            type: "GET",
            url: "./Home/listerLog",
            data: "listTermString=" + chaine,
            async:false,
            success: function (data) {
                $("#resultat").html("");
                var res=jQuery.parseJSON(data)
                for (var i = 0; i < res.length; i++)
                {
                    $("#resultat").append(res[i].Message +"<br/>");
                }
            },
            /*error: function (xhr, ajaxOptions, throwError, request, error)
            {
                alert("xhr : " + xhr +
                       "ajaxOption : " + ajaxOptions +
                        "throwError : " + throwError +
                        "request : " + request +
                        "error : " + error
                );
            }*/
        });
    }

    function afficherMessage() {
        var tabCoche = new Array();
        tabCoche=[];
        $('form[name="formCheckLog"] :input').each(function () {
                if ($(this).is(":checked"))
                {
                    tabCoche.push($(this).attr("value"));
                }
            });
            envoieServer(tabCoche);
    }

    $('form[name="formCheckLog"] :input').click(function () {
        afficherMessage();
    });


});