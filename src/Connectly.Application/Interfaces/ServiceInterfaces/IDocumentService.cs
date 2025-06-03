﻿using Connectly.Application.DTOs;
using Connectly.Application.DTOs.UserDtos;
using FluentResults;

namespace Connectly.Application.Interfaces.ServiceInterfaces;

public interface IDocumentService
{
    Task<Result<IEnumerable<DocumentDto>>> GetAllDocuments();
    Task<Result> AddDocumentAsync(DocumentDto? document);
    Task<Result> UpdateDocumentAsync(DocumentDto document, Guid id);
    Task<Result<IEnumerable<DocumentDto>>> GetDocumentsByResourceId(Guid resourceId);
    Task<FileDataDto?> GetFileData(Guid documentId);
    Task<List<FileDataDto>> GetImagesForUserByEventId(Guid eventId);
    Task<Result> DeleteDocumentAsync(Guid id);
}