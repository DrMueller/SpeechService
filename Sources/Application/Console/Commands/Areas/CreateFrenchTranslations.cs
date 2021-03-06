using System;
using System.Threading.Tasks;
using Mmu.SpeechService.Application.Mediation.Services;
using Mmu.SpeechService.Application.UseCases.CreateFrenchTranslations;
using Mmu.SpeechService.Console.Commands.Infrastructure.Models;

namespace Mmu.SpeechService.Console.Commands.Areas
{
    public class CreateFrenchTranslations : IConsoleCommand
    {
        private readonly IMediationService _mediator;

        public CreateFrenchTranslations(IMediationService mediator)
        {
            _mediator = mediator;
        }

        public string Description => "Create french translations";
        public ConsoleKey Key => ConsoleKey.F2;

        public async Task ExecuteAsync()
        {
            await _mediator.SendAsync(new CreateFrenchTranslationsCommand());
        }
    }
}