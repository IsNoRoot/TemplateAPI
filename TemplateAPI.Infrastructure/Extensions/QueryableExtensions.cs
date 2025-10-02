using Microsoft.EntityFrameworkCore;
using TemplateAPI.Application.DTOs;

namespace TemplateAPI.Infrastructure.Extensions;

public static class QueryableExtensions
{
    public static async Task<(List<T> Data, int TotalItems)> ToPagedListAsync<T>(
        this IQueryable<T> source,
        int pageNumber,
        int pageSize)
    {
        var count = await source.CountAsync();
        var items = await source
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return (items, count);
    }
}