using System;

namespace smert.Models {
    public class User_Address{
        private int user_address_id {get; set;}
        private int user_id {get; set;}
        private string full_address {get; set;}
        private string city {get; set;}
        private string state {get; set;}
        private string postal_code {get; set;}
        private string zip4 {get; set;}
        private double latitude {get; set;}
        private double longitude {get; set;}
        private int is_primary_address {get; set;}
        private DateTime create_timestamp {get; set;}
        private int create_user_id {get; set;}
        private DateTime suppress_timestamp {get; set;}
        private int suppress_user_id {get; set;}
    }
}