using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamFile
{
	internal class RIVDirInfo
	{

		private readonly RIVLog logger;
		public RIVDirInfo()
		{
			logger = new RIVLog();
		}

		public void GetFilesAmount(string path)
		{

			try
			{
				DirectoryInfo dir = new DirectoryInfo(path);

				if (dir.Exists)
				{
					var FilesAmount = $"Количество файлов в директории {dir}: {Directory.GetFiles(path).Length}";
					logger.WriteLog("Get Files Amount", FilesAmount);
				}

				else
				{
					logger.WriteLog("Get Files Amount", $"Каталога {path} не существует");
				}
			}

			catch (Exception ex)
			{
				logger.WriteLog("Get Files Amount", $"Ошибка запроса: {ex.Message}");
			}
		}

		public void GetDirectoryCreationTime(string path)
		{

			try
			{
				DirectoryInfo dir = new DirectoryInfo(path);

				if (dir.Exists)
				{
					var CreationTime = $"Время создания директория {dir} {dir.CreationTime}";
					logger.WriteLog("Get Directory Creation Date", CreationTime);
				}

				else
				{
					logger.WriteLog("Get Directory Creation Date", $"Каталога {path} не существует");
				}
			}
			catch (Exception ex)
			{
				logger.WriteLog("Get Directory Creation Date", $"Ошибка запроса: {ex.Message}");
			}

		}

		public void GetSubdirectoriesAmount(string path)
		{
			try
			{
				DirectoryInfo dir = new DirectoryInfo(path);

				if (dir.Exists)
				{
					var SubdirectoriesAmount = $"Количество файлов в директории {dir} {Directory.GetDirectories(path).Length}";
					logger.WriteLog("Get Subdirectories Amount", SubdirectoriesAmount);
				}

				else
				{
					logger.WriteLog("Get Subdirectories Amount", $"Каталога {path} не существует");
				}
			}
			catch (Exception ex)
			{
				logger.WriteLog("Get Subdirectories Amount", $"Ошибка запроса: {ex.Message}");
			}

		}

		public void GetDirectoryParents(string path)
		{
			try
			{

				DirectoryInfo dir = new DirectoryInfo(path);

				if (dir.Exists)
				{
					string DirectoryParents = $"Родительский каталог директория {path}: {dir.Root}";
					logger.WriteLog("Get Directory Parents", DirectoryParents);
				}
				else
				{
					logger.WriteLog("Get Directory Parents", $"Каталог {path} не существует");
				}
			}

			catch (Exception ex) 
			{
				logger.WriteLog("Get Directory Parents", $"Ошибка запроса: {ex.Message}");
			}

		}

	}
}
