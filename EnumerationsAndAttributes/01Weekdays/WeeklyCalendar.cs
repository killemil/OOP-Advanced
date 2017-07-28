using System.Collections.Generic;

public class WeeklyCalendar
{
    private IList<WeeklyEntry> weeklyschedule;

    public WeeklyCalendar()
    {
        this.weeklyschedule = new List<WeeklyEntry>();
    }
    public IEnumerable<WeeklyEntry> WeeklySchedule
    {
        get { return this.weeklyschedule; }
    }

    public void AddEntry(string weekday, string notes)
    {
        this.weeklyschedule.Add(new WeeklyEntry(weekday, notes));
    }
}

