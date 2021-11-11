using System.DateTime;

public class Job_Certification{
    private int job_certification_id {get; set;}
    private int job_id {get; set;}
    private string certification_name {get; set;}
    private DateTime create_timestamp {get; set;}
    private int create_user_id {get; set;}
    private DateTime suppress_timestamp {get; set;}
    private int suppress_user_id {get; set;}
}