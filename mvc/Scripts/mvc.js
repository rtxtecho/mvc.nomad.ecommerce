var client = "";

$(document).ajaxError(function (event, request, settings) {
    $("#msg").append("<li>Error requesting page " + settings.url + "</li>");
});

var s240 = String.fromCharCode(240);
var ni = "<i>Not Identified</i>"

c_serv = 0;

$.ajax({ cache: false });

$.ajaxSetup({
    // Disable caching of AJAX responses
    cache: false
});

function progress_go() {
    $("#progress_bg"
     ).css("display", ""
          );

}

function progress_stop() {
    $("#progress_bg"
     ).css("display", "none"
          );

}

function sub_scrn_go(
                     content,
                     topic
                     ) {
    var x = document.documentElement.clientWidth;
    x = x / 2 - 200;

    var y = document.documentElement.clientHeight;
    y = y / 2 - 200;

    $("#sub_scrn"
 ).css("left", x
      );

    $("#sub_scrn"
 ).css("top", y
      );

    $("#sub_scrn_topic"
 ).html(topic
      );

    $("#sub_scrn_content"
 ).html(content
      );

    $("#sub_scrn"
 ).css("display", ""
      );

    $("#sub_scrn_bg"
 ).css("display", ""
      );
}

function sub_scrn_stop() {
    $("#sub_scrn"
     ).css("display", "none"
          );

    $("#sub_scrn_bg"
         ).css("display", "none"
              );
}

function sub_scrn2_go(
                     content,
                     topic
                     ) {
    var x = document.documentElement.clientWidth;
    x = x / 2 - 200;

    var y = document.documentElement.clientHeight;
    y = y / 2 - 200;

    $("#sub_scrn2"
 ).css("left", x
      );

    $("#sub_scrn2"
 ).css("top", y
      );

    $("#sub_scrn_topic2"
 ).html(topic
      );

    $("#sub_scrn_content2"
 ).html(content
      );

    $("#sub_scrn2"
 ).css("display", ""
      );

    $("#sub_scrn_bg2"
 ).css("display", ""
      );
}

function sub_scrn2_stop() {
    $("#sub_scrn2"
     ).css("display", "none"
          );

    $("#sub_scrn_bg2"
         ).css("display", "none"
              );
}

function edit_comps() {
    progress_go();
    c_serv++;
    var url = "/Home/edit_comps";
    $.get(url,
         {
             c_serv: c_serv
         },
    function (r) {
        progress_stop();
        r = r.split(s240
                     );
        $("#prim"
        ).html(r[0]
               )
        client = r[1];
        get_sub_comps(0);
        revise_screen();
    });
}

function get_sub_comps(
                        comp
                      ) {
    progress_go();
    var xpnd = 1;

    if (comp > 0
        ) {
        xpnd =
            $("#get_comp_img_" + comp
             ).attr("xpnd"
                   );
        if (xpnd == 0
            ) {
            $("#get_comp_img_" + comp
             ).attr("src", "../imgs/col_subs.png"
                   );
            xpnd = 1;
        }
        else {
            $("#get_comp_img_" + comp
             ).attr("src", "../imgs/get_subs.png"
                   );
            xpnd = 0;

            $("#sub_comps_" + comp
            ).html(""
                  );
        }
        $("#get_comp_img_" + comp
         ).attr("xpnd", xpnd
               );
    }
    if (xpnd == 0
        ) {
        progress_stop();
        return;
    }
    c_serv++;
    var pgt_cur = $("#pgt"
                   ).attr("cur"
                         );
    var url = "/Home/get_sub_comps";
    $.get(url,
         {
             pgt_cur: pgt_cur, client: client,
             comp: comp,
             c_serv: c_serv
         },
    function (r) {
        progress_stop();
        r = r.split(s240);
        $("#sub_comps_" + r[1]
        ).html(r[0]
              );
        if (r[2] == ""
            ) {
        }
        else {
            $("#pgt"
                ).attr("mx", r[3]
                       );
            $("#pgt"
                ).html(r[2]);
        }
    });
}

function reconc_pgt() {
    var cur =
            $("#pgt"
                ).attr("cur"
                       );
    var mx =
            $("#pgt"
                ).attr("mx"
                      );
    if (cur < 2
    )
        $("#pgt_prev"
            ).css("display", "none"
                 );
    else
        $("#pgt_prev"
            ).css("display", ""
                 );
    if (mx - 1 < cur
        )
        $("#pgt_next"
            ).css("display", "none"
                 );
    else
        $("#pgt_next"
            ).css("display", ""
                 );
}    
    
function pgt_prev() {
    var cur =
            $("#pgt"
                ).attr("cur"
                       );
    var mx =
            $("#pgt"
                ).attr("mx"
                      );

    cur = cur - 1;

    if (1 > cur
        )
        return;
    
    $("#pgt"
        ).attr("cur", cur
              )
    $("#pgt_cur"
        ).html(" " + cur
              );

    reconc_pgt();

    get_sub_comps(0);
}

