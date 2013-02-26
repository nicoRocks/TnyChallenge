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
            var e = Request.QueryString["Tray"];
            e = e ?? "000000000";
            e = e== "init" ? "000000000":e;
            Moteur moteur = new Moteur();
            var d = moteur.GetValue(e);
            var url = c + "?Game=" + a + "&MoveId=" + b + "&Value=" + d;


            return Redirect(url);
        }
    }
}
