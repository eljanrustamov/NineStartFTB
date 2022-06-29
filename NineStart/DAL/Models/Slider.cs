using Core.Entity;
using DAL.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Slider : BaseEntity, IEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string RedirectToUrl { get; set; }
        public string RedirectToUrlText { get; set; }
        public string ImageName { get; set; }
    }
}
