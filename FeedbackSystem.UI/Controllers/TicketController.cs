using FeedbackSystem.Core.Dtos;
using FeedbackSystem.Core.Entities;
using FeedbackSystem.Core.Interfaces.IServices;
using FeedbackSystem.UI.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackSystem.UI.Controllers
{
    [Route("/feedback")]
    public class TicketController : Controller
    {
        private readonly IPlaceService _placeService;

        private readonly ISenderTypeService _senderTypeService;
        private readonly IRequestTypeService _requestTypeService;
        private readonly IClassificationService _classificationService;
        private readonly ITicketService _ticketService;
        private readonly IWebHostEnvironment _environment;

        public TicketController(ISenderTypeService senderTypeService, IClassificationService classificationService, IPlaceService placeService, IRequestTypeService requestTypeService, ITicketService ticketService, IWebHostEnvironment environment)
        {
            _senderTypeService = senderTypeService;
            _classificationService = classificationService;
            _placeService = placeService;
            _requestTypeService = requestTypeService;
            _ticketService = ticketService;
            _environment = environment;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("{Id:long}/Create")]
        public async Task<IActionResult> Create(long Id)
        {
            try
            {
                var requestViewModel = new RequestViewModel();

                if (Id != null)
                {
                    var senderTypes = await _senderTypeService.GetAllSenderTypes();
                    var requestTypes = await _requestTypeService.GetAllRequestTypes();
                    var classification = await _classificationService.GetAllClassifications();
                    requestViewModel = new RequestViewModel()
                    {
                        senderTypes = senderTypes.Where(s => s.DeletedAt == null),
                        requestTypes = requestTypes.Where(r => r.DeletedAt == null),
                        classifications = classification.Where(c => c.DeletedAt == null),
                        place = await _placeService.GetPlaceById(Id)
                    };
                }



                return View(requestViewModel);
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        [HttpPost("CreateRequest")]
        public async Task<IActionResult> CreateRequest(CreateRequestViewModel createRequestVM)
        {
            try
            {
                var ticketDto = new TicketDto()
                {
                    Rate = createRequestVM.rate,
                    ClassificationId = createRequestVM.classification,
                    RequestTypeId = createRequestVM.requestType,
                    PlaceId = createRequestVM.place,
                    ResponseTypeId = 1, // gets a new request of id 1 when it created.
                    SenderTypeId = createRequestVM.senderType,
                    Description = createRequestVM.description,
                    OtherRequest = createRequestVM.otherRequestType,
                    OtherClassification = createRequestVM.otherClassification,
                    SenderName = createRequestVM.name,
                    SenderEmail = createRequestVM.email,
                    SenderPhone = createRequestVM.phone,
                    CreatedAt = DateTime.UtcNow,


                };
                var requestTicket = await _ticketService.CreateTicketType(ticketDto, await CreateTicketsImage(createRequestVM.uploadImgs));
                return View();
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        private async Task<List<TicketImagesDto?>> CreateTicketsImage(List<IFormFile> images)
        {
            if (images != null)
            {
                var ticketImages = new List<TicketImagesDto>();
                foreach (var ImageUpload in images)
                {
                    if (ImageUpload != null && ImageUpload.Length > 0)
                    {
                        // Check if the uploaded file is an image
                        if (!ImageUpload.ContentType.StartsWith("image"))
                        {
                            ModelState.AddModelError("Image", "Please upload a valid image file.");

                        }

                        var uploadsFolder = Path.Combine(_environment.ContentRootPath, "wwwroot", "TicketsImages");
                        var uniqueFileName = $"{Guid.NewGuid().ToString()}_{ImageUpload.FileName}";
                        // file path
                        var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImageUpload.CopyToAsync(stream);
                        }

                        // You can save the file path to a database or do other operations here.
                        var image = new TicketImagesDto()
                        {
                            ImageFilePath = filePath,
                            ImageName = uniqueFileName,
                        };
                        ticketImages.Add(image);
                    }
                }
                return ticketImages;
            }
            else
            {
                return new List<TicketImagesDto?>();
            }

            
        }
    }
}
