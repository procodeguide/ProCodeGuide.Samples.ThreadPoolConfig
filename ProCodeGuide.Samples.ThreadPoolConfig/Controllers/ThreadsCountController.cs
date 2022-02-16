using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProCodeGuide.Samples.ThreadPoolConfig.Models;

namespace ProCodeGuide.Samples.ThreadPoolConfig.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThreadsCountController : ControllerBase
    {
        [HttpGet]
        public ThreadCount Get()
        {
            ThreadCount threadCount = new();

            ThreadPool.GetMinThreads(out int workerThreads, out int completionPortThreads);
            threadCount.MinWorkerThreads = workerThreads;
            threadCount.MinCompletionPortThreads = completionPortThreads;

            ThreadPool.GetMaxThreads(out workerThreads, out completionPortThreads);
            threadCount.MaxWorkerThreads = workerThreads;
            threadCount.MaxCompletionPortThreads = completionPortThreads;

            return threadCount;
        }
    }
}
