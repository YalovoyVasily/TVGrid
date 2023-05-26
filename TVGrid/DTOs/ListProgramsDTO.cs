using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVGrid.DTOs
{
    public class ListProgramsDTO
    {
        [DisplayName("Название передачи")]
        public string Name { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Начало")]
        public string TimeStart { get; set; }
        [DisplayName("Конец")]
        public string TimeEnd { get; set; }

        

        public ListProgramsDTO(Schedule schedule)
        {

            Name = schedule.Program.Name;

            Description = schedule.Program.Description;

            TimeStart = schedule.TimeStart.ToShortTimeString();

            TimeEnd = schedule.TimeEnd.ToShortTimeString();

        }

    }
}
