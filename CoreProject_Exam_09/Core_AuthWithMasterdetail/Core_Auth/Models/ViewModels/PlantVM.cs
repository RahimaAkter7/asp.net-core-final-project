using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Auth.Models.ViewModels
{
    public class PlantVM
    {
        public PlantVM()
        {
            this.potList = new List<int>();
        }
        public int PlantId { get; set; }
        public string PlantName { get; set; }
        [Required, DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StockDate { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("PlantSize")]
        public int SizeId { get; set; }
        public string Picture { get; set; }
        public IFormFile PictureFile { get; set; }
        public bool IsAvaible { get; set; }
        //Nev
        public virtual PlantSize PlantSize { get; set; }
        public List<int> potList { get; set; }


    }
}

