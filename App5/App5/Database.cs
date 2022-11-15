using App5.Janrs;
using App5.Serials;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App5
{
    public class Database
    {
        private List<Janr> janrs = new List<Janr>();
        private List<Serial> serials = new List<Serial>();
        private int autoincriment = 4;
        private int autoincrimentjanr = 4;


        public Database()
        {
            Janr item = new Janr
            {
                Id = 1,
                Name = "Комедия"
            };

            Janr item1 = new Janr
            {
                Id = 2,
                Name = "драмма"
            };


            Janr item2 = new Janr
            {
                Id = 3,
                Name = "ужасы"
            };
            janrs.Add(item);
            janrs.Add(item1);
            janrs.Add(item2);

            Serial serial = new Serial
            {
                Id = 1,
                Name = "Один дома",
                JanrId = 1
            };

            Serial serial1 = new Serial
            {
                Id = 2,
                Name = "кино типа серипл ",
                JanrId = 2
            };

            Serial serial2 = new Serial
            {
                Id = 3,
                Name = "ктоя",
                JanrId = 3
            };
            serials.Add(serial);
            serials.Add(serial1);
            serials.Add(serial2);
            GoToLoginForm();
        }

        private async void GoToLoginForm()
        {
            await Shell.Current.GoToAsync("//LoginForm");
        }

        public Task<List<Serial>> GetSerials() //получить все сериалы из коллекции
        {
            return Task.FromResult(serials);
        }
        public Task<List<Janr>> GetJanrs()//порлучить все жанры из коллекции
        {
            return Task.FromResult(janrs);
        }
        public Task AddSerial(Serial serial) //добавить новый serial 
        {
            serial.Id = autoincriment++;
            serials.Add(serial);
            return Task.CompletedTask;
        }
        public Task AddJanr(Janr janr)//добавить новый жанр 
        {
            janr.Id = autoincrimentjanr++;
            janrs.Add(janr);
            return Task.CompletedTask;
        }
        public Task<Janr> GetJanr(int id) //получить конкретный jannr 
        {
            return Task.FromResult(janrs.Find(s => s.Id == id));
        }
        public Task<Serial> GetSerial(int id) //получить конкретный сериал
        {
            return Task.FromResult(serials.Find(s => s.Id == id));
        }       
        public async Task EditSerial(Serial serial)//редактировать сериал
        {
            Serial oldSerial = await GetSerial(serial.Id);
            oldSerial = serial;
        }
        public async Task EditJanr(Janr janr)//редактировать сериал
        {
            Janr oldJanr = await GetJanr(janr.Id);
            oldJanr = janr;
        }
        public Task DeleteSerial(Serial serial)//удалить сериал
        {
            serials.Remove(serial);
            return Task.CompletedTask;
        }       

        public Task DeleteJanr(Janr janr)//удалить жанр
        {
            janrs.Remove(janr);
            return Task.CompletedTask;
        }
    }
}