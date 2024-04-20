using System;
using CSVSplitter;

namespace CSVSplitter_cli
{
	class Program{
		
		public static void showHelp(){
			
			Console.WriteLine("");
			Console.WriteLine("csvsplitter+ is a tool to split csv files.");
			Console.WriteLine("It can split by a given line number or");
			Console.WriteLine("before/after lines matching a defined regex.");
			Console.WriteLine("Line numbers and regex criteria can be combined.");
            Console.WriteLine("The file can even be split by columns.");
            Console.WriteLine("The program can be used to resort the columns of a csv file.");
            Console.WriteLine("");
            Console.WriteLine("Flag                        required default description");
            Console.WriteLine("-i | --inputFile            yes              Inputfile");
            Console.WriteLine("-l | --lineNumber                    10000   Split after n lines.");
            Console.WriteLine("-s | --sourceHeader                  False   Source contains header line.");
            Console.WriteLine("-t | --targetHeader                  False   Target contains header line.");
            Console.WriteLine("                                             Ignored if -s is not defined.");
            Console.WriteLine("-c | --sourceTextDelimiter           \"       Text delimiter in source.");
            Console.WriteLine("-m | --sourceLineDelimiter           \\r\\n    Line delimiter in source.");
            Console.WriteLine("-f | --sourceFieldDelimiter          ;       Field delimiter in source.");
            Console.WriteLine("-d | --sourcePrefix                  0       Number of prefix lines in source file.");
            Console.WriteLine("-n | --targetTextDelimiter           -t      Field delimiter in target");
            Console.WriteLine("-o | --targetLineDelimiter           -m      Line delimiter in target.");
            Console.WriteLine("-p | --targetFieldDelimiter          -f      Field delimiter in target.");
            Console.WriteLine("-g | --targetPrefix                  false   Target contains prefix.");
            Console.WriteLine("-j | --indices:[i | h]                       i - Export columns are definied by indices.");
            Console.WriteLine("                                             h - Export columns are definied by collum names.");
            Console.WriteLine("-e | --exportHeader                          Columns to export[csv - data].");
            Console.WriteLine("-b | --splitBefore");                        
            Console.WriteLine("-a | --splitAfter");                         
            Console.WriteLine("                                             Ignored if -b is defined.");
            Console.WriteLine("");
            Console.WriteLine("The export headers have to be defined in a certain way:");
            Console.WriteLine("No Text delimiter are allowed.");
            Console.WriteLine("Field delimiter has to be a ;");
            Console.WriteLine("No line breakes are allowed.");
            Console.WriteLine("No spaces are allowed in column names.");
            Console.WriteLine("");
            Console.WriteLine("Version " + Data.version + "(" + Data.releaseDate + ")");
            Console.WriteLine(Data.copyright + ", visit https://github.com/mlueft/CSVSplitter");

		}
		
