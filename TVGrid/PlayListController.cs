using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TVGrid
{
    internal class PlayListController
    {
        public static async Task<bool> Save(IEnumerable<Schedule> scheds)
        {
            if (scheds?.Count() == 0) { MessageBox.Show("Плейлист пустой"); return false; }
            try
            {
                MyDB db = new();
                foreach (Schedule sched in scheds) {
                    await db.Schedule.AddAsync(sched);
                }
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения плейлиста, пожалуйста обратитесь к администратору\n\n" + ex.Message.ToString());
                return false;
            }
        }

        public static async Task<bool> Update(IEnumerable<Schedule> scheds)
        {
            if (scheds?.Count() == 0) { MessageBox.Show("Плейлист пустой"); return false; }
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

        public static async Task<bool> Delete(IEnumerable<Schedule> scheds)
        {
            if (scheds?.Count() == 0) { MessageBox.Show("Плейлист пустой"); return false; }
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

        public static async Task<IEnumerable<Schedule>> Get(DateTime date)
        {
            try
            {
                MyDB db = new();
                 IEnumerable<Schedule> sched = await db.Schedule.Include(s => s.Program).ThenInclude(ap => ap.AdvertisementProgram).ThenInclude(a => a.Advertisement).Where(s => s.TimeStart <= date && s.TimeEnd >= date).ToListAsync();
                 return sched;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка получения плейлиста, пожалуйста обратитесь к администратору\n\n" + ex.Message.ToString());
                return null;
            }
        }
    }
}
