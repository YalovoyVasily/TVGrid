using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using TVGrid.DTOs;
using TVGrid.Enums;

namespace TVGrid
{
    public class PlayListController
    {

        //insert into [ProgramTypeDictionary] (Title, Description) values ('1', '1') 
        // insert into[ProgramTypeDictionary] (Title, Description) values('2', '2')
        //insert into[Program] (Name, Description, Duration, ProgramTypeDictionaryID) values('1', '1','01:00:00',1)
        //insert into[Program] (Name, Description, Duration, ProgramTypeDictionaryID) values('2', '1','02:00:00',1)
        //insert into[Program] (Name, Description, Duration, ProgramTypeDictionaryID) values('3', '1','04:00:00',2)
        //insert into[Schedule] (TimeStart, TimeEnd, ProgramID) values('2023-05-19 00:00:00.000', '2023-05-19 01:00:00.000',1)
        //insert into[Schedule] (TimeStart, TimeEnd, ProgramID) values('2023-05-19 02:00:00.000', '2023-05-19 04:00:00.000',2)
        //insert into[Schedule] (TimeStart, TimeEnd, ProgramID) values('2023-05-19 04:05:00.000', '2023-05-19 07:05:00.000',3)

        public async Task<List<ProgramDTO>> GetAllPrograms()
        {
            await using var context = new MyDB();

            var result = await context.Program.Where(x => x.ProgramTypeDictionaryID == (int)ProgramEnum.Program).Select(x => new ProgramDTO(x)).ToListAsync();

            return result;
        }

        public async Task<bool> CanAddProgram(DateTime dateFrom, DateTime dateTo)
        {
            await using var context = new MyDB();

            var isProgramExist = await context.Schedule.AnyAsync(s => 
            (s.TimeStart >= dateFrom && s.TimeEnd <= dateTo)||
            (dateFrom <= s.TimeEnd && dateTo>= s.TimeStart) 
            );

            return true;
        }

        public async Task<bool> Save(IEnumerable<Schedule> scheds)
        {
            if (scheds?.Any() != true)  // scheds?.Count() == 0 изменил проверку, т.к. эта "scheds?.Count() == 0"  не работает, хз почему
            {
                MessageBox.Show("Плейлист пустой");
                return false;
            }
            try
            {

                MyDB db = new();
                await db.Schedule.AddRangeAsync(scheds); // тоже самое, но foreach не нужен 

                //foreach (Schedule sched in scheds) {
                //await db.Schedule.Add(scheds);
                // }

                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения плейлиста, пожалуйста обратитесь к администратору\n\n" + ex.Message.ToString());
                return false;
            }
        }

        public async Task<bool> Update(IEnumerable<Schedule> scheds)
        {
            if (scheds?.Any() != true) { MessageBox.Show("Плейлист пустой"); return false; }
            try
            {
                MyDB db = new();
                foreach (Schedule sched in scheds)
                {
                    db.Entry(sched).State = EntityState.Modified;
                }
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления плейлиста, пожалуйста обратитесь к администратору\n\n" + ex.Message.ToString());
                return false;
            }
        }

        public async Task<bool> Delete(IEnumerable<Schedule> scheds)
        {
            if (scheds?.Any() != true) { MessageBox.Show("Плейлист пустой"); return false; }
            try
            {
                MyDB db = new();
                foreach (Schedule sched in scheds)
                {
                    db.Entry(sched).State = EntityState.Deleted;
                }
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления плейлиста, пожалуйста обратитесь к администратору\n\n" + ex.Message.ToString());
                return false;
            }
        }

        public async Task<IEnumerable<Schedule>> Get(DateTime dateFrom, DateTime dateTo) //  DateTime date добавил 2 даты, просто иначе инфу за временной период хуй получишь
        {
            try
            {
                MyDB db = new();

                IEnumerable<Schedule> sched = await db.Schedule
                   .Include(s => s.Program)
                   .Where(s => s.TimeStart >= dateFrom && s.TimeEnd <= dateTo).ToListAsync();

                return sched;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка получения плейлиста, пожалуйста обратитесь к администратору\n\n" + ex.Message.ToString());
                return null;
            }
        }


        //var D1 = new DateTime(2023, 5, 19, 07, 00, 00); //19.05.2023 2:00:00
        //var D2 = new DateTime(2023, 5, 19, 08, 02, 00); //19.05.2023 4:00:00

        //await dfsf.CanAddProgram(D1, D2);

        //var D1 = new DateTime(2023, 5, 19, 04, 01, 00); //19.05.2023 2:00:00
        //var D2 = new DateTime(2023, 5, 19, 04, 02, 00); //19.05.2023 4:00:00

        //await dfsf.CanAddProgram(D1, D2);


        //var dfsf = new PlayListController();
        ////var dff =new DateTime(2023,5,19,00,00,00); //2023-05-19 00:00:00.000
        ////var dff1 =new DateTime(2023,5,19,23,59,59); //2023-05-19 00:00:00.000

        ////await dfsf.Get(dff, dff1);

        ////var Schedule1 = new Schedule();

        ////Schedule1.TimeStart= new DateTime(2023, 5, 19, 00, 00, 00);
        ////Schedule1.TimeEnd= new DateTime(2023, 5, 19, 23, 59, 59);
        ////Schedule1.ProgramID= 2;


        ////var Schedule2 = new Schedule();

        ////Schedule2.TimeStart = new DateTime(2024, 7, 19, 00, 00, 00);
        ////Schedule2.TimeEnd = new DateTime(2024, 7, 19, 23, 59, 59);
        ////Schedule2.ProgramID = 2;

        ////var Schedulelist= new List<Schedule>() {Schedule1, Schedule2 };

        ////await dfsf.Save(Schedulelist);

        ////var Schedule3 = new Schedule();

        ////Schedule3.TimeStart = new DateTime(2000, 7, 19, 00, 00, 00);
        ////Schedule3.TimeEnd = new DateTime(2000, 7, 19, 23, 59, 59);
        ////Schedule3.ProgramID = 1;
        ////Schedule3.Id = 12;

        ////var SchedulelistToUpdate = new List<Schedule>() { Schedule3 };

        ////await dfsf.Update(SchedulelistToUpdate);


        //var Schedule3 = new Schedule();

        //Schedule3.TimeStart = new DateTime(2000, 7, 19, 00, 00, 00);
        //Schedule3.TimeEnd = new DateTime(2000, 7, 19, 23, 59, 59);
        //Schedule3.ProgramID = 1;
        //Schedule3.Id = 12;

        //var Schedule4 = new Schedule();

        //Schedule4.TimeStart = new DateTime(2000, 7, 19, 00, 00, 00);
        //Schedule4.TimeEnd = new DateTime(2000, 7, 19, 23, 59, 59);
        //Schedule4.ProgramID = 1;
        //Schedule4.Id = 14;

        //var SchedulelistToDelete = new List<Schedule>() { Schedule3, Schedule4 };

        //await dfsf.Delete(SchedulelistToDelete);

    }
}
