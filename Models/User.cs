using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace smert.Models {
    public class User {
        [Required(ErrorMessage = "user id is required")]
        private int user_id {get; set;}
        [Required(ErrorMessage = "user name is required")]
        private string user_name {get; set;}
        #nullable enable
        private string? email_address {get; set;}
        [Required(ErrorMessage = "password is required")]
        private string password {get; set;}
        #nullable enable
        private string? title {get; set;}
        #nullable enable
        private string? first_name {get; set; }
        #nullable enable
        private string? middle_name {get ;set;}
        #nullable enable
        private string? last_name {get; set;}
        #nullable enable
        private string? suffix {get; set;}
        #nullable enable
        private string? gender {get; set;}
        private int? referral_user_id {get; set;}
        [Required(ErrorMessage = "creation timestamp is required")]
        private DateTime create_timestamp {get; set;}
        #nullable enable
        private DateTime? suppress_timestamp {get; set;}
        #nullable enable
        private int? suppress_user_id {get; set;}
        #nullable enable
        private DateTime? modify_timestamp {get; set;}
        #nullable enable
        private int? modify_user_id {get; set;}
    }
}
