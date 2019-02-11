namespace JsonTestApp
{
    public interface ICentralizer
    {
        void ConvertJsonToTxt(string inputPath, string outputPath);
        void ConvertTxtToJson(string inputPath, string outputPath);
    }
}