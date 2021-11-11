using System.DateTime;

public class User_Subject_Matter_Expert_Status {
    private int user_subject_matter_expert_status_id {get; set;}
    private int user_id {get; set;}
    private int subject_matter_expert_status_id {get; set;}
    private string subject_matter_expert_status_notes {get; set;}
    private DateTime create_timestamp {get; set;}
    private int create_user_id {get; set;}
    private DateTime suppress_timestamp {get; set;}
    private int suppress_user_id {get; set;}
}