﻿namespace BashSoft
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using BashSoft.Contracts;
    using BashSoft.Exceptions;

    public class IOManager : IDirectoryManager
    {
        public void TraverseDirectory(int depth)
        {
            OutputWriter.WriteEmptyLine();
            int initialIdentation = SessionData.CurrentPath.Split('\\').Length;
            Queue<string> subFolders = new Queue<string>();
            subFolders.Enqueue(SessionData.CurrentPath);

            while (subFolders.Count != 0)
            {
                string current = subFolders.Dequeue();
                int identation = current.Split('\\').Length - initialIdentation;

                if (depth - identation < 0)
                {
                    break;
                }

                OutputWriter.WriteMessageOnNewLine(string.Format("{0}{1}", new string('-', identation), current));
                try
                {
                    foreach (var directory in Directory.GetDirectories(current))
                    {
                        subFolders.Enqueue(directory);
                    }

                    foreach (var file in Directory.GetFiles(current))
                    {
                        int indexOfLastSlash = file.LastIndexOf("\\");
                        string filename = file.Substring(indexOfLastSlash);
                        OutputWriter.WriteMessageOnNewLine(new string('-', indexOfLastSlash) + file);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                    OutputWriter.DisplayException(ExceptionMessages.UnauthorizedAccess);
                }
            }
        }

        public void CreateDirectoryInCurrentFolder(string name)
        {
            string path = SessionData.CurrentPath + "\\" + name;
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (ArgumentException)
            {
                throw new InvalidFileNameException();
            }
        }

        public void ChangeCurrentDirectoryRelative(string relativePath)
        {
            if (relativePath.Equals(".."))
            {
                try
                {
                    string currentPath = SessionData.CurrentPath;
                    int indexofLastSlash = currentPath.LastIndexOf('\\');
                    string newPath = currentPath.Substring(0, indexofLastSlash);
                    SessionData.CurrentPath = newPath;
                }
                catch (Exception)
                {
                    throw new InvalidPathException();
                }
            }
            else
            {
                string currentPath = SessionData.CurrentPath;
                currentPath += "\\" + relativePath;
                this.ChangeCurrentDirectoryAbsolute(currentPath);
            }
        }

        public void ChangeCurrentDirectoryAbsolute(string absolutePath)
        {
            if (!Directory.Exists(absolutePath))
            {
                throw new InvalidPathException();
            }

            SessionData.CurrentPath = absolutePath;
        }
    }
}