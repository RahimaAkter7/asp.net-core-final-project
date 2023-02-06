using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Auth.Models
{
    public class PlantSize
    {
        [Key]
        public int SizeId { get; set; }
        public string SizeType { get; set; }

    }
    public class Plant
    {
        public Plant()
        {
            this.StockEntries = new List<StockEntry>();
        }
        public int PlantId { get; set; }
        public string PlantName { get; set; }
        public DateTime StockDate { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("PlantSize")]
        public int SizeId { get; set; }
        public string Picture { get; set; }
        public bool IsAvaible { get; set; }
        //Nev
        public virtual PlantSize PlantSize { get; set; }
        public virtual ICollection<StockEntry> StockEntries { get; set; }


    }
    
    public class pot
    {
        public pot()
        {
            this.StockEntries = new List<StockEntry>();
        }
        public int potId { get; set; }
        public string potName { get; set; }
        //Nev
        public virtual ICollection<StockEntry> StockEntries { get; set; }
    }
    public class StockEntry
    {
        public int StockEntryId { get; set; }
        [ForeignKey("Plant")]
        public int PlantId { get; set; }
        [ForeignKey("pot")]
        public int potId { get; set; }

        //Nev
        public virtual Plant Plant { get; set; }
        public virtual pot pot { get; set; }
    }
   
}
