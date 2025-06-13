using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ModelMetadata = System.Web.Mvc.ModelMetadata;
using ControllerContext = System.Web.Mvc.ControllerContext;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;


namespace DemoFormulaires.Models
{

    public class CodeBarreValideAttribute : ValidationAttribute, IClientModelValidator //, IClientValidatable
    {
        public override bool IsValid(object value)
        {
            var str = value.ToString();
            ErrorMessage = ErrorMessage ?? "Le code-barres doit commencer par 100 et contenir 8 chiffres.";
            return str.StartsWith("100") && str.Length == 8;
        }

        //VALIDATION CLIENT
        public void AddValidation(ClientModelValidationContext context)
        {
            context.Attributes.Add("data-val", "true");
            context.Attributes.Add("data-val-codebarrevalide", /*ErrorMessage ??*/ "Le code-barres doit commencer par 1000 et contenir 8 chiffres.");
        }


        //PAS COMPATIBLE AVEC .NET CORE
        /*
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {

            yield return new ModelClientValidationRule
            {
                ValidationType = "codebarrevalide", 
                ErrorMessage = FormatErrorMessage(metadata.DisplayName)
            };
            /*
            List<ModelClientValidationRule> liste = new List<ModelClientValidationRule>();
            liste.Add(new ModelClientValidationRule()
            {
                ValidationType = "codebarrevalide",
                ErrorMessage = FormatErrorMessage(metadata.DisplayName)
            });
            return liste;
            */
        }
        */
    }
}
