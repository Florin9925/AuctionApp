// <copyright file="UserController.cs" company="Transilvania University of Brasov">
// Copyright (c) student Arhip Florin, Transilvania University of Brasov. All rights reserved.
// </copyright>

namespace AuctionApp.Controllers;

using DomainModel.Dto;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

/// <summary>
/// UserController.
/// </summary>
/// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService userService;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserController"/> class.
    /// </summary>
    /// <param name="userService">The user service.</param>
    public UserController(IUserService userService)
    {
        this.userService = userService;
    }

    // GET: api/UserAccounts
    /// <summary>
    /// Gets the user account.
    /// </summary>
    /// <returns>list of users.</returns>
    [HttpGet]
    public ActionResult<IEnumerable<UserDto>> GetUserAccount()
    {
        var users = this.userService.GetAll();
        return users.ToList();
    }
}