using Application.Common;
using Infrastructure.Persistance.Repositories;
using MediatR;


namespace Application.Person.Commands
{
    public class PersonCreateValidator : IPipelineBehavior<PersonCreate.Command, OperationResult<PersonCreate.Response>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonCreateValidator(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResult<PersonCreate.Response>> Handle(PersonCreate.Command request, CancellationToken cancellationToken, RequestHandlerDelegate<OperationResult<PersonCreate.Response>> next)
        {
            var nationalCodeExists = await _unitOfWork.PersonRepository.IsExistNationCode(request.NationalCode);
            if (nationalCodeExists)
            {
                var result = OperationResult<PersonCreate.Response>.BuildFailure(new Exception("این کد ملی قبلا ثبت شده است"), "این کد ملی قبلا ثبت شده است");

                return result;
                //throw 
            }
            var personalNumberExists = await _unitOfWork.PersonRepository.IsExistPersonalNumber(request.PersonalNumber);
            if (personalNumberExists)
            {
                var result = OperationResult<PersonCreate.Response>.BuildFailure(new Exception("این کد پرسنلی قبلا ثبت شده است"), "این کد پرسنلی قبلا ثبت شده است");

                return result;
                //throw 
            }

            //Postds
            foreach (var postId in request.PostIds)
            {
                var post = await _unitOfWork.PostRepository.FindById(postId);
                if (post == null)
                {
                    return OperationResult<PersonCreate.Response>.BuildFailure("سمت انتخاب شده نامعتبر می باشد");
                }
            }

            var response = await next();
            return response;
        }
    }
}
