// See https://aka.ms/new-console-template for more information

using System.Net.NetworkInformation;
using System.Net;
using SMBLibrary.Client;
using SMBLibrary;
using System.Text;

Read();

void Write()
{
    var client = new SMB2Client(); // SMB2Client can be used as well
    bool isConnected = client.Connect(IPAddress.Parse("10.161.0.98"), SMBTransportType.DirectTCPTransport);
    if (isConnected)
    {
        NTStatus status = client.Login(String.Empty, "Username", "Password");
        if (status == NTStatus.STATUS_SUCCESS)
        {

            ISMBFileStore fileStore = client.TreeConnect("tronweb_ecuador_batch", out status);

            if (status == NTStatus.STATUS_SUCCESS)
            {
                object directoryHandle;
                FileStatus fileStatus;
                status = fileStore.CreateFile(out directoryHandle, out fileStatus, "com_agt", AccessMask.GENERIC_READ, SMBLibrary.FileAttributes.Directory, ShareAccess.Read | ShareAccess.Write, CreateDisposition.FILE_OPEN, CreateOptions.FILE_DIRECTORY_FILE, null);
                if (status == NTStatus.STATUS_SUCCESS)
                {
                    status = fileStore.QueryDirectory(out List<QueryDirectoryFileInformation> fileList, directoryHandle, "*", FileInformationClass.FileDirectoryInformation);
                    status = fileStore.CloseFile(directoryHandle);

                    string fecha = "21102024";
                    foreach (FileDirectoryInformation file in fileList)
                    {
                        if (file.FileAttributes == SMBLibrary.FileAttributes.Archive || file.FileName.Contains(fecha))
                        {
                            Console.WriteLine($"File: {file.FileName}");
                        }
                        //else
                        //{
                        //    Console.WriteLine("File: " + file.FileName);
                        //}

                        //Console.WriteLine(file.FileName);
                    }

                }
            }

            status = fileStore.Disconnect();

            client.Logoff();
        }
        client.Disconnect();
    }

}

void Read()
{
    var client = new SMB2Client(); // SMB2Client can be used as well
    bool isConnected = client.Connect(IPAddress.Parse("10.161.0.98"), SMBTransportType.DirectTCPTransport);
    if (isConnected)
    {
        NTStatus status = client.Login(String.Empty, "Username", "Password");
        if (status == NTStatus.STATUS_SUCCESS)
        {

            ISMBFileStore fileStore = client.TreeConnect("tronweb_ecuador_lis", out status);
            object fileHandle;

            if (status == NTStatus.STATUS_SUCCESS)
            {
                object directoryHandle;
                FileStatus fileStatus;
                status = fileStore.CreateFile(out directoryHandle, out fileStatus, String.Empty, AccessMask.GENERIC_READ, SMBLibrary.FileAttributes.Directory, ShareAccess.Read | ShareAccess.Write, CreateDisposition.FILE_OPEN, CreateOptions.FILE_DIRECTORY_FILE, null);
                if (status == NTStatus.STATUS_SUCCESS)
                {
                    status = fileStore.QueryDirectory(out List<QueryDirectoryFileInformation> fileList, directoryHandle, "*", FileInformationClass.FileDirectoryInformation);
                    status = fileStore.CloseFile(directoryHandle);

                    string fecha = "21102024";
                    foreach (FileDirectoryInformation file in fileList)
                    {
                        if (file.FileAttributes == SMBLibrary.FileAttributes.Archive || file.FileName.Contains(fecha))
                        {
                            Console.WriteLine($"File: {file.FileName}");

                            status = fileStore.CreateFile(out fileHandle, out fileStatus, file.FileName, AccessMask.GENERIC_READ | AccessMask.SYNCHRONIZE, SMBLibrary.FileAttributes.Normal, ShareAccess.Read, CreateDisposition.FILE_OPEN, CreateOptions.FILE_NON_DIRECTORY_FILE | CreateOptions.FILE_SYNCHRONOUS_IO_ALERT, null);

                            if (status == NTStatus.STATUS_SUCCESS)
                            {
                                var stream = new MemoryStream();
                                byte[] data;
                                long bytesRead = 0;
                                while (true)
                                {
                                    status = fileStore.ReadFile(out data, fileHandle, bytesRead, (int)client.MaxReadSize);
                                    if (status != NTStatus.STATUS_SUCCESS && status != NTStatus.STATUS_END_OF_FILE)
                                    {
                                        throw new Exception("Failed to read from file");
                                    }

                                    if (status == NTStatus.STATUS_END_OF_FILE || data.Length == 0)
                                    {
                                        break;
                                    }
                                    bytesRead += data.Length;
                                    stream.Write(data, 0, data.Length);
                                }

                                var content = Encoding.Latin1.GetString(stream.ToArray());
                            }
                            status = fileStore.CloseFile(directoryHandle);

                        }
                    }

                }
            }

            status = fileStore.Disconnect();

            client.Logoff();
        }
        client.Disconnect();
    }

}