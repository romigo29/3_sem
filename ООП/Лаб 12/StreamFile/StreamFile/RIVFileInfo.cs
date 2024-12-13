using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamFile
{
	internal class RIVFileInfo
	{
		private readonly RIVLog logger;
		public RIVFileInfo()
		{
			logger = new RIVLog();
		}
		
		public void GetFullPath(string filePath)
		{
			var FullFilePath = $"Полный путь к файлу: {Path.GetFullPath(filePath)}";
			logger.WriteLog("GetFullPath", FullFilePath);
		}

		public void GetFileSizeExtensionName(string filePath)
		{

			FileInfo fileInfo = new FileInfo(filePath);

			var FullFileInfo = $"\nИмя файла по пути {Path.GetFileNameWithoutExtension(filePath)}" +
				$"\nРасширение: {Path.GetExtension(filePath)}" +
				$"\nРазмер: {fileInfo.Length}";
			logger.WriteLog("Get FullName, Extension, Size", FullFileInfo);
		}

		public void GetFileCreationModificationDate(string filePath)
		{

			FileInfo fileInfo = new FileInfo(filePath);

			var FileCreationModification = $"\nДата создания файла: {fileInfo.CreationTime}"+
				$"\nДата последнего изменения файла: {fileInfo.LastWriteTime}";
			logger.WriteLog("Creation and Modification File Date", FileCreationModification);
		}
	}
}
