using System;
using System.Collections;
using System.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySqlConnector;
namespace smert.Models {
    public class User {
        [Required(ErrorMessage = "user id is required")]
        private int userId {get; set;}
        [Required(ErrorMessage = "user name is required")]
        private string userName {get; set;}
        #nullable enable
        private string? emailAddress {get; set;}
        [Required(ErrorMessage = "password is required")]
        private string password {get; set;}
        #nullable enable
        private string? title {get; set;}
        #nullable enable
        private string? firstName {get; set; }
        #nullable enable
        private string? middleName {get ;set;}
        #nullable enable
        private string? lastName {get; set;}
        #nullable enable
        private string? suffix {get; set;}
        #nullable enable
        private string? gender {get; set;}
        private int? referralUserId {get; set;}
        [Required(ErrorMessage = "creation timestamp is required")]
        private DateTime createTimestamp {get; set;}
        #nullable enable
        private DateTime? suppressTimestamp {get; set;}
        #nullable enable
        private int? suppressUserId {get; set;}
        #nullable enable
        private DateTime? modifyTimestamp {get; set;}
        #nullable enable
        private int? modifyUserId {get; set;}
    }
}
