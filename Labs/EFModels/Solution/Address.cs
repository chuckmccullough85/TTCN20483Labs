using System.Text.RegularExpressions;
using static Utility.Validator;

namespace Payroll;
public enum UsState
{
    AL, AK, AZ, AR, CA, CO, CT, DE, FL, GA, HI, ID, IL, IN, IA, KS, KY, LA, ME, MD, MA, MI, MN, MS, MO, MT, NE, NV, NH, NJ, NM, NY, NC, ND, OH, OK, OR, PA, RI, SC, SD, TN, TX, UT, VT, VA, WA, WV, WI, WY
}

public class Address
{
    string street ="";
    string city = "";
    string zip = "";
    public Address() { }
    public const string NamePattern = @"^[a-zA-Z0-9\s.'-]{2,50}$";
    public const string ZipPattern = @"^\d{5}(-\d{4})?$";
    public Address(string Street, string City, UsState State, string Zip)
    {
        this.Street = Street;
        this.City = City;
        this.State = State;
        this.Zip = Zip;
    }
    public int Id { get; set; }
    public UsState State { get; set; }
    public string Street { get => street; set => street = ValidateRegex(value, NamePattern); }
    public string City { get => city; set => city = ValidateRegex(value, NamePattern); }
    public string Zip { get => zip; set => zip = ValidateRegex(value, ZipPattern); }
}