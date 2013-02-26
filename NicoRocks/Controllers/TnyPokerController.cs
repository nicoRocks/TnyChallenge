using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TnyGames.Poker;

namespace NicoRocks.Controllers
{
    public class TnyPokerController : Controller
    {
        //
        // GET: /TnyPoker/

        public ActionResult Gamble()
        {
            var a = Request.QueryString["Game"];
            var b = Request.QueryString["MoveId"];
            var c = Request.QueryString["Referee"];
            var m1 = Request.QueryString["Move1"];
            var m2 = Request.QueryString["Move2"];
            var e = Request.QueryString["Tray"];
            Moteur moteur = new Moteur();
            var d = moteur.GetValue(e);
            var url = c + "?Game=" + a + "&MoveId=" + b + "&Value=" + d;


            return Redirect(url);
        }

       
    }
}
