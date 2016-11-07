using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    using System.IO;

    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.NodeServices;

    public class ImageController : Controller
    {
        public async Task<IActionResult> Resize(string imagePath, [FromServices] IHostingEnvironment environment, [FromServices] INodeServices nodeServices)
        {
            var fileInfo = environment.WebRootFileProvider.GetFileInfo(imagePath);

            if (!fileInfo.Exists)
            {
                return NotFound();
            }

            var result = await nodeServices.InvokeAsync<Stream>("imageresizer.js", fileInfo.PhysicalPath, 300);

            return File(result, "image/jpeg");
        }

        public  IActionResult Index()
        {
            return this.View();
        }
    }
}
