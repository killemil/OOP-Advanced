using System;

public class WeeklyEntry : IComparable<WeeklyEntry>
{
    private WeekDay weekday;
    private string notes;

    public WeeklyEntry(string weekday, string notes)
    {
        this.Weekday = (WeekDay)Enum.Parse(typeof(WeekDay), weekday);
        this.Notes = notes;
    }

    public WeekDay Weekday
    {
        get
        {
            return this.weekday;
        }
        private set
        {
            this.weekday = value;
        }
    }

    public string Notes
    {
        get
        {
            return this.notes;
        }
        private set
        {
            this.notes = value;
        }
    }

    public int CompareTo(WeeklyEntry other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        if (ReferenceEquals(null, other))
        {
            return 1;
        }
        int weekDayComparison = this.Weekday.CompareTo(other.Weekday);
        if (weekDayComparison != 0)
        {
            return weekDayComparison;
        }

        return this.Notes.CompareTo(other.Notes);
    }

    public override string ToString()
    {
        return $"{this.Weekday} - {this.Notes}";
    }
}

