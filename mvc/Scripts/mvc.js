var s240 = String.fromCharCode(240);

$.ajax({ cache: false });

$.ajaxSetup({
    // Disable caching of AJAX responses
    cache: false
});

function get_sub_comps(
                        comp
                      )
{
    var url = "/Home/get_sub_comps";
    $.get(url,
         {
             comp: comp
         },
        function (r) {
            r = r.split(s240);
            $("#sub_comps_" + r[1]
            ).html(r[0]);
        });
}

function get2(prm_
               ) {
    var url = "/Home/returnn2";
    $.get(url,
        {
            prm: prm_
        },
             function (r) {
                 $("#resu").html(r);
             });
}
