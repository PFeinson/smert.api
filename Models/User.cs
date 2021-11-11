using System.DateTime;
public class User {
    private int user_id {get; set;}
    private string user_name {get; set;}
    private string email_address {get; set;}
    private string password {get; set;}
    private string title {get; set;}
    private string first_name {get; set; }
    private string middle_name {get ;set;}
    private string last_name {get; set;}
    private string suffix {get; set;}
    private int referral_user_id {get; set;}
    private DateTime create_timestamp {get; set;}
    private DateTime suppress_timestamp {get; set;}
    private int suppress_user_id {get; set;}
    private DateTime modify_timestamp {get; set;}
    private int modify_user_id {get; set;}
}