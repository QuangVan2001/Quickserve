﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuickServe.Application.DTOs.Payment;
using QuickServe.Application.Features.Payments.Commands.CreatePayment;
using QuickServe.Application.Utils.Payments.Model;
using QuickServe.Application.Wrappers;
using QuickServe.Domain.Settings;
using System.Threading;
using System;
using System.Threading.Tasks;
using QuickServe.Application.Interfaces;
using System.Linq;

namespace QuickServe.WebApi.Controllers.v1
{
    [ApiVersion("1")]
    public class PaymentsController : BaseApiController
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost("CreateVNPayPayment")]
        public async Task<BaseResult<Application.DTOs.Payment.PaymentResponse>> CreateVNPayPaymentAsync([FromBody] CreatePaymentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpGet("call-back")]
        public async Task<BaseResult<PaymentCallBackResult>> CallBack()
        {
            var payment = new GetVNPayPayment()
            {
                SecureHash = Request.Query["vnp_SecureHash"],
                TransDate = Request.Query["vnp_CreateDate"],
                TxnRef = Request.Query["vnp_TxnRef"]
            };

            var result = await _paymentService.VNPayCallBackResultAsync(payment, cancellationToken: default);

            return new BaseResult<PaymentCallBackResult>(result);
        }
    }
}