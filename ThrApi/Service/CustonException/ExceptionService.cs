using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace ThrApi.Service.CustonException
{
    public class ExceptionService : Exception
    {
        public ExceptionService(string message) : base(message){}



    }
}
