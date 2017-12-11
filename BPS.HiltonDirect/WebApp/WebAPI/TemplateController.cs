using BPS.HiltonDirect.Core.Context;
using BPS.HiltonDirect.Model;
using BPS.HiltonDirect.Model.Configuration;
using BPS.HiltonDirect.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BPS.HiltonDirect.WebApp.WebAPI
{
    public class TemplateController : BaseApiController
    {
        private ILogger logger;
        private IFileReadingService fileReadingService;

        public TemplateController(ILogger logger, IFileReadingService fileReadingService)
        {
            this.logger = logger;
            this.fileReadingService = fileReadingService;
        }

        public Model.Client.ClientServiceResult<IEnumerable<Model.Client.ViewModel.TemplateFile>> GetTemplates()
        {
            Model.Client.ClientServiceResult<IEnumerable<Model.Client.ViewModel.TemplateFile>> result = new Model.Client.ClientServiceResult<IEnumerable<Model.Client.ViewModel.TemplateFile>>();

            try
            {
                string rootFolder = HttpContext.Current.Server.MapPath("~");

                List<ClientFile> files = fileReadingService.ReadFolder(rootFolder + @"\Scripts\application", rootFolder + @"\Scripts\application", true, "html", true).ToList();

                result.Data = files.Select(f => new Model.Client.ViewModel.TemplateFile
                {
                    Id = f.ServerRelativeUrl + f.FileName,
                    Template = f.FileContent
                });
            }
            catch (Exception ex)
            {
                logger.LogException(ex);
                result.HasError = true;
                result.ErrorMessage = "Error loading templates";
            }

            return result;
        }
    }
}
