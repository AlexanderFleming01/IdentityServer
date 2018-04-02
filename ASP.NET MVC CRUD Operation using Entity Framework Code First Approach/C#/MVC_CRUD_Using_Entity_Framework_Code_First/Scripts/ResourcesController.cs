using FluentValidation.AspNetCore;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Entities;
using Bushel.Idserver.Management.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Bushel.Idserver.Management.Models;
using Bushel.Idserver.Management.Models.ApiResources;

namespace Bushel.Idserver.Management.Controllers
{
	public class ResourcesController : Controller
	{
		private ConfigurationDbContext _contextresource;
		private readonly IMapper _mapper;
		public ResourcesController(ConfigurationDbContext contextresource, IMapper mapper)
		{
			_contextresource = contextresource;
			_mapper = mapper;
		}
		[HttpGet]
		public IActionResult Navigate(string command)
		{
			if (command == "ApiResources")
			{
				return View("Resources");
			}
			return View("IdentityResources");
		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public IActionResult Resources()
		{
			_contextresource.ApiResources
			  .Include(i => i.Scopes)
			  .Include(i => i.Secrets)
			  .Include(i => i.UserClaims)
			  .ToList();
			return View(_contextresource.ApiResources.ToList());
		}
		[HttpGet]
		public IActionResult IdentityResources()
		{
			_contextresource.IdentityResources
		   .Include(i => i.UserClaims)
			  .ToList();
			return View(_contextresource.IdentityResources.ToList());
		}
		[HttpPost]
		public IActionResult Start(string Command)
		{

			return RedirectToAction("Resources");
		}
		[HttpGet]
		public IActionResult AddApiResources()
		{
			return View("AddApiResources");
		}
		[HttpGet]
		public IActionResult AddIdentity()
		{
			return View("AddIdentityResources");
		}
		[HttpPost]
		public IActionResult AddApiResources(ApiResourcesDTO apiResourceDto)
		{
			var validator = new ApiResourceValidator();
			var results = validator.Validate(apiResourceDto);
			results.AddToModelState(ModelState, null);

			if (ModelState.IsValid)
			{
				//    var scope = new List<ApiScope>();
				//    apiScope.ApiResource = apiResource;
				//    scope.Add(apiScope);
				//    apiResource.Scopes = scope;

				//    var secret = new List<ApiSecret>();
				//    apiSecret.ApiResource = apiResource;
				//    secret.Add(apiSecret);
				//    apiResource.Secrets = secret;

				//    var resourceclaim = new List<ApiResourceClaim>();
				//    apiResourceClaim.ApiResource = apiResource;
				//    resourceclaim.Add(apiResourceClaim);
				//    apiResource.UserClaims = resourceclaim;

				//    var scopeclaim = new List<ApiScopeClaim>();
				//    apiScopeClaim.ApiScope = apiScope;
				//    scopeclaim.Add(apiScopeClaim);
				var apiResource = _mapper.Map<ApiResource>(apiResourceDto);
				_contextresource.ApiResources.Add(apiResource);
			_contextresource.SaveChanges();

			return RedirectToAction("Resources");
			}
			else
			{
				return View("AddApiResources", apiResourceDto);
			}
		}
		[HttpPost]
		public IActionResult AddIdentity(IdentityResourceDTO identityResourceDto)
		{

			var validator = new IdentityResourceValidator();
			var results = validator.Validate(identityResourceDto);
			results.AddToModelState(ModelState, null);
			//ModelState.AddModelError("UserClaims[0].Type", "Enter user claim");

			if (ModelState.IsValid)
			{
				var identityResource = _mapper.Map<IdentityResource>(identityResourceDto);
				_contextresource.IdentityResources.Add(identityResource);
				_contextresource.SaveChanges();
				return RedirectToAction("IdentityResources");
			}
			else
			{
				return View("AddIdentityResources");
			}
		}
		[HttpGet]
		[Route("EditResources/{id}")]
		public IActionResult EditResources(int id)
		{
			ApiResource apiResource = _contextresource.ApiResources.Find(id);
			_contextresource.ApiResources
			 .Include(i => i.UserClaims)
				.ToList();
			ViewData["Resources"] = apiResource;
			return View("EditResources");
		}
		[HttpGet]
		[Route("EditIdentityResources/{id}")]
		public IActionResult EditIdentityResources(int id)
		{
			IdentityResource identityResource = _contextresource.IdentityResources.Find(id);
			_contextresource.IdentityResources
			.Include(i => i.UserClaims)
			   .ToList();
			ViewData["IdentityResources"] = identityResource;
			return View("EditIdentityResources");
		}
		[HttpGet]
		[Route("DeleteResources/{id}")]
		public IActionResult DeleteResources(int id)
		{
			ApiResource apiResource = _contextresource.ApiResources.Find(id);
			ViewData["Resources"] = apiResource;
			return View("DeleteResources");
		}
		[HttpGet]
		[Route("DeleteIdentityResources/{id}")]
		public IActionResult DeleteIdentitytResources(int id)
		{
			IdentityResource identityResource = _contextresource.IdentityResources.Find(id);
			ViewData["IdentityResources"] = identityResource;
			return View("DeleteIdentityResources");
		}

		[HttpPost]
		[Route("EditResources/{id}")]
		public IActionResult EditResources(ApiResource apiResource)
		{
			_contextresource.Entry(apiResource).State = EntityState.Modified;
			_contextresource.ApiResources.Update(apiResource);
			_contextresource.SaveChanges();
			return RedirectToAction("Resources");
		}
		[HttpPost]
		[Route("EditIdentityResources/{id}")]
		public IActionResult EditIdentitytResources(IdentityResource identityResource)
		{
			_contextresource.Entry(identityResource).State = EntityState.Modified;
			_contextresource.IdentityResources.Update(identityResource);
			_contextresource.SaveChanges();
			return RedirectToAction("IdentityResources");
		}
		[HttpPost]
		[Route("DeleteResources/{id}")]
		public IActionResult DeleteResources(ApiResource apiresource, string command)
		{
			if (command == "Delete")
			{
				_contextresource.Entry(apiresource).State = EntityState.Deleted;
				_contextresource.ApiResources.Remove(apiresource);
				_contextresource.SaveChanges();
			}
			return RedirectToAction("Resources");
		}
		[HttpPost]
		[Route("DeleteIdentityResources/{id}")]
		public IActionResult DeleteIdentityResources(IdentityResource identityresource, string command)
		{
			if (command == "Delete")
			{
				_contextresource.Entry(identityresource).State = EntityState.Deleted;
				_contextresource.IdentityResources.Remove(identityresource);
				_contextresource.SaveChanges();
			}
			return RedirectToAction("Resources");
		}
	}
}
