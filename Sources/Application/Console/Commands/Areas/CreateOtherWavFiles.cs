using System;
using System.Threading.Tasks;
using Mmu.SpeechService.Application.Mediation.Services;
using Mmu.SpeechService.Application.UseCases.CreateOtherWavFiles;
using Mmu.SpeechService.Console.Commands.Infrastructure.Models;

namespace Mmu.SpeechService.Console.Commands.Areas
{
    public class CreateOtherWavFiles : IConsoleCommand
    {
        private readonly IMediationService _mediator;

        public CreateOtherWavFiles(IMediationService mediator)
        {
            _mediator = mediator;
        }

        public string Description => "Create other WAV files";
        public ConsoleKey Key => ConsoleKey.F1;

        public async Task ExecuteAsync()
        {
            await _mediator.SendAsync(new CreateOtherWavFilesCommand());
        }
    }
}