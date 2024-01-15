using rinha_de_backend_2023.Services.Interfaces;

namespace rinha_de_backend_2023.Services;

public class ContagemPessoasService : IContagemPessoasService
{
    private int _pessoasCount;

    public ContagemPessoasService()
    {
    }

    public void RegisterSuccessfulInsert()
    {
        _pessoasCount++;
    }

    public string CountSuccessfulInserts()
    {
        return _pessoasCount.ToString();
    }
}