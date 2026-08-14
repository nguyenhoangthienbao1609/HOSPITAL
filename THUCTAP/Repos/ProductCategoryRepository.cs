using Microsoft.EntityFrameworkCore;
using THUCTAP.Data;
using THUCTAP.Extensions;
using THUCTAP.Interfaces;
using THUCTAP.Models;
using THUCTAP.ViewModels;

namespace THUCTAP.Repos
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly AppDbContext _context;

        public ProductCategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<ProductCategoryResponseDto>> GetAllAsync(ProductCategoryFilterRequest filter)
        {
            var query = _context.ProductCategories.AsQueryable();

            if (filter != null)
            {
                if (!string.IsNullOrWhiteSpace(filter.categoryName))
                    query = query.Where(x => x.categoryName.Contains(filter.categoryName));

                if (!string.IsNullOrWhiteSpace(filter.categoryCode))
                    query = query.Where(x => x.categoryCode.Contains(filter.categoryCode));
            }

            var pagedRawData = await query
                .AsNoTracking()
                .OrderByDescending(x => x.id)
                .ToPagedResultAsync(filter.pageIndex, filter.pageSize);

            return pagedRawData.Map(x => new ProductCategoryResponseDto
            {
                id = x.id,
                categoryName = x.categoryName,
                categoryCode = x.categoryCode,
                description = x.description
            });
        }

        public async Task<ProductCategory?> GetByIdAsync(int id)
        {
            return await _context.ProductCategories.FindAsync(id);
        }

        // --- KHÔI PHỤC LẠI SAVECHANGES ---
        public async Task CreateAsync(ProductCategory entity)
        {
            _context.ProductCategories.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ProductCategory entity)
        {
            _context.ProductCategories.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(ProductCategory entity)
        {
            _context.ProductCategories.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}