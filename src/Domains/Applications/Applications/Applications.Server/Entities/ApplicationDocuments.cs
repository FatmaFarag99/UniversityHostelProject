namespace Applications.Server.Entities;

public class ApplicationDocuments : BaseEntity
{
    public Guid ApplicationId { get; set; }

    public Guid? Document1Id { get; set; }
    public ApplicationDocument Document1 { get; set; }
    
    public Guid? Document2Id { get; set; }
    public ApplicationDocument Document2 { get; set; }
    
    public Guid? Document3Id { get; set; }
    public ApplicationDocument Document3 { get; set; }

    //public List<ApplicationDocumentViewModel> ApplicationDocuments { get; set; }
}