		public static int Main(string[] args){

            Logger.logFile = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\splitter.log";

			if( args.Length == 0 ){
				showHelp();
				return 1;
			}
			
			string inputFile            = null;
            UInt64 lineNumber           = 10000;
            bool sourceHeader           = false;
			bool targetHeader           = false;
            string sourceTextDelimiter  = "\"";
            string sourceLineDelimiter  = "\r\n";
            string sourceFieldDelimiter = ";";
            string targetTextDelimiter  = null;
            string targetLineDelimiter  = null;
            string targetFieldDelimiter = null;
            string indices              = null;
            string exportHeader         = null;
            string splitBefore          = null;
			string splitAfter           = null;
            UInt64 sourcePrefix         = 0;
            bool targetPrefix           = false;

			try{
				
				for(int i = 0; i < args.Length; i++){

                    Logger.Log( "reading parameter: "+ (string)args[i]);

					switch( ((string)args[i]) ){
						case "-i":
						case "--inputFile":
							inputFile = args[++i].Trim();
                            Logger.Log(" with value: " + inputFile );
                            break;
						case "-l":
						case "--lineNumber":
							lineNumber = Convert.ToUInt64(args[++i].Trim());
                            Logger.Log(" with value: " + lineNumber.ToString());
                            break;
						case "-s":
						case "--sourceHeader":
							sourceHeader = Convert.ToBoolean(args[++i].Trim());
                            Logger.Log(" with value: " + sourceHeader.ToString());
                            break;
						case "-t":
						case "--targetHeader":
							targetHeader = Convert.ToBoolean(args[++i].Trim());
                            Logger.Log(" with value: " + targetHeader.ToString());
                            break;
                        case "-c":
                        case "--sourceTextDelimiter":
                            sourceTextDelimiter = args[++i].Trim();
                            Logger.Log(" with value: " + sourceTextDelimiter.ToString());
                            break;
                        case "-m":
                        case "--sourceLineDelimiter":
                            sourceLineDelimiter = args[++i].Trim();
                            Logger.Log(" with value: " + sourceLineDelimiter.ToString());
                            break;
                        case "-f":
                        case "--sourceFieldDelimiter":
                            sourceFieldDelimiter = args[++i].Trim();
                            Logger.Log(" with value: " + sourceFieldDelimiter.ToString());
                            break;
                        case "-n":
                        case "--targetTextDelimiter":
                            targetTextDelimiter = args[++i].Trim();
                            Logger.Log(" with value: " + targetTextDelimiter.ToString());
                            break;
                        case "-o":
                        case "--targetLineDelimiter":
                            targetLineDelimiter = args[++i].Trim();
                            Logger.Log(" with value: " + targetLineDelimiter.ToString());
                            break;
                        case "-p":
                        case "--targetFieldDelimiter":
                            targetFieldDelimiter = args[++i].Trim();
                            Logger.Log(" with value: " + targetFieldDelimiter.ToString());
                            break;

                        case "-j":
                        case "--indices":
                            indices = args[++i].Trim().ToLower() == "i" ? "i" : "h";
                            Logger.Log(" with value: " + indices.ToString());
                            break;
                        case "-e":
                        case "--exportHeader":
                            exportHeader = args[++i].Trim();
                            Logger.Log(" with value: " + exportHeader.ToString());
                            break;

                        case "-b":
						case "--splitBefore":
							splitBefore = args[++i].Trim();
                            Logger.Log(" with value: " + splitBefore.ToString());
                            break;
						case "-a":
						case "--splitAfter":
							splitAfter = args[++i].Trim();
                            Logger.Log(" with value: " + splitAfter.ToString());
                            break;
                        case "-d":
                        case "--sourcePrefix":
                            sourcePrefix = Convert.ToUInt64(args[++i].Trim());
                            Logger.Log(" with value: " + sourcePrefix.ToString());
                            break;
                        case "-g":
                        case "--targetPrefix":
                            targetPrefix = Convert.ToBoolean(args[++i].Trim());
                            Logger.Log(" with value: " + targetPrefix.ToString());
                            break;

                        case "-h":
						case "--help":
						default:
							showHelp();
						return 1;
					}
				}
				
			}catch(Exception e){
				Console.WriteLine( "Couldn't read all parameters. Please check your parameter list." );

                Logger.Log("Couldn't read all parameters. Please check your parameter list.");
                Logger.Log(e.Message);
                Logger.Log(e.StackTrace);
                Logger.WriteToFile();

                return 1;
			}

            if (
                inputFile == null
            )
            {
                Console.WriteLine("Please define an input file.");
                Logger.Log("Please define an input file.");
                return 1;
            }

            if (!sourceHeader)
            {
                targetHeader = false;
                Logger.Log("targetHeader set to false, because sourceHeader is not defined.");
            }

            if (splitBefore != null)
            {
                splitAfter = null;
                Logger.Log("splitAfter set to null because splitBefore is defined.");
            }

            if (targetTextDelimiter == null)
            {
                targetTextDelimiter = sourceTextDelimiter;
                Logger.Log("sourceTextDelimiter is taken as targetTextDelimiter.");
            }

            if (targetLineDelimiter == null)
            {
                targetLineDelimiter = sourceLineDelimiter;
                Logger.Log("sourceLineDelimiter is taken as targetLineDelimiter.");
            }

            if (targetFieldDelimiter == null)
            {
                targetFieldDelimiter = sourceFieldDelimiter;
                Logger.Log("sourceFieldDelimiter is taken as targetFieldDelimiter.");
            }

            try{

                Logger.Log("Initializing Splitter.");

                Splitter sp = new Splitter();
				sp.sourceFile = inputFile;
				sp.splitAfterNumberOfLines = lineNumber;

                sp.splitBefore = null;
                sp.splitAfter = null;

                if (splitBefore != null)
                    sp.splitBefore = splitBefore;

                if (splitAfter != null)
                    sp.splitAfter = splitAfter;

                sp.sourceHasHeader = sourceHeader;
                sp.targetHeader = targetHeader;
                sp.sourceTextDelimiter = sourceTextDelimiter;
                sp.sourceLineDelimiter = sourceLineDelimiter;
                sp.sourceFieldDelimiter = sourceFieldDelimiter;
                sp.targetTextDelimiter = targetTextDelimiter;
                sp.targetLineDelimiter = targetLineDelimiter;
                sp.targetFieldDelimiter = targetFieldDelimiter;
                sp.sourcePrefix = sourcePrefix;
                sp.targetPrefix = targetPrefix;
                sp.indices = indices;
                sp.exportHeader = exportHeader;

                Logger.Log("Checking input file.");

                if (!Splitter.checkInputfile(inputFile))
                {
                    Console.WriteLine("Please choose a valid input file.");
                    return 1;
                }

                Logger.Log("starting execution.");
                sp.split();
                return 0;

			}catch(Exception e ){

				Console.WriteLine( "An error occured:" );
                Console.WriteLine( "Please check the log file." );

                Logger.Log( "An error occured" );
                Logger.Log(e.Message);
                Logger.Log(e.StackTrace);
                Logger.WriteToFile();
                
                return 1;

			}
		}
	}
}