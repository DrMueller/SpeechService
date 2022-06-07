using System;
using System.Threading.Tasks;
using Mmu.FrenchLearningSystem.Application.Mediation.Services;
using Mmu.FrenchLearningSystem.Application.UseCases.CreateOtherTranslations;
using Mmu.FrenchLearningSystem.Console.Commands.Models;

namespace Mmu.FrenchLearningSystem.Console.Commands.Areas
{
    public class CreateOtherTranslations : IConsoleCommand
    {
        private readonly IMediationService _mediator;

        public CreateOtherTranslations(IMediationService mediator)
        {
            _mediator = mediator;
        }

        public string Description { get; } = "Create other translations";
        public ConsoleKey Key { get; } = ConsoleKey.F1;

        public async Task ExecuteAsync()
        {
            await _mediator.SendAsync(new CreateOtherTranslationsCommand());
        }
    }
}