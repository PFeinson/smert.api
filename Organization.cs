using System;

namespace smert.Models {
    public class Organization{
        private int organization_id {get; set;}
        private string organization_name {get; set;}
        private string organization_website {get; set;}
        private string full_address {get; set;}
        private string city {get; set;}
        private string state {get; set;}
        private string postal_code {get; set;}
        private string organization_zip4 {get; set;}
        private double latitude {get; set;}
        private double longitude {get; set;}
        private byte organization_logo {get; set;}
        private string organization_description {get; set;}
        private string organization_type_id {get; set;}
        private string industry_type_name {get; set;}
        private int number_of_employees {get; set;}
        private DateTime create_timestamp {get; set;}
        private int create_user_id {get; set;}
        private DateTime suppress_timestamp {get; set;}
        private int suppress_user_id {get; set;}
        private DateTime modify_temestamp {get; set;}
        private int modify_user_id {get; set;}
    }
}