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
        public Task<Settings> Get(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Settings>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task Create(Settings entity)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int? id)
        {
            throw new NotImplementedException();
        }

       
        public Task Update(Settings entity)
        {
            throw new NotImplementedException();
        }
    }
}
