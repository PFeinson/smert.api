using System.Linq;
using smert.Models;
using System.Text.RegularExpressions;

namespace smert.Utility {
    public class ValidationUtils {
        public static InternalResponseMessage validateUserName(string userName) {
            var validationResponse = new InternalResponseMessage();
            if (!(userName.Length > 0 )) {
                validationResponse.content.Add("Username too short! Must be at least 2 characters!");
            }
            if (Regex.IsMatch(userName, @"[a-zA-Z0-9@]")) {
                validationResponse.content.Add("Username contains symbols! (Except: @");
            }
            if (validationResponse.content.Count == 0) {
                validationResponse.result = true;
            } else {
                validationResponse.result = false;
            }
            return validationResponse;
        }

        public static InternalResponseMessage validateEmail(string emailAddress) {
            var validationResponse = new InternalResponseMessage();
            if (!(emailAddress.Length > 0 )) {
                validationResponse.content.Add("Email cannot be blank!");
            }
            if (Regex.IsMatch(emailAddress, @"[a-zA-Z0-9]@[a-zA-Z0-9].[{3}[a-zA-Z]")) {
                validationResponse.content.Add("Email must match format someusername@somedomain.com !");
            }
            if (validationResponse.content.Count == 0) {
                validationResponse.result = true;
            } else {
                validationResponse.result = false;
            }
            return validationResponse;
        }
         
         public static InternalResponseMessage validatePassword(string password) {
            var validationResponse = new InternalResponseMessage();
            if (!(password.Length > 0 )) {
                validationResponse.content.Add("Username too short! Must be at least 2 characters!");
            }
            if (Regex.IsMatch(password, @"[a-zA-Z0-9@]")) {
                validationResponse.content.Add("Username contains symbols! (Except: @");
            }
            if (validationResponse.content.Count == 0) {
                validationResponse.result = true;
            } else {
                validationResponse.result = false;
            }
            return validationResponse;
        }
         
        public static InternalResponseMessage validateFirstName(string firstName) {
            var validationResponse = new InternalResponseMessage();
            if (!(firstName != null)) {
                if (!(firstName.Length > 0 )) {
                    validationResponse.content.Add("First Name too short! Must be at least 2 characters!");
                }
                if (Regex.IsMatch(firstName, @"[a-zA-Z-.'\s]")) {
                    validationResponse.content.Add("First Name can only be letters, periods, hyphens and apostraphes!");
                }
                if (validationResponse.content.Count == 0) {
                    validationResponse.result = true;
                } else {
                    validationResponse.result = false;
                }
            } else {
                validationResponse.result = true;
            }
            return validationResponse;
        }

        public static InternalResponseMessage validateMiddleName(string middleName) {
            var validationResponse = new InternalResponseMessage();
            if (middleName != null) {
                if (!(middleName.Length > 0)) {
                    validationResponse.content.Add("Middle Name too short! Must be at least 2 characters!");
                }
                if (Regex.IsMatch(middleName, @"[a-zA-Z0-9@-.'\s]")) {
                    validationResponse.content.Add("Middle Name can only be letters, periods, hyphens and apostraphes!");
                }
                if (validationResponse.content.Count == 0) {
                    validationResponse.result = true;
                } else {
                    validationResponse.result = false;
                }
            } else {
                validationResponse.result = true;
            }
            return validationResponse;
        }

        public static InternalResponseMessage validateLastName(string lastName) {            
            var validationResponse = new InternalResponseMessage();
            if (lastName != null) { 
                if (!(lastName.Length > 0 )) {
                    validationResponse.content.Add("Username too short! Must be at least 2 characters!");
                }
                if (Regex.IsMatch(lastName, @"[a-zA-Z0-9@]")) {
                    validationResponse.content.Add("Username contains symbols! (Except: @");
                }
                if (validationResponse.content.Count == 0) {
                    validationResponse.result = true;
                } else {
                    validationResponse.result = false;
                }
            } else {
                validationResponse.result = true;
            }
            return validationResponse;
        }

        // This needs to be in the repository : Validate referenced user exists!
        /*
        public static async Task<bool> validateReferalUserId(int referralUserId) {
            var validationResponse = new InternalResponseMessage();
            if (!userName.Length > 0 ) {
                validationResponse.content.Add("Username too short! Must be at least 2 characters!");
            }
            if (IsMatch(userName, @"[a-zA-Z0-9@]")) {
                validationResponse.content.Add("Username contains symbols! (Except: @");
            }
            if (validationResponse.content.Count == 0) {
                validationResponse.result = true;
            } else {
                validationResponse.result = false;
            }
            return validationResponse;
        }
        */
    }
}
