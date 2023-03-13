using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EditorValue;

public class DataFormModel : INotifyPropertyChanged
{
    private string name;
    private string password;
    private DateTime birthDate = new DateTime(1998,07,03);
    private int? age;
    private bool eligibility;
    private string city;
    private string country;
    public DataFormModel()
    {

    }

    [Display(Prompt = "Enter your name", Name = "Applicant's Name")]
    public string Name
    {
        get { return this.name; }
        set
        {
            if (value != name)
            {
                this.name = value;
                this.RaisePropertyChanged("Name");
            }
        }
    }
    
    [DataType(DataType.Password)]
    [Display(Prompt = "Enter your password", Name = "Password")]
    public string Password
    {
        get { return password; }
        set
        {
            if (value != password)
            {
                password = value;
                this.RaisePropertyChanged("Password");
            }
        }
    }

    [Display(Name = "Birth date")]
    public DateTime BirthDate
    {
        get { return birthDate; }
        set
        {
            if (value != birthDate)
            {
                birthDate = value;
                this.RaisePropertyChanged("BirthDate");
            }
        }
    }

    [Display(Prompt = "Your Age", Name = "Age")]
    public int? Age
    {
        get { return age; }
        set
        {
            if (value != age)
            {
                age = value;
                this.RaisePropertyChanged("Age");
            }
        }
    }
    public bool Eligibility
    {
        get { return this.eligibility; }
        set
        {
            if (value != eligibility)
            {
                this.eligibility = value;
                this.RaisePropertyChanged("Eligibility");
            }
        }
    }

    [Display(Name = "City")]
    public string City
    {
        get { return this.city; }
        set
        {
            if (value != city)
            {
                this.city = value;
                this.RaisePropertyChanged("City");
            }
        }
    }

    [Display(Name = "Country")]
    public string Country
    {
        get { return this.country; }
        set
        {
            if (value != country)
            {
                this.country = value;
                this.RaisePropertyChanged("Country");
            }
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
    private void RaisePropertyChanged(string propertyName)
    {
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}