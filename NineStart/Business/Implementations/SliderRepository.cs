using Business.Services;
using DAL.Abstracts;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implementations
{
    public class SliderRepository : ISliderService
    {
        private readonly ISliderDal _sliderRepository;
        public SliderRepository(ISliderDal sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }

        public async Task<Slider> Get(int? id)
        {
            if(id is null)
            {
                throw new ArgumentNullException();
            }

            var data = await _sliderRepository.GetAsync(s => s.Id == id);

            if(data is null)
            {
                throw new NullReferenceException();
            }

            return data;
        }

        public async Task<List<Slider>> GetAll()
        {
            var datas = await _sliderRepository.GetAllAsync();

            if (datas is null)
            {
                throw new NullReferenceException();
            }

            return datas;
        }

        public async Task Create(Slider entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException();
            }
            entity.CreatedDate = DateTime.Now;
            //entity.IsDeactivated = false;
            await _sliderRepository.AddAsync(entity);
        }

        public async Task Delete(int? id)
        {
            var data = await Get(id);

            if(data is null)
            {
                throw new NullReferenceException();
            }

            await _sliderRepository.DeleteAsync(data);
        }

        public async Task Update(Slider entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException();
            }

            entity.UpdatedDate = DateTime.Now;
            await _sliderRepository.UpdateAsync(entity);
        }
    }
}
