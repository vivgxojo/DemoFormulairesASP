namespace DemoFormulaires.Models
{
    public static class Magasin
    {
        public static List <Produit> produits = new List<Produit>() 
        {
            new Produit(100000000001, "Chocolat Noir", 2.9999999m),
            new Produit(100000000002, "Lait Écrémé", 1.25m),
            new Produit(100000000003, "Pain Complet", 1.75m),
            new Produit(100000000004, "Pâtes Spaghetti", 0.89m),
            new Produit(100000000005, "Jus d'Orange", 2.49m)

        };
    }
}
