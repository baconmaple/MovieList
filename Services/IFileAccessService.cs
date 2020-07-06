using System;
using System.Collections.Generic;
using MvcMovie.Models;

namespace MvcMovie.Services
{
    public interface IFileAccessService : IDisposable
    {
        void InitialData();
        List<Movie> FilePreProcess();
    }
}