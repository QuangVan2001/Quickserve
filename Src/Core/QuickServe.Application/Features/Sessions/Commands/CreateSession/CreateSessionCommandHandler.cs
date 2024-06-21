using MediatR;
using QuickServe.Application.Features.Categories.Commands.CreateCategory;
using QuickServe.Application.Helpers;
using QuickServe.Application.Interfaces.Repositories;
using QuickServe.Application.Interfaces;
using QuickServe.Application.Utils.Enums;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Categories.Entities;
using System.Threading.Tasks;
using System.Threading;
using QuickServe.Domain.Sessions.Entities;
using System;

namespace QuickServe.Application.Features.Sessions.Commands.CreateSession;

public class CreateSessionCommandHandler(ISessionRepository sessionRepository, IUnitOfWork unitOfWork, ITranslator translator) : IRequestHandler<CreateSessionCommand, BaseResult>
{
    public async Task<BaseResult> Handle(CreateSessionCommand request, CancellationToken cancellationToken)
    {
        if (await sessionRepository.ExistsByNameAsync(request.StoreId , request.Name.Trim()))
        {
            return new BaseResult(new Error(ErrorCode.Duplicate, translator.GetString(TranslatorMessages.SessionMessage.Tên_ca_làm_việc_đã_tồn_tại(request.Name)), nameof(request.Name)));
        }
        TimeSpan startTime = TimeSpan.Parse(request.StartTime);
        TimeSpan endTime = TimeSpan.Parse(request.EndTime);
        if (startTime >= endTime)
        {
            return new BaseResult(new Error(ErrorCode.FieldDataInvalid, translator.GetString(TranslatorMessages.SessionMessage.Thời_gian_bắt_đầu_phải_trước_thời_gian_kết_thúc(request.StoreId)), nameof(request.StoreId)));
        }

        if (await sessionRepository.ExistsByTimeAsync(request.StoreId, startTime, endTime))
        {
            return new BaseResult(new Error(ErrorCode.Duplicate, translator.GetString(TranslatorMessages.SessionMessage.Thời_gian_làm_việc_đã_có_trong_ca_khác(request.StoreId)), nameof(request.StoreId)));
        }
        var session = new Session
        {
            Name = request.Name,
            StartTime = startTime,
            EndTime = endTime,
            StoreId = request.StoreId,
            Status = (int) SessionStatus.Active
        };
        await sessionRepository.AddAsync(session);
        await unitOfWork.SaveChangesAsync();
        return new BaseResult<long>(session.Id);
    }
}