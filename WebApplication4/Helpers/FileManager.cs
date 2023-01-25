namespace WebApplication4.Helpers
{
    public static class FileManager
    {
        public static string SaveFile(string path,string folder,IFormFile file)
        {
            string name = file.FileName;
            name=name.Length>64?name.Substring(name.Length-64,64):name;
            name=Guid.NewGuid().ToString()+name;
            string savepath=Path.Combine(path,folder,name);
            using (FileStream fs = new FileStream(savepath,FileMode.Create))
            {
                file.CopyTo(fs);
            }
            return name;
        }
        public static void DeleteFile(string path,string folder,string file) 
        {
            string deletepath=Path.Combine(path,folder,file);
            if(System.IO.File.Exists(deletepath)) 
            {
                System.IO.File.Delete(deletepath);
            }
        }
    }
}
