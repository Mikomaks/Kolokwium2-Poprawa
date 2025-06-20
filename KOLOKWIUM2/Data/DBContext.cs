using KOLOKWIUM2.Models;
using Microsoft.EntityFrameworkCore;

namespace KOLOKWIUM2.Data;

public class DBContext : DbContext
{
    
    public DBContext(DbContextOptions<DBContext> options) : base(options) { }
    
    
    public DbSet<Gallery> Galleries { get; set; }
    public DbSet<ExhibitionArtwork> ExhibitionArtworks { get; set; }
    public DbSet<Exhibition> Exhibitions { get; set; }
    public DbSet<Artwork> Artworks { get; set; }
    public DbSet<Artist> Artists { get; set; }
    
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        



        modelBuilder.Entity<Artist>().HasData(
            new Artist()
            {
                ArtistId = 1,
                FirstName = "Alex",
                LastName = "Smith",
                BirthDate = new DateTime(2000, 5, 20)
            });

       

        modelBuilder.Entity<Artwork>().HasData(
            new Artwork()
            {   
                ArtworkId = 1,
                ArtistId = 1,
                Title = "dzielo sztuki",
                YearCreated = 2020
                });
        

        modelBuilder.Entity<Gallery>().HasData(
            new Gallery()
            {
                GalleryId = 1,
                Name = "galeria w wwa",
                EstablishedDate = new DateTime(2020, 1, 1)
            });
        
        modelBuilder.Entity<Gallery>().HasData(
            new Gallery()
            {
                GalleryId = 2,
                Name = "Galeria w krakowie",
                EstablishedDate = new DateTime(1999, 1, 1)
            });
        modelBuilder.Entity<ExhibitionArtwork>().HasData(
            new ExhibitionArtwork()
            {
                ExhibitionId = 1,
                ArtworkId = 1,
                InsuranceValue = new decimal((10000.5))
            });
        
        // modelBuilder.Entity<ExhibitionArtwork>().HasData(
        //     new ExhibitionArtwork()
        //     {
        //         ExhibitionId = 1,
        //         ArtworkId = 1,
        //         InsuranceValue = new decimal((8000.5))
        //     });
        
        modelBuilder.Entity<Exhibition>().HasData(
            new Exhibition()
            {
                ExhibitionId = 1,
                GalleryId = 1,
                Title = "wystawa sztuki numer 1",
                StartDate = new DateTime(2022, 1, 1),
                EndDate = new DateTime(2022, 3, 1),
                NumberOfArtworks = 3
            });
        
        modelBuilder.Entity<Exhibition>().HasData(
            new Exhibition()
            {
                ExhibitionId = 2,
                GalleryId = 1,
                Title = "wystawa sztuki numer 2",
                StartDate = new DateTime(2022, 1, 1),
                EndDate = new DateTime(2023, 2, 1),
                NumberOfArtworks = 4
            });

        /* generacja danych testowych

           modelBuilder.Entity<Customer>().HasData(
               new Customer { CustomerId = 1, FirstName = "Jan", LastName = "Kowalski", PhoneNumber = null }
           );
           modelBuilder.Entity<Models.Program>().HasData(
               new Models.Program { ProgramId = 1, Name = "Quick Wash", DurationMinutes = 69, TemperatureCelsius = 30 },
               new Models.Program { ProgramId = 2, Name = "Cotton Cycle", DurationMinutes = 140, TemperatureCelsius = 40 }
           );
           modelBuilder.Entity<WashingMachine>().HasData(
               new WashingMachine { WashingMachineId = 1, MaxWeight = 7.5m, SerialNumber = "WM123" },
               new WashingMachine { WashingMachineId = 2, MaxWeight = 8.0m, SerialNumber = "WM456" }
           );
           modelBuilder.Entity<AvailableProgram>().HasData(
               new AvailableProgram { AvailableProgramId = 1, WashingMachineId = 1, ProgramId = 1, Price = 10.00m },
               new AvailableProgram { AvailableProgramId = 2, WashingMachineId = 2, ProgramId = 2, Price = 12.50m }
           );
           modelBuilder.Entity<PurchaseHistory>().HasData(
               new PurchaseHistory { AvailableProgramId = 1, CustomerId = 1, PurchaseDate = new DateTime(2024, 6, 9, 12, 0, 0), Rating = 4 },
               new PurchaseHistory { AvailableProgramId = 2, CustomerId = 1, PurchaseDate = new DateTime(2024, 6, 9, 12, 0, 0), Rating = null }
           );


         */

    }
    
}