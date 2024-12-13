using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamFile
{
	internal class RIVDiskInfo
	{
		private readonly RIVLog logger;

		public RIVDiskInfo()
		{
			logger = new RIVLog();
		}

		public void GetFreeSpaceInfo(string driveName)
		{
			DriveInfo drive = new DriveInfo(driveName);
			var TotalFreeSpace = $"Свободное пространство на диске {driveName} {drive.TotalFreeSpace} байт";

			logger.WriteLog("GetFreeSpace", TotalFreeSpace);
		}

		public void GetFileSystemInfo(string drivename)
		{
			DriveInfo drive = new DriveInfo(drivename);
			var FileSystemInfo = $"Файловая система на диске {drivename} {drive.DriveFormat}";

			logger.WriteLog("GetFreeSpace", FileSystemInfo);
		}

		public void PrintAllDrivesInfo() {

			DriveInfo[] drives = DriveInfo.GetDrives();

			var AllDrivesInfo = $"Вся информация о дисках: \n";


			foreach (DriveInfo drive in drives)
			{
				AllDrivesInfo += $"\nИмя: {drive.Name}";

				if (drive.IsReady) 
				{
					AllDrivesInfo += $"\nОбщий объем: {drive.TotalSize}";
					AllDrivesInfo += $"\nДоступный объем: {drive.TotalFreeSpace}";
					AllDrivesInfo += $"\nМетка диска: {drive.VolumeLabel}";
				}

			}

			logger.WriteLog("DriveInfo", AllDrivesInfo);	
				
		}
	}
}
