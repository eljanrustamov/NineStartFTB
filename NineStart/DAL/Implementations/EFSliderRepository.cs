using Core.EFRepository.EFEntityRepository;
using DAL.Abstracts;
using DAL.Data;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Implementations
{
    public class EFSliderRepository : EFEntityRepositoryBase<Slider, AppDbContext>, ISliderDal
    {
        public EFSliderRepository(AppDbContext context) : base(context)
        {
        }
    }
}
