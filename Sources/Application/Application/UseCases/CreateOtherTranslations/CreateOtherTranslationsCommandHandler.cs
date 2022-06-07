using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mmu.FrenchLearningSystem.Domain.SsmlFileReading.Services;
using Mmu.FrenchLearningSystem.Domain.WavCreation.Services;
using Mmu.FrenchLearningSystem.Domain.WavFileSaving;

namespace Mmu.FrenchLearningSystem.Application.UseCases.CreateOtherTranslations
{
    public class CreateOtherTranslationsCommandHandler : IRequestHandler<CreateOtherTranslationsCommand>
    {
        private readonly ISsmlFileReader _ssmlFileReader;
        private readonly IWavFileFactory _wavFileFactory;
        private readonly IWavFileSaver _wavFileSaver;

        public CreateOtherTranslationsCommandHandler(
            ISsmlFileReader ssmlFileReader,
            IWavFileFactory wavFileFactory,
            IWavFileSaver wavFileSaver)
        {
            _ssmlFileReader = ssmlFileReader;
            _wavFileFactory = wavFileFactory;
            _wavFileSaver = wavFileSaver;
        }

        public async Task<Unit> Handle(CreateOtherTranslationsCommand request, CancellationToken cancellationToken)
        {
            var otherFiles = await _ssmlFileReader.ReadInDirectoryAsync("OtherTranslations");

            foreach (var of in otherFiles)
            {
                var wavResult = await _wavFileFactory.CreateAsync(of);
                await _wavFileSaver.SaveLocalAsync(wavResult);
            }

            return Unit.Value;
        }
    }
}