
namespace Application.Common
{
    public class CheckPasswordValidation<TResult>
    {
        public TResult Result { get; private set; }
        public bool Success { get; private set; }
        public string ErrorMessage { get; private set; }

        public static CheckPasswordValidation<TResult> CheckPassword(string password)
        {
            if (password.Length < 8)
                return new CheckPasswordValidation<TResult> { Success = false, ErrorMessage = "پسورد نمی تواند کوچک تر از 8 کاراکتر باشد." };

            //if (Regex.Match(password, @"/\d+/", RegexOptions.ECMAScript).Success)

            if (!password.Any(char.IsUpper))
                return new CheckPasswordValidation<TResult> { Success = false, ErrorMessage = "اسنفاده از حروف بزرگ در پسورد اجباری می باشد." };

            if (password.Contains(" "))
                return new CheckPasswordValidation<TResult> { Success = false, ErrorMessage = "اسنفاده از فاصله در پسورد مجاز نمی باشد." };

            string specialCh = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
            char[] specialChArray = specialCh.ToCharArray();
            var hasSpecialChar = false;
            foreach (char ch in specialChArray)
            {
                if (password.Contains(ch))
                    hasSpecialChar = true;
            }
            if (!hasSpecialChar)
                return new CheckPasswordValidation<TResult> { Success = false, ErrorMessage = "اسنفاده از علائم در پسورد اجباری می باشد." };
            return new CheckPasswordValidation<TResult> { Success = true, ErrorMessage = "" };
        }
    }
}
