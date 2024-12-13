using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamFile
{
	internal class RIVFileManager
	{
		private readonly RIVLog logger;
		string drivePath;
		public RIVFileManager() 
		{
			logger = new RIVLog();
		}

		public RIVFileManager(string drive)
		{
			logger = new RIVLog();
			drivePath = drive;
		}

		public void InspectDrive()
		{

			string inspectPath = Path.Combine(drivePath, "RIVDriveInspect");
			Directory.CreateDirectory(inspectPath);
			logger.WriteLog("Inspect Drive: Directory creation", $"Создана папка: {inspectPath}");

			string dirInfoPath = Path.Combine(inspectPath, "rivdirinfo.txt");
			WriteToFile(dirInfoPath);
			logger.WriteLog("Inspect Drive: Directory and Files info", $"В {dirInfoPath} записана информация о каталогах и файлах диска");

			CopyFileAndDelete(dirInfoPath);
			logger.WriteLog("Inspect Drive", $"Создан копия файла. Оригинал удален");

			string anotherPath = Path.Combine(drivePath, "RIVFiles");
			Directory.CreateDirectory(anotherPath);

			Console.Write("Введите расширение файла для поиска: ");
			string? userExtension = Console.ReadLine();
			Console.Write("Введите название каталога для поиска: ");
			string? userDirectory = Console.ReadLine();

			CopyFileByExtension(userDirectory, userExtension, anotherPath);
			logger.WriteLog("Inspect Drive", $"Создан каталог {anotherPath} с заданной информацией");

			string destinationPath = Path.Combine(inspectPath, Path.GetFileName(anotherPath));
			if (Directory.Exists(destinationPath)) Directory.Delete(destinationPath, recursive: true);
			Directory.Move(anotherPath, destinationPath);
			logger.WriteLog("Inspect Drive: Directory Movement", $"Каталог {anotherPath} перемещен в каталог {inspectPath}");

			string archivePath = Path.Combine(inspectPath, "RIVFiles.zip");
			string unarchivePath = Path.Combine(inspectPath, "Unzipped");

			ArchiveFiles(inspectPath, archivePath);
			UnarchiveFiles(archivePath, unarchivePath);
		}

		private void WriteToFile(string dirInfoPath)
		{
			string writeInfo = GetFilesAndDirectories();
			
			File.WriteAllText(dirInfoPath, writeInfo);
		}

		private string GetFilesAndDirectories()
		{
			string[] directories = Directory.GetDirectories(drivePath);
			string[] files = Directory.GetFiles(drivePath);
			string result = "Directories: \n";
			foreach (var directory in directories)
			{
				result += $"{directory} \n";
			}

			result += "\nFiles: \n";
			foreach (var file in files)
			{
				result += $"{file} \n";
			}

			return result;

		}

		private void CopyFileAndDelete(string dirInfoPath)
		{
			string dirInfoCopy = Path.Combine(Path.GetDirectoryName(dirInfoPath)!, "rivdirinfo_copy.txt");
			File.Copy(dirInfoPath, dirInfoCopy, overwrite: true);
			File.Delete(dirInfoPath);
		}

		private void CopyFileByExtension(string userDirectory, string userExtension, string destinationDirectory)
		{
			string[] files = Directory.GetFiles(userDirectory, $"*.{userExtension}", SearchOption.AllDirectories);

			foreach (var file in files)
			{
				string fileName = Path.GetFileName(file);
				string destinationPath = Path.Combine(destinationDirectory, fileName);
				File.Copy(file, destinationPath, overwrite: true);
			}

		}

		private void ArchiveFiles(string inspectPath, string archivePath)
		{
			if (!Directory.Exists(inspectPath))
			{
				throw new DirectoryNotFoundException($"Каталог {inspectPath} не найден.");
			}

			if (!File.Exists(archivePath))
			{
				ZipFile.CreateFromDirectory(inspectPath, archivePath);
				logger.WriteLog("Inspect Drive: Archiving", $"Каталог {inspectPath} успешно архивирован в {archivePath}");
			}
			else
			{
				logger.WriteLog("Inspect Drive: Archiving", $"Архив {archivePath} уже существует.");
			}
		}

		private void UnarchiveFiles(string archivePath, string unarchivePath)
		{
			if (Directory.Exists(unarchivePath))
			{
				Directory.Delete(unarchivePath, recursive: true);
				logger.WriteLog("Inspect Drive: Unarchiving", $"Старый каталог {unarchivePath} удален для перезаписи.");
			}

			ZipFile.ExtractToDirectory(archivePath, unarchivePath);
			logger.WriteLog("Inspect Drive: Unarchiving", $"Архив {archivePath} успешно разархивирован в {unarchivePath}");
		}
	}
}
