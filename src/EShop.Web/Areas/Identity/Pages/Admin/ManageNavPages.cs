// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace  EShop.Web.Areas.Identity.Pages.Admin
{
    public static class ManageNavPages
    {
        public static string Index => "Index";
        public static string Items => "Items";
        public static string Catalogs => "Catalogs";

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);
        public static string ItemsNavClass(ViewContext viewContext) => PageNavClass(viewContext, Items);
        public static string CatalogsNavClass(ViewContext viewContext) => PageNavClass(viewContext, Catalogs);

        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string
                ?? System.IO.Path.GetFileNameWithoutExtension(viewContext.ActionDescriptor.DisplayName);
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }
    }
}
