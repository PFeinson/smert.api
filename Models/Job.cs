using System;

namespace smert.Models {
    public class Job{
        private int job_id {get; set;}
        private int organization_id {get; set;}
        private string job_title {get; set;}
        private string job_description {get; set;}
        private string job_description_file {get; set;}
        private DateTime job_open_date {get; set;}
        private DateTime job_close_date {get; set;}
        private DateTime job_start_date {get; set;}
        private int compensation_amount {get; set;}
        private int total_compensation_amount {get; set;}
        private int number_of_openings {get; set;}
        private string job_postal_code {get; set;}
        private double job_latitude {get; set;}
        private double job_longitude {get; set;}
        private DateTime create_timestamp {get; set;}
        private int create_user_id {get; set;}
        private DateTime suppress_timestamp {get; set;}
        private int suppress_user_id {get; set;}
        private DateTime modify_timestamp {get; set;}
        private int modify_user_id {get; set;}
    }
}