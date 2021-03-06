﻿using System.Linq;
using DitFlo.Models;
using Our.Umbraco.Ditto;
using Umbraco.Web;

namespace DitFlo.Ditto.ValueResolvers
{
    public class MainNavResolver : DittoValueResolver
    {
        public override object ResolveValue()
        {
            if (Content == null) return Enumerable.Empty<NavLink>();

            var homePage = Content.AncestorsOrSelf(1).First();
            var menuItems = new[] { homePage }.Union(homePage.Children.Where(x => x.IsVisible()));
            return menuItems.As<NavLink>();
        }
    }
}