using System;

namespace smert.Models {
    public class Communication_Type{
        private int communication_type_id {get; set;}
        private string communication_type_name {get; set;}
        private DateTime create_timestamp {get; set;}
        private int is_active {get; set;}
    }
}