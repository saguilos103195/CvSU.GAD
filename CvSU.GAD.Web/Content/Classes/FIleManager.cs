using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace CvSU.GAD.Web.Content.Classes
{
    public class FileManager
    {

        private string _uploadPath;
        private string _filename;

        public FileManager()
        {
            _uploadPath = AppDomain.CurrentDomain.BaseDirectory + "Content/Images/Uploads";
        }

        public bool Upload(string base64, string filename)
        {

			///Creates the directory if it doesn't exist,
			///Ignores when it already exist.

			bool isSaved = false;
			Directory.CreateDirectory(_uploadPath);

            _filename = filename; 

            string[] fileProperties = filename.Split('.');

            ///Get the last index of file name for the file extension
            string fileExtention = fileProperties[fileProperties.Length - 1];

            byte[] bytes = Convert.FromBase64String(base64);

            switch (fileExtention)
            {
                case "jpg":

                        bool saveImageSuccess = SaveImageData(bytes);
                        
                        if(saveImageSuccess)
                        {
                            isSaved = true;
                        }

                    break;

                case "pdf":

                        bool savePDFSuccess = SavePDFData(bytes);

                        if (savePDFSuccess)
                        { 
							isSaved = true;
                        }

                    break;

                default:

                    break;
            }

			return isSaved;
        }

        private bool SaveImageData(byte[] bytes)
        {
            try
            {
                File.SetAttributes(_uploadPath, FileAttributes.Normal);

                using (var imageFile = new FileStream(_uploadPath + $"//{_filename}", FileMode.Create))
                {
                    imageFile.Write(bytes, 0, bytes.Length);
                    imageFile.Flush();
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool SavePDFData(byte[] bytes)
        {
            try
            {
                File.WriteAllBytes(_uploadPath + $"//{_filename}", bytes);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        
        }

    }
}