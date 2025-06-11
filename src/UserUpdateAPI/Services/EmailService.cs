using System.Threading.Tasks;

namespace UserUpdateAPI.Services
{
    public interface IEmailService
    {
        Task SendWelcomeEmailAsync(string email, string name);
    }

    public class EmailService : IEmailService
    {
        public async Task SendWelcomeEmailAsync(string email, string name)
        {
            // Simulate sending an email
            await Task.Delay(500); // Simulate email sending delay
            Console.WriteLine($"Welcome email sent to {name} at {email}.");
        }
    }
}