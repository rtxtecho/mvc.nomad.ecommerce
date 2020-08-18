var s240 = String.fromCharCode(240);
var ni = "<i>Not Identified</i>"

c_serv = 0;

$.ajax({ cache: false });

$.ajaxSetup({
    // Disable caching of AJAX responses
    cache: false
});

function get_sub_comps(
                        comp
                      )
{
    progress_go();
    c_serv++;
    var url = "/Home/get_sub_comps";
    $.get(url,
         {
             comp: comp,
             c_serv: c_serv
         },
    function (r) {
        progress_stop();
        r = r.split(s240);
        $("#sub_comps_" + r[1]
        ).html(r[0]);        
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
    var name = $("#create_sub_comp_name_"
                ).html();
    var type = $("#create_sub_comp_type"
                ).attr("cur");
    c_serv++;
    var url = "/Home/create_sub_comp2";
    $.get(url,
         {
             super_comp: comp,
             name: name,
             type: type,
             c_serv: c_serv
         },
    function (r) {

        progress_stop();

        r = r.split(s240);

        sub_scrn_go(r[0], r[1]
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

    var cur = $("#t_bo_create_sub_comp_name"
                ).val();
sub_scrn2_stop();
    cur = cur.trim();

    if (cur == ""
       ) cur = ni;

    $("#create_sub_comp_name_"
     ).html(cur);

    progress_stop();

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

function sub_scrn2_stop()
{
    $("#sub_scrn2"
     ).css("display", "none"
          );

    $("#sub_scrn_bg2"
         ).css("display", "none"
              );
}