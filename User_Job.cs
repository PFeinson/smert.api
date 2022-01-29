using System;

namespace smert.Models {
    public class User_Job{
        private int user_job_id {get; set;}
        private int user_id {get; set;}
        private int job_id {get; set;}
        private DateTime application_date {get; set;}
        private DateTime interview_date {get; set;}
        private DateTime start_date {get; set;}
        private DateTime end_date {get; set;}
        private DateTime create_timestamp {get; set;}
        private int create_user_id {get; set;}
        private DateTime suppress_timestamp {get; set;}
        private int suppress_user_id {get; set;}
        private DateTime modify_timestamp {get; set;}
        private string modify_user_id {get; set;}
    }
}