using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace Api.Models
{
    public class Track
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int dWt { get; set; } = 0;
        public int wWt { get; set; } = 0;
        public int mWt { get; set; } = 0;
        public int yWt { get; set; } = 0;

    }
}
