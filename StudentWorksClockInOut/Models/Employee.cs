using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentWorksClockInOut.Models;

public class Employee
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Name { get; set; }
}
