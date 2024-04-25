﻿using EduOnClone.Application.Common.Exceptions;
using EduOnClone.Application.DTOs.Common;
using Newtonsoft.Json;

namespace Edu_On_Clone.Middlewares;

public class ExceptionHandleMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (StatusCodeExeption exception)
        {
            await ClientErrorHandleAsync(context, exception);
        }
        catch (Exception exception)
        {
            await ServerErrorHandleAsync(context, exception);
        }
    }


    public async Task ServerErrorHandleAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var result = new ErrorMessage()
        {
            Message = exception.Message,
            StatusCode = 500
        };
        context.Response.StatusCode = 500;

        await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
    }

    public async Task ClientErrorHandleAsync(HttpContext context, StatusCodeExeption exeption)
    {
        context.Response.ContentType = "application/json";
        var result = new ErrorMessage()
        {
            Message = exeption.Message,
            StatusCode = (int)exeption.StatusCode,
        };
        context.Response.StatusCode = result.StatusCode;

        await context.Response.WriteAsync(JsonConvert.SerializeObject(result));
    }
}
