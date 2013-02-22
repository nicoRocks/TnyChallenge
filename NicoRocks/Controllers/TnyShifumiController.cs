using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NicoRocks.Controllers
{
    public class TnyShifumiController : Controller
    {
        static Random rnd = new Random();
        static int getRandom(int faces)
        {
            return rnd.Next(faces) + 1;
        }
        //
        // GET: /TnyShifumi/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /TnyShifumi/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /TnyShifumi/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /TnyShifumi/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /TnyShifumi/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /TnyShifumi/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /TnyShifumi/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /TnyShifumi/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public void Gamble()
        {
            /*
             
           <?php
//Entrées
$Partie=$_REQUEST['Game']; //On récupère le nom de partie
$MoveId=$_REQUEST['MoveId']; //On récupère le MoveId
$Arbitre=$_REQUEST['Referee']; //On récupère l'URL de l'arbitre
//Elaboration du jeu
$Valeur=mt_rand(1,3); //On choisit son coup
//Sorties : On construit l'URL cible
if ($Arbitre=='') {print $Valeur;} else {
$URL=$Arbitre.'?Game='.$Partie.'&MoveId='.$MoveId.'&Value='.$Valeur;
fopen($URL,"r"); } //On transmet à l'arbitre
//si fopen pose problème, essayer readfile()
?>
             
             
             */
            var a = Request.QueryString["Game"];
            var b = Request.QueryString["MoveId"];
            var c = Request.QueryString["Referee"];
            var d = getRandom(3);
            var url = c + "?Game=" + a + "&MoveId=" + b + "&Value=" + d;
            

             Redirect(url);
             ;
        } 
    }
}

