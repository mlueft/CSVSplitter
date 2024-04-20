using System;
using System.IO;
using System.Collections.Generic;


namespace CSVSplitter
{
    class CSVWriter
    {

        private string clearRegex(string value)
        {
            return value.Replace("\\n", "\n").Replace("\\r", "\r").Replace("\\t", "\t");
        }

        private string _fieldDelimiter = ",";
        public string fieldDelimiter
        {
            set { _fieldDelimiter = clearRegex(value); }
            get { return _fieldDelimiter; }
        }

        private string _textDelimiter = "\"";
        public string textDelimiter
        {
            set { _textDelimiter = clearRegex(value); }
            get { return _textDelimiter; }
        }

        private string _lineEnding = "\r\n";
        public string lineEnding
        {
            set { _lineEnding = clearRegex(value); }
            get { return _lineEnding; }
        }

        private string fileName;
        public string FileName
        {
            set { fileName = value; }
            get { return fileName; }
        }


        public string indices = null;
        public string exportHeader = null;
        private string[] exportColumns = null;
        public List<string> headerLine = null;

        private StreamWriter writer;

        public CSVWriter(string fileName)
        {

            FileName = fileName;
            writer = new StreamWriter(fileName);
            
        }

        public void WriteLine(List<string> line)
        {

            bool makeLineEnding = false;

            if(exportHeader == null)
            {
                for (int i = 0; i < line.Count; i++)
                {

                    if( 
                        line[i].Contains(textDelimiter)
                        ||
                        line[i].Contains(fieldDelimiter)
                    )
                        writer.Write(textDelimiter);

                    writer.Write(line[i].Replace(textDelimiter,textDelimiter+textDelimiter));

                    if (
                        line[i].Contains(textDelimiter)
                        ||
                        line[i].Contains(fieldDelimiter)
                    )
                        writer.Write(textDelimiter);

                    if (i < line.Count - 1)
                        writer.Write(fieldDelimiter);

                    makeLineEnding = true;
                }
            }
            else
            {

                if (exportColumns == null)
                {
                    exportColumns = exportHeader.Split(';');

                    if (indices == "h")
                    {
                        Logger.Log("Converting Export headers to index.");
                        for (int h = 0; h < exportColumns.Length; h++) 
                        {
                            for (int i = 0; i < headerLine.Count; i++)
                            {
                                if (headerLine[i] == exportColumns[h])
                                {
                                    exportColumns[h] = i.ToString();

                                }
                            }
                        }
                        Logger.Log("Done.");
                    }
                }

                for (int h = 0; h < exportColumns.Length; h++)
                {
                    for (int i = 0; i < line.Count; i++)
                    {
                        if(i.ToString() == exportColumns[h])
                        {

                            if (
                                line[i].Contains(textDelimiter)
                                ||
                                line[i].Contains(fieldDelimiter)
                            )
                                writer.Write(textDelimiter);

                            if (line[i].Contains(textDelimiter))
                                writer.Write(
                                    line[i].Replace( textDelimiter, textDelimiter + textDelimiter )
                                );
                            else
                                writer.Write(line[i]);

                            if (
                                line[i].Contains(textDelimiter)
                                ||
                                line[i].Contains(fieldDelimiter)
                            )
                                writer.Write(textDelimiter);


                            if (h < exportColumns.Length - 1)
                                writer.Write(fieldDelimiter);

                            makeLineEnding = true;

                        }
                    }
                }
            }

            if (makeLineEnding)
                writer.Write(lineEnding);

        }

        public void WriteTextLine(string line)
        {
            writer.Write(line);
            writer.Write(_lineEnding);
            
        }

        public void Close()
        {
            writer.Close();
        }
    }
}
