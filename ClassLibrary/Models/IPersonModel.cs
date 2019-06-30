namespace ClassLibrary.Models
{
    public interface IPersonModel
    {
        string email { get; set; }
        string emergencyContact { get; set; }
        string emergencyContactNo { get; set; }
        string firstName { get; set; }
        string lastName { get; set; }
        string middleName { get; set; }
        string mobile { get; set; }
        int personID { get; set; }
    }
}