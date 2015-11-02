﻿#region licence
// =====================================================
// EfSchemeCompare Project - project to compare EF schema to SQL schema
// Filename: DataTop.cs
// Date Created: 2015/10/31
// © Copyright Selective Analytics 2015. All rights reserved
// =====================================================
#endregion

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tests.EfClasses
{
    public class DataTop
    {

        public int DataTopId { get; set; }

        [MaxLength(25)]
        public string MyString { get; set; }

        public int LengthMyString { get { return MyString == null ? -1 : MyString.Length; } }

        //---------------------------------------------
        //relationships

        public int? DataSingletonId { get; set; }

        [ForeignKey("DataSingletonId")]
        public DataSingleton SingletonNullable { get; set; }

        public ICollection<DataChild> Children { get; set; }

        public ICollection<DataManyChildren> ManyChildren { get; set; }

        public ICollection<DataCompKey> ManyCompKeys { get; set; } 
    }
}
