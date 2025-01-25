using System.Text.RegularExpressions;
using static Utility.Validator;

namespace Payroll;
public enum UsState
{
    AL, AK, AZ, AR, CA, CO, CT, DE, FL, GA, HI, ID, IL, IN, IA, KS, KY, LA, ME, MD, MA, MI, MN, MS, MO, MT, NE, NV, NH, NJ, NM, NY, NC, ND, OH, OK, OR, PA, RI, SC, SD, TN, TX, UT, VT, VA, WA, WV, WI, WY
}


public record Address(string Street, string City, UsState State, string Zip)
{
    public const string NamePattern = @"^[a-zA-Z0-9\s.'-]{2,50}$";
    public const string zipPattern = @"^\d{5}(-\d{4})?$";
    public string Street { get; init; } = ValidateRegex(Street, NamePattern);
    public string City { get; init; } = ValidateRegex(City, NamePattern);
    public string Zip { get; init; } = ValidateRegex(Zip, zipPattern);
}