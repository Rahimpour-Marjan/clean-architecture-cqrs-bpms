using Api.Authorization;
using Api.Enum;
using Api.Model.Product;
using Application.ProductApplication.Commands;
using Application.ProductApplication.Queries.FindAll;
using Application.ProductApplication.Queries.FindById;
using Application.Helpers;
using Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using Application.ProductApplication.Queries.FilterData;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Api.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IUriService _uriService;
        public ProductController(IMediator mediator, IUriService uriService)
        {
            _mediator = mediator;
            _uriService = uriService;
        }

        // GET: api/<UserController>
        [CustomAuthorize(SiteAction.Product_View)]
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ApiQuery apiQuery)
        {
            var model = await _mediator.Send(new FindAllProductQuery
            {
                Query = apiQuery.Query,
            });

            if (apiQuery.Query == null)
                return StatusCode((int)HttpStatusCode.OK, new ApiResponse
                {
                    Data = model.Result,
                });

            var route = Request.Path.Value;
            var pagedReponse = PaginationHelper.CreatePagedResponse(model.Result, model.PageNumber, model.PageSize, model.ResultCount, _uriService, route, null);

            return StatusCode((int)HttpStatusCode.OK, pagedReponse);
        }

        //GET api/<UserController>/5
        [CustomAuthorize(SiteAction.Product_View)]
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _mediator.Send(new FindProductByIdQuery
            {
                Id = id
            });
            return StatusCode((int)HttpStatusCode.OK, new ApiResponse
            {
                Data = model,
            });
        }

        [CustomAuthorize(SiteAction.Product_View)]
        [HttpGet("GetColumnFilter")]
        public async Task<IActionResult> GetColumnFilter(string columnName, int pageNumber = 1, int pageSize = 10)
        {
            if (!string.IsNullOrEmpty(columnName))
            {
                if (string.Equals(columnName.ToLower(), "ProductType".ToLower()))
                {
                    var model = await _mediator.Send(new ProductType.Query
                    {
                        Start = pageNumber,
                        Length = pageSize,
                    });
                    return StatusCode((int)HttpStatusCode.OK, model);
                }
                else if (string.Equals(columnName.ToLower(), "ProductCategory".ToLower()))
                {
                    var model = await _mediator.Send(new ProductCategory.Query
                    {
                        Start = pageNumber,
                        Length = pageSize,
                    });
                    return StatusCode((int)HttpStatusCode.OK, model);
                }
                else if (string.Equals(columnName.ToLower(), "ProductBrand".ToLower()))
                {
                    var model = await _mediator.Send(new ProductCategory.Query
                    {
                        Start = pageNumber,
                        Length = pageSize,
                    });
                    return StatusCode((int)HttpStatusCode.OK, model);
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                    {
                        Errors = new string[] { "لطفا نام ستون را درست وارد نمایید." },
                    });
                }
            }
            else
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                {
                    Errors = new string[] { "لطفا نام ستون را وارد نمایید." },
                });
            }
        }

        // POST api/<UserController>
        [CustomAuthorize(SiteAction.Product_Add)]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = (int)HttpContext.Items["UserId"];

                var result = await _mediator.Send(new ProductCreate.Command
                {
                    Title = model.Title,
                    ProductTypeId = model.ProductTypeId,
                    ProductCategoryId = model.ProductCategoryId,
                    ProductBrandId = model.ProductBrandId,
                    H1 = model.H1,
                    Url = model.Url,
                    CodeValue = model.CodeValue,
                    Summary = model.Summary,
                    Description = model.Description,
                    Body = model.Body,
                    Priority = model.Priority,
                    MaxShowCount = model.MaxShowCount,
                    Quantity = model.Quantity,
                    MinOrder = model.MinOrder,
                    LastPrice = model.LastPrice,
                    Price = model.Price,
                    MinPrice = model.MinPrice,
                    MaxPrice = model.MaxPrice,
                    VisitCount = model.VisitCount,
                    ShowHomePage = model.ShowHomePage ?? false,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                    SellCount = model.SellCount,
                    MaxOrderCount = model.MaxOrderCount,
                    DiscountValue = model.DiscountValue,
                    DiscountPercent = model.DiscountPercent,
                    DiscountExpireDate = model.DiscountExpireDate,
                    MetaTagDescription = model.MetaTagDescription,
                    Canonical = model.Canonical,
                    NoFollow = model.NoFollow ?? false,
                    NoIndex = model.NoIndex ?? false,
                    Keywords = model.Keywords,
                    IsService = model.IsService ?? false,
                    IsCopy = model.IsCopy ?? false,
                    IsPublic = model.IsPublic??false,
                    IsActive = model.IsActive,
                    VideoDemoFileUrl = model.VideoDemoFileUrl,
                    ImageUrl = model.ImageUrl,
                    CreatorStoreId = currentUserId,
                    CreatorId =currentUserId,
                });

                if (!result.Success)
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                    {
                        Errors = new string[] { (result.Exception != null ? result.Exception.Message : result.ErrorMessage) },
                    });
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.OK, new ApiResponse
                    {
                        Data = result.Result.ProductId,
                    });
                }
            }
            else
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                {
                    Errors = ModelState.GetModelErrors(),
                });
            }
        }

        // PUT api/<UserController>/5
        [CustomAuthorize(SiteAction.Product_Edit)]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductInfoModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUserId = (int)HttpContext.Items["UserId"];

                var result = await _mediator.Send(new ProductUpdate.Command
                {
                    ProductId = id,
                    Title = model.Title,
                    ProductTypeId = model.ProductTypeId,
                    ProductCategoryId = model.ProductCategoryId,
                    ProductBrandId = model.ProductBrandId,
                    H1 = model.H1,
                    Url = model.Url,
                    CodeValue = model.CodeValue,
                    Summary = model.Summary,
                    Description = model.Description,
                    Body = model.Body,
                    Priority = model.Priority,
                    MaxShowCount = model.MaxShowCount,
                    Quantity = model.Quantity,
                    MinOrder = model.MinOrder,
                    LastPrice = model.LastPrice,
                    Price = model.Price,
                    MinPrice = model.MinPrice,
                    MaxPrice = model.MaxPrice,
                    VisitCount = model.VisitCount,
                    ShowHomePage = model.ShowHomePage ?? false,
                    Latitude = model.Latitude,
                    Longitude = model.Longitude,
                    SellCount = model.SellCount,
                    MaxOrderCount = model.MaxOrderCount,
                    DiscountValue = model.DiscountValue,
                    DiscountPercent = model.DiscountPercent,
                    DiscountExpireDate = model.DiscountExpireDate,
                    MetaTagDescription = model.MetaTagDescription,
                    Canonical = model.Canonical,
                    NoFollow = model.NoFollow ?? false,
                    NoIndex = model.NoIndex ?? false,
                    Keywords = model.Keywords,
                    IsService = model.IsService ?? false,
                    IsCopy = model.IsCopy ?? false,
                    IsPublic = model.IsPublic ?? false,
                    IsActive = model.IsActive,
                    VideoDemoFileUrl = model.VideoDemoFileUrl,
                    ImageUrl = model.ImageUrl,
                    ModifireId =currentUserId,
                });

                if (!result.Success)
                {
                    return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                    {
                        Errors = new string[] { (result.Exception != null ? result.Exception.Message : result.ErrorMessage) },
                    });
                }
                else
                {
                    return StatusCode((int)HttpStatusCode.OK, new ApiResponse
                    {
                        Data = result.Result.ProductId,
                    });
                }
            }
            else
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                {
                    Errors = ModelState.GetModelErrors(),
                });
            }
        }

        [CustomAuthorize(SiteAction.Product_Delete)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new ProductDelete.Command
            {
                ProductId = id
            });

            if (!result.Success)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                {
                    Errors = new string[] { (result.Exception != null ? result.Exception.Message : result.ErrorMessage) ?? "" },
                });
            }
            else
            {
                return StatusCode((int)HttpStatusCode.OK, new ApiResponse
                {
                    Data = result.Result.ProductId,
                });
            }
        }

        [CustomAuthorize(SiteAction.Product_Delete)]
        [HttpDelete]
        public async Task<IActionResult> Delete(int[] ids)
        {
            var result = await _mediator.Send(new ProductDeleteAll.Command
            {
                ProductIds = ids
            });

            if (!result.Success)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, new ApiResponse
                {
                    Errors = new string[] { (result.Exception != null ? result.Exception.Message : result.ErrorMessage) },
                });
            }
            else
            {
                return StatusCode((int)HttpStatusCode.OK, new ApiResponse
                {
                    Data = result.Result.Result,
                });
            }
        }
    }
}
