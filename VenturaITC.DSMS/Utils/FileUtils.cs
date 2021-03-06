﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace VenturaITC.DSMS.Utils
{
    /// <summary>
    /// Provides file utility methods. 
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20180113    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public class FileUtils
    {
        /// <summary>
        /// Gets the content of a file.
        /// </summary>
        /// <param name="file">The uploaded file HttpPostedFileBase object.</param>
        /// <returns>The byte[] containing the content of the file.</returns>
        public static byte[] GetFileContent(HttpPostedFileBase file)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                file.InputStream.CopyTo(stream);
                byte[] fileBytes = stream.ToArray();
                return fileBytes;
            }
        }

        /// <summary>
        /// Gets the source of an image.
        /// </summary>
        /// <param name="imageContent">The byte[] containing the images's content</param>
        /// <returns>The specified image source.</returns>
        public static string GetImageSource(byte[] imageContent)
        {
            if (imageContent != null)
            {
                return String.Format("data:image;png;base64,{0}", Convert.ToBase64String(imageContent));
            }

            return null;
        }
    }
}

