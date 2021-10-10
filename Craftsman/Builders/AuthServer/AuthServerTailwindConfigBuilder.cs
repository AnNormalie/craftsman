﻿namespace Craftsman.Builders.AuthServer
{
    using System;
    using System.IO.Abstractions;
    using System.Linq;
    using Enums;
    using Helpers;
    using Models;
    using static Helpers.ConstMessages;

    public class AuthServerTailwindConfigBuilder
    {
        public static void CreateTailwindConfig(string projectDirectory, string authServerProjectName, IFileSystem fileSystem)
        {
            var classPath = ClassPathHelper.AuthServerTailwindConfigClassPath(projectDirectory, "package.json", authServerProjectName);
            var fileText = GetPostCssText();
            Utilities.CreateFile(classPath, fileText, fileSystem);
        }
        
        public static string GetPostCssText()
        {
            return @$"module.exports = {{
  purge: [""./**/*.cshtml"",""../**/*.cshtml"", ""../**/*.html"",""./**/*.html"", ""./**/*.razor""],
  darkMode: false, // or 'media' or 'class'
  theme: {{
    extend: {{}},
  }},
  variants: {{
    extend: {{}},
  }},
  plugins: [
    require('@tailwindcss/forms'),
  ],
}}";
        }
    }
}