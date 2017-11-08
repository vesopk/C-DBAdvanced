using System;
using System.Globalization;


public class DateModifier
{
    public int DaysDiff { get; private set; }

    public DateModifier()
    {
        this.DaysDiff = 0;
    }

    public int CalculateDaysDiff(string firstDate,string secondDate)
    {
        var format = "yyyy MM dd";
        var dateOne = DateTime.ParseExact(firstDate, format, CultureInfo.InvariantCulture);
        var dateTwo = DateTime.ParseExact(secondDate, format, CultureInfo.InvariantCulture);
        var result = dateTwo.Subtract(dateOne);
        DaysDiff = Math.Abs(result.Days);
        return DaysDiff;
    }
}
