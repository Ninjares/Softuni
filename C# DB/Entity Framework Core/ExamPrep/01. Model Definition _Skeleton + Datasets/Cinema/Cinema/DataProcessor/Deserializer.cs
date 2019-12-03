namespace Cinema.DataProcessor
{
    using System;
    using Cinema.Data.Models;
    using Cinema.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string SuccessfulImportMovie 
            = "Successfully imported {0} with genre {1} and rating {2}!";
        private const string SuccessfulImportHallSeat 
            = "Successfully imported {0}({1}) with {2} seats!";
        private const string SuccessfulImportProjection 
            = "Successfully imported projection {0} on {1}!";
        private const string SuccessfulImportCustomerTicket 
            = "Successfully imported customer {0} {1} with bought tickets: {2}!";

        public static string ImportMovies(CinemaContext context, string jsonString)
        {
            var movDTO = JsonConvert.DeserializeObject<MovieDTO[]>(jsonString);
            var movies = Mapper.Map<Movie[]>(movDTO);
            StringBuilder sb = new StringBuilder();
            foreach(var movie in movies)
            {
                if (IsValid(movie))
                {
                    sb.AppendLine($"Successfully imported {movie.Title} with genre {movie.Genre.ToString()} and rating {movie.Rating:F2}!");
                    context.Movies.Add(movie);
                }
                else sb.AppendLine("Invalid data!");
            }
            context.SaveChanges();
            return sb.ToString();
        }

        public static string ImportHallSeats(CinemaContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var hallDTOs = JsonConvert.DeserializeObject<HallDTO[]>(jsonString);
            foreach(var halldto in hallDTOs)
            {
                Hall currentHall = new Hall()
                {
                    Name = halldto.Name,
                    Is4Dx = halldto.Is4Dx,
                    Is3D = halldto.Is3D
                };
                if (IsValid(currentHall) && halldto.Seats > 0)
                {
                    context.Halls.Add(currentHall);
                    for (int i = 0; i < halldto.Seats; i++)
                        context.Seats.Add(new Seat { Hall = currentHall });
                    string cinematype = "Normal";
                    if (currentHall.Is3D && currentHall.Is4Dx) cinematype = "4Dx/3D";
                    else if (currentHall.Is3D) cinematype = "3D";
                    else if (currentHall.Is4Dx) cinematype = "4Dx";
                    sb.AppendLine($"Successfully imported {currentHall.Name}({cinematype}) with {halldto.Seats} seats!");
                }
                else sb.AppendLine("Invalid data!");
            }
            context.SaveChanges();
            return sb.ToString();
        }

        public static string ImportProjections(CinemaContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        public static string ImportCustomerTickets(CinemaContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object obj)
        {
            return Validator.TryValidateObject(obj, new System.ComponentModel.DataAnnotations.ValidationContext(obj), new System.Collections.Generic.List<ValidationResult>(), true);
        }
    }
}