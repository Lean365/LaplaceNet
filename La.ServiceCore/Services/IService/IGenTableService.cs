using SqlSugar;
using System.Collections.Generic;
using La.Model;
using La.Model.System.Generate;

namespace La.Service.System.IService
{
    public interface IGenTableService : IBaseService<GenTable>
    {
        List<GenTable> SelectDbTableListByNamess(string[] tableNames);

        int ImportGenTable(GenTable tables);

        int DeleteGenTableByIds(long[] tableIds);
        int DeleteGenTableByTbName(string tableName);
        PagedInfo<GenTable> GetGenTables(GenTable genTable, PagerInfo pagerInfo);
        GenTable GetGenTableInfo(long tableId);
        bool SynchDb(long tableId, GenTable genTable, List<GenTableColumn> genTableColumns);
        List<GenTable> GetGenTableAll();
        int UpdateGenTable(GenTable genTable);
    }

    public interface IGenTableColumnService : IBaseService<GenTableColumn>
    {
        int InsertGenTableColumn(List<GenTableColumn> tableColumn);

        int DeleteGenTableColumn(long tableId);
        int DeleteGenTableColumn(long[] tableIds);
        int DeleteGenTableColumnByTableName(string tableName);
        List<GenTableColumn> GenTableColumns(long tableId);
        int UpdateGenTableColumn(List<GenTableColumn> tableColumn);
    }
}
