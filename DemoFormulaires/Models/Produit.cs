using System.ComponentModel.DataAnnotations;

namespace DemoFormulaires.Models
{
    public class Produit : IValidatableObject
    {
        List<ValidationResult> results = new List<ValidationResult>();

        [Required(ErrorMessage ="Ce champ est obligatoire.")]
        [Display(Name = "Code barre")]
        [Range(10000000, long.MaxValue, ErrorMessage = "Le code barre doit avoir au moins 8 chiffres")]
        [CodeBarreValide(ErrorMessage = "Le code-barres doit commencer par 100 et contenir 8 chiffres.")]
        public long CodeBarre { get; set; }

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage =
        "Le champ Nom doit commencer par une majuscule et contenir uniquement des lettres.")]
        public string Nom { get; set; }

        private decimal _prix;

        [Required(ErrorMessage = "Ce champ est obligatoire.")]
        [DataType("decimal", ErrorMessage ="Entrez un prix")]
        //[Range(0.01, double.MaxValue, ErrorMessage = "Le prix doit être plus grand que 0.")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public string Prix { 
            get { return string.Format("{0:C2}",_prix); }
            set {
                if (value == "")
                {
                    results.Add(new ValidationResult("Entrez un prix", new[] { "Prix" }));
                }
                else
                {
                    try
                    {
                        decimal p = decimal.Parse(value);
                        if (p < 0)
                        {
                            results.Add(new ValidationResult("Le prix doit être positif", new[] { "Prix" }));
                        }
                        _prix = p;
                    }
                    catch(Exception e)
                    {
                        results.Add(new ValidationResult("Le prix doit être un nombre", new[] { "Prix" }));
                    }
                }
            } 
        }

        public Produit() { }
        public Produit(long codeBarre, string nom, decimal prix)
        {
            CodeBarre = codeBarre;
            Nom = nom;
            Prix = prix.ToString();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return results;
        }
    }
}
