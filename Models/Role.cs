using System;

namespace smert.Models {
    public class Role {
        private int role_id {get; set;}
        private string role_name {get; set;}
        private DateTime create_timestamp {get; set;}
        private int is_active {get; set;}
    }
}