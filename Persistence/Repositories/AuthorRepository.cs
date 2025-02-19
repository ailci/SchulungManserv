using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contracts;

namespace Persistence.Repositories;

public class AuthorRepository(QotdContext qotdContext) :  RepositoryBase<Author>(qotdContext),IAuthorRepository
{
    public async Task<IEnumerable<Author>> GetAuthorsAsync()
    {
        return await GetAll().ToListAsync();
    }

    public async Task<Author> GetAuthorAsync(Guid authorId)
    {
        //QotdContext.Authors.FindAsync(authorId);
        return await FindByCondition(author => author.Id.Equals(authorId)).SingleOrDefaultAsync();
    }

    public void CreateAuthor(Author author)
    {
        Create(author);
    }
}