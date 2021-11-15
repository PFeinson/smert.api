using System;

namespace smert.Models {
    public class User_Email{
        private int user_email_id {get; set;}
        private int user_id {get; set;}
        private int email_type_id {get; set;}
        private string email_address {get; set;}
        private System.DateTime create_timestamp {get; set;}
        private int create_user_id {get; set;}
        private System.DateTime suppress_timestamp {get; set;}
        private int suppress_user_id {get; set;}
    }
}