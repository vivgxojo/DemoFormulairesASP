using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace DemoFormulaires.Models
{

    public class CodeBarreValideAttribute : ValidationAttribute, IClientModelValidator
    {
        public override bool IsValid(object value)
        {
            var str = value.ToString();
            // = ErrorMessage si ErrorMessage existe ou = "..." sinon
            ErrorMessage = ErrorMessage ?? "Le code-barres doit commencer par 100 et contenir 8 chiffres.";
            return str.StartsWith("100") && str.Length == 8;
        }

        //VALIDATION CLIENT
        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            //Ajouter l'attribut "data-val-codebarrevalide" pour lier à la validation JQuery
            context.Attributes.Add("data-val-codebarrevalide", /*ErrorMessage ??*/ 
                "Le code-barres doit commencer par 1000 et contenir 8 chiffres.");
        }

    }
}
