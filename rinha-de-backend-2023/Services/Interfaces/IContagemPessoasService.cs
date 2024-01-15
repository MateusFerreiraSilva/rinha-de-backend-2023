namespace rinha_de_backend_2023.Services.Interfaces;

public interface IContagemPessoasService
{
    void RegisterSuccessfulInsert();
    
    string CountSuccessfulInserts();   
}