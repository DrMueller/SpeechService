using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mmu.FrenchLearningSystem.Domain.SsmlFileReading.Services;
using Mmu.FrenchLearningSystem.Domain.WavCreation.Services;
using Mmu.FrenchLearningSystem.Domain.WavFileSaving;

namespace Mmu.FrenchLearningSystem.Application.UseCases.CreateFrenchTranslations
{
    internal class CreateFrenchTranslationsCommandHandler : IRequestHandler<CreateFrenchTranslationsCommand>
    {
        private readonly ISsmlFileReader _ssmlFileReader;
        private readonly IWavFileFactory _wavFileFactory;
        private readonly IWavFileSaver _wavFileSaver;

        public CreateFrenchTranslationsCommandHandler(
            ISsmlFileReader ssmlFileReader,
            IWavFileFactory wavFileFactory,
            IWavFileSaver wavFileSaver)
        {
            _ssmlFileReader = ssmlFileReader;
            _wavFileFactory = wavFileFactory;
            _wavFileSaver = wavFileSaver;
        }

        public async Task<Unit> Handle(CreateFrenchTranslationsCommand request, CancellationToken cancellationToken)
        {
            var transSsml = await _ssmlFileReader.ReadFileAsync("TranslationTexts.xml");
            var wavFile = await _wavFileFactory.CreateAsync(transSsml);
            await _wavFileSaver.SaveToBlobAsync(wavFile);

            return Unit.Value;
        }
    }
}