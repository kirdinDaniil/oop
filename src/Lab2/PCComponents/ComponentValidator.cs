using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Itmo.ObjectOrientedProgramming.Lab2.PCComponents;

public static class ComponentValidator
 {
     public static void ValidateObject(object component)
     {
         var context = new ValidationContext(component);
         var results = new List<ValidationResult>();
         if (Validator.TryValidateObject(component, context, results, true)) return;
         var exceptionText = new StringBuilder();
         exceptionText.Append("\nFailed to create an object " + component?.GetType().Name + "\n");
         foreach (ValidationResult error in results)
         {
             exceptionText.Append(error.ErrorMessage + '\n');
         }

         throw new PcComponentsException(exceptionText.ToString());
     }
 }