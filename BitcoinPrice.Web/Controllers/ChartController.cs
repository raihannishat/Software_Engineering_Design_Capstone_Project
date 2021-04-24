using BitcoinPrice.Library;
using BitcoinPrice.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitcoinPrice.Web.Controllers
{
    public class ChartController : Controller
    {
        private IBitCoinUnitOfWork _bitCoinUnitOfWork;
        private BitCoinContext _dbContext;
        public ChartController( IBitCoinUnitOfWork bitCoinUnitOfWork, BitCoinContext bitCoinContext)
        {
            _bitCoinUnitOfWork = bitCoinUnitOfWork;
            _dbContext = bitCoinContext;
        }
        public IActionResult Index()
        {
            var model = _dbContext.BitCoinPrice
                .Include(x => x.bpi.USD)
                .Include( be => be.bpi.EUR)
                .Include( be => be.bpi.GBP)
                .Include(y => y.time).OrderByDescending( t => t.time.updatedISO).ToList();
                                         
            return View(model);
        }
    }
}
