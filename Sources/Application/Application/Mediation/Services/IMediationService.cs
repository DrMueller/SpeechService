using System.Threading.Tasks;
using Mmu.SpeechService.Application.Mediation.Models;

namespace Mmu.SpeechService.Application.Mediation.Services
{
    public interface IMediationService
    {
        Task<T> SendAsync<T>(ICommand<T> command);

        Task SendAsync(ICommand command);

        Task<T> SendAsync<T>(IQuery<T> query);
    }
}