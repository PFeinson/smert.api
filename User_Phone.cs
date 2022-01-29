using System;

namespace smert.Models {
    public class User_Phone{
        private int user_phone_id {get; set;}
        private int user_id {get; set;}
        private string phone_country_code {get; set;}
        private string phone_number {get; set;}
        private string phone_extension {get; set;}
        private int is_primarty_phone {get; set;}
        private DateTime create_timestamp {get; set;}
        private int create_user_id {get; set;}
        private DateTime suppress_timestamp {get; set;}
        private int suppress_user_id {get; set;}
    }
}