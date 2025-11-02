using Belanjayuk.API.Models.LookUpTable;
using Microsoft.EntityFrameworkCore;

namespace Belanjayuk.API.Data;

public class DbSeeder
{
    
    public void SeedLookupTables(ModelBuilder modelBuilder)
    {
        SeedCategories(modelBuilder);
        SeedGenders(modelBuilder);
        SeedPayments(modelBuilder);
    }

    private void SeedCategories(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LtCategory>().HasData(
            CreateLtCategory("ELEC", "Electronics"),
            CreateLtCategory("FASH", "Fashion"),
            CreateLtCategory("HOME", "Home & Living"),
            CreateLtCategory("BEAU", "Beauty & Health"),
            CreateLtCategory("SPORT", "Sports & Outdoors"),
            CreateLtCategory("TOYS", "Toys & Hobbies"),
            CreateLtCategory("HLTH", "Health & Wellness")
        );
    }

    private void SeedGenders(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LtGender>().HasData(
            CreateLtGender("M", "Male"),
            CreateLtGender("F", "Female"),
            CreateLtGender("O", "Other")
        );
    }

    private void SeedPayments(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LtPayment>().HasData(
            CreateLtPayment("CASH", "Cash"),
            CreateLtPayment("CRDT", "Credit Card"),
            CreateLtPayment("DEBT", "Debit Card"),
            CreateLtPayment("E-WLT", "E-Wallet")
        );
    }
    
    private LtPayment CreateLtPayment(string id, string name)
    {
        return new LtPayment
        {
            IdPayment = id,
            PaymentName = name,
            DateIn = DateTime.UtcNow,
            DateUp = DateTime.UtcNow,
            UserIn = "SYSTEM",
            UserUp = "SYSTEM",
            IsActive = true
        };
    }
    
    private LtCategory CreateLtCategory(string id, string name)
    {
        return new LtCategory
        {
            IdCategory = id,
            CategoryName = name,
            DateIn = DateTime.UtcNow,
            DateUp = DateTime.UtcNow,
            UserIn = "SYSTEM",
            UserUp = "SYSTEM",
            IsActive = true
        };
    }
    
    private LtGender CreateLtGender(string id, string name)
    {
        return new LtGender
        {
            IdGender = id,
            GenderName = name,
            DateIn = DateTime.UtcNow,
            DateUp = DateTime.UtcNow,
            UserIn = "SYSTEM",
            UserUp = "SYSTEM",
            IsActive = true
        };
    }
    
    
}