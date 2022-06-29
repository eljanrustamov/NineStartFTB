using Core.EFRepository;
using DAL.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstracts
{
    public interface ISettingsDal : IBaseRepository<Settings>
    {
        public Task<Dictionary<string, string>> GetSettings();

    }

}
