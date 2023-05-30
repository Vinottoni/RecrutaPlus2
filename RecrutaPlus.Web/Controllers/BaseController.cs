using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RecrutaPlus.Domain.Constants;
using RecrutaPlus.Domain.Interfaces;
using RecrutaPlus.Domain.ValueObjects;

namespace RecrutaPlus.Web.Controllers
{
    public class BaseController : Controller
    {
        protected  IAppLogger _logger;
        protected  IMapper _mapper;

        public BaseController(IAppLogger logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [TempData]
        public string ErrorMessage { get; set; }

        [TempData]
        public string SuccessMessage { get; set; }

        protected string GetUserName()
        {
            return User.Identity.Name ?? DefaultConst.USER_ANONYMOUS;
        }
        protected string GetFullUserName()
        {
            return User.Claims?.FirstOrDefault(f => f.Type == ClaimPrincipalValueObject.NAME)?.Value;
        }
        protected int GetEmployeeeIdLogged()
        {
            return Convert.ToInt32(User.Claims?.FirstOrDefault(f => f.Type == ClaimPrincipalValueObject.EMPLOYEEID)?.Value);
        }
        protected bool GetProfile()
        {
            string profile = User.Claims?.FirstOrDefault(f => f.Type == ClaimPrincipalValueObject.DEFAULT)?.Value;
            bool hasProfile = profile == ClaimPrincipalConst.ADMINISTRADOR || profile == ClaimPrincipalConst.GESTOR || profile == ClaimPrincipalConst.FINANCEIRO;
            return hasProfile;
        }
    }
}
