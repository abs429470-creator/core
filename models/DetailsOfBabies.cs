namespace core.Models;
//מחלקה המיצגת פרטי תינוק בתינוקיה
public class DetailsOfBaby
{
    //פרטי תינוק
    //תעודת זהות
    public int babyId { get; set; }
    //שם, אם קיים
    public string? babyName { get; set; }
    //מספר העריסה בה הוא שוכב
    public int cribNumber { get; set; }
    //תעריך לידה
    public DateTime timeOfBirth { get; set; }
    //משקל
    public double babiesWeight { get; set; }
    // //פרטי האם
    // //תעודת זהות
    // public int motherId { get; set; }
    // //שם מלא
    // public string motherFullName  { get; set; }
    // //מספר טלפון ליצירת קשר
    // public string motherPhone { get; set; }
    // //פרטי האב
    // //תעודת זהות
    // public int fatherId { get; set; }
    // //שם מלא
    // public string fatherFullName  { get; set; }
    // //מספר טלפון ליצירת קשר
    // public string fatherPhone { get; set; }
}
