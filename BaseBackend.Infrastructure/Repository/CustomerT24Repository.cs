using BaseBackend.Application;
using BaseBackend.Domain;
using BaseBackend.Domain.Constant;
using Bogus;
using Dapper;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBackend.Infrastructure
{
    public class CustomerT24Repository : BaseRepository<CustomerT24, CustomerT24Filter>, ICustomerT24Repository
    {
        public CustomerT24Repository(IUnitOfWork uow) : base(uow)
        {
        }

        public override Task<List<CustomerT24>> GetPagingAsync(PagingInfo pagingInfo, CustomerT24Filter filter)
        {
            throw new NotImplementedException();
        }

        public async void SeedAccountInfo()
        {
            //var fakerCustomerRes = new Faker<CustomerInfoRes>()
            //    .RuleFor(c => c.CIF, f => "1005" + f.Random.Number(1000, 9999).ToString());

            //var faker = new Faker<CustomerT24>("en")
            //.RuleFor(a => a.CustomerName, f => f.Name.FullName())
            //.RuleFor(a => a.AccountTitle, f => f.Company.CompanyName())
            //.RuleFor(a => a.Category, f => f.Random.Word())
            //.RuleFor(a => a.Currency, f => "VND")
            //.RuleFor(a => a.WorkingBalance, f => f.Finance.Amount(1000000, 1000000000).ToString())
            //.RuleFor(a => a.LockedAmount, f => f.Finance.Amount(1000000, 1000000000).ToString())
            //.RuleFor(a => a.PostingRestrict, f => f.Random.Bool().ToString())
            //.RuleFor(a => a.Company, f => f.Company.CompanyName())
            //.RuleFor(a => a.Message, f => f.Lorem.Sentence())
            //.RuleFor(a => a.BlockAction, f => f.Random.Bool())
            //.RuleFor(a => a.PostingRestrictDesc, f => f.Lorem.Sentence())
            //.RuleFor(a => a.PostingRestrictType, f => f.Random.Word())
            //.RuleFor(a => a.Category_Name, f => f.Commerce.Department())
            //.RuleFor(a => a.IsPaymentAccount, f => f.Random.Bool());
            //using (var connection = Uow.Connection)
            //{
            //    connection.Open();

            //    for (int i = 0; i < 10; i++) // Sinh 10 bản ghi
            //    {
            //        var account = faker.Generate();

            //        string query = @"INSERT INTO accountinfo 
            //                    ( Cif, CustomerName, AccountTitle, acctTitle, Category, Currency, 
            //                    WorkingBalance, LockedAmount, PostingRestrict, InactivMarker, Company, 
            //                    Message, BlockAction, PostingRestrictDesc, PostingRestrictType, 
            //                    Category_Name, IsPaymentAccount) 
            //                    VALUES 
            //                    ( @Cif, @CustomerName, @AccountTitle, @acctTitle, @Category, @Currency, 
            //                    @WorkingBalance, @LockedAmount, @PostingRestrict, @InactivMarker, @Company, 
            //                    @Message, @BlockAction, @PostingRestrictDesc, @PostingRestrictType, 
            //                    @Category_Name, @IsPaymentAccount)";

            //        using (var command = new MySqlCommand(query, (MySqlConnection) connection))
            //        {
            //            command.Parameters.AddWithValue("@Id", Guid.NewGuid().ToString());
            //            command.Parameters.AddWithValue("@Cif", account.Cif);
            //            command.Parameters.AddWithValue("@CustomerName", account.CustomerName);
            //            command.Parameters.AddWithValue("@AccountTitle", account.AccountTitle);
            //            command.Parameters.AddWithValue("@acctTitle", account.AccountTitle); // giả sử giống AccountTitle
            //            command.Parameters.AddWithValue("@Category", account.Category);
            //            command.Parameters.AddWithValue("@Currency", account.Currency);
            //            command.Parameters.AddWithValue("@WorkingBalance", account.WorkingBalance);
            //            command.Parameters.AddWithValue("@LockedAmount", account.LockedAmount);
            //            command.Parameters.AddWithValue("@PostingRestrict", account.PostingRestrict);
            //            command.Parameters.AddWithValue("@InactivMarker", DBNull.Value); // Giả sử dữ liệu trống
            //            command.Parameters.AddWithValue("@Company", account.Company);
            //            command.Parameters.AddWithValue("@Message", account.Message);
            //            command.Parameters.AddWithValue("@BlockAction", account.BlockAction);
            //            command.Parameters.AddWithValue("@PostingRestrictDesc", account.PostingRestrictDesc);
            //            command.Parameters.AddWithValue("@PostingRestrictType", account.PostingRestrictType);
            //            command.Parameters.AddWithValue("@Category_Name", account.Category_Name);
            //            command.Parameters.AddWithValue("@IsPaymentAccount", account.IsPaymentAccount);

            //            command.ExecuteNonQuery();
            //        }
            //    }
            //}

            var customerFaker = new Faker<CustomerInfoRes>()
            .RuleFor(c => c.CIF, f => "1005" + f.Random.Number(1000, 9999).ToString())
            .RuleFor(c => c.Name, f => f.Name.FullName())
            .RuleFor(c => c.Sector, f => f.PickRandom(new[] { "1000", "1999", "2999", "3000", "1100", "1900"}))
            .RuleFor(c => c.TaxId, f => f.Random.Replace("TAX-####"))
            .RuleFor(c => c.Company, f => f.Company.CompanyName())
            .RuleFor(c => c.CustomerStatus, f => f.PickRandom(new[] { "Active", "Inactive", "Suspended" }))
            .RuleFor(c => c.Industry, f => f.Commerce.Categories(1)[0])
            .RuleFor(c => c.Target, f => f.Lorem.Word())
            .RuleFor(c => c.CustomerType, f => f.PickRandom(new[] { "Individual", "Corporate" }))
            .RuleFor(c => c.Residence, f => f.Address.City())
            .RuleFor(c => c.Nationality, f => f.Address.Country())
            .RuleFor(c => c.IdentifyMethod, f => f.PickRandom(new[] { "Passport", "National ID", "Driver's License" }))
            .RuleFor(c => c.DateOfBirth, f => f.Date.Past(30, DateTime.Now.AddYears(-20)).ToString("yyyy-MM-dd"))
            .RuleFor(c => c.Gender, f => f.PickRandom(new[] { "Male", "Female", "Other" }))
            .RuleFor(c => c.IdentType, f => f.PickRandom(new[] { "Passport", "National ID", "Driver's License" }))
            .RuleFor(c => c.IdentNo, f => f.Random.Replace("ID-######"))
            .RuleFor(c => c.IdentDate, f => f.Date.Past(10, DateTime.Now).ToString("yyyy-MM-dd"))
            .RuleFor(c => c.IdentExpDate, f => f.Date.Future(10).ToString("yyyy-MM-dd"))
            .RuleFor(c => c.IdentPlace, f => f.Address.City())
            .RuleFor(c => c.PhoneNumber, f => f.Phone.PhoneNumber())
            .RuleFor(c => c.PostingRestrict, f => f.PickRandom(new[] { "None", "Blocked", "Pending" }))
            .RuleFor(c => c.Address, f => f.Address.FullAddress())
            .RuleFor(c => c.ContactPerson, f => f.Name.FullName())
            .RuleFor(c => c.Position, f => f.Name.JobTitle())
            .RuleFor(c => c.BirthDate, f => f.Date.Past(30, DateTime.Now.AddYears(-20)).ToString("yyyy-MM-dd"))
            .RuleFor(c => c.IdNum, f => f.Random.Replace("ID-######"))
            .RuleFor(c => c.IssueDate, f => f.Date.Past(10, DateTime.Now).ToString("yyyy-MM-dd"))
            .RuleFor(c => c.PlaceOfIssue, f => f.Address.City())
            .RuleFor(c => c.CustomerSectorType, f => f.Random.Int(1, 10))
            .RuleFor(c => c.CustomerSectorName, f => f.Commerce.Categories(1)[0])
            .RuleFor(c => c.Message, f => f.Lorem.Sentence())
            .RuleFor(c => c.BlockAction, f => f.Random.Bool())
            .RuleFor(c => c.PostingRestrictDesc, f => f.Lorem.Sentence())
            .RuleFor(c => c.PostingRestrictType, f => f.PickRandom(new[] { "Type1", "Type2", "Type3" }));

            var customers = customerFaker.Generate(10); // Generate 10 customers

            using (var connection = (MySqlConnection) Uow.Connection)
            {
                connection.Open();

                foreach (var customer in customers)
                {
                    var command = new MySqlCommand(@"INSERT INTO Customer (CIF, Name, Sector, TaxId, Company, CustomerStatus, Industry, 
                    Target, CustomerType, Residence, Nationality, IdentifyMethod, DateOfBirth, Gender, IdentType, IdentNo, IdentDate, 
                    IdentExpDate, IdentPlace, PhoneNumber, PostingRestrict, Address, ContactPerson, Position, BirthDate, IdNum, 
                    IssueDate, PlaceOfIssue, Account, ListAccount, CustomerSectorType, CustomerSectorName, Message, BlockAction, 
                    PostingRestrictDesc, PostingRestrictType) 
                    VALUES (@CIF, @Name, @Sector, @TaxId, @Company, @CustomerStatus, @Industry, @Target, @CustomerType, @Residence, 
                    @Nationality, @IdentifyMethod, @DateOfBirth, @Gender, @IdentType, @IdentNo, @IdentDate, @IdentExpDate, @IdentPlace, 
                    @PhoneNumber, @PostingRestrict, @Address, @ContactPerson, @Position, @BirthDate, @IdNum, @IssueDate, @PlaceOfIssue, 
                    @Account, @ListAccount, @CustomerSectorType, @CustomerSectorName, @Message, @BlockAction, @PostingRestrictDesc, 
                    @PostingRestrictType);", connection);

                    command.Parameters.AddWithValue("@CIF", customer.CIF);
                    command.Parameters.AddWithValue("@Name", customer.Name);
                    command.Parameters.AddWithValue("@Sector", customer.Sector);
                    command.Parameters.AddWithValue("@TaxId", customer.TaxId);
                    command.Parameters.AddWithValue("@Company", customer.Company);
                    command.Parameters.AddWithValue("@CustomerStatus", customer.CustomerStatus);
                    command.Parameters.AddWithValue("@Industry", customer.Industry);
                    command.Parameters.AddWithValue("@Target", customer.Target);
                    command.Parameters.AddWithValue("@CustomerType", customer.CustomerType);
                    command.Parameters.AddWithValue("@Residence", customer.Residence);
                    command.Parameters.AddWithValue("@Nationality", customer.Nationality);
                    command.Parameters.AddWithValue("@IdentifyMethod", customer.IdentifyMethod);
                    command.Parameters.AddWithValue("@DateOfBirth", customer.DateOfBirth);
                    command.Parameters.AddWithValue("@Gender", customer.Gender);
                    command.Parameters.AddWithValue("@IdentType", customer.IdentType);
                    command.Parameters.AddWithValue("@IdentNo", customer.IdentNo);
                    command.Parameters.AddWithValue("@IdentDate", customer.IdentDate);
                    command.Parameters.AddWithValue("@IdentExpDate", customer.IdentExpDate);
                    command.Parameters.AddWithValue("@IdentPlace", customer.IdentPlace);
                    command.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
                    command.Parameters.AddWithValue("@PostingRestrict", customer.PostingRestrict);
                    command.Parameters.AddWithValue("@Address", customer.Address);
                    command.Parameters.AddWithValue("@ContactPerson", customer.ContactPerson);
                    command.Parameters.AddWithValue("@Position", customer.Position);
                    command.Parameters.AddWithValue("@BirthDate", customer.BirthDate);
                    command.Parameters.AddWithValue("@IdNum", customer.IdNum);
                    command.Parameters.AddWithValue("@IssueDate", customer.IssueDate);
                    command.Parameters.AddWithValue("@PlaceOfIssue", customer.PlaceOfIssue);
                    command.Parameters.AddWithValue("@Account", customer.Account);
                    command.Parameters.AddWithValue("@ListAccount", customer.ListAccount);
                    command.Parameters.AddWithValue("@CustomerSectorType", customer.CustomerSectorType);
                    command.Parameters.AddWithValue("@CustomerSectorName", customer.CustomerSectorName);
                    command.Parameters.AddWithValue("@Message", customer.Message);
                    command.Parameters.AddWithValue("@BlockAction", customer.BlockAction);
                    command.Parameters.AddWithValue("@PostingRestrictDesc", customer.PostingRestrictDesc);
                    command.Parameters.AddWithValue("@PostingRestrictType", customer.PostingRestrictType);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}
