using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;


namespace Application.Account.Commands
{
    public class AccountCreateValidator : IPipelineBehavior<AccountCreate.Command, OperationResult<AccountCreate.Response>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountCreateValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<AccountCreate.Response>> Handle(AccountCreate.Command request, CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult<AccountCreate.Response>> next)
        {
            var nationalCodeExists = await _unitOfWork.AccountRepository.IsExistNationCode(request.NationalCode);
            if (nationalCodeExists)
            {
                var result = OperationResult<AccountCreate.Response>.BuildFailure(new Exception("این کد ملی قبلا ثبت شده است"), "این کد ملی قبلا ثبت شده است");

                return result;
                //throw 
            }
            var accountalNumberExists = await _unitOfWork.AccountRepository.IsExistAccountalNumber(request.AccountalNumber);
            if (accountalNumberExists)
            {
                var result = OperationResult<AccountCreate.Response>.BuildFailure(new Exception("این کد پرسنلی قبلا ثبت شده است"), "این کد پرسنلی قبلا ثبت شده است");

                return result;
                //throw 
            }

            //Postds
            foreach (var postId in request.PostIds)
            {
                var post = await _unitOfWork.PostRepository.FindById(postId);
                if (post == null)
                {
                    return OperationResult<AccountCreate.Response>.BuildFailure("سمت انتخاب شده نامعتبر می باشد");
                }
            }

            var response = await next();
            return response;
        }
    }
}
