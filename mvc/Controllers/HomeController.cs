using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc.business;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        public string s240 = "" + (char)240;

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public string get_sub_comps(
                                    int comp
                                   )
        {
            List<component_p> comps = components_p.get_sub_comps(0);

            string r = "";

            foreach (component_p c in comps
                      )
            {
                r += "<div " +
                           "class = 'get_sub' " +
                           "onclick = 'get_sub_comps(" + c.ID +
                                                   ");" +
                                     "'" +
                     ">";

                r += "+";

                r += "</div>";

                r += "<div " +
                           "class = 'l'" +
                     ">";

                r += c.name;

                r += "</div>";

                r += "<div " +
                           "class = 'cls'" +
                     ">";

                r += "</div>";
            }

            return r + s240 + comp;
        }

        public string returnn2(string prm
                              )
        {
            return "returnn " + prm;
        }

    }
}

