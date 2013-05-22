using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MobileServices.Common.Attributes {

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public class InjectionValidatorAttribute : ValidationAttribute {
        
        public override bool IsValid(object value) {
            return Validate((string)value);
        }

        private bool Validate(string value) {

            var validationPatterns = new List<Regex>() {
                // SQL Injection patterns
                new Regex(@"(\%27)|(\')|(\-\-)|(\%23)|(\#)", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace),
                new Regex(@"((\%3D)|(=))[^\n]*((\%27)|(\')|(\-\-)|(\%3B)|(;))", RegexOptions.Compiled | RegexOptions.IgnoreCase),
                new Regex(@"\w*((\%27)|(\'))((\%6F)|o|(\%4F))((\%72)|r|(\%52))", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace),
                new Regex(@"((\%27)|(\'))union", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace),
                new Regex(@"((\%27)|(\'))drop", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace),
                new Regex(@"((\%27)|(\'))delete", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace),
                new Regex(@"((\%27)|(\'))insert", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace),
                //new Regex(@"exec(\s|\+)+(s|x)p\w+", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace),

                // Xss Injection patterns
                new Regex(@"((\%3C)|<)((\%2F)|\/)*[a-z0-9\%]+((\%3E)|>)", RegexOptions.Compiled | RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace),
                new Regex(@"((\%3C)|<)((\%69)|i|(\%49))((\%6D)|m|(\%4D))((\%67)|g|(\%47))[^\n]+((\%3E)|>)", RegexOptions.Compiled | RegexOptions.IgnoreCase),
                new Regex(@"((\%3C)|<)[^\n]+((\%3E)|>)", RegexOptions.Compiled | RegexOptions.IgnoreCase)
            };

            var result = false;
            foreach (var pattern in validationPatterns) {
                result = pattern.IsMatch(value);
                if (result)
                    break;
            }

            return !result;
        }
    }
}