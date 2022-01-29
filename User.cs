using System;
using System.Collections;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySqlConnector;
namespace smert.Models {
    public class User {
        [Required(ErrorMessage = "user id is required")]
        public int? userId {get; set;}
        [Required(ErrorMessage = "user name is required")]
        public string userName {get; set;}
        #nullable enable
        public string? emailAddress {get; set;}
        [Required(ErrorMessage = "password is required")]
        public string? password {get; set;}
        #nullable enable
        public string? title {get; set;}
        #nullable enable
        public string? firstName {get; set; }
        #nullable enable
        public string? middleName {get ;set;}
        #nullable enable
        public string? lastName {get; set;}
        #nullable enable
        public string? suffix {get; set;}
        #nullable enable
        public string? gender {get; set;}
        public int? referralUserId {get; set;}
        [Required(ErrorMessage = "creation timestamp is required")]
        public DateTime? createTimestamp {get; set;}
        #nullable enable
        public DateTime? suppressTimestamp {get; set;}
        #nullable enable
        public int? suppressUserId {get; set;}
        #nullable enable
        public DateTime? modifyTimestamp {get; set;}
        #nullable enable
        public int? modifyUserId {get; set;}
    }
}
