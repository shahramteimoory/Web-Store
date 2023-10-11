﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Store.Application.Interfaces.Contexts;
using Web_Store.Application.Interfaces.FacadPatterns;
using Web_Store.Application.Services.Finances.Commands.AddRequestPay;
using Web_Store.Application.Services.Finances.Queries.GetRequestPay;

namespace Web_Store.Application.Services.Finances.FacadPattern
{
    public class FinancesFacad : IFinancesFacad
    {
        private readonly IDataBaseContext _context;
        public FinancesFacad(IDataBaseContext context)
        {
            _context=context;
        }
        private IAddRequestPayService _AddRequestPayService;
        public IAddRequestPayService AddRequestPayService
        {
            get
            {
               return _AddRequestPayService = _AddRequestPayService ?? new AddRequestPayService(_context);
            }
        }
        private IGetRequestPayService _getRequestPayService;
        public IGetRequestPayService getRequestPayService
        {
            get
            {
                return _getRequestPayService = _getRequestPayService ?? new GetRequestPayService(_context);
            }
        }
    }
}