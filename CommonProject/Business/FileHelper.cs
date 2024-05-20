using FluentFTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonProject.Business
{
    public static class FileHelper
    {
        public static string DownloadFile(string localPath, string remotePath)
        {
            using (var ftp = new FtpClient(FTP.ADDRESS, FTP.USER, FTP.PASSWORD))
            {
                ftp.Connect();
                ftp.DownloadFile(localPath, remotePath, FtpLocalExists.Overwrite, FtpVerify.Retry);
                return localPath;
            }
        }

        public static void UploadFile(string localPath, string remotePath)
        {
            using (var ftp = new FtpClient(FTP.ADDRESS, FTP.USER, FTP.PASSWORD))
            {
                ftp.Connect();
                // upload a file and ensure the FTP directory is created on the server, verify the file after upload
                ftp.UploadFile(localPath, remotePath, FtpRemoteExists.Overwrite, true, FtpVerify.Retry);

            }
        }

    }
}
