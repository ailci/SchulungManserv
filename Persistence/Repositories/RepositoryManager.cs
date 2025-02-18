using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Persistence.Contracts;

namespace Persistence.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly QotdContext _qotdContext;
    private readonly Lazy<IQuoteRepository> _quoteRepository;

    public RepositoryManager(QotdContext qotdContext)
    {
        _qotdContext = qotdContext;
        _quoteRepository = new Lazy<IQuoteRepository>(() => new QuoteRepository(qotdContext));
    }

    public IQuoteRepository QuoteRepo => _quoteRepository.Value;
    
    public async Task SaveAsync() => await _qotdContext.SaveChangesAsync();
}