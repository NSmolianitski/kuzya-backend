using KuzyaBackend.DataAccess.Interfaces;
using KuzyaBackend.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace KuzyaBackend.DataAccess.Implementations;

public class MealListRepository(ApplicationDbContext db) : IMealListRepository
{
    public async Task<IEnumerable<MealList>> GetAllAsync()
    {
        return await db.MealLists
            .Include(ml => ml.MealGroups)
                .ThenInclude(mealGroup => mealGroup.Recipes)
            .ToListAsync();
    }

    public Task<MealList?> TryGetByIdAsync(long id)
    {
        return db.MealLists
            .Include(ml => ml.MealGroups)
                .ThenInclude(mealGroup => mealGroup.Recipes)
            .SingleOrDefaultAsync(ml => ml.Id == id);
    }

    public async Task<MealList> CreateAsync(MealList mealList)
    {
        mealList = db.MealLists.Add(mealList).Entity;
        await db.SaveChangesAsync();
        return mealList;
    }
}