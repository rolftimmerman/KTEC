using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KTEC.Core.Domain.Interfaces;
using MediatR;

namespace KTEC.Core.Application.Queries
{
    public class GetCameraListQueryHandler : IRequestHandler<GetCameraListQuery, CameraListVm>
    {
        private readonly ICameraRepository _repository;

        public GetCameraListQueryHandler(ICameraRepository repository)
        {
            _repository = repository;
        }

        public async Task<CameraListVm> Handle(GetCameraListQuery request, CancellationToken cancellationToken)
        {
            var cameras = await Task.Run(() => _repository.GetAll().Select(c => c.CreateMap()).ToList(), cancellationToken);

            var vm = new CameraListVm
            {
                Cameras = cameras,
                Count = cameras.Count()
            };

            return vm;
        }
    }
}