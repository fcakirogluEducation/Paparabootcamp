namespace PaparaApp.API.Models.Definitions
{
    public interface IProductDefinitionRepository
    {
        ProductDefinition Save(ProductDefinition productDefinition);
        ProductDefinition? GetById(int id);
    }
}