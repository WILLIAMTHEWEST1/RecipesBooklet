﻿using RecipeBooklet.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeBooklet.Services
{
    public class BasicImageService
    {
        private readonly IConfiguration _configuration;

        public BasicImageService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<byte[]> EncodeImageAsync(IFormFile file)
        {
            if (file is null)
            {
                return null;
            }

            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            return ms.ToArray();
        }

        public async Task<byte[]> EncodeImageAsync(string fileName)
        {
            var file = $"{Directory.GetCurrentDirectory()}/wwwroot/img/{fileName}";
            return await File.ReadAllBytesAsync(file);
        }

        public string ContentType(IFormFile file)
        {
            return file?.ContentType;
        }

        public string DecodeImage(byte[] data, string type)
        {
            if (data is null || type is null) return null;
            return $"data:{type};base64,{Convert.ToBase64String(data)}";
        }

        private bool ValidType(IFormFile file)
        {
            var fileContentType = ContentType(file).Split("/")[1];

            var acceptableExtensions = _configuration["AppImages:AllowedExtensions"];
            var extList = acceptableExtensions.Split(',').ToList();
            var position = extList.IndexOf(fileContentType);

            return position >= 0;
        }

        private bool ValidSize(IFormFile file)
        {
            const int maxFileSize = 2 * 1024 * 1024;
            return Size(file) < maxFileSize;
        }

        public bool ValidImage(IFormFile file)
        {
            return ValidType(file) && ValidSize(file);
        }

        private int Size(IFormFile file)
        {
            return Convert.ToInt32(file?.Length);
        }
    }
}
