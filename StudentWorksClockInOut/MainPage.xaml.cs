using StudentWorksClockInOut.Config;
using StudentWorksClockInOut.Models;
using StudentWorksClockInOut.Repositories;
using StudentWorksClockInOut.Types;
using System.Diagnostics;

namespace StudentWorksClockInOut;

public partial class MainPage : ContentPage
{
    EmployeeDatabase _employeeDatabase;
    TimeEntryRepository _timeEntryDatabase;
    List<Employee> _employeeList = new List<Employee>();
    Employee? _displayedEmployee;

    public MainPage(EmployeeDatabase employeeDatabase, TimeEntryRepository timeEntryRepository)
    {
        InitializeComponent();
        _employeeDatabase = employeeDatabase;
        _timeEntryDatabase = timeEntryRepository;
    }

    private async void OnSubmit(object sender, EventArgs e)
    {
        int id = int.Parse(_emplyeeIdEntry.Text);

        _displayedEmployee = await _employeeDatabase.GetEmployeeAsync(id);

        _employeeDetails.Text = $"Signed In: Employee ... {_displayedEmployee.Name}";
    }

    private async void OnClockIn(object sender, EventArgs e)
    {
        try
        {
            TimeEntry recentEntry = await _timeEntryDatabase.GetEmployeeLatestEntryAsync(_displayedEmployee.Id);

            if (recentEntry is null || recentEntry.EntryType == EntryType.ClockOut)
            {
                TimeEntry newTimeEntry = new TimeEntry
                {
                    EmployeeId = _displayedEmployee.Id,
                    EmployeeName = _displayedEmployee.Name,
                    EntryType = EntryType.ClockIn,
                    EntryTime = DateTime.Now
                };

                await _timeEntryDatabase.SaveTimeEntryAsync(newTimeEntry);
                await DisplayAlert("Student Works", "Clocked In", "Ok");

            }
            else
            {
                throw new FlowException("Clocked in twice in a row. Must clock out before clocking in");
            }
        }
        catch (NullReferenceException ex)
        {
            await DisplayAlert("Student Works", $"Did not clock in. You have to sign in before clocking in.\nError: {ex.Message}", "Ok");
        }
        catch (FlowException ex)
        {
            await DisplayAlert("Student Works", $"Did not clock in.\nError: {ex.Message}", "Ok");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Student Works", $"Did not clock in.\nError: {ex.Message}", "Ok");
        }
    }

    private async void OnClockOut(object sender, EventArgs e)
    {
        try
        {
            TimeEntry recentEntry = await _timeEntryDatabase.GetEmployeeLatestEntryAsync(_displayedEmployee.Id);

            if (recentEntry is null || recentEntry.EntryType == Types.EntryType.ClockIn)
            {
                TimeEntry newTimeEntry = new TimeEntry
                {
                    EmployeeId = _displayedEmployee.Id,
                    EmployeeName = _displayedEmployee.Name,
                    EntryType = EntryType.ClockOut,
                    EntryTime = DateTime.Now
                };

                await _timeEntryDatabase.SaveTimeEntryAsync(newTimeEntry);
                await DisplayAlert("Student Works", "Clocked Out", "Ok");

            }
            else
            {
                throw new FlowException("Clocked out twice in a row. Must clock in before clocking in.");
            }
        }
        catch (NullReferenceException ex)
        {
            await DisplayAlert("Student Works", $"Did not clock out. You have to sign in before clocking out.\nError: {ex.Message}", "Ok");
        }
        catch (FlowException ex)
        {
            await DisplayAlert("Student Works", $"Did not clock out.\nError: {ex.Message}", "Ok");
        }
        catch (Exception ex)
        {
            await DisplayAlert("Student Works", $"Did not clock out.\nError: {ex.Message}", "Ok");
        }
    }
}
