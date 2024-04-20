using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CSVSplitter
{

	public class Splitter{

        public string sourceFile = null;
        public UInt64 splitAfterNumberOfLines = 1000;
        public bool sourceHasHeader = false;
		public bool targetHeader = false;
        public string sourceTextDelimiter = "\"";
        public string sourceLineDelimiter = "\r\n";
        public string sourceFieldDelimiter = ";";
        public string targetTextDelimiter = "\"";
        public string targetLineDelimiter = "\r\n";
        public string targetFieldDelimiter = ";";
        public string indices = null;
        public string exportHeader = null;
        private List<string> sourceHeader = null;
        public UInt64 sourcePrefix = 0;
        public bool targetPrefix = false;

        public Splitter()
        {

        }

        private List<string> prefixLines = new List<string>();

        private List<List<string[]>> afterCriteria = null;
		public string splitAfter{
			set{
                afterCriteria = parseCriteriaString(value);
                beforeCriteria = null;
            }
		}
		
        private List<List<string[]>> beforeCriteria = null;
        public string splitBefore{
			set{
                afterCriteria = null;
                beforeCriteria = parseCriteriaString(value);
            }
		}
		
		public static bool checkInputfile(string sourceFile){
			if( !File.Exists(sourceFile) )
				return false;
			return true;
		}
		
		private void checks(){

            // has to be minimum 1
            splitAfterNumberOfLines = Math.Max( 1, splitAfterNumberOfLines );

		}

        private int countLast(string data, char needle)
        {
            int result = 0;

            for (int i = data.Length - 1; i >= 0; i--)
            {
                if (data.Substring(i, 1) == needle.ToString())
                    result++;
                else
                    return result;
            }

            return result;
        }

        private List<List<string[]>> parseCriteriaString(string data)
        {

            if (data == null)
                return null;

            char openingTag = '<';
            char closingTag = '>';
            char seperator = '|';
            char escaper = '\\';

            bool inOrBlock = false;
            bool inAndBlock = false;

            List<List<string[]>> orBlocks = new List<List<string[]>>();
            List<string[]> andBlock = new List<string[]>();
            string content = "";

            int p = 0;
            foreach (char i in data.ToCharArray())
            {

                if (!inOrBlock && !inAndBlock && i == openingTag)
                {
                    // entering OR-Block
                    inOrBlock = true;
                    andBlock = new List<string[]>();
                }
                else if (inOrBlock && !inAndBlock && i == openingTag)
                {
                    // entering AND-Block
                    inAndBlock = true;
                    content = "";
                }
                else if (inOrBlock && inAndBlock && i == closingTag && countLast(data.Substring(0, p), escaper) % 2 == 0)
                {
                    // leaving AND-Block
                    inAndBlock = false;
                    andBlock.Add(new string[] { content, "" });
                }
                else if (inOrBlock && i == closingTag && countLast(data.Substring(0, p), escaper) % 2 == 0)
                {
                    // leaving OR-Block
                    inOrBlock = false;
                    orBlocks.Add(andBlock);
                }
                else if (inOrBlock && inAndBlock)
                {
                    // reading data
                    content += i;
                }
                p++;
            }

            for (int i = 0; i < orBlocks.Count; i++)
            {
                for (int j = 0; j < orBlocks[i].Count; j++)
                {
                    string c = orBlocks[i][j][0];
                    int si = c.IndexOf(seperator);

                    orBlocks[i][j][0] = c.Substring(0, si);
                    orBlocks[i][j][1] = c.Substring(si + 1, c.Length - si - 1);
                }
            }

            return orBlocks;
        }

		private bool matchCriteria(List<string> line , List<List<string[]>> criterias ){

            if (criterias == null)
                return false;

            if (indices == "h")
            {

                for (int u = 0; u < sourceHeader.Count; u++)
                {
                    for (int h = 0; h < criterias.Count; h++)
                    {
                        
                        for (int i = 0; i < criterias[h].Count; i++)
                        {
                            if (criterias[h][i][0] == sourceHeader[u])
                            {
                                criterias[h][i][0] = u.ToString();
                                
                            }
                        }
                    }
                }
            }


            foreach( List<string[]> orBlock in criterias)
            {
                bool allMet = true;
                foreach (string[] andBlock in orBlock)
                {
                    string column = andBlock[0];
                    string regex = andBlock[1];

                    bool columnFound = false;

                    for (int i = 0; i < line.Count; i++)
                    {
                        if (i.ToString() == column)
                        {
                            columnFound = true;
                            string fieldValue = line[i];

                            if ( !Regex.IsMatch(fieldValue, regex))
                                allMet = false;

                        }
                    }

                    if (!columnFound )
                        throw new Exception("Header in criteria not found('"+ column + "').");

                }

                if (allMet)
                    return true;
            }

            return false;

		}

        public void split() {


            if (!checkInputfile(sourceFile))
            {
                Logger.Log("checkInputfile failed!");
                return;
            }

            checks();

			UInt64 qtyLinesInFile = 0;
			UInt64 qtySplitFile = 0;
            List<string> line;
			
			string filePath      = Path.GetDirectoryName(Path.GetFullPath(sourceFile))+@"\";
			string fileName      = Path.GetFileName(sourceFile);
			fileName             = fileName.Substring(0,fileName.LastIndexOf('.')); //"splitter";
			string fileExtension = Path.GetExtension(sourceFile); //"csv";

            Logger.Log("Preparing CSVReader.");
            CSVReader source = new CSVReader(sourceFile);

            source.fieldDelimiter = sourceFieldDelimiter;
            source.textDelimiter = sourceTextDelimiter;
            source.lineEnding = sourceLineDelimiter;

            CSVWriter target = null;

            Logger.Log("Reading prefix lines.");
            prefixLines = new List<string>();

            if(sourcePrefix > 0)
            {
                for (UInt64 i = 0; i < sourcePrefix;i++)
                    prefixLines.Add(source.readTextLine());
            }

            Logger.Log("Reading source header.");
            if ( sourceHasHeader ){
				sourceHeader = source.ReadLine();
            }


            try
            {
                Logger.Log("start reading source.");
                while (!source.EndOfStream)
                {

                    line = source.ReadLine();


                    // if no export header defined take all
                    if (exportHeader == null)
                    {
                        Logger.Log("Taking all input columns as export headers.");
                        string h = "";

                        for (int i = 0; i < line.Count; i++)
                            h += i.ToString() + ";";

                        h = h.Substring(0, h.Length - 1);

                        exportHeader = h;
                    }

                    // Close part file if full
                    if (
					    // split at linecount
					    (qtyLinesInFile > splitAfterNumberOfLines-1 && target != null && (afterCriteria == null && beforeCriteria == null ) )
					    ||
					    // split at linecount && before XX
					    (qtyLinesInFile > splitAfterNumberOfLines-1 && target != null && matchCriteria( line, beforeCriteria) )
				    ){

                        Logger.Log("Closing part file.");
                        target.Close();
					    qtyLinesInFile = 0;
					    target = null;
					
				    }
				
				
				    // Open new part file if not open
				    if( target == null ){
                        
                        Logger.Log("creating new part file.");
                        Directory.CreateDirectory( filePath + "split_"+fileName+ @"\" );
					    target = new CSVWriter( filePath + "split_"+fileName+ @"\" + fileName + ".part" + qtySplitFile + fileExtension );

                        Logger.Log("File:"+ target.FileName );

                        target.fieldDelimiter = targetFieldDelimiter;
                        target.textDelimiter = targetTextDelimiter;
                        target.lineEnding = targetLineDelimiter;
                        target.indices = indices;
                        target.exportHeader = exportHeader;

                        if(targetPrefix)
                        {
                            Logger.Log("Writing prefix.");
                            foreach (string l in prefixLines)
                            {
                                target.WriteTextLine(l);
                            }
                        }

                        if ( sourceHasHeader )
                        {
                            target.headerLine = sourceHeader;
                            if ( targetHeader ){
                                Logger.Log("Writing header line.");
                                target.WriteLine(sourceHeader);
					        }
                        }

                        qtySplitFile++;
				    }
				
				
				
				    target.WriteLine(line);
				
				
				
				    // Close part file if full
				    if(
					    // split at linecount && after XX
					    (qtyLinesInFile > splitAfterNumberOfLines-1 && target != null && matchCriteria( line, afterCriteria) )
				    ){
                        Logger.Log("Closing part file.");
                        target.Close();
					    qtyLinesInFile = 0;
					    target = null;
					
				    }
				
				
				    qtyLinesInFile++;
			    }
            }
            finally
            {
                source.Close();
                Logger.Log("Closing source file.");
                try
                {
                    target.Close();
                    Logger.Log("Closing part file.");
                }
                catch (Exception)
                {}
            }

            source.Close();
			
			if(target != null)
				target.Close();
			
		}
	}
}