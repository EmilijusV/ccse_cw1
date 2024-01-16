using System.ComponentModel.DataAnnotations.Schema;
using Humanizer.Localisation.TimeToClockNotation;

namespace ccse_cw1.Models
{
    public class TourDate
    {
        public int TourDateID {  get; set; }

        public int TourID {  get; set; }

        public DateTime AvailableFrom { get; set; }

        public DateTime AvailableTo { get; set; }

        public Tour Tour { get; set; } = null!;

    }
}
