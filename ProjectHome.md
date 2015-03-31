PrettyTime.NET is an OpenSource .NET time comparison library for creating human readable time. This is a modified version of PrettyTime, created by Lincoln Baxter, III from OcpSoft. PrettyTime can be found at http://code.google.com/p/prettytime/.

Completely customizable, PrettyTime.NET creates human readable, relative timestamps like those seen on Digg, Twitter, Gmail, Facebook and FeedWatchdog. It's simple, get started "right now!"


### Simple Example ###
```
private string PrettyItUp(DateTime Date)
{
    using (PrettyTime.PrettyTime p = new PrettyTime.PrettyTime())
        return p.format(Date);
}
```

### minutes from now test ###
```
/// <summary>
/// A test for minutes from now
/// </summary>
[TestMethod()]
public void MinutesFromNow()
{
    using (PrettyTime p = new PrettyTime())
    {
        Assert.AreEqual(“12 minutes from now”, p.format(DateTime.Now.AddMinutes(12)));
    }
}
```

### days ago test ###
```
/// <summary>
/// A test for days ago
/// </summary>
[TestMethod()]
public void DaysAgo()
{
    using (PrettyTime p = new PrettyTime())
    {
        Assert.AreEqual(“3 days ago”, p.format(DateTime.Now.AddDays(-3)));
    }
}
```