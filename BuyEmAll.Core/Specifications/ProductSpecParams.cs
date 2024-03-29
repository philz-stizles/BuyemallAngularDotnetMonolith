﻿namespace BuyEmAll.Core.Specifications
{
    public class ProductSpecParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 10;
        public int PageSize 
        { 
            get => _pageSize; 
            set => _pageSize = (value >  MaxPageSize) ? MaxPageSize : value; 
        }

        public int? CategoryId { get; set; }
        public int? BrandId { get; set; }
        public string Sort { get; set; }
        public string Search { get; set; }

        //public string _search { get; set; }
        //public string Search
        //{
        //    get => _search;
        //    set => _search.ToLower();
        //}
    }
}
