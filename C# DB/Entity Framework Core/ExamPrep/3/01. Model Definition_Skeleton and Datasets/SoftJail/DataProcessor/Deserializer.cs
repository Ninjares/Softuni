namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var dtos = JsonConvert.DeserializeObject<DepartmentDTO[]>(jsonString);
            foreach(var dto in dtos)
            {
                List<Cell> cells = new List<Cell>();
                bool allgood = true;
                Department department = new Department { Name = dto.Name };
                if (IsValid(department))
                {
                    foreach (var cel in dto.Cells)
                    {
                        Cell cell = new Cell { CellNumber = cel.CellNumber, HasWindow = cel.HasWindow, Department = department };
                        if (IsValid(cell)) cells.Add(cell);
                        else { allgood = false; break; }
                    }
                }
                else allgood = false;
                if (allgood)
                {
                    context.Departments.Add(department);
                    context.Cells.AddRange(cells);
                    sb.AppendLine($"Imported {department.Name} with {cells.Count} cells");
                }
                else sb.AppendLine("Invalid data!");
            }
            context.SaveChanges();
            return sb.ToString();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            var yubumpa = JsonConvert.DeserializeObject<PrisonerDTO[]>(jsonString);
            foreach(PrisonerDTO prisonerDTO in yubumpa.Where(x => IsValid(x)))
            {
                
                List<Mail> mails = new List<Mail>();
                bool allgood = true;
                Prisoner prisoner = new Prisoner
                {
                    FullName = prisonerDTO.FullName,
                    Nickname = prisonerDTO.Nickname,
                    Age = prisonerDTO.Age,
                    IncarcerationDate = DateTime.ParseExact(prisonerDTO.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    //ReleaseDate = DateTime.ParseExact(prisonerDTO.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    //Bail = prisonerDTO.Bail.HasValue ? prisonerDTO.Bail.HasValue : ,
                    CellId = prisonerDTO.CellId,
                };
                if (IsValid(prisoner) && context.Cells.Any(x => x.Id == prisoner.CellId))
                {
                    foreach (MailDTO mailDTO in prisonerDTO.Mails)
                    {
                        Mail mail = new Mail
                        {
                            Address = mailDTO.Address,
                            Sender = mailDTO.Sender,
                            Description = mailDTO.Description,
                            Prisoner = prisoner
                        };
                        if (IsValid(mail)) mails.Add(mail);
                        else { allgood = false; break; }
                    }
                }
                else allgood = false;
                if (allgood)
                {
                    context.Prisoners.Add(prisoner);
                    context.Mails.AddRange(mails);
                    sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
                }
                else sb.AppendLine("Invalid Data!");
                
            }
            context.SaveChanges();
            return sb.ToString();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            throw new NotImplementedException();
        }

        private static bool IsValid(object obj)
        {
            return Validator.TryValidateObject(obj, new ValidationContext(obj), new List<ValidationResult>(), true);
        }
    }
}