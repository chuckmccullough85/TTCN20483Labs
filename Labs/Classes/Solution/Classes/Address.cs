using System.Text.RegularExpressions;

namespace Payroll;
public enum UsState
{
    AL, AK, AZ, AR, CA, CO, CT, DE, FL, GA, HI, ID, IL, IN, IA, KS, KY, LA, ME, MD, MA, MI, MN, MS, MO, MT, NE, NV, NH, NJ, NM, NY, NC, ND, OH, OK, OR, PA, RI, SC, SD, TN, TX, UT, VT, VA, WA, WV, WI, WY
}


public class Address
{
    public Address(string street, string city, UsState state, string zip)
    {
        Regex namepattern = new(@"^[a-zA-Z0-9\s.'-]{2,50}$");
        if (!namepattern.IsMatch(street))
            throw new ArgumentException("Invalid street address");
        Street = street;
        if (!namepattern.IsMatch(city))
            throw new ArgumentException("Invalid city");
        City = city;
        State = state;
        Regex zipPattern = new(@"^\d{5}(-\d{4})?$");
        if (!zipPattern.IsMatch(zip))
            throw new ArgumentException("Invalid zip code");
        Zip = zip;
    }
    public string Street { get; init; }
    public string City { get; init; }
    public UsState State { get; init; }
    public string Zip { get; init; }
}