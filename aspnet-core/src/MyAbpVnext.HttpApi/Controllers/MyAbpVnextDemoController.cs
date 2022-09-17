using Microsoft.AspNetCore.Mvc;
using MyAbpVnext.FileManagement.Files;
using System;
using Volo.Abp.MultiTenancy;
using Volo.Abp.Users;

namespace MyAbpVnext.Controllers;

/// <summary>
/// 我们在这里继承Abp提供的类去实现我们自定义的一些封装性质的Api
/// </summary>
[ControllerName("MyAbpVnextDemo")]
[Route("api/MyAbpVnextDemo")]
public class MyAbpVnextDemoController : MyAbpVnextController
{
    readonly ICurrentTenant currentTenant;
    readonly ICurrentUser currentUser;
    public MyAbpVnextDemoController(ICurrentUser _currentUser, ICurrentTenant _currentTenant, IFileAppService fileAppService)
    {
        currentTenant = _currentTenant;
        currentUser = _currentUser;
        #region For Test Api Client
        var result = fileAppService.FindByBlobNameAsync("e212e607fcc74347bfc989424d80a164").GetAwaiter().GetResult();
        Console.WriteLine(result);
        #endregion

    }

    [HttpGet]
    [Route("GetCurrent")]
    public string GetCurrent()
    {
        return "当前用户：" + currentUser.Name + ",当前租户：" + currentTenant.Name;
    }



}