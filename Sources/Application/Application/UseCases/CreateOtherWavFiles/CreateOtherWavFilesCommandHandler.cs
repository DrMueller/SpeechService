using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Mmu.SpeechService.Domain.SsmlFileReading.Services;
using Mmu.SpeechService.Domain.WavCreation.Services;
using Mmu.SpeechService.Domain.WavFileSaving;

namespace Mmu.SpeechService.Application.UseCases.CreateOtherWavFiles
{
    public class CreateOtherWavFilesCommandHandler : IRequestHandler<CreateOtherWavFilesCommand>
    {
        private readonly ISsmlFileReader _ssmlFileReader;
        private readonly IWavFileFactory _wavFileFactory;
        private readonly IWavFileSaver _wavFileSaver;

        public CreateOtherWavFilesCommandHandler(
            ISsmlFileReader ssmlFileReader,
            IWavFileFactory wavFileFactory,
            IWavFileSaver wavFileSaver)
        {
            _ssmlFileReader = ssmlFileReader;
            _wavFileFactory = wavFileFactory;
            _wavFileSaver = wavFileSaver;
        }

        public async Task<Unit> Handle(CreateOtherWavFilesCommand request, CancellationToken cancellationToken)
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