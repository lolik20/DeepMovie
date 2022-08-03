using DeepMovie.Common.ResponseModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeepMovie.Common.RequestModels
{
    public class AddFilmRequest : IRequest<AddFilmResponse>
    {
        public string URL { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public int Minutes { get; set; }
        public string Country { get; set; }
        public string Sound { get; set; }
        public int TotalBudget { get; set; }
        public int USAFees { get; set; }
        public int TotalFees { get; set; }
        public int RussiaFees { get; set; }
        public decimal FundTotal { get; set; }
        public decimal FundRaised { get; set; }
        public DateTime TotalPremiere { get; set; }
        public DateTime RussiaPremiere { get; set; }
        public int AgeRating { get; set; }
    }
}
