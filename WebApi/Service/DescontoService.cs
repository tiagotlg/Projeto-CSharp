using AutoMapper;
using WebApi.Dtos;
using WebApi.Interfaces;

namespace WebApi.Service;

public class DescontoService(IMapper mapper, ICheapSharkApi cheapSharkApi) : IDescontoService
{
    private readonly IMapper _mapper = mapper;
    private readonly ICheapSharkApi _cheapSharkApi = cheapSharkApi;

    public async Task<ResponseGenerico<DescontoResponse>> BuscaDescontoPorId(string descontoId)
    {
        var desconto = await _cheapSharkApi.BuscaDescontoPorId(descontoId);
        return _mapper.Map<ResponseGenerico<DescontoResponse>>(desconto);
    }

    public async Task<ResponseListaGenerico<ListaDescontosResponse>> BuscaPorDescontos(int lojaId, int precoMaximo, int precoMinimo, int steamRating , int pageNumber, int pageSize)
    {
        var descontos = await _cheapSharkApi.BuscaPorDescontos(lojaId, precoMaximo, precoMinimo, steamRating, pageNumber, pageSize);
        return _mapper.Map<ResponseListaGenerico<ListaDescontosResponse>>(descontos);
    }

    public async Task<ResponseListaGenerico<ListaDescontosResponse>> BuscaPorDescontosMenor(int lojaId)
    {
        var descontos = await _cheapSharkApi.BuscaPorDescontosMenor(lojaId);
        return _mapper.Map<ResponseListaGenerico<ListaDescontosResponse>>(descontos);
    }
}
