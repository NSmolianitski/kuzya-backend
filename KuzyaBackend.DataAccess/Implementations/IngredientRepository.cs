﻿using KuzyaBackend.DataAccess.Interfaces;
using KuzyaBackend.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace KuzyaBackend.DataAccess.Implementations;

public class IngredientRepository(ApplicationDbContext db) : IIngredientRepository
{
    public async Task<IEnumerable<Ingredient>> GetAllAsync()
    {
        return await db.Ingredients.ToListAsync();
    }

    public Task<Ingredient?> TryGetByIdAsync(long id)
    {
        return db.Ingredients.SingleOrDefaultAsync(i => i.Id == id);
    }

    public async Task<Ingredient> CreateAsync(Ingredient ingredient)
    {
        ingredient = db.Ingredients.Add(ingredient).Entity;
        await db.SaveChangesAsync();
        return ingredient;
    }
}