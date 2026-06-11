using SQLite;
using StudentWorksClockInOut.Config;
using StudentWorksClockInOut.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentWorksClockInOut.Repositories;

public class EmployeeDatabase
{
    SQLiteAsyncConnection database;

    async Task Init()
    {
        if (database is not null)
        {
            return;
        }

        database = new SQLiteAsyncConnection(Constants.employeeDbPath, Constants.Flags);
        var result = await database.CreateTableAsync<Employee>();
    }

    // All employess
    public async Task<List<Employee>> GetEmployeesAsync()
    {
        await Init();
        return await database.Table<Employee>().ToListAsync();
    }

    // Specific employee
    public async Task<Employee> GetEmployeeAsync(int id)
    {
        await Init();
        return await database.Table<Employee>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    // Add employee
    public async Task<int> SaveEmployeeAsync(Employee employee)
    {
        await Init();
        if (employee.Id != 0)
        {
            return await database.UpdateAsync(employee);
        }
        else
        {
            return await database.InsertAsync(employee);
        }
    }

    // Delete employee
    public async Task<int> DeleteEmployeeAsync(Employee employee)
    {
        await Init();
        return await database.DeleteAsync(employee);
    }
}
