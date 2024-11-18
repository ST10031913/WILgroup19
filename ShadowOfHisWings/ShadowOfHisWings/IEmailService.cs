using System.Threading.Tasks;
using ShadowOfHisWings.Models;

namespace ShadowOfHisWings.Services
{
    public interface IEmailService
    {
        Task SendContactEmailAsync(Contact contact);
    }
}
