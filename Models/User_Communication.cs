using System;

public class User_Communication{
    private int user_communication_id {get; set;}
    private int user_id {get; set;}
    private int communication_type_id {get; set;}
    private int communication_result_id {get; set;}
    private string communication_notes {get; set;}
    private DateTime communication_datetime {get; set;}
    private DateTime followup_datetime {get; set;}
    private DateTime create_timestamp {get; set;}
    private int create_user_id {get; set;}
    private int create_role_id {get; set;}
    private DateTime suppress_timestamp {get; set;}
    private int suppress_user_id {get; set;}
}