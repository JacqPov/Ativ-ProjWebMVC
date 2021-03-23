using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Data;
using Model;

namespace ProjWebMVC.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Dog
        public ActionResult Index()
        {
            var lst = this.Crud().Select();
            return View(lst);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost] //envia as info via post

        [ValidateAntiForgeryToken] //evita que surja falsificação, valida requisições estrangeiras a essa aplicação

        public ActionResult Create(Pizza pizza)
        {
            if (ModelState.IsValid) //valida se info estão preenchidas corretamente
            {
                this.Crud().Insert(pizza); 
                return RedirectToAction("Index");
            }
            return View(pizza);//se modelo não é valido irá continuar como está
        }

        public ActionResult Edit(int id)
        {
            var pizza = this.Crud().SelectById(id);//consulta pelo id para retornar dog para processo de alteração
            return View(pizza);
        }

        public ActionResult Edit(Pizza pizza) //nome tem que ser o mesmo no processo de crud
        {
            if (ModelState.IsValid)
            {
                this.Crud().Update(pizza);
                return RedirectToAction("Index");
            }
            return View(pizza);
        }

        public ActionResult Details(int id)
        {
            var pizza = this.Crud().SelectById(id);
            return View(pizza);
        }

        public ActionResult Delete(int id)
        {
            var pizza = this.Crud().SelectById(id);
            return View(pizza);
        }

        [HttpPost, ActionName("Delete")]//pode utilizar metodos com o mesmo nome
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(int id)
        {
            this.Crud().Delete(id);
            return RedirectToAction("Index");
        }


        private IPizzaDB Crud()
        {
            return new PizzaDB();
        }
    }
}