namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
           StringBuilder sb = new StringBuilder();
           var serializer = new XmlSerializer(typeof(BookDTO[]), new XmlRootAttribute("Books"));
            var dtos = (BookDTO[])serializer.Deserialize(new StringReader(xmlString));
            foreach(BookDTO bookdto in dtos)
            {
                Book book = new Book();
                try
                {
                    book.Name = bookdto.Name;
                    book.Genre = (Genre)bookdto.Genre;
                    book.Price = bookdto.Price;
                    book.Pages = bookdto.Pages;
                    book.PublishedOn = DateTime.ParseExact(bookdto.PublishedOn, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                }
                catch (Exception)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (IsValid(book) && (int)book.Genre > 0 && (int)book.Genre < 4)
                {
                    context.Books.Add(book);
                    sb.AppendLine(String.Format(SuccessfullyImportedBook, book.Name, book.Price.ToString("F2")));
                }
                else sb.AppendLine(ErrorMessage);
            }
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var dtos = JsonConvert.DeserializeObject<AuthorDTO[]>(jsonString);
            foreach(AuthorDTO authorDTO in dtos)
            {
                List<AuthorBook> authorBooks = new List<AuthorBook>();
                Author author = new Author
                {
                    FirstName = authorDTO.FirstName,
                    LastName = authorDTO.LastName,
                    Phone = authorDTO.Phone,
                    Email = authorDTO.Email
                };
                if (IsValid(author))
                {
                    foreach (BookId bookId in authorDTO.Books)
                    {
                        if (bookId.Id.HasValue)
                        {
                            if (context.Books.Any(x => x.Id == bookId.Id.Value))
                            {
                                AuthorBook authorBook = new AuthorBook
                                {
                                    BookId = bookId.Id.Value,
                                    Author = author
                                };
                                authorBooks.Add(authorBook);
                            }
                        }
                    }
                    if (authorBooks.Count == 0) sb.AppendLine(ErrorMessage);
                    else
                    {
                        context.Authors.Add(author);
                        context.AuthorsBooks.AddRange(authorBooks);
                        sb.AppendLine(String.Format(SuccessfullyImportedAuthor, author.FirstName + " " + author.LastName, authorBooks.Count));
                    }

                }
                else sb.AppendLine(ErrorMessage);

            }
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}