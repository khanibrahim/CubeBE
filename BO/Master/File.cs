namespace BO.Master
{
    public class File : Base
    {
        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] FileBinary { get; set; }
        public string ParentTableName { get; set; }
        public int? ParentTableCode { get; set; }

    }

}
