using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App5
{
    public class Database
    {
        private List<Janr> janrs = new List<Janr>();
        private List<Item> film = new List<Item>();
        private int autoincriment = 4;
        private int autoincrimentjanr = 4;


        public Database()
        {
            Item item = new Item
            {
                Id = 1,
                Name = "один дома"
            };

            Item item2 = new Item
            {
                Id = 2,
                Name = "азер в россии"
            };

            Item item3 = new Item
            {
                Id = 3,
                Name = "моя жизнь"
            };
            film.Add(item);
            film.Add(item2);
            film.Add(item3);

            Janr janr = new Janr
            {
                Id = 1,
                Name = "драмма"
            };

            Janr janr1 = new Janr
            {
                Id = 2,
                Name = "ужасы"
            };

            Janr janr2 = new Janr
            {
                Id = 3,
                Name = "семейное"
            };
            janrs.Add(janr);
            janrs.Add(janr1);
            janrs.Add(janr2);

        }

        public Task<List<Item>> GetItems()
        {
            return Task.FromResult(film);
        }
        public Task<Item> GetItem(int id)
        {
            return Task.FromResult(film.Find(s => s.Id == id));
        }
        public Task AddItem(Item item)
        {
            item.Id = autoincriment++;
            film.Add(item);
            return Task.CompletedTask;
        }
        public async Task EditItem(Item item)
        {
            Item oldItem = await GetItem(item.Id);
            oldItem = item;
        }
        public  Task DeleteItem(Item item)
        {
            film.Remove(item);
            return Task.CompletedTask;
        }
        //для жанров
        public Task<List<Janr>> GetJanr()
        {
            return Task.FromResult(janrs);
        }
        public Task<Janr> GetJanr(int id)
        {
            return Task.FromResult(janrs.Find(s => s.Id == id));
        }
        public Task AddJanr(Janr janr)
        {
            janr.Id = autoincrimentjanr++;
            janrs.Add(janr);
            return Task.CompletedTask;
        }
        public async Task EditJanr(Janr janr)
        {
            Janr oldJanr = await GetJanr(janr.Id);
            oldJanr = janr;
        }
        public Task DeleteJanr(Janr janr)
        {
            janrs.Remove(janr);
            return Task.CompletedTask;
        }
    }
}