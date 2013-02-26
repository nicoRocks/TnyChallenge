using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TnyGames.Morpion;

namespace NicoRocks.Controllers
{
    public class TnyTictacpionController : Controller
    {

        public ActionResult Gamble()
        {
            var a = Request.QueryString["Game"];
            var b = Request.QueryString["MoveId"];
            var c = Request.QueryString["Referee"];
            var m1 = Request.QueryString["Move1"];
            var m2 = Request.QueryString["Move2"];
            int? dernierCoup=null;
            if (m1 != null)
            {
                dernierCoup = int.Parse(m1);
            }
            else if (m2 != null)
            {
                dernierCoup = int.Parse(m2);
            }
            var e = Request.QueryString["Tray"];
            e = e ?? "000000000";
            e = e== "init" ? "000000000":e;
            Moteur moteur = new Moteur();
            var d = moteur.GetValue(e,dernierCoup);
            var url = c + "?Game=" + a + "&MoveId=" + b + "&Value=" + d;


            return Redirect(url);
        }
    }
}
