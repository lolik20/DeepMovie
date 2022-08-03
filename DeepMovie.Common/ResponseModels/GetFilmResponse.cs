using System;
using System.Collections.Generic;
using System.Text;

namespace DeepMovie.Common.ResponseModels
{
    public class GetFilmResponse
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Year { get; set; }
        public string? Time { get; set; }
        public string Director { get; set; }
        public string MainActors { get; set; }
        public int PercentCollected { get; set; }
        public string Country { get; set; }
        public string Sound { get; set; }
        public string TotalBudget { get; set; }
        public string USAFees { get; set; }
        public string TotalFees { get; set; }
        public string RussiaFees { get; set; }
        public decimal FundTotal { get; set; }
        public decimal FundRaised { get; set; }
        public string TotalPremiere { get; set; }
        public string RussiaPremiere { get; set; }
        public int AgeRating { get; set; }
        public bool IsImmersive { get; set; }
        public IEnumerable<ContentResponse> Photos { get; set; }
        public IEnumerable<ContentResponse> Videos { get; set; }
        public IEnumerable<DonationStageResponse>? DonationStages { get; set; }
        public string Categories { get; set; }
        public IEnumerable<CreatorsResponse> Creators { get; set; }
        public string Format { get; set; }
        public IEnumerable<ReviewResponse> Reviews { get; set; }
        public IEnumerable<LinkResponse> Links { get; set; }
    }
}
