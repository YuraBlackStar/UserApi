using Core.Interfaces;
using Microsoft.Extensions.Configuration;
using System;

namespace CrossCutting.Params
{
    public class AppParameters : IAppParameters
    {
        private readonly IConfiguration _config;
        public AppParameters(IConfiguration config)
        {
            _config = config;
        }

        //public string DapperConnectionString => _config.GetConnectionString("DapperConnection");

        //public int NumExecutions => Convert.ToInt32(_config["Parameters:Executions"]);
    }
}
