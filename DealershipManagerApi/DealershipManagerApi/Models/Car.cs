﻿namespace DealershipManagerApi.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
        public int ProdYear { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
        public bool IsSold { get; set; }
    }
}
