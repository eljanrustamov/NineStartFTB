using Core.EFRepository.EFEntityRepository;
using DAL.Abstracts;
using DAL.Data;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class EFSetttingsRepository : EFEntityRepositoryBase<Settings, AppDbContext> , ISettingsDal
    {
        private readonly AppDbContext _context;
        public EFSetttingsRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Dictionary<string, string>> GetSettings()
        {
            return await _context.Settings.ToDictionaryAsync(t => t.Key, t => t.Value);
        }
    }
}
