using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using ModelMetadata = System.Web.Mvc.ModelMetadata;
using ControllerContext = System.Web.Mvc.ControllerContext;


namespace DemoFormulaires.Models
{

    public class CodeBarreValideAttribute : ValidationAttribute, IClientValidatable
    {
        public override bool IsValid(object value)
        {
            var str = value.ToString();
            return str.StartsWith("100") && str.Length == 8;
        }

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

    }
}
