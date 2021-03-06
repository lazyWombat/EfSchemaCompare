﻿#region licence
// =====================================================
// EfSchemeCompare Project - project to compare EF schema to SQL schema
// Filename: Test34EfTableInfoRelationships.cs
// Date Created: 2016/04/06
// 
// Under the MIT License (MIT)
// 
// Written by Jon Smith : GitHub JonPSmith, www.thereformedprogrammer.net
// =====================================================
#endregion

using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CompareCore.EFInfo;
using Ef6SchemaCompare.InternalEf6;
using Ef6TestDbContext;
using EfPocoClasses.Relationships;
using NUnit.Framework;
using Tests.Helpers;

namespace Tests.UnitTests
{
    public class Test34EfTableInfoRelationships
    {
        private IList<EfTableInfo> _efInfos;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            using (var db = new TestEf6SchemaCompareDb())
            {
                var decoder = new Ef6MetadataDecoder(Assembly.GetAssembly(typeof(DataTop)));
                _efInfos = decoder.GetAllEfTablesWithColInfo(db);
            }
        }

        [Test]
        public void Test10DataTopNormalColsOk()
        {
            //SETUP
            var classType = typeof (DataTop);

            //EXECUTE
            var efInfo = _efInfos.SingleOrDefault(x => x.ClrClassType == classType);

            //VERIFY
            efInfo.ShouldNotEqualNull();
            efInfo.TableName.ShouldEqual(classType.Name);
            //foreach (var col in efInfo.NormalCols)
            //{
            //    Console.WriteLine("list[i++].ToString().ShouldEqual(\"{0}\");", col);
            //}
            efInfo.NormalCols.Count.ShouldEqual(4);
            var list = efInfo.NormalCols.ToList();
            var i = 0;
            list[i++].ToString().ShouldEqual("SqlColumnName: DataTopId, SqlTypeName: int, ClrColumName: DataTopId, ClrColumnType: System.Int32, IsPrimaryKey: True, PrimaryKeyOrder: 1, IsNullable: False, MaxLength: 4");
            list[i++].ToString().ShouldEqual("SqlColumnName: MyString, SqlTypeName: varchar, ClrColumName: MyString, ClrColumnType: System.String, IsPrimaryKey: False, PrimaryKeyOrder: 0, IsNullable: True, MaxLength: 25");
            list[i++].ToString().ShouldEqual("SqlColumnName: Key1, SqlTypeName: int, ClrColumName: Key1, ClrColumnType: System.Int32, IsPrimaryKey: False, PrimaryKeyOrder: 0, IsNullable: False, MaxLength: 4");
            list[i++].ToString().ShouldEqual("SqlColumnName: Key2, SqlTypeName: uniqueidentifier, ClrColumName: Key2, ClrColumnType: System.Guid, IsPrimaryKey: False, PrimaryKeyOrder: 0, IsNullable: False, MaxLength: 16");
        }

        [Test]
        public void Test20DataChildNormalColsOk()
        {
            //SETUP
            var classType = typeof(DataChild);

            //EXECUTE
            var efInfo = _efInfos.SingleOrDefault(x => x.ClrClassType == classType);

            //VERIFY
            efInfo.ShouldNotEqualNull();
            efInfo.TableName.ShouldEqual(classType.Name);
            //foreach (var col in efInfo.NormalCols)
            //{
            //    Console.WriteLine("list[i++].ToString().ShouldEqual(\"{0}\");", col);
            //}
            efInfo.NormalCols.Count.ShouldEqual(4);
            var list = efInfo.NormalCols.ToList();
            var i = 0;
            list[i++].ToString().ShouldEqual("SqlColumnName: DataChildId, SqlTypeName: int, ClrColumName: DataChildId, ClrColumnType: System.Int32, IsPrimaryKey: True, PrimaryKeyOrder: 1, IsNullable: False, MaxLength: 4");
            list[i++].ToString().ShouldEqual("SqlColumnName: MyInt, SqlTypeName: int, ClrColumName: MyInt, ClrColumnType: System.Int32, IsPrimaryKey: False, PrimaryKeyOrder: 0, IsNullable: False, MaxLength: 4");
            list[i++].ToString().ShouldEqual("SqlColumnName: MyString, SqlTypeName: nvarchar, ClrColumName: MyString, ClrColumnType: System.String, IsPrimaryKey: False, PrimaryKeyOrder: 0, IsNullable: True, MaxLength: -1");
            list[i++].ToString().ShouldEqual("SqlColumnName: DataTopId, SqlTypeName: int, ClrColumName: DataTopId, ClrColumnType: System.Int32, IsPrimaryKey: False, PrimaryKeyOrder: 0, IsNullable: False, MaxLength: 4");
        }

        [Test]
        public void Test30DataManyChildrenNormalColsOk()
        {
            //SETUP
            var classType = typeof(DataManyChildren);

            //EXECUTE
            var efInfo = _efInfos.SingleOrDefault(x => x.ClrClassType == classType);

            //VERIFY
            efInfo.ShouldNotEqualNull();
            efInfo.TableName.ShouldEqual(classType.Name);
            //foreach (var col in efInfo.NormalCols)
            //{
            //    Console.WriteLine("list[i++].ToString().ShouldEqual(\"{0}\");", col);
            //}
            efInfo.NormalCols.Count.ShouldEqual(2);
            var list = efInfo.NormalCols.ToList();
            var i = 0;
            list[i++].ToString().ShouldEqual("SqlColumnName: DataManyChildrenId, SqlTypeName: int, ClrColumName: DataManyChildrenId, ClrColumnType: System.Int32, IsPrimaryKey: True, PrimaryKeyOrder: 1, IsNullable: False, MaxLength: 4");
            list[i++].ToString().ShouldEqual("SqlColumnName: MyInt, SqlTypeName: int, ClrColumName: MyInt, ClrColumnType: System.Int32, IsPrimaryKey: False, PrimaryKeyOrder: 0, IsNullable: False, MaxLength: 4");
        }

