using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace UserUpdateAPI.Services
{
    public interface ICreateCustomerService
    {
        Task<CreateCustomerResult> CreateCustomerAsync(CreateCustomerRequest request);
    }

    public class CreateCustomerService : ICreateCustomerService
    {
        private readonly AppDbContext _dbContext;
        private readonly IEmailService _emailService;

        public CreateCustomerService(AppDbContext dbContext, IEmailService emailService)
        {
            _dbContext = dbContext;
            _emailService = emailService;

        }

        public async Task<CreateCustomerResult> CreateCustomerAsync(CreateCustomerRequest request)
        {
            // Check for duplicate email
            if (await _dbContext.Customers.AnyAsync(c => c.Email == request.Email))
            {
                return new CreateCustomerResult
                {
                    IsSuccess = false,
                    StatusCode = 409,
                    Message = "Email already exists."
                };
            }

            // Add new customer
            var customer = new Customer
            {
                Name = request.Name,
                Email = request.Email
            };

            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync();

            // Send welcome email
            await _emailService.SendWelcomeEmailAsync(customer.Email, customer.Name);
            return new CreateCustomerResult
            {
                IsSuccess = true,
                StatusCode = 201,
                Message = "Customer created successfully.",
                CustomerId = customer.Id
            };
        }
    }

    public class CreateCustomerRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class CreateCustomerResult
    {
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public int? CustomerId { get; set; }
    }

    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}