function pgt_next() {
    var cur =
            $("#pgt"
                ).attr("cur"
                       );
    var mx =
            $("#pgt"
                ).attr("mx"
                      );

    cur++;

    if (cur > mx
        )
        return;

    $("#pgt"
        ).attr("cur", cur
              )

    $("#pgt_cur"
        ).html(" " + cur
              );

    reconc_pgt();

    get_sub_comps(0);
}

function unchoose(

                 )
{
    $(".comp"
       ).css("background-color", ""
           );
    $("#comp_content"
    ).html("");
} 
    function choose(
                        comp
                   )
    {
        $("#comp_" + comp
       ).css("background-color", "rgb(177, 177, 200" +
                                     ")"
              );
    }

    function get_comp(
                           comp
                     )
    {
        progress_go();
        unchoose();
        c_serv++;
        var url = "/Home/get_comp";
        $.get(url,
             {
                 comp: comp,
                 c_serv: c_serv
             },
        function (r) {
            progress_stop();
            $("#comp_content"
            ).html(r);
            choose(comp);
        });
    }

    function purge_comp(
                          comp
                       ) {
        progress_go();
        c_serv++;
        var url = "/Home/purge_comp";
        $.get(url,
             {
                 comp: comp, client: client,
                 c_serv: c_serv
             },
        function (r) {

            progress_stop();

            r = r.split(s240);

            if (r[0] == 0
                ) {
                $("#comp_content"
                   ).html("");

                get_sub_comps(r[1]);
                unchoose();
            }
            else {
                sub_scrn_go(r[1], r[2]
                           );
            }
        });
    }

    function purge_comp_subs(
                          comp
                            ) {
        progress_go();
        sub_scrn_stop();
        c_serv++;
        var url = "/Home/purge_comp_subs"
        $.get(url,
             {
                 comp: comp, client: client,
                 c_serv: c_serv
             },
        function (r) {

            progress_stop();

            $("#comp_content"
               ).html("");

            get_sub_comps(r);

            unchoose();
        });
    }

    function purge_comp_promote(
                          comp
                              ) {
        progress_go();
        sub_scrn_stop();
        c_serv++;
        var url = "/Home/purge_comp_promote";
        $.get(url,
             {
                 comp: comp, client: client,
                 c_serv: c_serv
             },
        function (r) {

            progress_stop();

            $("#comp_content"
               ).html("");

            get_sub_comps(r);

            unchoose();
        });
    }

    function create_sub_comp(
                            comp
                          ) {
        progress_go();
        c_serv++;
        var url = "/Home/create_sub_comp";
        $.get(url,
             {
                 comp: comp,
                 c_serv: c_serv
             },
        function (r) {

            progress_stop();

            r = r.split(s240);

            sub_scrn_go(r[0], r[1]
                       );
        });
    }

    function create_sub_comp2(
                            comp
                          ) {
        progress_go();
        var name = $("#create_sub_comp_name"
                    ).attr("cur");
        if (name == undefined
            )
            name = "";
        var type = $("#create_sub_comp_type"
                    ).attr("cur");
        if (type == undefined
            )
            type = 0;
        var img = $( "#create_sub_comp_img"
                   ).attr("cur");
        if (img == undefined
            )
            img = "";

        c_serv++;
        var url = "/Home/create_sub_comp2";
        $.get(url,
             {
                 super_comp: comp,
                 name: name,
                 type: type,
                 img_stg: img, client: client,
                 c_serv: c_serv
             },
        function (r) {
            progress_stop();
            r = r.split(s240);
            if (r[0] == 0
                ) 
            {
                sub_scrn_stop();
                get_sub_comps(r[1]);                         
                return;
            }
            sub_scrn2_go(r[1], "Issues"
                        );
        });
    }

    function create_sub_comp_name() {
        progress_go();
        c_serv++;
        var url = "/Home/create_sub_comp_name";
        $.get(url,
             {
                 c_serv: c_serv
             },
        function (r) {

            progress_stop();

            r = r.split(s240);

            sub_scrn2_go(r[0], r[1]
                       );
        });
    }

    function create_sub_comp_name2() {
        progress_go();
        c_serv++;

        var cur = $("#t_bo_edit_comp_name"
                    ).val();
        sub_scrn2_stop();
        cur = cur.trim();

        $("#create_sub_comp_name"
         ).attr("cur", cur
               );

        if (cur == ""
           ) cur = ni;

        $("#create_sub_comp_name_"
         ).html(cur);

        progress_stop();
    }

    function edit_comp_name(comp) {
        progress_go();
        c_serv++;
        var url = "/Home/edit_comp_name";
        $.get(url,
             {
                 comp: comp,
                 c_serv: c_serv
             },
        function (r) {

            progress_stop();

            r = r.split(s240);

            sub_scrn_go(r[0], r[1]
                       );
        });
    }

    function edit_comp_name2(comp) {
        progress_go();
        c_serv++;
        var cur = $("#t_bo_edit_comp_name"
                    ).val();
        var url = "/Home/edit_comp_name2";
        $.get(url,
             {
                 cur: cur,
                 comp: comp,
                 c_serv: c_serv
             },
        function (r) {
            progress_stop();
            sub_scrn_stop();
            r = r.split(s240);
            $("#edit_comp_name_"
                ).html(r[1]
                      );
            $("#comp_name" + "_" + r[0]
                        ).html(r[1]
                              );
        });
    }

    function create_sub_comp_type() {
        progress_go();
        c_serv++;
        var url = "/Home/create_sub_comp_type";
        $.get(url,
             {
                 c_serv: c_serv
             },
        function (r) {

            progress_stop();

            r = r.split(s240);

            sub_scrn2_go(r[0], r[1]
                       );
        });
    }

    function create_sub_comp_type2(ID, cur
                                   ) {
        progress_go();
        c_serv++;

        sub_scrn2_stop();
        cur = cur.trim();

        if (cur == ""
           ) cur = ni;

        $("#create_sub_comp_type"
         ).attr("cur", ID
                );

        $("#create_sub_comp_type_"
         ).html(cur);

        progress_stop();
    }

    function edit_comp_type(comp) {
        progress_go();
        c_serv++;
        var url = "/Home/edit_comp_type";
        $.get(url,
             {
                 comp: comp,
                 c_serv: c_serv
             },
        function (r) {

            progress_stop();

            r = r.split(s240);

            sub_scrn_go(r[0], r[1]
                       );
        });
    }

    function edit_comp_type2(ID, cur, comp
                              )
    {
        progress_go();
        c_serv++;
        var url = "/Home/edit_comp_type2";
        $.get(url,
             {
                 type: ID,
                 comp: comp,
                 c_serv: c_serv
             },
        function (r) {
            progress_stop();
            sub_scrn_stop();
            r = r.split(s240);
            $("#edit_comp_type_"
                ).html(r[1]
                      );
            $("#comp_type" + "_" + r[0]
                        ).html(r[1]
                              );
        });
    }

    function create_sub_comp_img() {
        progress_go();
        c_serv++;
        var url = "/Home/create_sub_comp_img";
        $.get(url,
             {
                 c_serv: c_serv
             },
        function (r) {

            progress_stop();

            r = r.split(s240);

            sub_scrn2_go(r[0], r[1]
                       );
        });
    }

    function create_sub_comp_img2(r) {
        sub_scrn2_stop();
        r = r.split(s240);
        progress_go();
        c_serv++;
        var src = r[3];
        $("#create_sub_comp_img_ni"
         ).css("display", "none"
               );
        $("#create_sub_comp_img_content"
            ).attr("src", src
                   );
        $("#create_sub_comp_img"
            ).attr("cur", r[1]
                   );
        $("#create_sub_comp_img"
            ).attr("format", r[2]
                   );
        progress_stop();

    }

    function edit_comp_img(comp) {
        progress_go();
        c_serv++;
        var url = "/Home/edit_comp_img";
        $.get(url,
             {
                 comp: comp,
                 c_serv: c_serv
             },
        function (r) {

            progress_stop();

            r = r.split(s240);

            sub_scrn_go(r[0], r[1]
                       );
        });
    }

    function edit_comp_img2(r, comp
                            )
    {
        sub_scrn_stop();
        r = r.split(s240);
        progress_go();
        c_serv++;
        var url = "/Home/edit_comp_img2";
        $.get(url,
             {
                 img_stg: r[1],
                 comp: comp,
                 c_serv: c_serv
             },
        function (r) {
            progress_stop();

            r = r.split(s240);
            if (r[0] == 0
                )
            {
                $("#edit_comp_img"
                 ).attr("src", r[2]
                       );
            
                $("#comp_img_" + r[1]
                 ).attr("src", r[2]
                       );
            }
        });
    }

    var cur_y = 0;
    var cur_x = 0;

    function monitor_screen() {
        var y = document.documentElement.clientHeight;
        var x = document.documentElement.clientWidth;

        if (!(y == cur_y &&
              x == cur_x
                 )
           ) {
            cur_y = y;
            cur_x = x;

            revise_screen();
        }

        setTimeout("monitor_screen();", 1000
                  );
    }

    setTimeout("monitor_screen();", 1000
              );

    function revise_screen()
    {
        $("#sub_comps_0"
         ).css("height", cur_y - 140
                 );
    }