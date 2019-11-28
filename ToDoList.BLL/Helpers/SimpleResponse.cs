using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ToDoList.BLL.Helpers
{
    public class SimpleResponse
    {
        public bool IsSuccess { get; set; }
        public string ErrorText { get; set; }

        public static SimpleResponse Success()
        {
            return new SimpleResponse { IsSuccess = true };
        }

        public static SimpleResponse<T> Success<T>(T data)
        {
            return new SimpleResponse<T> { IsSuccess = true, Data = data };
        }

        public static SimpleResponse Error(string errorText)
        {
            return new SimpleResponse { ErrorText = errorText };
        }

        public static SimpleResponse Error(ModelStateDictionary modelState)
        {
            return new SimpleResponse { ErrorText = string.Join(Environment.NewLine, modelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage)) };
        }
        public static SimpleResponse<T> Error<T>(string errorText, T data)
        {
            return new SimpleResponse<T> { ErrorText = errorText, Data = data };
        }
    }

    public class SimpleResponse<T> : SimpleResponse
    {
        public T Data { get; set; }
    }
}
