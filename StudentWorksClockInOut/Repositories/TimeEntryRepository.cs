using SQLite;
using StudentWorksClockInOut.Config;
using StudentWorksClockInOut.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentWorksClockInOut.Repositories;

public class TimeEntryRepository
{
    SQLiteAsyncConnection database;

    async Task Init()
    {
        if (database is not null)
        {
            return;
        }

        database = new SQLiteAsyncConnection(Constants.timeEntryDbName, Constants.Flags);
        var result = await database.CreateTableAsync<TimeEntry>();
    }

    // All Entries
    public async Task<List<TimeEntry>> GetTimeEntriesAsync()
    {
        await Init();
        return await database.Table<TimeEntry>().ToListAsync();
    }

    // Specific Time Entry
    public async Task<TimeEntry> GetTimeEntryAsync(int id)
    {
        await Init();
        return await database.Table<TimeEntry>().Where(i => i.Id == id).FirstOrDefaultAsync();
    }

    // Insert time entry
    public async Task<int> SaveTimeEntryAsync(TimeEntry timeEntry)
    {
        await Init();
        if (timeEntry.Id != 0)
        {
            return await database.UpdateAsync(timeEntry);
        }
        else
        {
            return await database.InsertAsync(timeEntry);
        }
    }

    // Delete time entry
    public async Task<int> DeleteTimeEntryAsync(TimeEntry timeEntry)
    {
        await Init();
        return await database.DeleteAsync(timeEntry);
    }
}
