using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MvcStartApp.Models.Db;
using System.Threading.Tasks;
using System;
using static System.Net.WebRequestMethods;

namespace MvcStartApp.Controllers
{
    public class RequestController
    {
        // ссылка на репозиторий
        private readonly IRequestRepository _repo;
        private readonly ILogger<RequestController> _logger;
        public RequestController(ILogger<RequestController> logger, IRequestRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }
       

    }
}
