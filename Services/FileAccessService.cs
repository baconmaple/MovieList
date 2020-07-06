using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Services
{
    public class FileAccessService : IFileAccessService, IDisposable
    {
        private readonly MvcMovieContext _database;
       
        public FileAccessService(MvcMovieContext database)
        {
            _database = database ?? throw new ArgumentNullException(nameof(database));
        }

        public void Dispose()
        {
            _database.Dispose();
        }

        public void InitialData()
        {
            try
            {
                List<Movie> data = FilePreProcess();
                _database.InitData(data);                 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Have a Problem About Seed Data: {ex.Message}");                
            }            
        }

        public List<Movie> FilePreProcess()
        {
            Console.WriteLine("hello");
            string jsonString = File.ReadAllText("./InitialData/movie.json");
            Console.WriteLine(jsonString);
            List<Movie> data = JsonSerializer.Deserialize<List<Movie>>(jsonString);   
            return data;
        }   
    }
}