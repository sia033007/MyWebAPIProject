﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyMVCProject.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace MyMVCProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;

        public UserController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }
        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:42045/api/user/register");
            if(user != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(user),
                    System.Text.Encoding.UTF8, "application/json");
            }
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            if(response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                TempData["success"] = "Registered Successfully!";
                var apiString = await response.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<User>(apiString);
                return RedirectToAction("Index", "Home");
            }
            else if(response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                TempData["badrequest"] = "User With The Same Name Already Exists !";
            }
            return View(user);
        }
        public ViewResult Register() => View();
        public ViewResult Login() => View();
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:42045/api/user/login");
            if (user != null)
            {
                request.Content = new StringContent(JsonConvert.SerializeObject(user),
                    System.Text.Encoding.UTF8, "application/json");
            }
            var client = _clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                TempData["loginsuccess"] = "Successfully Logged In !";
                var apiString = await response.Content.ReadAsStringAsync();
                user = JsonConvert.DeserializeObject<User>(apiString);
                HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));
                return RedirectToAction("Index", "Home");
            }
            else if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                TempData["notfound"] = "Not Found Such a User";
            }
            else if(response.StatusCode == System.Net.HttpStatusCode.BadRequest)
            {
                TempData["badrequest"] = "Wrong Password !";
            }
            return View(user);

        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            TempData["success"] = "Successfully Logged Out";
            return RedirectToAction("Index", "Home");
        }
        
    }
}
