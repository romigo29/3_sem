namespace StreamFile
{
	class Program
	{
		static void Main()
		{
			try
			{
				string path = @"..\..\..\rivlogfile.txt";
				string C = "C:";
				string D = "D:";

				RIVDiskInfo diskInfo = new RIVDiskInfo();
				diskInfo.GetFreeSpaceInfo(C);
				diskInfo.GetFileSystemInfo(C);
				diskInfo.PrintAllDrivesInfo();

				RIVFileInfo fileInfo = new RIVFileInfo();
				fileInfo.GetFullPath(path);
				fileInfo.GetFileSizeExtensionName(path);
				fileInfo.GetFileCreationModificationDate(path);

				RIVDirInfo dirInfo = new RIVDirInfo();
				dirInfo.GetFilesAmount(C);
				dirInfo.GetDirectoryCreationTime(C);
				dirInfo.GetSubdirectoriesAmount(C);
				dirInfo.GetDirectoryParents(C);


				RIVFileManager fileManager = new RIVFileManager(D);
				fileManager.InspectDrive();

				RIVLog.GetLogRecordByTime(new DateTime(2024, 12, 6));
			}

			catch(Exception ex)
			{
				Console.WriteLine($"ОШИБКА: {ex.Message}\nМЕСТО ОШИБКИ: {ex.StackTrace}");
			}

		}

	}
}