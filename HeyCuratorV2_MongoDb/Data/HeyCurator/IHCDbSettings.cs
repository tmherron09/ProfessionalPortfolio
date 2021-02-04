namespace tmherronProfessionalSite.Data.HeyCurator
{
    public interface IHCDbSettings
    {
        string ConnectionString { get; set; }
        string HeyCuratorDatabaseName { get; set; }
        string EmployeesCollectionName { get; set; }
        string CuratorRolesCollectionName { get; set; }
        string ExhibitAreasCollectionName { get; set; }
        string ItemsCollectionName { get; set; }
        string ItemInstancesCollectionName { get; set; }
        string UpdateRecordsCollectionName { get; set; }
    }
}
