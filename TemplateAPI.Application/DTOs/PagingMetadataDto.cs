namespace TemplateAPI.Application.DTOs;

public class PagingMetadataDto(int items, int pageSize)
{
    public int TotalPages { get; } = (int)Math.Ceiling(items / (double)pageSize);
    public int TotalItems { get; } = items;
}