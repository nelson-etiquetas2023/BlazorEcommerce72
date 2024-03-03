﻿using System.Net;

namespace Orders.FrontEnd.Repositories
{
    public class HttpResponseWrapper<T>
    {
       
        public HttpResponseWrapper(T? response, bool error, HttpResponseMessage httpResponseMessage)
        {
            Response = response;
            Error = error;
            HttpResponseMessage = httpResponseMessage;     
        }

        public T? Response { get; }
        public bool Error { get; }
        public HttpResponseMessage HttpResponseMessage { get; }


        public async Task<string?> GetErrorMessageAsync() 
        {
            if (!Error) 
            {
                return null; 
            }
            var statusCode = HttpResponseMessage.StatusCode;
            if (statusCode == HttpStatusCode.NotFound) 
            {
                return "Recurso no encontrado";
            }
            if (statusCode == HttpStatusCode.BadRequest)
            {
                return await HttpResponseMessage.Content.ReadAsStringAsync();
            }
            if (statusCode == HttpStatusCode.Unauthorized)
            {
                return "Debes estar logueado para utilizar este recurso...";
            }
            if (statusCode == HttpStatusCode.Forbidden)
            {
                return "No tienes permisos para utilizar este operacion...";
            }
            return "Ha ocurrido un error inesperado, comuniquese con el soporte tecnico de la aplicacion";
        }
    }
}
