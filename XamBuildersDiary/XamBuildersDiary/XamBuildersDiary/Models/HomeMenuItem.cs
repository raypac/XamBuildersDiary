#region Copyright
// ===================================================================
//  This file is part of the XamBuilderDiary application.
//  Copyright © 2020 Martin Pulgar Construction. All rights reserved.
// ===================================================================
#endregion

namespace XamBuildersDiary.Models
{
    /// <summary>
    /// Menu Item Type
    /// </summary>
    public enum MenuItemType
    {
        Browse,
        About
    }

    /// <summary>
    /// Home Menu Item
    /// </summary>
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
