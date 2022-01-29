using System;

namespace smert.Models.DTO {
    public class UserDTO {
        public int user_id {get; set;}
        public string user_name {get; set;}
        public string? email_address {get; set;}
        public string password {get; set;}
        public string? title {get; set;}
        public string? first_name {get; set; }
        public string? middle_name {get ;set;}
        public string? last_name {get; set;}
        public string? suffix {get; set;}
        public string? gender {get; set;}
        public int? referall_user_id {get; set;}
        public DateTime create_time_stamp {get; set;}
        public DateTime? suppress_time_stamp {get; set;}
        public int? suppress_user_id {get; set;}
        public DateTime? modify_time_stamp {get; set;}
        public int? modify_user_id {get; set;}
    }
}