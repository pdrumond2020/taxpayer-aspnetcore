using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Taxpayer.Application.Interface;
using Taxpayer.Application.Model.Enum;
using Taxpayer.Application.Model.Enum.Helper;
using Taxpayer.Application.Model.RequestResponse;
using Taxpayer.Domain.Interface.Services;
using Taxpayer.Domain.Interface.UnitOfWork;

namespace Taxpayer.Application.Implementation
{
    public class EmployeeAppService : IEmployeeAppService
    {
        private readonly IEmployeeService _employeeService;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeAppService(IEmployeeService employeeService, IUnitOfWork unitOfWork)
        {
            _employeeService = employeeService;
            _unitOfWork = unitOfWork;
        }

        public async Task<MessageResponse<IEnumerable<EmployeeResponse>>> ListAsync()
        {
            var messageResponse = new MessageResponse<IEnumerable<EmployeeResponse>>();

            try
            {
                var employess = await _employeeService.ListAsync();
                messageResponse.StatusCode = HttpStatusCode.OK;
                messageResponse.Data = employess;
                messageResponse.Message = messageResponse.Data.Any() ? Enumerations.GetDescription(SuccessAndErrorMessages.SuccessfullyListed) : Enumerations.GetDescription(SuccessAndErrorMessages.NoDateFound);
                messageResponse.Count = messageResponse.Data.Any() ? messageResponse.Data.Count() : 0;
                messageResponse.IsSuccess = true;
            }
            catch (Exception e)
            {
                messageResponse.IsSuccess = false;
                messageResponse.Message = e.Message.ToString();
            }

            return messageResponse;
        }

        public async Task<MessageResponse<EmployeeResponse>> InsertAsync(EmployeeRequest employeeRequest)
        {
            var messageResponse = new MessageResponse<EmployeeResponse>
            {
                Inconsistencies = employeeRequest.Validate()
            };

            var result = false;
            string message = "";

            if (!messageResponse.Inconsistencies.Any())
            {
                var employeeExist = await _employeeService.ListByIdetificationNumberAsync(employeeRequest.IdentificationNumber);
                if (employeeExist == null)
                {
                    _employeeService.InsertAsync(employeeRequest);
                    result = await _unitOfWork.CompletedAsync();
                    message = result ? Enumerations.GetDescription(SuccessAndErrorMessages.SuccessfullyIncluded) : Enumerations.GetDescription(SuccessAndErrorMessages.ErrorOccurredWhileAdding);
                }
                else
                {
                    message = Enumerations.GetDescription(SuccessAndErrorMessages.NotAddedAlreadyExists);
                }
            }

            messageResponse.IsSuccess = result;
            messageResponse.StatusCode = HttpStatusCode.OK;
            messageResponse.Message = message;

            return messageResponse;
        }

        public async Task<MessageResponse<IEnumerable<EmployeeResponse>>> ListCalculationIR(decimal minimumWage)
        {
            var messageResponse = new MessageResponse<IEnumerable<EmployeeResponse>>();

            try
            {
                var employees = await _employeeService.ListCalculationIR(minimumWage);
                messageResponse.StatusCode = HttpStatusCode.OK;
                messageResponse.Data = employees;
                messageResponse.Message = messageResponse.Data.Any() ? Enumerations.GetDescription(SuccessAndErrorMessages.SuccessfullyListed) : Enumerations.GetDescription(SuccessAndErrorMessages.NoDateFound);
                messageResponse.Count = messageResponse.Data.Any() ? messageResponse.Data.Count() : 0;
                messageResponse.IsSuccess = true;
            }
            catch (Exception e)
            {
                messageResponse.IsSuccess = false;
                messageResponse.Message = e.Message.ToString();
            }

            return messageResponse;
        }
    }
}