        [Test]
        public void Test40DataSingletonNormalColsOk()
        {
            //SETUP
            var classType = typeof(DataSingleton);

            //EXECUTE
            var efInfo = _efInfos.SingleOrDefault(x => x.ClrClassType == classType);

            //VERIFY
            efInfo.ShouldNotEqualNull();
            efInfo.TableName.ShouldEqual(classType.Name);
            //foreach (var col in efInfo.NormalCols)
            //{
            //    Console.WriteLine("list[i++].ToString().ShouldEqual(\"{0}\");", col);
            //}
            efInfo.NormalCols.Count.ShouldEqual(2);
            var list = efInfo.NormalCols.ToList();
            var i = 0;
            list[i++].ToString().ShouldEqual("SqlColumnName: DataTopId, SqlTypeName: int, ClrColumName: DataTopId, ClrColumnType: System.Int32, IsPrimaryKey: True, PrimaryKeyOrder: 1, IsNullable: False, MaxLength: 4");
            list[i++].ToString().ShouldEqual("SqlColumnName: MyDateTime, SqlTypeName: datetime, ClrColumName: MyDateTime, ClrColumnType: System.DateTime, IsPrimaryKey: False, PrimaryKeyOrder: 0, IsNullable: False, MaxLength: 8");
        }

        [Test]
        public void Test50DataCompKeyNormalColsOk()
        {
            //SETUP
            var classType = typeof(DataCompKey);

            //EXECUTE
            var efInfo = _efInfos.SingleOrDefault(x => x.ClrClassType == classType);

            //VERIFY
            efInfo.ShouldNotEqualNull();
            efInfo.TableName.ShouldEqual("NonStandardCompKeyTable");
            //foreach (var col in efInfo.NormalCols)
            //{
            //    Console.WriteLine("list[i++].ToString().ShouldEqual(\"{0}\");", col);
            //}
            efInfo.NormalCols.Count.ShouldEqual(3);
            var list = efInfo.NormalCols.ToList();
            var i = 0;
            list[i++].ToString().ShouldEqual("SqlColumnName: Key1, SqlTypeName: int, ClrColumName: Key1, ClrColumnType: System.Int32, IsPrimaryKey: True, PrimaryKeyOrder: 1, IsNullable: False, MaxLength: 4");
            list[i++].ToString().ShouldEqual("SqlColumnName: Key2, SqlTypeName: uniqueidentifier, ClrColumName: Key2, ClrColumnType: System.Guid, IsPrimaryKey: True, PrimaryKeyOrder: 2, IsNullable: False, MaxLength: 16");
            list[i++].ToString().ShouldEqual("SqlColumnName: NonStandardColumnName, SqlTypeName: int, ClrColumName: MyEnum, ClrColumnType: EfPocoClasses.Relationships.EnumTests, IsPrimaryKey: False, PrimaryKeyOrder: 0, IsNullable: False, MaxLength: 4");
        }

        [Test]
        public void Test60DataManyCompKeyNormalColsOk()
        {
            //SETUP
            var classType = typeof(DataManyCompKey);

            //EXECUTE
            var efInfo = _efInfos.SingleOrDefault(x => x.ClrClassType == classType);

            //VERIFY
            efInfo.ShouldNotEqualNull();
            efInfo.TableName.ShouldEqual(classType.Name);
            //foreach (var col in efInfo.NormalCols)
            //{
            //    Console.WriteLine("list[i++].ToString().ShouldEqual(\"{0}\");", col);
            //}
            efInfo.NormalCols.Count.ShouldEqual(2);
            var list = efInfo.NormalCols.ToList();
            var i = 0;
            list[i++].ToString().ShouldEqual("SqlColumnName: ManyKey1, SqlTypeName: int, ClrColumName: ManyKey1, ClrColumnType: System.Int32, IsPrimaryKey: True, PrimaryKeyOrder: 1, IsNullable: False, MaxLength: 4");
            list[i++].ToString().ShouldEqual("SqlColumnName: ManyKey2, SqlTypeName: uniqueidentifier, ClrColumName: ManyKey2, ClrColumnType: System.Guid, IsPrimaryKey: True, PrimaryKeyOrder: 2, IsNullable: False, MaxLength: 16");
        }

        [Test]
        public void Test80DataZeroOrOneColsOk()
        {
            //SETUP
            //SETUP
            var classType = typeof(DataManyCompKey);

            //EXECUTE
            var efInfo = _efInfos.SingleOrDefault(x => x.ClrClassType == classType);

            //VERIFY
            efInfo.ShouldNotEqualNull();
            efInfo.TableName.ShouldEqual(classType.Name);
            //foreach (var col in efInfo.NormalCols)
            //{
            //    Console.WriteLine("list[i++].ToString().ShouldEqual(\"{0}\");", col);
            //}
            efInfo.NormalCols.Count.ShouldEqual(2);
            var list = efInfo.NormalCols.ToList();
            var i = 0;
            list[i++].ToString().ShouldEqual("SqlColumnName: ManyKey1, SqlTypeName: int, ClrColumName: ManyKey1, ClrColumnType: System.Int32, IsPrimaryKey: True, PrimaryKeyOrder: 1, IsNullable: False, MaxLength: 4");
            list[i++].ToString().ShouldEqual("SqlColumnName: ManyKey2, SqlTypeName: uniqueidentifier, ClrColumName: ManyKey2, ClrColumnType: System.Guid, IsPrimaryKey: True, PrimaryKeyOrder: 2, IsNullable: False, MaxLength: 16");
            
        }
    }
}