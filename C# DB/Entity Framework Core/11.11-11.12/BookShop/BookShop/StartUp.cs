namespace BookShop
{
    using BookShop.Models;
    using BookShop.Data.ViewModels;
    using Data;
    using Initializer;
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Collections.Generic;

    using Newtonsoft.Json;
    using AutoMapper;
    using AutoMapper.Collection;
    using Microsoft.EntityFrameworkCore;
    using AutoMapper.EquivalencyExpression;

    public class StartUp
    {
        public static void Main()
        {
            using (var db = new BookShopContext())
            {   //DbInitializer.ResetDatabase(db);

                Mapper.Initialize(cfg =>
                {             //source, destination
                    cfg.CreateMap<Book, BookDTO>().ForMember(dest => dest.Author, opt => opt.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}"));
                    cfg.AddCollectionMappers(); //Needs automapper collection from nuget
                });
                
                
                var book = db.Books.Include(x => x.Author).First();
                var bookDTO = new BookDTO()
                {
                    Title = book.Title,
                    Price = book.Price,
                    //Author = book.Author.FirstName +" "+book.Author.LastName
                };
                var bookDTO2 = Mapper.Map<BookDTO>(book);
                

                var books = db.Books.Select(b => new
                {
                    Title = b.Title,
                    Price = b.Price,
                    Author = b.Author.FirstName + " " + b.Author.LastName
                }).ToList();
                string result = JsonConvert.SerializeObject(bookDTO2, Formatting.Indented);
                Console.WriteLine(result);
            }
        }
    }
}
