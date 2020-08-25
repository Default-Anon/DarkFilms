using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestAspNetSite.Models
{
    public static class SeedData 
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if(!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Сияние",
                        Price = 0,
                        Description = "Главный герой - Джек Торренс - приехал в элегантный уединенный отель, чтобы поработать смотрителем во время мертвого сезона вместе со своей женой и сыном. Торренс здесь раньше никогда не бывал. Или это не совсем так? Ответ лежит во мраке, сотканном из преступного кошмара.",
                        Image_Url = "Content/Siyanie.jpg",
                        Url_to_Download = "magnet:?xt=urn:btih:526e38c15668086b64f49d4356b27eccc9227011&dn=&tr=http%3A%2F%2Fretracker.local%2Fannounce"
                    },
                    new Product
                    {
                        Name = "V значит Вендетта",
                        Price = 0,
                        Description = "jxikasjxasixjsajxiasjxisajixjaisjxaisji",
                        Url_to_Download = "https://kinoframe.net/torrents/66/665765.torrent",
                        Image_Url = "Content/Vendetta.jpg"
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
