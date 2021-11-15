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
        private string? email_address {get; set;}
        [Required(ErrorMessage = "password is required")]
        private string password {get; set;}
        private string? title {get; set;}
        private string? first_name {get; set; }
        private string? middle_name {get ;set;}
        private string? last_name {get; set;}
        private string? suffix {get; set;}
        private string? gender {get; set;}
        private int? referral_user_id {get; set;}
        [Required(ErrorMessage = "creation timestamp is required")]
        private DateTime create_timestamp {get; set;}
        private DateTime? suppress_timestamp {get; set;}
        private int? suppress_user_id {get; set;}
        private DateTime? modify_timestamp {get; set;}
        private int? modify_user_id {get; set;}
    }
}
