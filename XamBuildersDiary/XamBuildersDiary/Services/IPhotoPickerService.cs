#region Copyright
// ===================================================================
//  This file is part of the XamBuilderDiary application.
//  Copyright © 2020 Martin Pulgar Construction. All rights reserved.
// ===================================================================
#endregion
using System.IO;
using System.Threading.Tasks;

namespace XamBuildersDiary.Services
{
    public interface IPhotoPickerService
    {
        Task<Stream> GetImageStreamAsync();
    }
}
