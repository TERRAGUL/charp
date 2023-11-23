using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

public static class ConsoleFileManager
{
    private static DriveInfo[] drives;
    private static int currentSelectionIndex;
    private static DriveInfo currentDrive;
    private static DirectoryInfo currentDirectory;
    private static Stack<DirectoryInfo> directoryHistory;

    static ConsoleFileManager()
    {
        // Загружаем доступные диски
        drives = DriveInfo.GetDrives();
        currentSelectionIndex = 0;
        currentDrive = null;
        currentDirectory = null;
        directoryHistory = new Stack<DirectoryInfo>();
    }

    public static void RunFileManager()
    {
        ConsoleKeyInfo key;

        do
        {
            Console.Clear();
            DisplayDrives();
            key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (currentSelectionIndex > 0)
                        currentSelectionIndex--;
                    break;
                case ConsoleKey.DownArrow:
                    if (currentSelectionIndex < drives.Length - 1)
                        currentSelectionIndex++;
                    break;
                case ConsoleKey.Enter:
                    ExploreDrive(drives[currentSelectionIndex]);
                    break;
            }
        } while (key.Key != ConsoleKey.Escape);
    }

    private static void ExploreDrive(DriveInfo drive)
    {
        ConsoleKeyInfo key;

        currentDrive = drive;
        currentDirectory = drive.RootDirectory;
        directoryHistory.Clear();

        do
        {
            Console.Clear();
            DisplayDriveInfo(drive);
            DisplayDirectoriesAndFiles(currentDirectory);

            key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (currentSelectionIndex > 0)
                        currentSelectionIndex--;
                    break;
                case ConsoleKey.DownArrow:
                    if (currentSelectionIndex < currentDirectory.GetDirectories().Length + currentDirectory.GetFiles().Length - 1)
                        currentSelectionIndex++;
                    break;
                case ConsoleKey.Enter:
                    FileSystemInfo selectedInfo = GetFileSystemInfo(currentDirectory, currentSelectionIndex);
                    if (selectedInfo is DirectoryInfo)
                    {
                        directoryHistory.Push(currentDirectory);
                        ExploreDirectory((DirectoryInfo)selectedInfo);
                    }
                    else if (selectedInfo is FileInfo)
                    {
                        OpenFile((FileInfo)selectedInfo);
                    }
                    break;
            }
        } while (key.Key != ConsoleKey.Escape);
    }

    private static void ExploreDirectory(DirectoryInfo directory)
    {
        ConsoleKeyInfo key;

        currentDirectory = directory;

        do
        {
            Console.Clear();
            DisplayDriveInfo(currentDrive);
            DisplayDirectoryInfo(directory);
            DisplayDirectoriesAndFiles(currentDirectory);

            key = Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    if (currentSelectionIndex > 0)
                        currentSelectionIndex--;
                    break;
                case ConsoleKey.DownArrow:
                    if (currentSelectionIndex < currentDirectory.GetDirectories().Length + currentDirectory.GetFiles().Length - 1)
                        currentSelectionIndex++;
                    break;
                case ConsoleKey.Enter:
                    FileSystemInfo selectedInfo = GetFileSystemInfo(currentDirectory, currentSelectionIndex);
                    if (selectedInfo is DirectoryInfo)
                    {
                        directoryHistory.Push(currentDirectory);
                        ExploreDirectory((DirectoryInfo)selectedInfo);
                    }
                    else if (selectedInfo is FileInfo)
                    {
                        OpenFile((FileInfo)selectedInfo);
                    }
                    break;
            }
        } while (key.Key != ConsoleKey.Escape);

        if (directoryHistory.Count > 0)
        {
            currentDirectory = directoryHistory.Pop();
        }
    }

    private static void DisplayDrives()
    {
        Console.WriteLine("Выберите диск:");

        for (int i = 0; i < drives.Length; i++)
        {
            Console.Write(i == currentSelectionIndex ? "> " : "  ");
            Console.WriteLine($"{drives[i].Name} ({drives[i].DriveFormat}, {FormatSize(drives[i].TotalFreeSpace)} свободно из {FormatSize(drives[i].TotalSize)})");
        }

        Console.WriteLine("Esc. Выход");
    }

    private static void DisplayDriveInfo(DriveInfo drive)
    {
        Console.WriteLine($"Диск {drive.Name} ({drive.DriveFormat})");
        Console.WriteLine($"Свободно {FormatSize(drive.TotalFreeSpace)} из {FormatSize(drive.TotalSize)}");
        Console.WriteLine();
    }

    private static void DisplayDirectoryInfo(DirectoryInfo directory)
    {
        Console.WriteLine($"Папка: {directory.FullName}");
        Console.WriteLine();
    }

    private static void DisplayDirectoriesAndFiles(DirectoryInfo directory)
    {
        Console.WriteLine("  Название                                 Тип         Размер");
        Console.WriteLine("-------------------------------------------------------------");

        var directories = directory.GetDirectories();
        var files = directory.GetFiles();

        for (int i = 0; i < directories.Length; i++)
        {
            Console.Write(i == currentSelectionIndex ? "> " : "  ");
            DisplayFileSystemInfo(directories[i]);
        }

        for (int i = 0; i < files.Length; i++)
        {
            Console.Write((directories.Length + i) == currentSelectionIndex ? "> " : "  ");
            DisplayFileSystemInfo(files[i]);
        }

        Console.WriteLine("Esc. Назад");
    }

    private static void DisplayFileSystemInfo(FileSystemInfo info)
    {
        string name = info.Name;
        string type = GetFileSystemType(info);
        string size = (info is FileInfo) ? FormatSize(((FileInfo)info).Length) : string.Empty;

        Console.WriteLine($"{name,-40} {type,-10} {size,20}");
    }

    private static string GetFileSystemType(FileSystemInfo info)
    {
        return info is DirectoryInfo ? "Папка" : "Файл";
    }

    private static FileSystemInfo GetFileSystemInfo(DirectoryInfo directory, int selectedIndex)
    {
        var directories = directory.GetDirectories();
        var files = directory.GetFiles();

        int totalItems = directories.Length + files.Length;

        if (selectedIndex < totalItems)
        {
            if (selectedIndex < directories.Length)
            {
                return directories[selectedIndex];
            }
            else
            {
                return files[selectedIndex - directories.Length];
            }
        }
        else
        {
            // Вернуть null или другое значение, если индекс за пределами диапазона
            return null;
        }
    }

    private static void OpenFile(FileInfo file)
    {
        Console.WriteLine($"Открытие файла: {file.FullName}");

        try
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = file.FullName,
                UseShellExecute = true
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при открытии файла: {ex.Message}");
        }

        Console.WriteLine("Нажмите Enter для продолжения...");
        Console.ReadLine(); // Пауза, чтобы пользователь мог увидеть вывод
    }

    private static string FormatSize(long sizeInBytes)
    {
        const long kb = 1024;
        const long mb = kb * 1024;
        const long gb = mb * 1024;

        if (sizeInBytes >= gb)
        {
            return $"{sizeInBytes / gb} GB";
        }
        else if (sizeInBytes >= mb)
        {
            return $"{sizeInBytes / mb} MB";
        }
        else if (sizeInBytes >= kb)
        {
            return $"{sizeInBytes / kb} KB";
        }
        else
        {
            return $"{sizeInBytes} B";
        }
    }
}

class Program
{
    static void Main()
    {
        ConsoleFileManager.RunFileManager();
    }
}
