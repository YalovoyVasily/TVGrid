using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVGrid.DTOs
{
    public class ProgramDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
        public IEnumerable<Schedule> Schedule { get; set; }
        public IEnumerable<AdvertisementProgram> AdvertisementProgram { get; set; }


        public ProgramDTO(Program program)
        {
            Name = program.Name;
            Description = program.Description;
            Schedule= program.Schedule;
            AdvertisementProgram= program.AdvertisementProgram;
            Duration = program.Duration.TotalSeconds;
        }

    }
}
