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
        public static async Task<bool> Save(Schedule sched)
        {
            if (sched == null) { MessageBox.Show("Плейлист пустой"); return false; }
            try
            {
                MyDB db = new();
                await db.Schedule.AddAsync(sched);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сохранения плейлиста, пожалуйста обратитесь к администратору\n\n" + ex.Message.ToString());
                return false;
            }
        }

        public static async Task<bool> Update(Schedule sched)
        {
            if (sched == null) { MessageBox.Show("Плейлист пустой"); return false; }
            try
            {
                MyDB db = new();
                db.Entry(sched).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления плейлиста, пожалуйста обратитесь к администратору\n\n" + ex.Message.ToString());
                return false;
            }
        }

        public static async Task<bool> Delete(Schedule sched)
        {
            if (sched == null) { MessageBox.Show("Плейлист пустой"); return false; }
            try
            {
                MyDB db = new();
                db.Entry(sched).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка удаления плейлиста, пожалуйста обратитесь к администратору\n\n" + ex.Message.ToString());
                return false;
            }
        }

        public static async Task<Schedule> Get(DateOnly date)
        {
            try
            {
                MyDB db = new();
                Schedule sched = await db.Schedule.Include(s => s.Programs).ThenInclude(p => p.Advertisements).Where(s => DateOnly.FromDateTime(s.TimeStart) >= date && DateOnly.FromDateTime(s.TimeEnd) >= date);
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
