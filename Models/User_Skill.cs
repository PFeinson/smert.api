using System;

namespace smert.Models {
    public class User_Skill{
        private int user_skill_id {get; set;}
        private int user_id {get; set;}
        private int skill_id {get; set;}
        private int skill_level {get; set;}
        private string skill_level_notes {get; set;}
        private double years_of_experience {get; set;}
        private DateTime create_timestamp {get; set;}
        private int create_user_role_id {get; set;}
        private DateTime suppress_timestamp {get; set;}
        private string suppress_user_id {get; set;}
    }
}