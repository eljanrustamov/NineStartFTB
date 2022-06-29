using Business.Services;
using DAL.Abstracts;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class SettingsRepository : ISettingsService
    {
        private readonly ISettingsDal _settingsRepository;

        public SettingsRepository(ISettingsDal settingsRepository)
        {
            _settingsRepository = settingsRepository;
        }

        public async Task<Dictionary<string, string>> GetSettings()
        {
            return await _settingsRepository.GetSettings();
        }

        public Task AddAsync(Settings entity)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(Settings entity)
        {
            throw new NotImplementedException();
        }
        public Task<List<Settings>> GetAllAsync(Expression<Func<Settings, bool>> expression = null)
        {
            throw new NotImplementedException();
        }
        public Task<Settings> GetAsync(Expression<Func<Settings, bool>> expression = null)
        {
            throw new NotImplementedException();
        }
        public Task UpdateAsync(Settings entity)
        {
            throw new NotImplementedException();
        }
    }
}
