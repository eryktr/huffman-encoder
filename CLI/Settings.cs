namespace huffman_encoder.CLI
{
    internal class Settings
    {
        public RunMode Mode { get; }
        public string AlphabetFile { get; set; } = null;
        public string FileToEncode { get; set; } = null;
        public string FileToDecode { get; set; } = null;
        public string OutputFile { get; set; } = null;
        public Settings(RunMode mode)
        {
            Mode = mode;
        }
        
    }
}