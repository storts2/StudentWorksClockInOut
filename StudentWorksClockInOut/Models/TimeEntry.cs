using SQLite;
using StudentWorksClockInOut.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentWorksClockInOut.Models;

public class TimeEntry
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public string EmployeeName { get; set; }
    public EntryType EntryType { get; set; }
    public DateTime EntryTime { get; set; }
}
