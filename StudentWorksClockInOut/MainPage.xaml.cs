using StudentWorksClockInOut.Config;
using StudentWorksClockInOut.Models;
using StudentWorksClockInOut.Repositories;

namespace StudentWorksClockInOut;

public partial class MainPage : ContentPage
{
    EmployeeDatabase _employeeDatabase;
    List<Employee> _employeeList = new List<Employee>();
    Employee? _displayedEmployee;

    public MainPage(EmployeeDatabase employeeDatabase)
    {
        InitializeComponent();
        _employeeDatabase = employeeDatabase;

    }

    private async void OnSubmit(object sender, EventArgs e)
    {
        int id = int.Parse(_emplyeeIdEntry.Text);

        _displayedEmployee = await _employeeDatabase.GetEmployeeAsync(id);

        _employeeDetails.Text = $"Signed In: Employee ... {_displayedEmployee.Name}";
    }
}
