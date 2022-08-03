using System;
using System.Collections.Generic;
using System.Text;

namespace DeepMovie.Common.Entities
{
    public class Film
    {
        public int ID { get; set; }
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
        public string Format { get; set; }
        public decimal FundTotal { get; set; }
        public decimal FundRaised { get; set; }
        public DateTime TotalPremiere { get; set; }
        public DateTime RussiaPremiere { get; set; }
        public int AgeRating { get; set; }
        public bool IsImmersive { get; set; }
        public List<Review> Reviews { get; set; }
        public List<FilmCategory> FilmCategories { get; set; }
        public List<DonationStage> DonationStages { get; set; }
        public List<FilmMember> FilmMembers { get; set; }
        public List<Content> Contents { get; set; }
        public List<Link> Links { get; set; }
    }
}
