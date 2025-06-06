using DemoFormulaires.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoFormulaires.Controllers
{
    public class EpicerieController : Controller
    {
        List<Produit> produits = Magasin.produits;
        public IActionResult Index()
        {
            return View(produits);
        }

        public IActionResult Produit(string id)
        {
            Produit produit = produits.FirstOrDefault(p => p.CodeBarre == id);
            return View(produit);
        }

        public IActionResult Nouveau()
        {
            return View();
        }

        public IActionResult Ajouter(Produit produit)
        {
            if (ModelState.IsValid)
            {
                produits.Add(produit);
                return RedirectToAction("Index");
            }
            return View("Nouveau", produit);
        }
    }
}
