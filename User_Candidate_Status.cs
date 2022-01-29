using System;

namespace smert.Models {
    public class User_Candidate_Status{
        private int user_candidate_status_id {get; set;}
        private int user_id {get; set;}
        private int candidate_status_id {get; set;}
        private string candidate_status_notes {get; set;}
        private System.DateTime create_timestamp {get; set;}
        private int create_user_id {get; set;}
        private System.DateTime suppress_timestamp {get; set;}
        private string suppress_user_id {get; set;}
    }
}