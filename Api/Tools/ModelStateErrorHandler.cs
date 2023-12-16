using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text;

namespace Api
{
    public static class ModelStateErrorHandler
    {
        /// <summary>
        /// Returns a Key/Value pair with all the errors in the model
        /// according to the data annotation properties.
        /// </summary>
        /// <param name="errDictionary"></param>
        /// <returns>
        /// Key: Name of the property
        /// Value: The error message returned from data annotation
        /// </returns>
        public static Dictionary<string, string> GetModelErrorsDic(this ModelStateDictionary errDictionary)
        {
            var errors = new Dictionary<string, string>();
            var err = errDictionary.Where(k => k.Value.Errors.Count > 0);
            if (err.Any())
            {
                foreach (var item in err)
                {
                    var er = string.Join(", ", item.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                    errors.Add(item.Key, er);
                };
            }
            return errors;
        }

        public static string[] GetModelErrors(this ModelStateDictionary errDictionary)
        {
            var errors = new List<string>();
            var err = errDictionary.Where(k => k.Value.Errors.Count > 0);
            if (err.Any())
            {
                foreach (var item in err)
                {
                    var er = string.Join(", ", item.Value.Errors.Select(e => e.ErrorMessage).ToArray());
                    errors.Add(er);
                };
            }
            return errors.ToArray();
        }

        public static string StringifyModelErrors(ModelStateDictionary errDictionary)
        {
            var errorsBuilder = new StringBuilder();
            var errors = errDictionary.GetModelErrorsDic();
            foreach (var key in errors)
            {
                errorsBuilder.AppendFormat("{0}: {1} -", key.Key, key.Value);
            }
            return errorsBuilder.ToString();
        }
    }

}
