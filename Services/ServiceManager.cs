using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Persistence.Contracts;

namespace Services;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IQotdService> _qotdService;

    public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _qotdService = new Lazy<IQotdService>(() => new QotdService(repositoryManager, mapper));
    }

    public IQotdService QotdService => _qotdService.Value;
}