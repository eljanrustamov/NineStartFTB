using Core.EFRepository.EFEntityRepository;
using DAL.Abstracts;
using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Implementations
{
    public class EFSetttingsRepository : EFEntityRepositoryBase<Settings, AppDbContext> , ISettingsDal
    {
        public EFSetttingsRepository(AppDbContext context) : base(context)
        {

        }

    }
}
