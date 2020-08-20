using System.Linq;
using System.IO;
using System.Web.Http;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;

namespace mvc.Controllers
{
    public class fileController : ApiController
    {
        [HttpPost()]
        public string UploadFiles()
        {
            string s240 = (char)240 + "";
            string cur = DateTime.Now.Ticks.ToString();
            int cnt = 0;

            string sPath = "";
            sPath = System.Web.Hosting.HostingEnvironment.MapPath("~/imgs/" + "stg/"
                                                                 );

            DirectoryInfo folder = new DirectoryInfo(sPath);

            string ext = "";

            if (!folder.Exists
                )
                folder.Create();

            System.Web.HttpFileCollection hfc = System.Web.HttpContext.Current.Request.Files;
            string crypt = "";

            for (int i = 0; i <= hfc.Count - 1; i++)
            {
                System.Web.HttpPostedFile hpf = hfc[i];

                if (hpf.ContentLength > 0)
                {
                    List<string> comps = hpf.FileName.Split('.').ToList();

                    comps.Reverse();

                    ext = comps[0].ToUpper();

                    if (ext == "BMP" || ext == "PNG" || ext == "JPG"
                        )
                    {
                    }
                    else
                        return 1 + s240 + "File format must be .bmp | png | jpg";

                    string store_to = cur + "." + ext;

                    for (; File.Exists(store_to);
                        )
                    {
                        Thread.Sleep(2);
                        cur = DateTime.Now.Ticks.ToString();
                    }

                    hpf.SaveAs(sPath + store_to
                              );

                    cnt++;

                    string from = sPath + store_to;

                    string to = from.Replace(ext, "txt"
                                            );

                    Process proc = new Process();

                    proc.StartInfo.UseShellExecute = true;

                    proc.StartInfo.CreateNoWindow = true;

                    proc.StartInfo.FileName = "certutil";

                    proc.StartInfo.Arguments = " -encode " + "\"" + from +
                                                             "\" \"" + to +
                                                                 "\"";
                    proc.Start();

                    proc.WaitForExit();

                    List<string> srs = new List<string>();

                    StreamReader sr = new StreamReader(to);

                    for (; sr.Peek() > -1;
                        )
                    {
                        srs.Add(sr.ReadLine()
                                );
                    }

                    for (int ii = 1; ii < srs.Count - 1; ii++
                        )
                    {
                        crypt += srs[ii];
                    }
                }
            }
            
            if (cnt > 0)
            {
                return "0" + s240 + crypt + s240 + ext;
            }
            else
            {
                return "Upload Failed";
            }
        }
    }
}