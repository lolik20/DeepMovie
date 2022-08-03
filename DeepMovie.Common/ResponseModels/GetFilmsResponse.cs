using System;
using System.Collections.Generic;
using System.Text;

namespace DeepMovie.Common.ResponseModels
{
    public class GetFilmsResponse
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? Year { get; set; }
        public string? Time { get; set; }
        public int PercentCollected { get; set; }
        public string PosterURL { get; set; }
        public IEnumerable<DonationStageResponse>? DonationStages { get; set; }
        public string Categories { get; set; }
    }
}
