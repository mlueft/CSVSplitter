

using System;
using System.IO;
using System.Collections.Generic;

namespace CSVSplitter
{
    class CSVReader
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

        private StreamReader reader;
        private string _fileName;

        public CSVReader(string fileName)
        {
            _fileName = fileName;
            SetPos(0);
        }

        private string last(string a, int b)
        {
            return a.Substring(a.Length - b, b);
        }

        private int count(string text, string c, int pos)
        {

            char[] charArray = text.ToCharArray();
            Array.Reverse(charArray);
            text = new string(charArray);

            charArray = c.ToCharArray();
            Array.Reverse(charArray);
            c = new string(charArray);

            int result = 0;

            for (int i = pos; i < text.Length - pos && text.Substring(i, c.Length) == c; i += c.Length)
            {
                result++;
            }

            return result;
        }

        public bool EndOfStream
        {
            get {
                return reader.Peek() == -1;

                //long cPos = reader.BaseStream.Position;
                //bool result = reader.EndOfStream;
                //reader.BaseStream.Position = cPos;
                //return result;

            }
        }

        bool _endOfLine = false;
        public bool EndOfLine
        {
            get { return _endOfLine; }
        }

        private int Peek()
        {
            return reader.Peek();
        }

        private int Read()
        {
            _pos++;
            return reader.Read();
        }

        private void SetPos(long i)
        {
            //reader.BaseStream.Seek(i, SeekOrigin.Begin);
            //reader.DiscardBufferedData();

            try
            {
                reader.Close();
            }
            catch (NullReferenceException)
            {}

            reader = File.OpenText(_fileName);
            _pos = 0;
            _endOfLine = false;
            while (_pos < i)
                Read();

        }


        private long _pos;
        public long getPos()
        {
            return _pos;
        }

        public string ReadFieldRaw()
        {
            if (reader == null)
                return null;

            if (EndOfStream)
                return null;

            _endOfLine = false;

            string result = "";
            bool inString = false;

            while (true)
            {

                string c = "";

                try
                {
                    c = Convert.ToChar(Peek()).ToString();
                }
                catch (OverflowException)
                { }

                if (c == textDelimiter && result.Length == 0)
                {
                    inString = true;
                }
                else
                {
                    if (!inString)
                    {
                        if (c == fieldDelimiter)
                        {
                            //Console.WriteLine("-0-");
                            Read();
                            return result;
                        }
                        else if (result.Length >= lineEnding.Length)
                        {
                            if (last(result, lineEnding.Length) == lineEnding)
                            {
                                //Console.WriteLine("-1-");
                                _endOfLine = true;
                                return result.Substring(0, result.Length - lineEnding.Length);
                            }
                        }
                    }
                    else
                    {
                        if (result.Length >= Math.Max(2, lineEnding.Length + 1))
                        {
                            if (
                                last(result, textDelimiter.Length+ fieldDelimiter.Length) == textDelimiter.ToString() + fieldDelimiter.ToString()
                                &&
                                count(result, textDelimiter, fieldDelimiter.Length) %2 == 1
                                )
                            {
                                //Console.WriteLine("-2-");
                                return result.Substring(1, result.Length - 3);
                            }
                            if (
                                last(result, lineEnding.Length + textDelimiter.Length) == textDelimiter.ToString() + lineEnding.ToString()
                                &&
                                count(result, textDelimiter, lineEnding.Length) % 2 == 1
                            )
                            {
                                //Console.WriteLine("-3-");
                                _endOfLine = true;
                                return result.Substring(textDelimiter.Length, result.Length - lineEnding.Length - textDelimiter.Length );
                            }
                        }
                    }
                }

                // EOF
                if( EndOfStream )
                {
                    _endOfLine = true;
                    return result;
                }

                result += Convert.ToChar(Read()).ToString();
            }
        }

        public string ReadField()
        {
            return ReadFieldRaw().Replace(textDelimiter+textDelimiter,textDelimiter);
        }

        public List<string> ReadHeaders()
        {
            long cPos = getPos();
            SetPos(0);
            List<string> result = ReadLine();
            SetPos(cPos);
            return result;
        }

        public List<string> ReadLine()
        {
            List<string> result = new List<string>();

            do
            {
                result.Add(ReadField());
            }
            while (!_endOfLine);

            return result;
        }

        public string readTextLine()
        {









            if(reader == null)
                return null;

            if(EndOfStream)
                return null;

            _endOfLine = false;

            string result = "";

            while(true)
            {

                string c = "";

                try
                {
                    c = Convert.ToChar(Peek()).ToString();
                }
                catch(OverflowException)
                { }

                if(result.Length >= Math.Max(2,lineEnding.Length + 1))
                {
                    if(
                        last(result,lineEnding.Length ) == lineEnding.ToString()
                    )
                    {
                        _endOfLine = true;
                        return result.Substring(0,result.Length - lineEnding.Length);
                    }
                }

                // EOF
                if(EndOfStream)
                {
                    _endOfLine = true;
                    return result;
                }

                result += Convert.ToChar(Read()).ToString();
            }
















        }

        public void Close()
        {
            reader.Close();
        }
    }
}
