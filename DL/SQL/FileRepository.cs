//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL.SQL
{
    using System;
    using System.Collections.Generic;
    
    public partial class FileRepository
    {
        public long Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public byte[] FileBinary { get; set; }
        public string ParentTableName { get; set; }
        public Nullable<int> ParentTableCode { get; set; }
        public long RCB { get; set; }
        public long RUB { get; set; }
        public System.DateTime RCT { get; set; }
        public System.DateTime RUT { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
