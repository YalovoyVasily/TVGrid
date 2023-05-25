using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVGrid.DTOs
{
    public class ProgramDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Duration { get; set; }
        public IEnumerable<Schedule> Schedule { get; set; }


        public ProgramDTO(Program program)
        {
            Id = program.Id;
            Name = program.Name;
            Description = program.Description;
            Schedule= program.Schedule;
            Duration = program.Duration.TotalSeconds;
        }

    }
}
