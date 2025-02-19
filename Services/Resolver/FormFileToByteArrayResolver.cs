﻿using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Shared.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Resolver;

public class FormFileToByteArrayResolver : IValueResolver<AuthorForCreateDto, Author, byte[]?>
{
    public byte[]? Resolve(AuthorForCreateDto source, Author destination, byte[]? destMember, ResolutionContext context)
    {
        return ConvertFileToByteArray(source.Photo);
    }

    private byte[] ConvertFileToByteArray(IFormFile file)
    {
        ArgumentNullException.ThrowIfNull(file);

        using var memoryStream = new MemoryStream();
        file.CopyTo(memoryStream);
        return memoryStream.ToArray();
    }
}