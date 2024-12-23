string path =  @"C:\OldDir\content.txt";
string newPath = @"C:\NewDir\index.txt";
FileInfo fileInf = new FileInfo(path);
if (fileInf.Exists)
{
    fileInf.MoveTo(newPath);       
    
}
